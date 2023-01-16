#include "SectionWriteCode.h"

SectionWriteCode::SectionWriteCode(quint32 addr, quint32 val, bool useOffset, int size, int sectionId)
    : WriteCode(addr, val, useOffset, size)
    , sectionId(sectionId)
{
}

void SectionWriteCode::execute(SaveManager* mgr, int&)
{
    if (!mgr)
        return;
    switch (size) {
    case 1:
        mgr->writeSection((quint8)(this->value & 0xFF), this->address, this->sectionId);
        break;
    case 2:
        mgr->writeSection((quint16)(this->value & 0xFFFF), this->address, this->sectionId);
        break;
    case 4:
        mgr->writeSection(this->value, this->address, this->sectionId);
        break;
    }
}
