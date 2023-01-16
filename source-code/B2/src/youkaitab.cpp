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
    this->setItemSize(0x4C);

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
    foreach (const dataentry_t& it, GameData::getInstance().getData("hackslash_technic")) {
        form->move1CB->addItem(it.second.value("name"), it.first);
        form->move2CB->addItem(it.second.value("name"), it.first);
        form->move3CB->addItem(it.second.value("name"), it.first);
    }
    form->move1CB->setCurrentIndex(-1);
    form->move2CB->setCurrentIndex(-1);
    form->move3CB->setCurrentIndex(-1);

    connect(form->youkaiNumApplyB, SIGNAL(clicked(bool)), SLOT(updateYoukaiCount()));
    connect(form->updateIDButton, SIGNAL(clicked(bool)), SLOT(updateID()));
    connect(form->fixIVButton, SIGNAL(clicked(bool)), SLOT(fixIVs()));
    connect(form->defaultAtkB, SIGNAL(clicked(bool)), SLOT(loadDefaultAttacks()));

    /* editors */
    ListEditor* youkaiE = new ListEditor(this, form->youkaiLabel, form->youkaiCB, 0x04, 32);
    this->setPrimaryEditor(youkaiE);
    this->editors.append(new IntegerEditor(this, form->num1Label, form->num1SB, 0x00, 16, false));
    this->editors.append(new IntegerEditor(this, form->num2Label, form->num2SB, 0x02, 16, false));
    this->editors.append(youkaiE);
    this->editors.append(new StringEditor(this, form->nicknameLabel, form->nicknameEdit, 0x08, 0x18));
    this->editors.append(new HexIntegerEditor(this, form->IDLabel, form->IDEdit, 0x3C, 32));

    this->editors.append(new IntegerEditor(this, form->IV_HPLabel, form->IV_HPSB, 0x40, 8, false));
    this->editors.append(new IntegerEditor(this, form->IV_StrLabel, form->IV_StrSB, 0x41, 8, false));
    this->editors.append(new IntegerEditor(this, form->IV_SprLabel, form->IV_SprSB, 0x42, 8, false));
    this->editors.append(new IntegerEditor(this, form->IV_DefLabel, form->IV_DefSB, 0x43, 8, false));
    this->editors.append(new IntegerEditor(this, form->IV_SpdLabel, form->IV_SpdSB, 0x44, 8, false));

    this->editors.append(new IntegerEditor(this, form->levelLabel, form->levelSB, 0x48, 8, false));

    this->editors.append(new ListEditor(this, form->move1Label, form->move1CB, 0x28, 32));
    this->editors.append(new ListEditor(this, form->move2Label, form->move2CB, 0x2C, 32));
    this->editors.append(new ListEditor(this, form->move3Label, form->move3CB, 0x30, 32));

    this->editors.append(new BitEditor(this, form->flag4CB, 0x4A, 0));
    this->editors.append(new BitEditor(this, form->flag5CB, 0x4A, 1));
    this->editors.append(new BitEditor(this, form->flag6CB, 0x4A, 2));
    this->editors.append(new BitEditor(this, form->flag7CB, 0x4A, 4));
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
    //    form->allPoseB->setEnabled(true);
    form->defaultAtkB->setEnabled(true);
}

void YoukaiTab::updateYoukaiCount()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("UPDATE_INDEX_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->writeSelectedItem();
        for (int i = 0; i < this->getItemsCount(); ++i) {
            quint32 num = this->read<quint32>(0x00 + 0x4C * i);
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
            quint32 youkaiId = this->read<quint32>(0x04 + 0x4C * i);
            if (form->youkaiCB->findData(youkaiId) >= 0) {
                this->write<quint32>(myId, 0x3C + 0x4C * i); // ownerId
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
            quint32 youkaiId = this->read<quint32>(0x04 + 0x4C * i);
            if (form->youkaiCB->findData(youkaiId) >= 0) {
                quint8 IV_Sum = 0;
                quint8 IV_HP = this->read<quint8>(0x40 + 0x4C * i);
                quint8 IV_Str = this->read<quint8>(0x41 + 0x4C * i);
                quint8 IV_Spr = this->read<quint8>(0x42 + 0x4C * i);
                quint8 IV_Def = this->read<quint8>(0x43 + 0x4C * i);
                quint8 IV_Spd = this->read<quint8>(0x44 + 0x4C * i);
                IV_Sum = IV_HP / 2 + IV_Str + IV_Spr + IV_Def + IV_Spd;
                int ivs[5] = {};
                if (this->read<quint8>(0x4A + 0x4C * i) & (1 << 1)) {
                    ivs[0] = ivs[1] = ivs[2] = ivs[3] = ivs[4] = 8;
                } else if (IV_HP % 2 != 0 || IV_Sum != 40) {
                    for (int j = 0; j < 40; ++j) {
                        ivs[qrand() % 5]++;
                    }
                } else {
                    continue;
                }
                this->write<quint8>(ivs[0] * 2, 0x40 + 0x4C * i); // IV_HP
                this->write<quint8>(ivs[1], 0x41 + 0x4C * i); // IV_Str
                this->write<quint8>(ivs[2], 0x42 + 0x4C * i); // IV_Spr
                this->write<quint8>(ivs[3], 0x43 + 0x4C * i); // IV_Def
                this->write<quint8>(ivs[4], 0x44 + 0x4C * i); // IV_Spd
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
            if (GameData::getInstance().getJSONObjectData("technic").contains(QString::number(youkaiId))) {
                QJsonArray technic = GameData::getInstance().getJSONObjectData("technic")[QString::number(youkaiId)].toArray();
                form->move1CB->setCurrentIndex(form->move1CB->findData(technic.at(0).toVariant().toUInt()));
                form->move2CB->setCurrentIndex(form->move2CB->findData(technic.at(1).toVariant().toUInt()));
                form->move3CB->setCurrentIndex(form->move3CB->findData(technic.at(2).toVariant().toUInt()));
            }
        }
    }
}
