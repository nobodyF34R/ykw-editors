#pragma execution_character_set("utf-8")

#include "itemtab.h"
#include "ui_itemtab.h"

ItemTab::ItemTab(SaveManager *mgr, QWidget *parent, int sectionId) :
    ListTab(mgr, parent, sectionId),
    ui(new Ui::ItemTab)
{
    ui->setupUi(this);
    for (int i = 0; i < GameConfig::ItemCountMax; ++i) {
        ui->listWidget->addItem(QString(""));
    }
    this->setItemsCount(GameConfig::ItemCountMax);

    /* intert items into combobox */
    for (QList<QPair<quint32, QString> >::const_iterator it = GameData::getInstance().getData("consume").constBegin();
         it != GameData::getInstance().getData("consume").constEnd();
         ++it) {
        ui->itemCB->addItem((*it).second, (*it).first);
    }
    for (QList<QPair<quint32, QString> >::const_iterator it = GameData::getInstance().getData("creature").constBegin();
         it != GameData::getInstance().getData("creature").constEnd();
         ++it) {
        ui->itemCB->addItem((*it).second, (*it).first);
    }
    ui->itemCB->setCurrentIndex(-1);
    connect(ui->listWidget, SIGNAL(currentRowChanged(int)), SLOT(loadItemAt(int)));
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(loadCurrentItem()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(writeCurrentItem()));
}

ItemTab::~ItemTab()
{
    delete ui;
}

void ItemTab::update()
{
    for (int i = 0; i < this->itemsCount; ++i) {
        quint32 ItemId = this->read<quint32>(0x04 + 0x0C * i);
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
    this->loadCurrentItem();
}

void ItemTab::loadItemAt(int row)
{
    if (row >= 0 && row < this->itemsCount) {
        /* 0x10 is for header */
        quint16 num1 = this->read<quint16>(0x00 + 0x0C * row);
        quint16 num2 = this->read<quint16>(0x02 + 0x0C * row);
        quint32 ItemId = this->read<quint32>(0x04 + 0x0C * row);
        quint8 itemCount = this->read<quint8>(0x08 + 0x0C * row);
        ui->num1SB->setValue(num1);
        ui->num2SB->setValue(num2);
        ui->countSB->setValue(itemCount);

        /* load item */
        ui->itemCB->setCurrentIndex(ui->itemCB->findData(ItemId));
    }
}

void ItemTab::writeItemAt(int row)
{
    if (row >= 0 && row < this->itemsCount) {
        this->write<quint16>(ui->num1SB->value(), 0x00 + 0x0C * row); // num1
        this->write<quint16>(ui->num2SB->value(), 0x02 + 0x0C * row); // num2
        if (ui->itemCB->currentIndex() >= 0) {
            this->write<quint32>(
                        ui->itemCB->currentData().value<quint32>(),
                        0x04 + 0x0C * row
                        ); // ItemId
        }
        this->write<quint8>(ui->countSB->value(), 0x08 + 0x0C * row); // itemCount
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

void ItemTab::loadCurrentItem()
{
    int i;
    if ((i = ui->listWidget->currentRow()) >= 0) {
        this->loadItemAt(i);
    }
}

void ItemTab::writeCurrentItem()
{
    int i;
    if ((i = ui->listWidget->currentRow()) >= 0) {
        this->writeItemAt(i);
    }
}
