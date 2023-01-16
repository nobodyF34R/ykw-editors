#include "LoopCode.h"

LoopCode::LoopCode(quint32 addr, quint32 val, bool useOffset, int size)
    : CyberCode(addr, val, useOffset)
    , loopCount(0)
    , addrDiff(0)
    , dataDiff(0)
    , size(size)
{
}

void LoopCode::setLoopCount(quint32 d)
{
    this->loopCount = d;
}

void LoopCode::setAddrDiff(quint32 d)
{
    this->addrDiff = d;
}

void LoopCode::setDataDiff(quint32 d)
{
    this->dataDiff = d;
}

void LoopCode::execute(SaveManager* mgr, int& offset)
{
    if (!mgr)
        return;
    quint32 val = this->value;
    quint32 addr = this->address + (this->useOffset ? offset : -headerSize);
    for (quint32 i = 0; i < this->loopCount; ++i) {
        switch (size) {
        case 2:
            mgr->writeRaw((quint8)(val & 0xFF), addr);
            break;
        case 1:
            mgr->writeRaw((quint16)(val & 0xFFFF), addr);
            break;
        case 0:
            mgr->writeRaw(val, addr);
            break;
        }
        val += this->dataDiff;
        addr += this->addrDiff;
    }
}
