#include "equipmenttab.h"

#include "dataeditor/biteditor.h"
#include "dataeditor/integereditor.h"
#include "dataeditor/listeditor.h"

#include <QMessageBox>

EquipmentTab::EquipmentTab(SaveManager* mgr, int num1Offset, int itemCount, QWidget* parent, int sectionId)
    : ListTab(mgr, parent, sectionId)
    , form(new Ui::EquipmentTabForm)
{
    QWidget* w = new QWidget(this);
    form->setupUi(w);
    ui->form->addWidget(w);

    this->setNum1Offset(num1Offset);
    this->setItemsCount(itemCount);
    this->setItemSize(0x14);

    for (int i = 0; i < itemCount; ++i) {
        ui->listWidget->addItem(QString(""));
    }

    /* intert items into combobox */
    foreach (const dataentry_t& it, GameData::getInstance().getData("hackslash_equipment")) {
        form->itemCB->addItem(it.second.value("name"), it.first);
        this->enchantability.insert(it.first, it.second.value("enchant").toUInt());
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
    this->editors.append(new IntegerEditor(this, form->countLabel, form->countSB, 0xA, 8, false));
    this->editors.append(new IntegerEditor(this, form->count2Label, form->count2SB, 0xB, 8, false));
    this->editors.append(new ListEditor(this, form->skill1Label, form->skill1CB, 0xC, 32, false));
    this->editors.append(new ListEditor(this, form->skill2Label, form->skill2CB, 0x10, 32, false));

    connect(form->enchantB, SIGNAL(clicked(bool)), SLOT(enchantAll()));
}

EquipmentTab::~EquipmentTab()
{
    delete form;
}

void EquipmentTab::setButtonsEnabled(bool s)
{
    ListTab::setButtonsEnabled(s);
    if (this->getItemsCount() <= this->editors.count()) {
        ui->addAllButton->setEnabled(false);
    }
}

void EquipmentTab::enchantAll()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("ENCHANT_ALL_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeSelectedItem();
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 eq_id = this->read<quint32>(0x04 + 0x14 * i);
            quint8 enchantability = std::min((quint8)127, this->enchantability.value(eq_id, -1));
            if (eq_id && enchantability >= 0) {
                this->write<quint8>(enchantability, 0xB + 0x14 * i);
            }
        }

        this->update();
    }
}
