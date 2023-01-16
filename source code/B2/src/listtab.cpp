#include "listtab.h"
#include <QMessageBox>

#include "dataeditor/dataeditor.h"
#include "dataeditor/listeditor.h"

ListTab::ListTab(SaveManager* mgr, QWidget* parent, int sectionId)
    : Tab(mgr, parent, sectionId)
    , itemsCount(0)
    , num1Offset(0)
    , itemSize(0)
    , primaryEditor(nullptr)
    , ui(new Ui::ListTab)
    , editors()
{
    ui->setupUi(this);
    connect(ui->listWidget, SIGNAL(currentRowChanged(int)), SLOT(loadCurrentItem()));
    connect(ui->addAllButton, SIGNAL(clicked(bool)), SLOT(insertAllItems()));
    connect(ui->autonumberingB, SIGNAL(clicked(bool)), SLOT(automaticNumbering()));
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(loadCurrentItem()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(writeSelectedItem()));
    connect(ui->filterLineEdit, SIGNAL(textChanged(QString)), SLOT(updateFilter(QString)));
    connect(ui->clearB, SIGNAL(clicked(bool)), SLOT(clearData()));
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
    ui->clearB->setEnabled(s);
    ui->addAllButton->setEnabled(s);
}

void ListTab::update()
{
    if (!primaryEditor) {
        return;
    }
    for (int i = 0; i < this->getItemsCount(); ++i) {
        ui->listWidget->item(i)->setText(primaryEditor->text(i));
    }
    this->setButtonsEnabled(true);
    if (ui->listWidget->currentRow() < 0) {
        ui->listWidget->setCurrentRow(0);
    }
    this->loadCurrentItem();
}

void ListTab::loadCurrentItem()
{
    int row;
    if ((row = ui->listWidget->currentRow()) >= 0) {
        if (row >= 0 && row < this->getItemsCount()) {
            foreach (DataEditor* e, this->editors) {
                e->load(row);
                e->markAsClean();
            }
        }
    }
}

void ListTab::writeSelectedItem()
{
    foreach (QModelIndex i, ui->listWidget->selectionModel()->selectedIndexes()) {
        int row = i.row();
        if (row >= 0 && row < this->getItemsCount()) {
            foreach (DataEditor* e, this->editors) {
                e->apply(row);
            }
        }
        ui->listWidget->item(row)->setText(primaryEditor->text(row));
    }
    foreach (DataEditor* e, this->editors) {
        e->markAsClean();
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
    for (int i = 0; i < ui->listWidget->count(); ++i) {
        ui->listWidget->item(i)->setHidden(false);
    }
}

void ListTab::automaticNumbering()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("AUTOMATIC_NUMBERING_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeSelectedItem();
        int k = 0;
        for (int i = 0; i < this->getItemsCount(); ++i) {
            if (this->read<quint32>(0x04 + itemSize * i)) { // if identifier is non-zero
                this->write<quint16>(k + num1Offset, 0x00 + itemSize * i); // num1
                this->write<quint16>(k + 1, 0x02 + itemSize * i); // num2
                k++;
            }
        }
        this->update();
    }
}

void ListTab::clearData()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("CLEAR_ENTRY_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans != QMessageBox::Ok) {
        return;
    }

    foreach (QModelIndex i, ui->listWidget->selectionModel()->selectedIndexes()) {
        int row = i.row();
        for (int j = 0; j < itemSize; ++j) {
            this->write<quint8>(0, j + itemSize * row);
        }
    }
    foreach (DataEditor* e, this->editors) {
        e->markAsClean();
    }
    this->update();
}

void ListTab::insertAllItems()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("INSERT_ALL_ENTRIES_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans != QMessageBox::Ok) {
        return;
    }

    if (!this->primaryEditor)
        return;

    int s = this->primaryEditor->count();
    for (int i = 0; i < s; ++i) {
        this->write<quint32>(
            this->primaryEditor->comboboxData(i), itemSize * i + 4);
    }
    this->update();
}

void ListTab::hideAll()
{
    for (int i = 0; i < ui->listWidget->count(); ++i) {
        ui->listWidget->item(i)->setHidden(true);
    }
}

ListEditor* ListTab::getPrimaryEditor() const
{
    return primaryEditor;
}

void ListTab::setPrimaryEditor(ListEditor* value)
{
    primaryEditor = value;
}
