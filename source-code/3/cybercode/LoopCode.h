#ifndef LOOPCODE_H
#define LOOPCODE_H

#include "CyberCode.h"
#include <QtCore>

class LoopCode : public CyberCode {
public:
    LoopCode(quint32 addr, quint32 val, bool useOffset, int size);
    void execute(SaveManager* mgr, int& offset);
    void setLoopCount(quint32 d);
    void setAddrDiff(quint32 d);
    void setDataDiff(quint32 d);

private:
    quint32 loopCount;
    quint32 addrDiff;
    quint32 dataDiff;
    int size;
};

#endif // LOOPCODE_H
