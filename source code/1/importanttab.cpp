#pragma execution_character_set("utf-8")

#include "importanttab.h"
#include "ui_importanttab.h"

ImportantTab::ImportantTab(SaveManager *mgr, QWidget *parent, int sectionId) :
    ListTab(mgr, parent, sectionId),
    ui(new Ui::ImportantTab)
{
    ui->setupUi(this);
    for (int i = 0; i < GameConfig::ImportantCountMax; ++i) {
        ui->listWidget->addItem(QString(""));
    }
    this->setItemsCount(GameConfig::ImportantCountMax);

    /* intert items into combobox */
    for (QList<QPair<quint32, QString> >::const_iterator it = GameData::getInstance().getData("important").constBegin();
         it != GameData::getInstance().getData("important").constEnd();
         ++it) {
        ui->itemCB->addItem((*it).second, (*it).first);
    }
    ui->itemCB->setCurrentIndex(-1);
    connect(ui->listWidget, SIGNAL(currentRowChanged(int)), SLOT(loadItemAt(int)));
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(loadCurrentItem()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(writeCurrentItem()));

}

ImportantTab::~ImportantTab()
{
    delete ui;
}

void ImportantTab::update()
{
    for (int i = 0; i < this->itemsCount; ++i) {
        quint32 ItemId = this->read<quint32>(0x04 + 0x08 * i);
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

void ImportantTab::loadItemAt(int row)
{
    if (row >= 0 && row < this->itemsCount) {
        /* 0x08 is for header */
        quint16 num1 = this->read<quint16>(0x00 + 0x08 * row);
        quint16 num2 = this->read<quint16>(0x02 + 0x08 * row);
        quint32 ItemId = this->read<quint32>(0x04 + 0x08 * row);
        ui->num1SB->setValue(num1);
        ui->num2SB->setValue(num2);

        /* load item */
        ui->itemCB->setCurrentIndex(ui->itemCB->findData(ItemId));
    }
}

void ImportantTab::writeItemAt(int row)
{
    if (row >= 0 && row < this->itemsCount) {
        this->write<quint16>(ui->num1SB->value(), 0x00 + 0x08 * row); // num1
        this->write<quint16>(ui->num2SB->value(), 0x02 + 0x08 * row); // num2
        if (ui->itemCB->currentIndex() >= 0) {
            this->write<quint32>(
                        ui->itemCB->currentData().value<quint32>(),
                        0x04 + 0x08 * row
                        ); // ItemId
        }
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

void ImportantTab::loadCurrentItem()
{
    int i;
    if ((i = ui->listWidget->currentRow()) >= 0) {
        this->loadItemAt(i);
    }
}

void ImportantTab::writeCurrentItem()
{
    int i;
    if ((i = ui->listWidget->currentRow()) >= 0) {
        this->writeItemAt(i);
    }
}
