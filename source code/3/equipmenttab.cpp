#pragma execution_character_set("utf-8")

#include "equipmenttab.h"

#include "dataeditor/integereditor.h"
#include "dataeditor/listeditor.h"

EquipmentTab::EquipmentTab(SaveManager* mgr, QWidget* parent, int sectionId)
    : ListTab(mgr, parent, sectionId)
    , form(new Ui::EquipmentTabForm)
{
    QWidget* w = new QWidget(this);
    form->setupUi(w);
    ui->form->addWidget(w);

    this->setNum1Offset(0x1000);
    this->setItemsCount(GameConfig::EquipmentCountMax);
    this->setItemSize(0x0C);

    for (int i = 0; i < GameConfig::EquipmentCountMax; ++i) {
        ui->listWidget->addItem(QString(""));
    }

    /* intert items into combobox */
    foreach (const dataentry_t& it, GameData::getInstance().getData("equipment")) {
        form->itemCB->addItem(it.second.value("name"), it.first);
    }
    foreach (const dataentry_t& it, GameData::getInstance().getData("battle")) {
        form->itemCB->addItem(it.second.value("name"), it.first);
    }
    form->itemCB->setCurrentIndex(-1);

    /* editors */
    ListEditor* itemE = new ListEditor(this, form->itemLabel, form->itemCB, 0x04, 32);
    this->setPrimaryEditor(itemE);
    this->editors.append(new IntegerEditor(this, form->num1Label, form->num1SB, 0x00, 16, false));
    this->editors.append(new IntegerEditor(this, form->num2Label, form->num2SB, 0x02, 16, false));
    this->editors.append(itemE);
    this->editors.append(new IntegerEditor(this, form->countLabel, form->countSB, 0x8, 8, false));
    this->editors.append(new IntegerEditor(this, form->count2Label, form->count2SB, 0x9, 8, false));
}

EquipmentTab::~EquipmentTab()
{
    delete form;
}
