#ifndef SECTIONWRITECODE_H
#define SECTIONWRITECODE_H

#include "WriteCode.h"
#include <QtCore>

class SectionWriteCode : public WriteCode {
public:
    SectionWriteCode(quint32 addr, quint32 val, bool useOffset, int size, int sectionId);
    void execute(SaveManager* mgr, int&);

protected:
    int sectionId;
};

#endif // SECTIONWRITECODE_H
