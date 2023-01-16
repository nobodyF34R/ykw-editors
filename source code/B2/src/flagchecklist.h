#ifndef FLAGCHECKLIST_H
#define FLAGCHECKLIST_H

#include "checklist.h"

class FlagCheckList : public CheckList {
public:
    explicit FlagCheckList(int sectionId, int offset, SaveManager* mgr, QWidget* parent = 0);
};

#endif // FLAGCHECKLIST_H
