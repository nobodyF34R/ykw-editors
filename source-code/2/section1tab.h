#pragma execution_character_set("utf-8")

#ifndef SECTION1TAB_H
#define SECTION1TAB_H

#include <QWidget>
#include "tab.h"

namespace Ui {
class Section1Tab;
}

class Section1Tab : public Tab
{
    Q_OBJECT

public:
    explicit Section1Tab(SaveManager *mgr, QWidget *parent=0, int sectionId=-1);
    ~Section1Tab();
public slots:
    void update();
    void apply();
private:
    Ui::Section1Tab *ui;
};

#endif // SECTION1TAB_H
