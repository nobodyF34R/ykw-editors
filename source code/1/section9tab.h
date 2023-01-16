#pragma execution_character_set("utf-8")

#ifndef SECTION9TAB_H
#define SECTION9TAB_H

#include <QWidget>
#include "tab.h"

namespace Ui {
class Section9Tab;
}

class Section9Tab : public Tab
{
    Q_OBJECT

public:
    explicit Section9Tab(SaveManager *mgr, QWidget *parent=0, int sectionId=-1);
    ~Section9Tab();
public slots:
    void update();
    void apply();
private:
    Ui::Section9Tab *ui;
};

#endif // SECTION9TAB_H
