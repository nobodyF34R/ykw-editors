#ifndef SECTION1TAB_H
#define SECTION1TAB_H

#include "tab.h"
#include <QWidget>

namespace Ui {
class Section1Tab;
}

class Section1Tab : public Tab {
    Q_OBJECT

public:
    explicit Section1Tab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~Section1Tab();
    void setLocale(SaveManager::GameLocale locale);
public slots:
    void update();
    void apply();

private:
    Ui::Section1Tab* ui;
};

#endif // SECTION1TAB_H
