#ifndef YOUKAICHECKLIST_H
#define YOUKAICHECKLIST_H

#include "gamedata.h"
#include "savemanager.h"
#include <QListWidget>

class YoukaiCheckList : public QListWidget {
    Q_OBJECT
public:
    explicit YoukaiCheckList(int sectionId, int offset, SaveManager* mgr, QWidget* parent = 0);
public slots:
    void update();
    void apply();
    void setAllState(bool isChecked);
    void setAllChecked();
    void setAllUnchecked();

private:
    quint8 sectionId;
    int offset;
    SaveManager* mgr;
};

#endif // YOUKAICHECKLIST_H
