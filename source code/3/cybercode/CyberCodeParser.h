#ifndef CYBERCODEPARSER_H
#define CYBERCODEPARSER_H

#include "AddCode.h"
#include "CyberCode.h"
#include "LoopCode.h"
#include "OffsetCode.h"
#include "SearchCode.h"
#include "SectionOffsetCode.h"
#include "SectionWriteCode.h"
#include "WriteCode.h"
#include <memory>

class CyberCodeParser : public QObject {
    Q_OBJECT
public:
    enum ReturnCode {
        SUCCESS,
        INVALID_FORMAT,
        INVALID_SYNTAX,
        INCOMPLETE_CODE
    };
    CyberCodeParser(QWidget* parent);
    ~CyberCodeParser() = default;
    ReturnCode parseString(QString s);
    const QString& getErrorMessage();
    const QList<std::shared_ptr<CyberCode> >& getCodes();

private:
    enum States {
        nextCode,
        secondLine,
        arbitraryLength
    };
    CyberCodeParser::States state;
    int transition(const QString& addr, const QString& val, bool isSpecial, int section);
    void reset();
    void addSearchData(quint32 d, quint32 sizeInByte);
    static QRegularExpression linePat;
    QList<std::shared_ptr<CyberCode> > codes;
    QString errorMessage;
    struct {
        bool useOffset;
        quint32 addr;
        quint32 loopCount;
        quint32 addrDiff;
        int size;
    } loopCodeInfo;
    struct {
        bool useOffset;
        quint32 searchCount;
        qint32 searchSize;
    } searchCodeInfo;
    QByteArray searchData;
};

#endif // CYBERCODEPARSER_H
