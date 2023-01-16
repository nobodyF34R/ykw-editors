#pragma execution_character_set("utf-8")

#ifndef SOULTAB_H
#define SOULTAB_H

#include <QWidget>
#include <QtCore>

#include "listtab.h"
#include "gameconfig.h"
#include "gamedata.h"

#include "ui_soultabform.h"

class SoulTab : public ListTab, private Ui::SoulTabForm
{
    Q_OBJECT

public:
    explicit SoulTab(SaveManager *mgr, QWidget *parent=0, int sectionId=-1);
    ~SoulTab();
public slots:
    void update();
    void loadItemAt(int row);
    void writeItemAt(int row);
    void loadCurrentItem();
    void writeCurrentItem();

private:
    Ui::SoulTabForm *form;
};

#endif // SOULTAB_H
