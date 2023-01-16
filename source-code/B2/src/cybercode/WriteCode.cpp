#include "WriteCode.h"

WriteCode::WriteCode(quint32 addr, quint32 val, bool useOffset, int size)
    : CyberCode(addr, val, useOffset)
    , size(size)
{
}

void WriteCode::execute(SaveManager* mgr, int& offset)
{
    if (!mgr)
        return;
    switch (size) {
    case 1:
        mgr->writeRaw((quint8)(this->value & 0xFF),
            this->address + (this->useOffset ? offset : -headerSize));
        break;
    case 2:
        mgr->writeRaw((quint16)(this->value & 0xFFFF),
            this->address + (this->useOffset ? offset : -headerSize));
        break;
    case 4:
        mgr->writeRaw(this->value, this->address + (this->useOffset ? offset : -headerSize));
        break;
    }
}
