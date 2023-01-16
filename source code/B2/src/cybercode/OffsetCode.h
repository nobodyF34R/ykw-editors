#ifndef OFFSETCODE_H
#define OFFSETCODE_H

#include "CyberCode.h"
#include <QtCore>

class OffsetCode : public CyberCode {
public:
    OffsetCode(quint32 addr, quint32 val, bool useOffset, qint32 offset);
    void execute(SaveManager* mgr, int& offset);

private:
    qint32 offset;
};

#endif // OFFSETCODE_H
