#ifndef ITEMTAB_H
#define ITEMTAB_H

#include <QCheckBox>
#include <QWidget>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_itemtabform.h"

class ItemTab : public ListTab, private Ui::ItemTabForm {
    Q_OBJECT

public:
    explicit ItemTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~ItemTab();
public slots:
    virtual void update();
    virtual void setButtonsEnabled(bool s);

private:
    Ui::ItemTabForm* form;
};

#endif // ITEMTAB_H
