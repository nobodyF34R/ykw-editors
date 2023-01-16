#pragma execution_character_set("utf-8")

#include "youkaitab.h"

#include <QMessageBox>
#include <QtGlobal>
#include <QTime>

YoukaiTab::YoukaiTab(SaveManager *mgr, QWidget *parent, int sectionId) :
    ListTab(mgr, parent, sectionId),
    form(new Ui::YoukaiTabForm)
{
    QWidget *w = new QWidget(this);
    form->setupUi(w);
    ui->form->addWidget(w);

    this->setNum1Offset(0);
    this->setItemsCount(GameConfig::YoukaiCountMax);
    this->setItemSize(0x5C);

    for (int i = 0; i < this->getItemsCount(); ++i) {
        ui->listWidget->addItem(QString(""));
    }

    /* intert items into combobox */
    foreach (const dataentry_t& it, GameData::getInstance().getData("youkai")) {
        form->youkaiCB->addItem(QString("%1 %2")
                              .arg(it.second.value("index").toInt(), 3, 10, QChar('0'))
                              .arg(it.second.value("name")),
                              it.first); /* userData */
    }
    form->youkaiCB->setCurrentIndex(-1);
    foreach (const dataentry_t& it, GameData::getInstance().getData("ai")) {
        form->AICB->addItem(it.second.value("name"), it.first);
    }
    form->AICB->setCurrentIndex(-1);
    connect(ui->listWidget, SIGNAL(currentRowChanged(int)), SLOT(loadItemAt(int)));
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(loadCurrentItem()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(writeCurrentItem()));
    connect(form->youkaiNumApplyB, SIGNAL(clicked(bool)), SLOT(updateYoukaiCount()));
    connect(form->updateIDButton, SIGNAL(clicked(bool)), SLOT(updateID()));
    connect(form->fixIVButton, SIGNAL(clicked(bool)), SLOT(fixIVs()));
}

YoukaiTab::~YoukaiTab()
{
    delete form;
}

void YoukaiTab::update()
{
    for (int i = 0; i < this->getItemsCount(); ++i) {
        quint32 youkaiId = this->read<quint32>(0x04 + 0x5C * i);
        int itemIndex = form->youkaiCB->findData(youkaiId);
        if (itemIndex >= 0) {
            ui->listWidget->item(i)->setText(
                        form->youkaiCB->itemText(itemIndex).mid(4) /* skip index */
                        );
        } else {
            ui->listWidget->item(i)->setText(tr("(UNKNOWN)"));
        }
    }
    this->setButtonsEnabled(true);
    form->youkaiNumApplyB->setEnabled(true);
    form->updateIDButton->setEnabled(true);
    form->fixIVButton->setEnabled(true);
    if (ui->listWidget->currentRow() < 0) {
        ui->listWidget->setCurrentRow(0);
    }
    this->loadCurrentItem();
}

void YoukaiTab::loadItemAt(int row)
{
    if (row >= 0 && row < this->getItemsCount()) {
        /* 0x08 is for header */
        quint16 num1 = this->read<quint16>(0x00 + 0x5C * row);
        quint16 num2 = this->read<quint16>(0x02 + 0x5C * row);
        quint32 youkaiId = this->read<quint32>(0x04 + 0x5C * row);
        QString nickname = this->readString(0x08 + 0x5C * row, 0x18 - 1);
        qint32 expPoint = this->read<qint32>(0x34 + 0x5C * row);
        quint32 ownerId = this->read<quint32>(0x3C + 0x5C * row);
        quint8 IV_HP = this->read<quint8>(0x40 + 0x5C * row);
        quint8 IV_Str = this->read<quint8>(0x41 + 0x5C * row);
        quint8 IV_Spr = this->read<quint8>(0x42 + 0x5C * row);
        quint8 IV_Def = this->read<quint8>(0x43 + 0x5C * row);
        quint8 IV_Spd = this->read<quint8>(0x44 + 0x5C * row);
        quint8 CB_HP = this->read<quint8>(0x45 + 0x5C * row);
        quint8 CB_Str = this->read<quint8>(0x46 + 0x5C * row);
        quint8 CB_Spr = this->read<quint8>(0x47 + 0x5C * row);
        quint8 CB_Def = this->read<quint8>(0x48 + 0x5C * row);
        quint8 CB_Spd = this->read<quint8>(0x49 + 0x5C * row);
        quint8 SC_HP = this->read<qint8>(0x4A + 0x5C * row);
        quint8 SC_Str = this->read<qint8>(0x4B + 0x5C * row);
        quint8 SC_Spr = this->read<qint8>(0x4C + 0x5C * row);
        quint8 SC_Def = this->read<qint8>(0x4D + 0x5C * row);
        quint8 SC_Spd = this->read<qint8>(0x4E + 0x5C * row);
        quint8 level = this->read<quint8>(0x4F + 0x5C * row);
        quint8 loaf = this->read<quint8>(0x54 + 0x5C * row) >> 4;
        quint8 ai = this->read<quint8>(0x54 + 0x5C * row) & 0xF;
        form->num1SB->setValue(num1);
        form->num2SB->setValue(num2);
        form->nicknameEdit->setText(nickname);
        form->expSB->setValue(expPoint);
        form->IDEdit->setText(QString::number(ownerId, 16));
        form->IV_HPSB->setValue(IV_HP);
        form->IV_StrSB->setValue(IV_Str);
        form->IV_SprSB->setValue(IV_Spr);
        form->IV_DefSB->setValue(IV_Def);
        form->IV_SpdSB->setValue(IV_Spd);
        form->CB_HPSB->setValue(CB_HP);
        form->CB_StrSB->setValue(CB_Str);
        form->CB_SprSB->setValue(CB_Spr);
        form->CB_DefSB->setValue(CB_Def);
        form->CB_SpdSB->setValue(CB_Spd);
        form->SC_HPSB->setValue(SC_HP);
        form->SC_StrSB->setValue(SC_Str);
        form->SC_SprSB->setValue(SC_Spr);
        form->SC_DefSB->setValue(SC_Def);
        form->SC_SpdSB->setValue(SC_Spd);
        form->levelSB->setValue(level);
        form->loafSB->setValue(loaf);

        /* load Yo-kai */
        form->youkaiCB->setCurrentIndex(form->youkaiCB->findData(youkaiId));
        /* load AI */
        form->AICB->setCurrentIndex(form->AICB->findData(ai));
    }
}

void YoukaiTab::writeItemAt(int row)
{
    if (row >= 0 && row < this->getItemsCount()) {
        this->write<quint16>(form->num1SB->value(), 0x00 + 0x5C * row); // num1
        this->write<quint16>(form->num2SB->value(), 0x02 + 0x5C * row); // num2
        if (form->youkaiCB->currentIndex() >= 0) {
            this->write<quint32>(
                        form->youkaiCB->currentData().value<quint32>(),
                        0x04 + 0x5C * row
                        ); // youkaiId
        }
        quint8 loafAndAi = this->read<quint8>(0x54 + 0x5C * row);
        if (form->AICB->currentIndex() >= 0) {
            loafAndAi = (loafAndAi & 0xF0) | (quint8)(form->AICB->currentData().value<quint32>() & 0xF); // AI
        }
        loafAndAi = (loafAndAi & 0xF) | ((form->loafSB->value() & 0xF) << 4); // loaf
        this->write<quint8>(loafAndAi, 0x54 + 0x5C * row); // loafAndAi

        this->writeString(form->nicknameEdit->text(), 0x08 + 0x5C * row, 0x18 - 1); // nickname
        this->write<qint32>(form->expSB->value(), 0x34 + 0x5C * row); // expPoint
        this->write<quint32>(form->IDEdit->text().toUInt(0, 16), 0x3C + 0x5C * row); // ownerId

        this->write<quint8>(form->IV_HPSB->value(), 0x40 + 0x5C * row); // IV_HP
        this->write<quint8>(form->IV_StrSB->value(), 0x41 + 0x5C * row); // IV_Str
        this->write<quint8>(form->IV_SprSB->value(), 0x42 + 0x5C * row); // IV_Spr
        this->write<quint8>(form->IV_DefSB->value(), 0x43 + 0x5C * row); // IV_Def
        this->write<quint8>(form->IV_SpdSB->value(), 0x44 + 0x5C * row); // IV_Spd
        this->write<quint8>(form->CB_HPSB->value(), 0x45 + 0x5C * row); // CB_HP
        this->write<quint8>(form->CB_StrSB->value(), 0x46 + 0x5C * row); // CB_Str
        this->write<quint8>(form->CB_SprSB->value(), 0x47 + 0x5C * row); // CB_Spr
        this->write<quint8>(form->CB_DefSB->value(), 0x48 + 0x5C * row); // CB_Def
        this->write<quint8>(form->CB_SpdSB->value(), 0x49 + 0x5C * row); // CB_Spd
        this->write<qint8>(form->SC_HPSB->value(), 0x4A + 0x5C * row); // SC_HP
        this->write<qint8>(form->SC_StrSB->value(), 0x4B + 0x5C * row); // SC_Str
        this->write<qint8>(form->SC_SprSB->value(), 0x4C + 0x5C * row); // SC_Spr
        this->write<qint8>(form->SC_DefSB->value(), 0x4D + 0x5C * row); // SC_Def
        this->write<qint8>(form->SC_SpdSB->value(), 0x4E + 0x5C * row); // SC_Spd

        this->write<quint8>(form->levelSB->value(), 0x4F + 0x5C * row); // level
    }

    /* update */
    this->loadItemAt(row);
    quint32 youkaiId = form->youkaiCB->currentData().value<quint32>();
    int itemIndex = form->youkaiCB->findData(youkaiId);
    if (itemIndex >= 0) {
        ui->listWidget->item(row)->setText(
                    form->youkaiCB->itemText(itemIndex).mid(4) /* skip index */
                    );
    } else {
        ui->listWidget->item(row)->setText(tr("(UNKNOWN)"));
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
    int ans = QMessageBox::question(this, tr("CONFIRM"),
                          tr("UPDATE_YO-KAI_INDEX_WARNING"),
                          QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeCurrentItem();
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 num = this->read<quint32>(0x00 + 0x5C * i);
            this->getMgr()->writeSection<quint32>(num, 0x00 + 0x04 * i, 0x0A);
        }
        this->update();
    }
}

void YoukaiTab::updateID()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
                          tr("FIX_ID_WARNING"),
                          QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeCurrentItem();
        quint32 myId = this->getMgr()->readSection<quint32>(0x00, 0x14);
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 youkaiId = this->read<quint32>(0x04 + 0x5C * i);
            if (form->youkaiCB->findData(youkaiId) >= 0) {
                this->write<quint32>(myId, 0x3C + 0x5C * i); // ownerId
            }
        }
        this->update();
    }
}

void YoukaiTab::fixIVs()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
                          tr("FIX_IV_WARNING"),
                          QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeCurrentItem();
        qsrand(QTime::currentTime().msec());
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 youkaiId = this->read<quint32>(0x04 + 0x5C * i);
            if (form->youkaiCB->findData(youkaiId) >= 0) {
                quint8 IV_Sum = 0;
                quint8 IV_HP = this->read<quint8>(0x40 + 0x5C * i);
                quint8 IV_Str = this->read<quint8>(0x41 + 0x5C * i);
                quint8 IV_Spr = this->read<quint8>(0x42 + 0x5C * i);
                quint8 IV_Def = this->read<quint8>(0x43 + 0x5C * i);
                quint8 IV_Spd = this->read<quint8>(0x44 + 0x5C * i);
                IV_Sum = IV_HP / 2 + IV_Str + IV_Spr + IV_Def + IV_Spd;
                int ivs[5] = {};
                if (IV_HP % 2 != 0 || IV_Sum != 40) {
                    for (int j = 0; j < 40; ++j) {
                        ivs[qrand() % 5]++;
                    }
                } else {
                    continue;
                }
                this->write<quint8>(ivs[0] * 2, 0x40 + 0x5C * i); // IV_HP
                this->write<quint8>(ivs[1], 0x41 + 0x5C * i); // IV_Str
                this->write<quint8>(ivs[2], 0x42 + 0x5C * i); // IV_Spr
                this->write<quint8>(ivs[3], 0x43 + 0x5C * i); // IV_Def
                this->write<quint8>(ivs[4], 0x44 + 0x5C * i); // IV_Spd
            }
        }
        this->update();
    }
}
