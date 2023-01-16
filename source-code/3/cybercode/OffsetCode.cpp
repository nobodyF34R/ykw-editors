#include "OffsetCode.h"

OffsetCode::OffsetCode(quint32 addr, quint32 val, bool useOffset, qint32 offset)
    : CyberCode(addr, val, useOffset)
    , offset(offset)
{
}

void OffsetCode::execute(SaveManager* mgr, int& offset)
{
    if (!mgr)
        return;
    offset -= this->offset;
}
