#pragma execution_character_set("utf-8")

#include "youkaitab.h"
#include <QMessageBox>
#include <QTime>
#include <QtGlobal>

#include "dataeditor/biteditor.h"
#include "dataeditor/hexintegereditor.h"
#include "dataeditor/integereditor.h"
#include "dataeditor/listeditor.h"
#include "dataeditor/stringeditor.h"

YoukaiTab::YoukaiTab(SaveManager* mgr, QWidget* parent, int sectionId)
    : ListTab(mgr, parent, sectionId)
    , form(new Ui::YoukaiTabForm)
{
    QWidget* w = new QWidget(this);
    form->setupUi(w);
    ui->form->addWidget(w);

    this->setNum1Offset(0);
    this->setItemsCount(GameConfig::YoukaiCountMax);
    this->setItemSize(0x54);

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

    connect(form->youkaiNumApplyB, SIGNAL(clicked(bool)), SLOT(updateYoukaiCount()));
    connect(form->updateIDButton, SIGNAL(clicked(bool)), SLOT(updateID()));
    connect(form->fixIVButton, SIGNAL(clicked(bool)), SLOT(fixIVs()));
    connect(form->allPoseB, SIGNAL(clicked(bool)), SLOT(allWinPoses()));

    /* editors */
    ListEditor* youkaiE = new ListEditor(this, form->youkaiLabel, form->youkaiCB, 0x04, 32);
    this->setPrimaryEditor(youkaiE);
    this->editors.append(new IntegerEditor(this, form->num1Label, form->num1SB, 0x00, 16, false));
    this->editors.append(new IntegerEditor(this, form->num2Label, form->num2SB, 0x02, 16, false));
    this->editors.append(youkaiE);
    this->editors.append(new StringEditor(this, form->nicknameLabel, form->nicknameEdit, 0x08, 0x18));
    this->editors.append(new HexIntegerEditor(this, form->IDLabel, form->IDEdit, 0x30, 32));

    this->editors.append(new IntegerEditor(this, form->IV_HPLabel, form->IV_HPSB, 0x34, 8, false));
    this->editors.append(new IntegerEditor(this, form->IV_StrLabel, form->IV_StrSB, 0x35, 8, false));
    this->editors.append(new IntegerEditor(this, form->IV_SprLabel, form->IV_SprSB, 0x36, 8, false));
    this->editors.append(new IntegerEditor(this, form->IV_DefLabel, form->IV_DefSB, 0x37, 8, false));
    this->editors.append(new IntegerEditor(this, form->IV_SpdLabel, form->IV_SpdSB, 0x38, 8, false));

    this->editors.append(new IntegerEditor(this, form->SC_HPLabel, form->SC_HPSB, 0x39, 8, true));
    this->editors.append(new IntegerEditor(this, form->SC_StrLabel, form->SC_StrSB, 0x3A, 8, true));
    this->editors.append(new IntegerEditor(this, form->SC_SprLabel, form->SC_SprSB, 0x3B, 8, true));
    this->editors.append(new IntegerEditor(this, form->SC_DefLabel, form->SC_DefSB, 0x3C, 8, true));
    this->editors.append(new IntegerEditor(this, form->SC_SpdLabel, form->SC_SpdSB, 0x3D, 8, true));

    this->editors.append(new IntegerEditor(this, form->atkLVLabel, form->atkLVSB, 0x46, 8, false));
    this->editors.append(new IntegerEditor(this, form->inspiritLVLabel, form->inspiritLVSB, 0x47, 8, false));
    this->editors.append(new IntegerEditor(this, form->soultimateLVLabel, form->soultimateLVSB, 0x48, 8, false));

    this->editors.append(new IntegerEditor(this, form->levelLabel, form->levelSB, 0x49, 8, false));

    this->editors.append(new IntegerEditor(this, form->loafLabel, form->loafSB, 0x4C, 4, false, false));
    this->editors.append(new ListEditor(this, form->AILabel, form->AICB, 0x4C, 4, true));

    this->editors.append(new BitEditor(this, form->flag4CB, 0x4D, 4));
    this->editors.append(new BitEditor(this, form->flag5CB, 0x4D, 5));
    this->editors.append(new BitEditor(this, form->flag6CB, 0x4D, 6));
    this->editors.append(new BitEditor(this, form->flag7CB, 0x4D, 7));
}

YoukaiTab::~YoukaiTab()
{
    delete form;
}

void YoukaiTab::setButtonsEnabled(bool s)
{
    ListTab::setButtonsEnabled(s);
    form->youkaiNumApplyB->setEnabled(true);
    form->updateIDButton->setEnabled(true);
    form->fixIVButton->setEnabled(true);
    form->allPoseB->setEnabled(true);
}

void YoukaiTab::updateYoukaiCount()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("UPDATE_INDEX_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeSelectedItem();
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 num = this->read<quint32>(0x00 + 0x54 * i);
            this->getMgr()->writeSection<quint32>(num, 0x00 + 0x04 * i, 0x0A);
        }
        this->update();
    }
}

void YoukaiTab::updateID()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("UPDATE_ID_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeSelectedItem();
        quint32 myId = this->getMgr()->readSection<quint32>(0x00, 0x14);
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 youkaiId = this->read<quint32>(0x04 + 0x54 * i);
            if (form->youkaiCB->findData(youkaiId) >= 0) {
                this->write<quint32>(myId, 0x30 + 0x54 * i); // ownerId
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
        this->writeSelectedItem();
        qsrand(QTime::currentTime().msec());
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 youkaiId = this->read<quint32>(0x04 + 0x54 * i);
            if (form->youkaiCB->findData(youkaiId) >= 0) {
                quint8 IV_Sum = 0;
                quint8 IV_HP = this->read<quint8>(0x34 + 0x54 * i);
                quint8 IV_Str = this->read<quint8>(0x35 + 0x54 * i);
                quint8 IV_Spr = this->read<quint8>(0x36 + 0x54 * i);
                quint8 IV_Def = this->read<quint8>(0x37 + 0x54 * i);
                quint8 IV_Spd = this->read<quint8>(0x38 + 0x54 * i);
                IV_Sum = IV_HP / 2 + IV_Str + IV_Spr + IV_Def + IV_Spd;
                int ivs[5] = {};
                if (this->read<quint8>(0x4D + 0x54 * i) & (1 << 4)) {
                    ivs[0] = ivs[1] = ivs[2] = ivs[3] = ivs[4] = 8;
                } else if (IV_HP % 2 != 0 || IV_Sum != 40) {
                    for (int j = 0; j < 40; ++j) {
                        ivs[qrand() % 5]++;
                    }
                } else {
                    continue;
                }
                this->write<quint8>(ivs[0] * 2, 0x34 + 0x54 * i); // IV_HP
                this->write<quint8>(ivs[1], 0x35 + 0x54 * i); // IV_Str
                this->write<quint8>(ivs[2], 0x36 + 0x54 * i); // IV_Spr
                this->write<quint8>(ivs[3], 0x37 + 0x54 * i); // IV_Def
                this->write<quint8>(ivs[4], 0x38 + 0x54 * i); // IV_Spd
            }
        }
        this->update();
    }
}

void YoukaiTab::allWinPoses()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("ALL_WINPOSES_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeSelectedItem();
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 youkaiId = this->read<quint32>(0x04 + 0x54 * i);
            if (form->youkaiCB->findData(youkaiId) >= 0) {
                quint8 curr = this->read<quint16>(0x4B + 0x54 * i);
                this->write<quint8>(curr | 0xA8, 0x4B + 0x54 * i); // num1
            }
        }
        this->update();
    }
}
