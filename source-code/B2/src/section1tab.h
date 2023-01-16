#ifndef SECTION1TAB_H
#define SECTION1TAB_H

#include "flagchecklist.h"
#include "tab.h"
#include "trophychecklist.h"
#include <QWidget>

namespace Ui {
class Section1Tab;
}

class Section1Tab : public Tab {
    Q_OBJECT

public:
    explicit Section1Tab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~Section1Tab();
public slots:
    void update();
    void apply();

private:
    Ui::Section1Tab* ui;
    TrophyCheckList* trophies;
private slots:
    void resetLegendary();
};

#endif // SECTION1TAB_H
