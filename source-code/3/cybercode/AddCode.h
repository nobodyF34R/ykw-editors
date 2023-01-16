#ifndef ADDCODE_H
#define ADDCODE_H

#include "CyberCode.h"
#include <QtCore>

class AddCode : public CyberCode {
public:
    AddCode(quint32 addr, quint32 val, bool useOffset, int size);
    void execute(SaveManager* mgr, int& offset);

private:
    int size;
};

#endif // ADDCODE_H
