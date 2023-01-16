#include "itemtab.h"
#include <QMessageBox>

#include "dataeditor/biteditor.h"
#include "dataeditor/integereditor.h"
#include "dataeditor/listeditor.h"

ItemTab::ItemTab(SaveManager* mgr, QWidget* parent, int sectionId)
    : ListTab(mgr, parent, sectionId)
    , form(new Ui::ItemTabForm)
{
    QWidget* w = new QWidget(this);
    form->setupUi(w);
    ui->form->addWidget(w);

    this->setNum1Offset(0x4000);
    this->setItemsCount(GameConfig::BattleItemCountMax);
    this->setItemSize(0x14);

    for (int i = 0; i < this->getItemsCount(); ++i) {
        ui->listWidget->addItem(QString(""));
    }

    /* intert items into combobox */
    foreach (const dataentry_t& it, GameData::getInstance().getData("hackslash_consume")) {
        form->itemCB->addItem(it.second.value("name"), it.first);
    }
    foreach (const dataentry_t& it, GameData::getInstance().getData("hackslash_battle")) {
        form->itemCB->addItem(it.second.value("name"), it.first);
    }
    foreach (const dataentry_t& it, GameData::getInstance().getData("hackslash_equipment")) {
        form->itemCB->addItem(it.second.value("name"), it.first);
    }
    foreach (const dataentry_t& it, GameData::getInstance().getData("hackslash_important")) {
        form->itemCB->addItem(it.second.value("name"), it.first);
    }
    foreach (const dataentry_t& it, GameData::getInstance().getData("equipment_skill")) {
        form->skill1CB->addItem(it.second.value("name"), it.first);
        form->skill2CB->addItem(it.second.value("name"), it.first);
    }
    form->itemCB->setCurrentIndex(-1);

    /* editors */
    ListEditor* itemE = new ListEditor(this, form->itemLabel, form->itemCB, 0x04, 32);
    this->setPrimaryEditor(itemE);
    this->editors.append(new IntegerEditor(this, form->num1Label, form->num1SB, 0x00, 16, false));
    this->editors.append(new IntegerEditor(this, form->num2Label, form->num2SB, 0x02, 16, false));
    this->editors.append(itemE);
    this->editors.append(new IntegerEditor(this, form->countLabel, form->countSB, 0xA, 8));
    this->editors.append(new IntegerEditor(this, form->enchantmentLabel, form->enchantmentSB, 0xB, 8, true));
    this->editors.append(new ListEditor(this, form->skill1Label, form->skill1CB, 0x0C, 32, false));
    this->editors.append(new ListEditor(this, form->skill2Label, form->skill2CB, 0x10, 32, false));
}

ItemTab::~ItemTab()
{
    delete form;
}

void ItemTab::update()
{
    ListTab::update();
}

void ItemTab::setButtonsEnabled(bool s)
{
    ListTab::setButtonsEnabled(s);
    ui->addAllButton->setEnabled(false);
}
