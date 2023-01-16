#ifndef SEARCHCODE_H
#define SEARCHCODE_H

#include "CyberCode.h"
#include <QtCore>

class SearchCode : public CyberCode {
public:
    SearchCode(quint32 addr, quint32 val, bool useOffset);
    void execute(SaveManager* mgr, int& offset);
    void setSearchCount(quint32 d);
    void setData(const QByteArray& d);

private:
    quint32 searchCount;
    QByteArray data;
};

#endif // SEARCHCODE_H
