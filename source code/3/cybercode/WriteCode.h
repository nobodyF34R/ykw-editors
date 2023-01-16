#ifndef WRITECODE_H
#define WRITECODE_H

#include "CyberCode.h"
#include <QtCore>

class WriteCode : public CyberCode {
public:
    WriteCode(quint32 addr, quint32 val, bool useOffset, int size);
    void execute(SaveManager* mgr, int& offset);

protected:
    int size;
};

#endif // WRITECODE_H
