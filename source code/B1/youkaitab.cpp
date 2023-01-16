#include "youkaitab.h"
#include <QMessageBox>
#include <QTime>
#include <QtGlobal>

YoukaiTab::YoukaiTab(SaveManager* mgr, QWidget* parent, int sectionId)
    : ListTab(mgr, parent, sectionId)
    , form(new Ui::YoukaiTabForm)
    , nicknameLen(nicknameLenJP)
{
    QWidget* w = new QWidget(this);
    form->setupUi(w);
    ui->form->addWidget(w);

    this->setNum1Offset(0x0);
    this->setItemSize(itemSizeJP);

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
    foreach (const dataentry_t& it, GameData::getInstance().getData("technic")) {
        form->move1CB->addItem(it.second.value("name"), it.first);
        form->move2CB->addItem(it.second.value("name"), it.first);
        form->move3CB->addItem(it.second.value("name"), it.first);
    }
    form->youkaiCB->setCurrentIndex(-1);
    form->move1CB->setCurrentIndex(-1);
    form->move2CB->setCurrentIndex(-1);
    form->move3CB->setCurrentIndex(-1);
    this->flagCBs.append(form->flag0CB);
    this->flagCBs.append(form->flag1CB);
    this->flagCBs.append(form->flag2CB);
    this->flagCBs.append(form->flag3CB);
    this->flagCBs.append(form->flag4CB);
    this->flagCBs.append(form->flag5CB);
    this->flagCBs.append(form->flag6CB);
    this->flagCBs.append(form->flag7CB);
    connect(ui->listWidget, SIGNAL(currentRowChanged(int)), SLOT(loadItemAt(int)));
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(loadCurrentItem()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(writeCurrentItem()));
    connect(form->youkaiNumApplyB, SIGNAL(clicked(bool)), SLOT(updateYoukaiCount()));
    connect(form->updateIDButton, SIGNAL(clicked(bool)), SLOT(updateID()));
    connect(form->fixIVButton, SIGNAL(clicked(bool)), SLOT(fixIVs()));
    connect(form->defaultAtkB, SIGNAL(clicked(bool)), SLOT(loadDefaultAttacks()));
}

YoukaiTab::~YoukaiTab()
{
    delete form;
}

void YoukaiTab::setLocale(SaveManager::GameLocale locale)
{
    switch (locale) {
    case SaveManager::GameLocale::JP:
        this->nicknameLen = nicknameLenJP;
        this->setItemSize(itemSizeJP);
        break;
    case SaveManager::GameLocale::NONJP:
        this->nicknameLen = nicknameNONJP;
        this->setItemSize(itemSizeNONJP);
        break;
    }

    // adjust item counts
    while (ui->listWidget->count() < this->getItemsCount()) {
        ui->listWidget->addItem(QString(""));
    }
    while (ui->listWidget->count() > this->getItemsCount()) {
        ui->listWidget->takeItem(0);
    }
}

void YoukaiTab::updateList()
{
    for (int i = 0; i < this->getItemsCount(); ++i) {
        quint32 youkaiId = this->read<quint32>(0x04 + this->getItemSize() * i);
        int itemIndex = form->youkaiCB->findData(youkaiId);
        if (itemIndex >= 0) {
            ui->listWidget->item(i)->setText(
                form->youkaiCB->itemText(itemIndex));
        } else {
            ui->listWidget->item(i)->setText(tr("(不明)"));
        }
    }
    this->setButtonsEnabled(true);
    form->youkaiNumApplyB->setEnabled(true);
    form->updateIDButton->setEnabled(true);
    form->fixIVButton->setEnabled(true);
    form->defaultAtkB->setEnabled(true);
    if (ui->listWidget->currentRow() < 0) {
        ui->listWidget->setCurrentRow(0);
    }
    this->loadCurrentItem();
}

void YoukaiTab::loadItemAt(int row)
{
    if (row >= 0 && row < this->getItemsCount()) {
        /* 0x08 is for header */
        quint16 num1 = this->read<quint16>(0x00 + this->getItemSize() * row);
        quint16 num2 = this->read<quint16>(0x02 + this->getItemSize() * row);
        quint32 youkaiId = this->read<quint32>(0x04 + this->getItemSize() * row);
        QString nickname = this->readString(0x08 + this->getItemSize() * row, this->nicknameLen - 1);
        quint32 move1 = this->read<quint32>(0x08 + this->nicknameLen + 0x08 + this->getItemSize() * row);
        quint32 move2 = this->read<quint32>(0x08 + this->nicknameLen + 0x0C + this->getItemSize() * row);
        quint32 move3 = this->read<quint32>(0x08 + this->nicknameLen + 0x10 + this->getItemSize() * row);
        qint32 expPoint = this->read<qint32>(0x08 + this->nicknameLen + 0x14 + this->getItemSize() * row);
        quint32 ownerId = this->read<quint32>(0x08 + this->nicknameLen + 0x18 + this->getItemSize() * row);
        quint8 IV_HP = this->read<quint8>(0x08 + this->nicknameLen + 0x1C + this->getItemSize() * row);
        quint8 IV_Str = this->read<quint8>(0x08 + this->nicknameLen + 0x1D + this->getItemSize() * row);
        quint8 IV_Spr = this->read<quint8>(0x08 + this->nicknameLen + 0x1E + this->getItemSize() * row);
        quint8 IV_Def = this->read<quint8>(0x08 + this->nicknameLen + 0x1F + this->getItemSize() * row);
        quint16 unk1 = this->read<quint16>(0x08 + this->nicknameLen + 0x20 + this->getItemSize() * row);
        quint16 unk2 = this->read<quint16>(0x08 + this->nicknameLen + 0x22 + this->getItemSize() * row);
        quint8 flags = this->read<quint8>(0x08 + this->nicknameLen + 0x24 + this->getItemSize() * row);
        quint8 level = this->read<quint8>(0x08 + this->nicknameLen + 0x25 + this->getItemSize() * row);
        form->num1SB->setValue(num1);
        form->num2SB->setValue(num2);
        form->nicknameEdit->setText(nickname);
        form->expSB->setValue(expPoint);
        form->IDEdit->setText(QString::number(ownerId, 16));
        form->IV_HPSB->setValue(IV_HP);
        form->IV_StrSB->setValue(IV_Str);
        form->IV_SprSB->setValue(IV_Spr);
        form->IV_DefSB->setValue(IV_Def);
        form->unk1SB->setValue(unk1);
        form->unk2SB->setValue(unk2);
        form->levelSB->setValue(level);

        for (QList<QCheckBox*>::const_iterator it = this->flagCBs.constBegin();
             it != this->flagCBs.constEnd();
             ++it) {
            if ((1 << (it - this->flagCBs.constBegin())) & flags) {
                (*it)->setChecked(true);
            } else {
                (*it)->setChecked(false);
            }
        }
        /* load Yo-kai */
        form->youkaiCB->setCurrentIndex(form->youkaiCB->findData(youkaiId));
        /* load technic */
        form->move1CB->setCurrentIndex(form->move1CB->findData(move1));
        form->move2CB->setCurrentIndex(form->move2CB->findData(move2));
        form->move3CB->setCurrentIndex(form->move3CB->findData(move3));
    }
}

void YoukaiTab::writeItemAt(int row)
{
    quint8 flag = 0;
    for (QList<QCheckBox*>::const_iterator it = this->flagCBs.constBegin();
         it != this->flagCBs.constEnd();
         ++it) {
        if ((*it)->isChecked()) {
            flag |= (1 << (it - this->flagCBs.constBegin()));
        }
    }

    if (row >= 0 && row < this->getItemsCount()) {
        this->write<quint16>(form->num1SB->value(), 0x00 + this->getItemSize() * row); // num1
        this->write<quint16>(form->num2SB->value(), 0x02 + this->getItemSize() * row); // num2
        if (form->youkaiCB->currentIndex() >= 0) {
            this->write<quint32>(
                form->youkaiCB->currentData().value<quint32>(),
                0x04 + this->getItemSize() * row); // youkaiId
        }
        this->writeString(form->nicknameEdit->text(), 0x08 + this->getItemSize() * row, this->nicknameLen - 1); // nickname
        if (form->move1CB->currentIndex() >= 0) {
            this->write<quint32>(
                form->move1CB->currentData().value<quint32>(),
                0x08 + this->nicknameLen + 0x08 + this->getItemSize() * row); // move1
        }
        if (form->move2CB->currentIndex() >= 0) {
            this->write<quint32>(
                form->move2CB->currentData().value<quint32>(),
                0x08 + this->nicknameLen + 0x0C + this->getItemSize() * row); // move2
        }
        if (form->move3CB->currentIndex() >= 0) {
            this->write<quint32>(
                form->move3CB->currentData().value<quint32>(),
                0x08 + this->nicknameLen + 0x10 + this->getItemSize() * row); // move3
        }
        this->write<qint32>(form->expSB->value(), 0x08 + this->nicknameLen + 0x14 + this->getItemSize() * row); // expPoint
        this->write<quint32>(form->IDEdit->text().toUInt(0, 16), 0x08 + this->nicknameLen + 0x18 + this->getItemSize() * row); // ownerId
        this->write<quint8>(form->IV_HPSB->value(), 0x08 + this->nicknameLen + 0x1C + this->getItemSize() * row); // IV_HP
        this->write<quint8>(form->IV_StrSB->value(), 0x08 + this->nicknameLen + 0x1D + this->getItemSize() * row); // IV_Str
        this->write<quint8>(form->IV_SprSB->value(), 0x08 + this->nicknameLen + 0x1E + this->getItemSize() * row); // IV_Spr
        this->write<quint8>(form->IV_DefSB->value(), 0x08 + this->nicknameLen + 0x1F + this->getItemSize() * row); // IV_Def
        this->write<quint16>(form->unk1SB->value(), 0x08 + this->nicknameLen + 0x20 + this->getItemSize() * row); // unk1
        this->write<quint16>(form->unk2SB->value(), 0x08 + this->nicknameLen + 0x22 + this->getItemSize() * row); // unk2
        this->write<quint8>(flag, 0x08 + this->nicknameLen + 0x24 + this->getItemSize() * row); // flags
        this->write<quint8>(form->levelSB->value(), 0x08 + this->nicknameLen + 0x25 + this->getItemSize() * row); // level
    }

    /* update */
    this->loadItemAt(row);
    quint32 youkaiId = form->youkaiCB->currentData().value<quint32>();
    int itemIndex = form->youkaiCB->findData(youkaiId);
    if (itemIndex >= 0) {
        ui->listWidget->item(row)->setText(
            form->youkaiCB->itemText(itemIndex));
    } else {
        ui->listWidget->item(row)->setText(tr("(不明)"));
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
    int ans = QMessageBox::question(this, tr("確認"),
        tr("妖怪番号を更新します。追加した妖怪が一覧に出てこないときに使用してください。"
           "セクション10の領域が変更され、直ちに適用されます。"
           "この操作によって、セーブデータが破壊される可能性があります。"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeCurrentItem();
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 num = this->read<quint32>(0x00 + this->getItemSize() * i);
            this->getMgr()->writeSection<quint32>(num, 0x00 + 0x04 * i, 0x0A);
        }
        this->update();
    }
}

void YoukaiTab::updateID()
{
    int ans = QMessageBox::question(this, tr("確認"),
        tr("全ての妖怪のIDを自分のIDに書き換えます。"
           "セクション7の領域が変更され、直ちに適用されます。"
           "この操作によって、セーブデータが破壊される可能性があります。"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeCurrentItem();
        quint32 myId = this->getMgr()->readSection<quint32>(0x00, 0x12);
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 youkaiId = this->read<quint32>(0x04 + this->getItemSize() * i);
            if (form->youkaiCB->findData(youkaiId) >= 0) {
                this->write<quint32>(myId, 0x08 + this->nicknameLen + 0x18 + this->getItemSize() * i); // ownerId
            }
        }
        this->update();
    }
}

void YoukaiTab::fixIVs()
{
    int ans = QMessageBox::question(this, tr("確認"),
        tr("個体値が不正な妖怪の個体値を修正します。"
           "新たな個体値はランダムで決定されます。"
           "この操作によって、セーブデータが破壊される可能性があります。"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeCurrentItem();
        qsrand(QTime::currentTime().msec());
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 youkaiId = this->read<quint32>(0x04 + this->getItemSize() * i);
            if (form->youkaiCB->findData(youkaiId) >= 0) {
                quint8 IV_Sum = 0;
                quint8 IV_HP = this->read<quint8>(0x08 + this->nicknameLen + 0x1C + this->getItemSize() * i);
                quint8 IV_Str = this->read<quint8>(0x08 + this->nicknameLen + 0x1D + this->getItemSize() * i);
                quint8 IV_Spr = this->read<quint8>(0x08 + this->nicknameLen + 0x1E + this->getItemSize() * i);
                quint8 IV_Def = this->read<quint8>(0x08 + this->nicknameLen + 0x1F + this->getItemSize() * i);
                IV_Sum = IV_HP / 2 + IV_Str + IV_Spr + IV_Def;
                int ivs[4] = {};
                if (IV_HP % 2 != 0 || IV_Sum != 40) {
                    for (int j = 0; j < 40; ++j) {
                        ivs[qrand() % 4]++;
                    }
                } else if (this->read<quint8>(0x08 + this->nicknameLen + 0x24 + this->getItemSize() * i) & (1 << 1)) {
                    ivs[0] = ivs[1] = ivs[2] = ivs[3] = 10;
                } else {
                    continue;
                }
                this->write<quint8>(ivs[0] * 2, 0x08 + this->nicknameLen + 0x1C + this->getItemSize() * i); // IV_HP
                this->write<quint8>(ivs[1], 0x08 + this->nicknameLen + 0x1D + this->getItemSize() * i); // IV_Str
                this->write<quint8>(ivs[2], 0x08 + this->nicknameLen + 0x1E + this->getItemSize() * i); // IV_Spr
                this->write<quint8>(ivs[3], 0x08 + this->nicknameLen + 0x1F + this->getItemSize() * i); // IV_Def
            }
        }
        this->update();
    }
}

void YoukaiTab::loadDefaultAttacks()
{
    int row;
    if ((row = ui->listWidget->currentRow()) >= 0) {
        if (form->youkaiCB->currentIndex() >= 0) {
            quint32 youkaiId = form->youkaiCB->currentData().value<quint32>();
            if (GameData::getInstance().getJSONData("technic").contains(QString::number(youkaiId))) {
                QJsonArray technic = GameData::getInstance().getJSONData("technic")[QString::number(youkaiId)].toArray();
                form->move1CB->setCurrentIndex(form->move1CB->findData(technic.at(0).toVariant().toUInt()));
                form->move2CB->setCurrentIndex(form->move2CB->findData(technic.at(1).toVariant().toUInt()));
                form->move3CB->setCurrentIndex(form->move3CB->findData(technic.at(2).toVariant().toUInt()));
            }
        }
    }
}
