#pragma execution_character_set("utf-8")

#ifndef BUSTERS_EQUIPMENTTAB_H
#define BUSTERS_EQUIPMENTTAB_H

#include <QCheckBox>
#include <QWidget>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_busters_equipmenttabform.h"

class BustersEquipmentTab : public ListTab, private Ui::BustersEquipmentTabForm {
    Q_OBJECT

public:
    explicit BustersEquipmentTab(SaveManager* mgr, int num1Offset, QWidget* parent = 0, int sectionId = -1);
    ~BustersEquipmentTab();

private:
    Ui::BustersEquipmentTabForm* form;
};

#endif // BUSTERS_EQUIPMENTTAB_H
