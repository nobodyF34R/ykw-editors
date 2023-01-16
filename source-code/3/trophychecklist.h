#ifndef TROPHYCHECKLIST_H
#define TROPHYCHECKLIST_H

#include "checklist.h"

class TrophyCheckList : public CheckList {
public:
    explicit TrophyCheckList(int sectionId, int offset, SaveManager* mgr, QWidget* parent = 0);
    void apply();
};

#endif // TROPHYCHECKLIST_H
