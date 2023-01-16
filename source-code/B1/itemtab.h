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
    void setLocale(SaveManager::GameLocale locale);
public slots:
    void updateList();
    void loadItemAt(int row);
    void writeItemAt(int row);
    void loadCurrentItem();
    void writeCurrentItem();

private:
    Ui::ItemTabForm* form;
};

#endif // ITEMTAB_H
