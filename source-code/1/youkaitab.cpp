#pragma execution_character_set("utf-8")

#include "youkaitab.h"
#include "ui_youkaitab.h"
#include <QMessageBox>
#include <QtGlobal>
#include <QTime>

YoukaiTab::YoukaiTab(SaveManager *mgr, QWidget *parent, int sectionId) :
    ListTab(mgr, parent, sectionId),
    ui(new Ui::YoukaiTab)
{
    ui->setupUi(this);
    for (int i = 0; i < GameConfig::YoukaiCountMax; ++i) {
        ui->listWidget->addItem(QString(""));
    }
    this->setItemsCount(GameConfig::YoukaiCountMax);

    /* intert items into combobox */
    for (QList<QPair<quint32, QString> >::const_iterator it = GameData::getInstance().getData("youkai").constBegin();
         it != GameData::getInstance().getData("youkai").constEnd();
         ++it) {
        ui->youkaiCB->addItem((*it).second, (*it).first);
    }
    ui->youkaiCB->setCurrentIndex(-1);
    for (QList<QPair<quint32, QString> >::const_iterator it = GameData::getInstance().getData("ai").constBegin();
         it != GameData::getInstance().getData("ai").constEnd();
         ++it) {
        ui->attitudeCB->addItem((*it).second, (*it).first);
    }
    ui->attitudeCB->setCurrentIndex(-1);
    connect(ui->listWidget, SIGNAL(currentRowChanged(int)), SLOT(loadItemAt(int)));
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(loadCurrentItem()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(writeCurrentItem()));
    connect(ui->youkaiNumApplyB, SIGNAL(clicked(bool)), SLOT(updateYoukaiCount()));
    connect(ui->autoNumberingButton, SIGNAL(clicked(bool)), SLOT(automaticNumbering()));
}

YoukaiTab::~YoukaiTab()
{
    delete ui;
}

void YoukaiTab::update()
{
    for (int i = 0; i < this->itemsCount; ++i) {
        quint32 youkaiId = this->read<quint32>(0x04 + 0x5C * i);
        int itemIndex = ui->youkaiCB->findData(youkaiId);
        if (itemIndex >= 0) {
            ui->listWidget->item(i)->setText(
                        ui->youkaiCB->itemText(itemIndex)
                        );
        } else {
            ui->listWidget->item(i)->setText(tr("(unknown)"));
        }

        quint8 attitudeId = this->read<quint8>(0x55 + 0x5C * i);
        itemIndex = ui->attitudeCB->findData(attitudeId);
    }
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
    ui->youkaiNumApplyB->setEnabled(true);
    ui->autoNumberingButton->setEnabled(true);
    if (ui->listWidget->currentRow() < 0) {
        ui->listWidget->setCurrentRow(0);
    }
    this->loadCurrentItem();
}

void YoukaiTab::loadItemAt(int row)
{
    if (row >= 0 && row < this->itemsCount) {
        /* 0x08 is for header */
        quint16 num1 = this->read<quint16>(0x00 + 0x5C * row);
        quint16 num2 = this->read<quint16>(0x02 + 0x5C * row);
        quint32 youkaiId = this->read<quint32>(0x04 + 0x5C * row);
        QString nickname = this->readString(0x08 + 0x5C * row, 0x18 - 1);
        quint8 attack = this->read<quint8>(0x2E + 0x5C * row);
        quint8 technique = this->read<quint8>(0x32 + 0x5C * row);
        quint8 soultimate = this->read<quint8>(0x36 + 0x5C * row);
        quint8 IVA_HP = this->read<quint8>(0x40 + 0x5C * row);
        quint8 IVA_Str = this->read<quint8>(0x41 + 0x5C * row);
        quint8 IVA_Spr = this->read<quint8>(0x42 + 0x5C * row);
        quint8 IVA_Def = this->read<quint8>(0x43 + 0x5C * row);
        quint8 IVA_Spd = this->read<quint8>(0x44 + 0x5C * row);
        quint8 IVB_HP = this->read<quint8>(0x45 + 0x5C * row);
        quint8 IVB_Str = this->read<quint8>(0x46 + 0x5C * row);
        quint8 IVB_Spr = this->read<quint8>(0x47 + 0x5C * row);
        quint8 IVB_Def = this->read<quint8>(0x48 + 0x5C * row);
        quint8 IVB_Spd = this->read<quint8>(0x49 + 0x5C * row);
        quint8 EV_HP = this->read<quint8>(0x4A + 0x5C * row);
        quint8 EV_Str = this->read<quint8>(0x4B + 0x5C * row);
        quint8 EV_Spr = this->read<quint8>(0x4C + 0x5C * row);
        quint8 EV_Def = this->read<quint8>(0x4D + 0x5C * row);
        quint8 EV_Spd = this->read<quint8>(0x4E + 0x5C * row);
        quint8 level = this->read<quint8>(0x54 + 0x5C * row);
        quint8 attitudeID = this->read<quint8>(0x55 + 0x5C * row);
        // quint16 rawEV = this->read<quint16>(0x5A + 0x5C * row);
        ui->num1SB->setValue(num1);
        ui->num2SB->setValue(num2);
        ui->nicknameEdit->setText(nickname);
        ui->attackSB->setValue(attack);
        ui->techniqueSB->setValue(technique);
        ui->soultimateSB->setValue(soultimate);
        ui->IVA_HPSB->setValue(IVA_HP);
        ui->IVA_StrSB->setValue(IVA_Str);
        ui->IVA_SprSB->setValue(IVA_Spr);
        ui->IVA_DefSB->setValue(IVA_Def);
        ui->IVA_SpdSB->setValue(IVA_Spd);
        ui->IVB1_HPSB->setValue(IVB_HP & 0xF);
        ui->IVB1_StrSB->setValue(IVB_Str & 0xF);
        ui->IVB1_SprSB->setValue(IVB_Spr & 0xF);
        ui->IVB1_DefSB->setValue(IVB_Def & 0xF);
        ui->IVB1_SpdSB->setValue(IVB_Spd & 0xF);
        ui->IVB2_HPSB->setValue(IVB_HP >> 4);
        ui->IVB2_StrSB->setValue(IVB_Str >> 4);
        ui->IVB2_SprSB->setValue(IVB_Spr >> 4);
        ui->IVB2_DefSB->setValue(IVB_Def >> 4);
        ui->IVB2_SpdSB->setValue(IVB_Spd >> 4);
        ui->EV_HPSB->setValue(EV_HP);
        ui->EV_StrSB->setValue(EV_Str);
        ui->EV_SprSB->setValue(EV_Spr);
        ui->EV_DefSB->setValue(EV_Def);
        ui->EV_SpdSB->setValue(EV_Spd);
        ui->levelSB->setValue(level);
        // ui->evSB->setValue(rawEV); // affection points

        /* load Combo Boxes */
        ui->youkaiCB->setCurrentIndex(ui->youkaiCB->findData(youkaiId));
        ui->attitudeCB->setCurrentIndex(ui->attitudeCB->findData(attitudeID));
    }
}

void YoukaiTab::writeItemAt(int row)
{
    quint8 flag = 0;
    for (QList<QCheckBox *>::const_iterator it = this->flagCBs.constBegin();
         it != this->flagCBs.constEnd();
         ++it) {
        if ((*it)->isChecked()) {
            flag |= (1 << (it - this->flagCBs.constBegin()));
        }
    }

    if (row >= 0 && row < this->itemsCount) {
        this->write<quint16>(ui->num1SB->value(), 0x00 + 0x5C * row); // num1
        this->write<quint16>(ui->num2SB->value(), 0x02 + 0x5C * row); // num2
        if (ui->youkaiCB->currentIndex() >= 0) {
            this->write<quint32>(
                        ui->youkaiCB->currentData().value<quint32>(),
                        0x04 + 0x5C * row
                        ); // youkaiId
        }
        if (ui->attitudeCB->currentIndex() >= 0) {
            this->write<quint8>(
                        ui->attitudeCB->currentData().value<quint8>(),
                        0x55 + 0x5C * row
                        ); // attitudeId
        }
        this->writeString(ui->nicknameEdit->text(), 0x08 + 0x5C * row, 0x18 - 1); // nickname
        this->write<quint8>(ui->attackSB->value(), 0x2E + 0x5C * row); // attack
        this->write<quint8>(ui->techniqueSB->value(), 0x32 + 0x5C * row); // technique
        this->write<quint8>(ui->soultimateSB->value(), 0x36 + 0x5C * row); // soultimate
        this->write<quint8>(ui->IVA_HPSB->value(), 0x40 + 0x5C * row); // IVA_HP
        this->write<quint8>(ui->IVA_StrSB->value(), 0x41 + 0x5C * row); // IVA_Str
        this->write<quint8>(ui->IVA_SprSB->value(), 0x42 + 0x5C * row); // IVA_Spr
        this->write<quint8>(ui->IVA_DefSB->value(), 0x43 + 0x5C * row); // IVA_Def
        this->write<quint8>(ui->IVA_SpdSB->value(), 0x44 + 0x5C * row); // IVA_Spd
        this->write<quint8>(ui->IVB1_HPSB->value() | ui->IVB2_HPSB->value() << 4, 0x45 + 0x5C * row); // IVB_HP
        this->write<quint8>(ui->IVB1_StrSB->value() | ui->IVB2_StrSB->value() << 4, 0x46 + 0x5C * row); // IVB_Str
        this->write<quint8>(ui->IVB1_SprSB->value() | ui->IVB2_SprSB->value() << 4, 0x47 + 0x5C * row); // IVB_Spr
        this->write<quint8>(ui->IVB1_DefSB->value() | ui->IVB2_DefSB->value() << 4, 0x48 + 0x5C * row); // IVB_Def
        this->write<quint8>(ui->IVB1_SpdSB->value() | ui->IVB2_SpdSB->value() << 4, 0x49 + 0x5C * row); // IVB_Spd
        this->write<quint8>(ui->EV_HPSB->value(), 0x4A + 0x5C * row); // EV_HP
        this->write<quint8>(ui->EV_StrSB->value(), 0x4B + 0x5C * row); // EV_Str
        this->write<quint8>(ui->EV_SprSB->value(), 0x4C + 0x5C * row); // EV_Spr
        this->write<quint8>(ui->EV_DefSB->value(), 0x4D + 0x5C * row); // EV_Def
        this->write<quint8>(ui->EV_SpdSB->value(), 0x4E + 0x5C * row); // EV_Spd
        this->write<quint8>(ui->levelSB->value(), 0x54 + 0x5C * row); // level
        // this->write<quint16>(ui->evSB->value(), 0x5A + 0x5C * row); // affection points
    }

    /* update */
    this->loadItemAt(row);
    quint32 youkaiId = ui->youkaiCB->currentData().value<quint32>();
    int itemIndex = ui->youkaiCB->findData(youkaiId);
    if (itemIndex >= 0) {
        ui->listWidget->item(row)->setText(
                    ui->youkaiCB->itemText(itemIndex)
                    );
    } else {
        ui->listWidget->item(row)->setText(tr("(unknown)"));
    }
}

void YoukaiTab::loadCurrentItem()
{
    int i;
    if ((i = ui->listWidget->currentRow()) >= 0) {
        this->loadItemAt(i);
    }
}

void YoukaiTab::writeCurrentItem()
{
    int i;
    if ((i = ui->listWidget->currentRow()) >= 0) {
        this->writeItemAt(i);
    }
}

void YoukaiTab::updateYoukaiCount()
{
    int ans = QMessageBox::question(this, tr("Confirm"),
                          tr("This operation adds all edited yokai to the medallium.\n"
                          "If edited yokai don't appear in-game, use this.\n\n"
                          "This is experimental feature and can destroy your savedata."),
                          QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeCurrentItem();
        for (int i = 0; i < GameConfig::YoukaiCountMax; ++i) {
            quint32 num = this->read<quint32>(0x00 + 0x5C * i);
            this->getMgr()->writeSection<quint32>(num, 0x00 + 0x04 * i, 0x0A);
        }
        this->update();
    }
}

void YoukaiTab::automaticNumbering()
{
    int ans = QMessageBox::question(this, tr("Confirm"),
                          tr("This operation renumbers your Yo-kai's #1 and #2.\n\n"
                          "This is experimental feature and can destroy your savedata."),
                          QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeCurrentItem();
        int k = 0;
        for (int i = 0; i < GameConfig::YoukaiCountMax; ++i) {
            quint32 youkaiId = this->read<quint32>(0x04 + 0x5C * i);
            if (ui->youkaiCB->findData(youkaiId) >= 0) {
                this->write<quint16>(k, 0x00 + 0x5C * i);     // num1
                this->write<quint16>(k + 1, 0x02 + 0x5C * i); // num2
                k++;
            }
        }
        this->update();
    }
}
