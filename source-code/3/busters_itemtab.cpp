#pragma execution_character_set("utf-8")

#include "busters_itemtab.h"

#include "dataeditor/integereditor.h"
#include "dataeditor/listeditor.h"

BustersItemTab::BustersItemTab(SaveManager* mgr, QWidget* parent, int sectionId, bool is_itembox)
    : ListTab(mgr, parent, sectionId)
    , form(new Ui::BustersItemTabForm)
{
    QWidget* w = new QWidget(this);
    form->setupUi(w);
    ui->form->addWidget(w);

    if (is_itembox) {
        this->setNum1Offset(0x0);
        this->setItemsCount(GameConfig::BustersItemBoxCountMax);
    } else {
        this->setNum1Offset(0x1000);
        this->setItemsCount(GameConfig::BustersItemPouchCountMax);
    }
    this->setItemSize(0x0C);

    for (int i = 0; i < this->getItemsCount(); ++i) {
        ui->listWidget->addItem(QString(""));
    }

    /* intert items into combobox */
    foreach (const dataentry_t& it, GameData::getInstance().getData("hackslash")) {
        form->itemCB->addItem(it.second.value("name"), it.first);
    }
    foreach (const dataentry_t& it, GameData::getInstance().getData("busters_equipment")) {
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
    this->editors.append(new IntegerEditor(this, form->enchantmentLabel, form->enchantmentSB, 0x9, 8, false));
}

BustersItemTab::~BustersItemTab()
{
    delete form;
}

void BustersItemTab::automaticNumbering()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("AUTOMATIC_NUMBERING_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeSelectedItem();
        int k = 0;
        for (int i = 0; i < this->getItemsCount(); ++i) {
            if (this->read<quint32>(0x04 + this->getItemSize() * i)) { // if identifier is non-zero
                this->write<quint16>(k + this->getNum1Offset(), 0x00 + this->getItemSize() * i); // num1
                this->write<quint16>(k + 1, 0x02 + this->getItemSize() * i); // num2
                this->write<quint8>(k, 0x08 + this->getItemSize() * i); // pos
                k++;
            }
        }
        this->update();
    }
}
