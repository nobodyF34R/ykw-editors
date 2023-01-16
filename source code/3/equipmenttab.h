#pragma execution_character_set("utf-8")

#ifndef EQUIPMENTTAB_H
#define EQUIPMENTTAB_H

#include <QCheckBox>
#include <QWidget>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_equipmenttabform.h"

class EquipmentTab : public ListTab, private Ui::EquipmentTabForm {
    Q_OBJECT

public:
    explicit EquipmentTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~EquipmentTab();

private:
    Ui::EquipmentTabForm* form;
};

#endif // EQUIPMENTTAB_H
