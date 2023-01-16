#include "consumetab.h"
#include <QMessageBox>

#include "dataeditor/biteditor.h"
#include "dataeditor/integereditor.h"
#include "dataeditor/listeditor.h"

ConsumeTab::ConsumeTab(SaveManager* mgr, QWidget* parent, int sectionId)
    : ListTab(mgr, parent, sectionId)
    , form(new Ui::ConsumeTabForm)
{
    QWidget* w = new QWidget(this);
    form->setupUi(w);
    ui->form->addWidget(w);

    this->setNum1Offset(0x2000);
    this->setItemsCount(GameConfig::HackslashConsumeCountMax);
    this->setItemSize(0x14);

    for (int i = 0; i < this->getItemsCount(); ++i) {
        ui->listWidget->addItem(QString(""));
    }

    /* intert items into combobox */
    foreach (const dataentry_t& it, GameData::getInstance().getData("hackslash_consume")) {
        form->itemCB->addItem(it.second.value("name"), it.first);
    }
    form->itemCB->setCurrentIndex(-1);

    /* editors */
    ListEditor* itemE = new ListEditor(this, form->itemLabel, form->itemCB, 0x04, 32);
    this->setPrimaryEditor(itemE);
    this->editors.append(new IntegerEditor(this, form->num1Label, form->num1SB, 0x00, 16, false));
    this->editors.append(new IntegerEditor(this, form->num2Label, form->num2SB, 0x02, 16, false));
    this->editors.append(itemE);
    this->editors.append(new IntegerEditor(this, form->countLabel, form->countSB, 0xA, 8));

    this->editors.append(new BitEditor(this, form->flag0CB, 0xB, 0));
    this->editors.append(new BitEditor(this, form->flag1CB, 0xB, 1));
    this->editors.append(new BitEditor(this, form->flag2CB, 0xB, 2));
    this->editors.append(new BitEditor(this, form->flag3CB, 0xB, 3));
    this->editors.append(new BitEditor(this, form->flag4CB, 0xB, 4));
    this->editors.append(new BitEditor(this, form->flag5CB, 0xB, 5));
    this->editors.append(new BitEditor(this, form->flag6CB, 0xB, 6));
    this->editors.append(new BitEditor(this, form->flag7CB, 0xB, 7));
}

ConsumeTab::~ConsumeTab()
{
    delete form;
}

void ConsumeTab::update()
{
    ListTab::update();
}
