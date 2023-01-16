#include "SearchCode.h"

SearchCode::SearchCode(quint32 addr, quint32 val, bool useOffset)
    : CyberCode(addr, val, useOffset)
    , searchCount(0)
{
}

void SearchCode::setSearchCount(quint32 d)
{
    this->searchCount = d;
}

void SearchCode::setData(const QByteArray& d)
{
    this->data = d;
}

void SearchCode::execute(SaveManager* mgr, int& offset)
{
    if (!mgr)
        return;
    int from = 0;
    for (quint32 i = 0; i < this->searchCount; ++i) {
        from = mgr->indexOfRaw(this->data, from);
        if (from < 0)
            return;
        from += this->data.size();
    }
    offset = from;
}
