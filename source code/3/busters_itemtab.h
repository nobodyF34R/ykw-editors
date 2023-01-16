#pragma execution_character_set("utf-8")

#ifndef BUSTERS_ITEMTAB_H
#define BUSTERS_ITEMTAB_H

#include <QMessageBox>
#include <QWidget>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_busters_itemtabform.h"

class BustersItemTab : public ListTab, private Ui::BustersItemTabForm {
    Q_OBJECT

public:
    explicit BustersItemTab(SaveManager* mgr, QWidget* parent, int sectionId, bool is_itembox);
    ~BustersItemTab();

private:
    Ui::BustersItemTabForm* form;
    void automaticNumbering();
};

#endif // BUSTERS_ITEMTAB_H
