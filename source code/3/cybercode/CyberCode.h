#ifndef CYBERCODE_H
#define CYBERCODE_H

#include "savemanager.h"
#include <QtCore>

class CyberCode {
public:
    CyberCode(quint32 addr, quint32 val, bool useOffset);
    virtual ~CyberCode() = default;
    virtual void execute(SaveManager* mgr, int& offset) = 0;
    void setUseOffset(bool b);
    static const int headerSize;

protected:
    quint32 address;
    quint32 value;
    bool useOffset;
};

#endif // CYBERCODE_H
