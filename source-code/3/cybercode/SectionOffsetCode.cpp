#include "SectionOffsetCode.h"

SectionOffsetCode::SectionOffsetCode(quint32 addr, quint32 val, bool useOffset, qint32 section)
    : CyberCode(addr, val, useOffset)
    , section(section)
{
}

void SectionOffsetCode::execute(SaveManager* mgr, int& offset)
{
    if (!mgr)
        return;
    Section* s = mgr->getSectionById(section);
    if (!s)
        return;
    offset = s->getOffset();
}
