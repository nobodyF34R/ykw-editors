#pragma execution_character_set("utf-8")

#include "section1tab.h"
#include "ui_section1tab.h"
#include <QMessageBox>

Section1Tab::Section1Tab(SaveManager* mgr, QWidget* parent, int sectionId)
    : Tab(mgr, parent, sectionId)
    , ui(new Ui::Section1Tab)
{
    ui->setupUi(this);
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(update()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(apply()));
    this->flags = new FlagCheckList(sectionId, 0x974, mgr);
    this->trophies = new TrophyCheckList(sectionId, 0xA54, mgr);
    ui->flagLayout->insertWidget(0, this->flags);
    ui->trophyLayout->insertWidget(0, this->trophies);
    connect(ui->flagCheckAll, SIGNAL(clicked(bool)), this->flags, SLOT(setAllChecked()));
    connect(ui->flagUncheckAll, SIGNAL(clicked(bool)), this->flags, SLOT(setAllUnchecked()));
    connect(ui->trophyCheckAll, SIGNAL(clicked(bool)), this->trophies, SLOT(setAllChecked()));
    connect(ui->trophyUncheckAll, SIGNAL(clicked(bool)), this->trophies, SLOT(setAllUnchecked()));
    connect(ui->legendResetButton, SIGNAL(clicked(bool)), this, SLOT(resetLegendary()));
    connect(ui->resetDaily, SIGNAL(clicked(bool)), this, SLOT(resetDailyEvents()));
}

Section1Tab::~Section1Tab()
{
    delete ui;
}

void Section1Tab::resetLegendary()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("RESET_LEGENDARY_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        this->write<quint8>(0, 0xA8C);
        this->write<quint8>(0, 0xA8D);
    }
}

void Section1Tab::resetDailyEvents()
{
    int ans = QMessageBox::question(this, tr("CONFIRM"),
        tr("RESET_DAILYEVENTS_WARNING"),
        QMessageBox::Ok | QMessageBox::Cancel, QMessageBox::Cancel);
    if (ans == QMessageBox::Ok) {
        for (int i = 0; i < 8; i++) {
            this->write<quint32>(0, 0xA94 + i * 4);
        }
    }
}

void Section1Tab::update()
{
    quint8 gashaRemaining = this->read<quint8>(0x284);
    quint8 yokaislots = this->read<quint8>(0x288);
    quint8 flag = this->read<quint8>(0x05) & noDeathFlag;
    ui->noDeathCB->setChecked(flag != 0);
    this->flags->update();
    this->trophies->update();
    ui->gashaRemainingCB->setValue(gashaRemaining);
    ui->yokaislotsSB->setValue(yokaislots);
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
    ui->flagCheckAll->setEnabled(true);
    ui->flagUncheckAll->setEnabled(true);
    ui->trophyCheckAll->setEnabled(true);
    ui->trophyUncheckAll->setEnabled(true);
    ui->legendResetButton->setEnabled(true);
    ui->resetDaily->setEnabled(true);
}

void Section1Tab::apply()
{
    quint8 flag = this->read<quint8>(0x5);
    if (ui->noDeathCB->isChecked()) {
        flag |= noDeathFlag;
    } else {
        flag &= ~noDeathFlag;
    }
    this->write<quint8>(flag, 0x05);

    this->write<quint8>(ui->gashaRemainingCB->value(), 0x284); // gashaRemaining
    this->write<quint8>(ui->yokaislotsSB->value(), 0x288); // yokaislots
    this->flags->apply();
    this->trophies->apply();
}
