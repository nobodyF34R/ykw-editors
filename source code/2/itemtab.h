#pragma execution_character_set("utf-8")

#ifndef ITEMTAB_H
#define ITEMTAB_H

#include <QWidget>
#include <QtCore>
#include <QCheckBox>

#include "listtab.h"
#include "gameconfig.h"
#include "gamedata.h"

#include "ui_itemtabform.h"

class ItemTab : public ListTab, private Ui::ItemTabForm
{
    Q_OBJECT

public:
    explicit ItemTab(SaveManager *mgr, QWidget *parent=0, int sectionId=-1);
    ~ItemTab();
public slots:
    void update();
    void loadItemAt(int row);
    void writeItemAt(int row);
    void loadCurrentItem();
    void writeCurrentItem();

private:
    Ui::ItemTabForm *form;
};

#endif // ITEMTAB_H
