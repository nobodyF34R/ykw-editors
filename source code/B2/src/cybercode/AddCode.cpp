#include "AddCode.h"

AddCode::AddCode(quint32 addr, quint32 val, bool useOffset, int size)
    : CyberCode(addr, val, useOffset)
    , size(size)
{
}

void AddCode::execute(SaveManager* mgr, int& offset)
{
    if (!mgr)
        return;
    quint32 val = mgr->readRaw<quint32>(this->address + (this->useOffset ? offset : -headerSize));
    switch (size) {
    case 1:
        mgr->writeRaw((quint8)((this->value | val) & 0xFF),
            this->address + (this->useOffset ? offset : -headerSize));
        break;
    case 2:
        mgr->writeRaw((quint16)((this->value | val) & 0xFFFF),
            this->address + (this->useOffset ? offset : -headerSize));
        break;
    case 4:
        mgr->writeRaw(this->value | val, this->address + (this->useOffset ? offset : -headerSize));
        break;
    }
}
