#pragma execution_character_set("utf-8")

#include "equipmenttab.h"
#include "ui_equipmenttab.h"
#include <QMessageBox>

EquipmentTab::EquipmentTab(SaveManager *mgr, QWidget *parent, int sectionId) :
    ListTab(mgr, parent, sectionId),
    ui(new Ui::EquipmentTab)
{
    ui->setupUi(this);
    for (int i = 0; i < GameConfig::EquipmentCountMax; ++i) {
        ui->listWidget->addItem(QString(""));
    }
    this->setItemsCount(GameConfig::EquipmentCountMax);

    /* intert items into combobox */
    for (QList<QPair<quint32, QString> >::const_iterator it = GameData::getInstance().getData("equipment").constBegin();
         it != GameData::getInstance().getData("equipment").constEnd();
         ++it) {
        ui->itemCB->addItem((*it).second, (*it).first);
    }
    ui->itemCB->setCurrentIndex(-1);
    connect(ui->listWidget, SIGNAL(currentRowChanged(int)), SLOT(loadItemAt(int)));
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(loadCurrentItem()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(writeCurrentItem()));
    connect(ui->autoNumberingB, SIGNAL(clicked(bool)), SLOT(automaticNumbering()));
}

EquipmentTab::~EquipmentTab()
{
    delete ui;
}

void EquipmentTab::update()
{
    for (int i = 0; i < this->itemsCount; ++i) {
        quint32 ItemId = this->read<quint32>(0x04 + 0x10 * i);
        int itemIndex = ui->itemCB->findData(ItemId);
        if (itemIndex >= 0) {
            ui->listWidget->item(i)->setText(
                        ui->itemCB->itemText(itemIndex)
                        );
        } else {
            ui->listWidget->item(i)->setText(tr("(unknown)"));
        }
    }
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
    ui->listWidget->setCurrentRow(0);
    ui->autoNumberingB->setEnabled(true);
    this->loadCurrentItem();
}

void EquipmentTab::loadItemAt(int row)
{
    if (row >= 0 && row < this->itemsCount) {
        /* 0x08 is for header */
        quint16 num1 = this->read<quint16>(0x00 + 0x10 * row);
        quint16 num2 = this->read<quint16>(0x02 + 0x10 * row);
        quint32 ItemId = this->read<quint32>(0x04 + 0x10 * row);
        quint8 itemCount = this->read<quint8>(0x08 + 0x10 * row);
        quint8 itemCount2 = this->read<quint8>(0x0C + 0x10 * row);
        ui->num1SB->setValue(num1);
        ui->num2SB->setValue(num2);
        ui->countSB->setValue(itemCount);
        ui->count2SB->setValue(itemCount2);

        /* load item */
        ui->itemCB->setCurrentIndex(ui->itemCB->findData(ItemId));
    }
}

void EquipmentTab::writeItemAt(int row)
{
    if (row >= 0 && row < this->itemsCount) {
        this->write<quint16>(ui->num1SB->value(), 0x00 + 0x10 * row); // num1
        this->write<quint16>(ui->num2SB->value(), 0x02 + 0x10 * row); // num2
        if (ui->itemCB->currentIndex() >= 0) {
            this->write<quint32>(
                        ui->itemCB->currentData().value<quint32>(),
                        0x04 + 0x10 * row
                        ); // ItemId
        }
        this->write<quint8>(ui->countSB->value(), 0x08 + 0x10 * row); // itemCount
        this->write<quint8>(ui->count2SB->value(), 0x0C + 0x10 * row); // itemCount2
    }

    /* update */
    this->loadItemAt(row);
    quint32 ItemId = ui->itemCB->currentData().value<quint32>();
    int itemIndex = ui->itemCB->findData(ItemId);
    if (itemIndex >= 0) {
        ui->listWidget->item(row)->setText(
                    ui->itemCB->itemText(itemIndex)
                    );
    } else {
        ui->listWidget->item(row)->setText(tr("(unknown)"));
    }
}

void EquipmentTab::loadCurrentItem()
{
    int i;
    if ((i = ui->listWidget->currentRow()) >= 0) {
        this->loadItemAt(i);
    }
}

void EquipmentTab::writeCurrentItem()
{
    int i;
    if ((i = ui->listWidget->currentRow()) >= 0) {
        this->writeItemAt(i);
    }
}

void EquipmentTab::automaticNumbering()
{
    int ans = QMessageBox::question(this, tr("Confirm"),
                                    tr("This action will automatically assign the #1 and #2 values of each entry.\n\n"
                                       "Because this is an experimental feature, your save data may get corrupted. Continue?"),
                                    QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeCurrentItem();
        int k = 0;
        for (int i = 0; i < GameConfig::EquipmentCountMax; ++i) {
            quint32 ItemId = this->read<quint32>(0x04 + 0x10 * i);
            if (ui->itemCB->findData(ItemId) >= 0) {
                this->write<quint16>(k + 0x1000, 0x00 + 0x10 * i); // num1
                this->write<quint16>(k + 1, 0x02 + 0x10 * i);      // num2
                k++;
            }
        }
        this->update();
    }
}