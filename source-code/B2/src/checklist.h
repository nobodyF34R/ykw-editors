#ifndef CHECKLIST_H
#define CHECKLIST_H

#include "gamedata.h"
#include "savemanager.h"
#include <QListWidget>

class CheckList : public QListWidget {
    Q_OBJECT
public:
    explicit CheckList(int sectionId, int offset, SaveManager* mgr, QWidget* parent = 0);
    SaveManager* getMgr() const;

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

#endif // CHECKLIST_H
