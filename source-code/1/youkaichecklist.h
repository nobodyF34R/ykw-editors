#pragma execution_character_set("utf-8")

#ifndef YOUKAICHECKLIST_H
#define YOUKAICHECKLIST_H

#include <QListWidget>
#include "savemanager.h"
#include "gamedata.h"

class YoukaiCheckList : public QListWidget
{
    Q_OBJECT
public:
    explicit YoukaiCheckList(int sectionId, int offset, SaveManager *mgr, QWidget *parent=0);
public slots:
    void update();
    void apply();
    void setAllState(bool isChecked);
    void setAllChecked();
    void setAllUnchecked();
private:
    quint8 sectionId;
    int offset;
    SaveManager *mgr;
};

#endif // YOUKAICHECKLIST_H
