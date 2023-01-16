#pragma execution_character_set("utf-8")

#include "busters_hiddentreasuretab.h"

#include "dataeditor/integereditor.h"
#include "dataeditor/listeditor.h"

BustersHiddenTreasureTab::BustersHiddenTreasureTab(SaveManager* mgr, QWidget* parent, int sectionId)
    : ListTab(mgr, parent, sectionId)
    , form(new Ui::BustersHiddenTreasureTabForm)
{
    QWidget* w = new QWidget(this);
    form->setupUi(w);
    ui->form->addWidget(w);

    this->setNum1Offset(0x4000);
    this->setItemsCount(GameConfig::BustersHiddenTreasureCountMax);
    this->setItemSize(0x0C);

    for (int i = 0; i < this->getItemsCount(); ++i) {
        ui->listWidget->addItem(QString(""));
    }

    /* intert items into combobox */
    foreach (const dataentry_t& it, GameData::getInstance().getData("busters_hidden_treasure")) {
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
}

BustersHiddenTreasureTab::~BustersHiddenTreasureTab()
{
    delete form;
}
