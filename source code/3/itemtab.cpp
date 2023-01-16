#pragma execution_character_set("utf-8")

#include "itemtab.h"
#include <QMessageBox>

#include "dataeditor/integereditor.h"
#include "dataeditor/listeditor.h"

ItemTab::ItemTab(SaveManager* mgr, QWidget* parent, int sectionId)
    : ListTab(mgr, parent, sectionId)
    , form(new Ui::ItemTabForm)
{
    QWidget* w = new QWidget(this);
    form->setupUi(w);
    ui->form->addWidget(w);

    this->setNum1Offset(0);
    this->setItemsCount(GameConfig::ItemCountMax);
    this->setItemSize(0x0C);

    for (int i = 0; i < this->getItemsCount(); ++i) {
        ui->listWidget->addItem(QString(""));
    }

    /* intert items into combobox */
    foreach (const dataentry_t& it, GameData::getInstance().getData("creature")) {
        form->itemCB->addItem(it.second.value("name"), it.first);
    }
    foreach (const dataentry_t& it, GameData::getInstance().getData("consume")) {
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

    connect(form->allCreaturesB, SIGNAL(clicked(bool)), this, SLOT(addAllCreatures()));
}

ItemTab::~ItemTab()
{
    delete form;
}

void ItemTab::update()
{
    ListTab::update();
    form->allCreaturesB->setEnabled(true);
}

void ItemTab::addAllCreatures()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("ALL_CREATURES_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        int i = 0;
        foreach (const dataentry_t& it, GameData::getInstance().getData("creature")) {
            while (i < this->getItemsCount()) {
                quint32 ItemId = this->read<quint32>(0x04 + 0x0C * i);
                int itemIndex = form->itemCB->findData(ItemId);
                if (itemIndex >= 0) {
                    i++;
                } else {
                    break; // invalid item
                }
            }
            if (i >= this->getItemsCount()) {
                break;
            }
            if (!(ui->listWidget->findItems(it.second.value("name"), Qt::MatchExactly).isEmpty())) {
                continue;
            }
            this->write<quint32>(it.first, 0x04 + 0x0C * i); // ItemId
        }
        this->update();
    }
}
