#include "CyberCode.h"

const int CyberCode::headerSize = 32;

CyberCode::CyberCode(quint32 addr, quint32 val, bool useOffset)
    : address(addr)
    , value(val)
    , useOffset(useOffset)
{
}

void CyberCode::setUseOffset(bool b)
{
    this->useOffset = b;
}
