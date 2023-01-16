#ifndef MEDALIUMTAB_H
#define MEDALIUMTAB_H

#include "tab.h"
#include "youkaichecklist.h"
#include <QWidget>

namespace Ui {
class MedaliumTab;
}

class MedaliumTab : public Tab {
    Q_OBJECT

public:
    explicit MedaliumTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1, int offset = 0);
    ~MedaliumTab();
public slots:
    void update();
    void apply();

private:
    Ui::MedaliumTab* ui;
    YoukaiCheckList* seen;
    YoukaiCheckList* befriended;
};

#endif // MEDALIUMTAB_H
