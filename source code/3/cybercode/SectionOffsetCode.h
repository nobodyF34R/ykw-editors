#ifndef SECTIONOFFSETCODE_H
#define SECTIONOFFSETCODE_H

#include "CyberCode.h"
#include <QtCore>

class SectionOffsetCode : public CyberCode {
public:
    SectionOffsetCode(quint32 addr, quint32 val, bool useOffset, qint32 section);
    void execute(SaveManager* mgr, int& offset);

private:
    qint32 section;
};

#endif // SECTIONOFFSETCODE_H
