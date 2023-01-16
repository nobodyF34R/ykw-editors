#include "CyberCodeParser.h"
#include <algorithm>

QRegularExpression CyberCodeParser::linePat = QRegularExpression("^((?<atmark>@)?(?<addr>[0-9a-fA-F]{8})\\s+(?<val>[0-9a-fA-F]{8}))"
                                                                 "|"
                                                                 "@section\\s+((?<hex_section>0x[0-9a-fA-F]+)|(?<dec_section>[0-9]+))$",
    QRegularExpression::OptimizeOnFirstUsageOption);

CyberCodeParser::CyberCodeParser(QWidget* parent)
    : QObject(parent)
    , errorMessage("")
{
    this->state = States::nextCode;
}

CyberCodeParser::ReturnCode CyberCodeParser::parseString(QString s)
{
    this->reset();
    QStringList input = s.split("\n", QString::SkipEmptyParts);
    int lineno = 1;
    QRegularExpressionMatch m;
    int status = ReturnCode::SUCCESS;
    foreach (auto a, input) {
        if (!a.trimmed().isEmpty() && a.trimmed().at(0) != QLatin1Char('#')) {
            m = linePat.match(a.trimmed());
            if (!m.hasMatch()) {
                this->errorMessage = QString(tr("INVALID_FORMAT_AT_LINE_%1")).arg(lineno);
                return ReturnCode::INVALID_FORMAT;
            }
            int section_no = -1;
            if (!m.captured("hex_section").isEmpty()) {
                section_no = m.captured("hex_section").toInt(nullptr, 16);
            } else if (!m.captured("dec_section").isEmpty()) {
                section_no = m.captured("dec_section").toInt(nullptr, 10);
            }
            if ((status = transition(m.captured("addr"), m.captured("val"), !m.captured("atmark").isEmpty(), section_no)) < 0) {
                this->errorMessage = QString(tr("INVALID_SYNTAX_AT_LINE_%1")).arg(lineno);
                return ReturnCode::INVALID_SYNTAX;
            }
        }
        lineno++;
    }
    if (status) {
        this->errorMessage = QString(tr("INCOMPLETE_CODE_AT_LINE_%1")).arg(lineno - 1);
        return ReturnCode::INCOMPLETE_CODE;
    }
    return ReturnCode::SUCCESS;
}

int CyberCodeParser::transition(const QString& addr, const QString& val, bool isSpecial, int section)
{
    if (isSpecial && (this->state != States::nextCode))
        return -1;
    if (section >= 0 && (this->state != States::nextCode))
        return -1;
    if (section >= 0) {
        this->codes.append(std::make_shared<SectionOffsetCode>(0, 0, true, section));
        return 0;
    }

    bool useOffset = (addr.at(1) == QLatin1Char('8'));
    quint32 addrN = addr.midRef(2).toUInt(nullptr, 16);
    quint32 valN = val.toUInt(nullptr, 16);

    if (this->state == States::nextCode) {
        if (isSpecial) {
            int sectionId = addr.midRef(1, 2).toInt(nullptr, 16);
            if (addr.at(0) == QLatin1Char('0')) {
                // 1 byte write
                this->codes.append(std::make_shared<SectionWriteCode>(addrN & 0xFFFFF, valN, useOffset, 1, sectionId));
            } else if (addr.at(0) == QLatin1Char('1')) {
                // 2 byte write
                this->codes.append(std::make_shared<SectionWriteCode>(addrN & 0xFFFFF, valN, useOffset, 2, sectionId));
            } else if (addr.at(0) == QLatin1Char('2')) {
                // 4 byte write
                this->codes.append(std::make_shared<SectionWriteCode>(addrN & 0xFFFFF, valN, useOffset, 4, sectionId));
            } else {
                return -1;
            }
        } else if (addr.at(0) == QLatin1Char('0')) {
            // 1 byte write
            this->codes.append(std::make_shared<WriteCode>(addrN, valN, useOffset, 1));
        } else if (addr.at(0) == QLatin1Char('1')) {
            // 2 byte write
            this->codes.append(std::make_shared<WriteCode>(addrN, valN, useOffset, 2));
        } else if (addr.at(0) == QLatin1Char('2')) {
            // 4 byte write
            this->codes.append(std::make_shared<WriteCode>(addrN, valN, useOffset, 4));
        } else if (addr.at(0) == QLatin1Char('4')) {
            // Loop
            this->loopCodeInfo.useOffset = useOffset;
            this->loopCodeInfo.addr = addrN;
            this->loopCodeInfo.loopCount = (valN >> 16) & 0xFFF;
            this->loopCodeInfo.addrDiff = valN & 0xFFFF;
            this->loopCodeInfo.size = valN >> 28;
            if (this->loopCodeInfo.size > 2) {
                return -1; // INVALID_SYNTAX
            }
            this->state = secondLine;
            return 1; // DATA_RECEIVING
        } else if (addr.at(0) == QLatin1Char('7')) {
            // Add
            bool useOffset7Code = (addr.at(2) == QLatin1Char('8'));
            if (addr.at(1) == QLatin1Char('0')) {
                // 1 byte write
                this->codes.append(std::make_shared<AddCode>(addrN & 0xFFFFF, valN, useOffset7Code, 1));
            } else if (addr.at(1) == QLatin1Char('1')) {
                // 2 byte write
                this->codes.append(std::make_shared<AddCode>(addrN & 0xFFFFF, valN, useOffset7Code, 2));
            } else if (addr.at(1) == QLatin1Char('2')) {
                // 4 byte write
                this->codes.append(std::make_shared<AddCode>(addrN & 0xFFFFF, valN, useOffset7Code, 4));
            }
        } else if (addr.at(0) == QLatin1Char('8')) {
            // Search
            this->searchData.clear();
            quint32 tmp = addr.midRef(1).toUInt(nullptr, 16);
            this->searchCodeInfo.useOffset = useOffset;
            this->searchCodeInfo.searchCount = (tmp >> 16) & 0xFFF;
            this->searchCodeInfo.searchSize = tmp & 0xFFFF;
            this->addSearchData(valN, std::min(this->searchCodeInfo.searchSize, 4));
            if (this->searchCodeInfo.searchSize > 4) {
                this->searchCodeInfo.searchSize -= 4;
                this->state = States::arbitraryLength;
                return 1; // DATA_RECEIVING
            } else {
                auto l = std::make_shared<SearchCode>(addrN, valN, useOffset);
                l->setUseOffset(useOffset);
                l->setSearchCount(this->searchCodeInfo.searchCount);
                l->setData(this->searchData);
                this->codes.append(l);
            }
        } else if (addr.at(0) == QLatin1Char('9')) {
            // Offset
            if (addr.at(1) == QLatin1Char('3')) {
                // offset decrement
                this->codes.append(std::make_shared<OffsetCode>(addrN, valN, useOffset, valN));
            } else {
                return -1; // INVALID_SYNTAX
            }
        } else {
            return -1; // INVALID_SYNTAX
        }
    } else if (this->state == States::secondLine) {
        auto l = std::make_shared<LoopCode>(this->loopCodeInfo.addr, addr.toUInt(nullptr, 16), useOffset, this->loopCodeInfo.size);
        l->setUseOffset(this->loopCodeInfo.useOffset);
        l->setLoopCount(this->loopCodeInfo.loopCount);
        l->setAddrDiff(this->loopCodeInfo.addrDiff);
        l->setDataDiff(valN);
        this->codes.append(l);
        this->state = States::nextCode;
    } else if (this->state == States::arbitraryLength) {
        this->addSearchData(addr.toUInt(nullptr, 16), std::min(this->searchCodeInfo.searchSize, 4));
        this->searchCodeInfo.searchSize -= 4;
        if (this->searchCodeInfo.searchSize > 0) {
            this->addSearchData(valN, std::min(this->searchCodeInfo.searchSize, 4));
            this->searchCodeInfo.searchSize -= 4;
        }
        if (this->searchCodeInfo.searchSize > 0) {
            return 1; // DATA_INCOMPLETE
        } else {
            auto l = std::make_shared<SearchCode>(addrN, valN, useOffset);
            l->setUseOffset(useOffset);
            l->setSearchCount(this->searchCodeInfo.searchCount);
            l->setData(this->searchData);
            this->codes.append(l);
            this->state = States::nextCode;
        }
    }
    return 0;
}

void CyberCodeParser::addSearchData(quint32 d, quint32 sizeInByte)
{
    for (quint32 i = 0; i < sizeInByte; ++i) {
        this->searchData.append((quint8)((d & (0xFF << (8 * i))) >> (8 * i)));
    }
}

const QString& CyberCodeParser::getErrorMessage()
{
    return this->errorMessage;
}

const QList<std::shared_ptr<CyberCode> >& CyberCodeParser::getCodes()
{
    return this->codes;
}

void CyberCodeParser::reset()
{
    this->codes.clear();
    this->state = States::nextCode;
}
