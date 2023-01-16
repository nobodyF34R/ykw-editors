#pragma execution_character_set("utf-8")

#include "listtab.h"
#include <QMessageBox>

ListTab::ListTab(SaveManager *mgr, QWidget *parent, int sectionId) :
    Tab(mgr, parent, sectionId),
    itemsCount(0),
    num1Offset(0),
    itemSize(0),
    ui(new Ui::ListTab)
{
    ui->setupUi(this);
    connect(ui->listWidget, SIGNAL(currentRowChanged(int)), SLOT(loadItemAt(int)));
    connect(ui->autonumberingB, SIGNAL(clicked(bool)), SLOT(automaticNumbering()));
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(loadCurrentItem()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(writeCurrentItem()));
    connect(ui->filterLineEdit, SIGNAL(textChanged(QString)), SLOT(updateFilter(QString)));
}

ListTab::~ListTab()
{
    delete ui;
}

int ListTab::getItemsCount() const
{
    return itemsCount;
}

void ListTab::setItemsCount(int value)
{
    itemsCount = value;
}

int ListTab::getItemSize() const
{
    return itemSize;
}

void ListTab::setItemSize(int value)
{
    itemSize = value;
}

int ListTab::getNum1Offset() const
{
    return num1Offset;
}

void ListTab::setNum1Offset(int value)
{
    num1Offset = value;
}

void ListTab::setButtonsEnabled(bool s)
{
    ui->applyButton->setEnabled(s);
    ui->resetButton->setEnabled(s);
    ui->autonumberingB->setEnabled(s);
}

void ListTab::loadCurrentItem()
{
    int i;
    if ((i = ui->listWidget->currentRow()) >= 0) {
        this->loadItemAt(i);
    }
}

void ListTab::writeCurrentItem()
{
    int i;
    if ((i = ui->listWidget->currentRow()) >= 0) {
        this->writeItemAt(i);
    }
}

void ListTab::updateFilter(QString term)
{
    if (term.isEmpty()) {
        clearFilter();
        return;
    }
    hideAll();
    QList<QListWidgetItem*> matches = ui->listWidget->findItems(term, Qt::MatchContains);
    foreach (QListWidgetItem* i, matches) {
        i->setHidden(false);
    }
}

void ListTab::clearFilter()
{
    for (int i = 0; i < ui->listWidget->count(); ++i){
        ui->listWidget->item(i)->setHidden(false);
    }
}

void ListTab::automaticNumbering()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
                          tr("AUTOMATIC_NUMBERING_WARNING"),
                          QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeCurrentItem();
        int k = 0;
        for (int i = 0; i < this->getItemsCount(); ++i) {
            if (this->read<quint32>(0x04 + itemSize * i)) { // if identifier is non-zero
                this->write<quint16>(k + num1Offset, 0x00 + itemSize * i); // num1
                this->write<quint16>(k + 1, 0x02 + itemSize * i);          // num2
                k++;
            }
        }
        this->update();
    }

}

void ListTab::hideAll()
{
    for (int i = 0; i < ui->listWidget->count(); ++i){
        ui->listWidget->item(i)->setHidden(true);
    }
}
