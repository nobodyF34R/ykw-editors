#pragma execution_character_set("utf-8")

#include "medalliumtab.h"
#include "ui_medalliumtab.h"

MedalliumTab::MedalliumTab(SaveManager *mgr, QWidget *parent, int sectionId) :
    Tab(mgr, parent, sectionId),
    ui(new Ui::MedalliumTab)
{
    ui->setupUi(this);
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(update()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(apply()));
    /* offsets are for shin'uchi */
    this->seen = new YoukaiCheckList(sectionId, 0x408, mgr);
    this->befriended = new YoukaiCheckList(sectionId, 0x448, mgr);
    this->youkaiCam = new YoukaiCheckList(sectionId, 0x5E8, mgr);
    ui->seenLayout->insertWidget(0, this->seen);
    ui->befriendedLayout->insertWidget(0, this->befriended);
    ui->youkaiCamLayout->insertWidget(0, this->youkaiCam);
    connect(ui->seenCheckAll, SIGNAL(clicked(bool)), this->seen, SLOT(setAllChecked()));
    connect(ui->seenUncheckAll, SIGNAL(clicked(bool)), this->seen, SLOT(setAllUnchecked()));
    connect(ui->befriendedCheckAll, SIGNAL(clicked(bool)), this->befriended, SLOT(setAllChecked()));
    connect(ui->befriendedUncheckAll, SIGNAL(clicked(bool)), this->befriended, SLOT(setAllUnchecked()));
    connect(ui->youkaiCamCheckAll, SIGNAL(clicked(bool)), this->youkaiCam, SLOT(setAllChecked()));
    connect(ui->youkaiCamUncheckAll, SIGNAL(clicked(bool)), this->youkaiCam, SLOT(setAllUnchecked()));
}

MedalliumTab::~MedalliumTab()
{
    delete ui;
}

void MedalliumTab::update()
{
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
    ui->seenCheckAll->setEnabled(true);
    ui->seenUncheckAll->setEnabled(true);
    ui->befriendedCheckAll->setEnabled(true);
    ui->befriendedUncheckAll->setEnabled(true);
    ui->youkaiCamCheckAll->setEnabled(true);
    ui->youkaiCamUncheckAll->setEnabled(true);

    if (this->getMgr()->getFlags() & GameConfig::GameTypeFlags::IS_SHINNUCHI) {
        this->seen->setOffset(0x408);
        this->befriended->setOffset(0x448);
        this->youkaiCam->setOffset(0x4C8);
        ui->befriendedGB->setTitle(tr("BEFRIENDED"));
        ui->youkaiCamGB->setTitle(tr("YO-KAI_CAM"));
    } else {
        this->seen->setOffset(0x400);
        this->befriended->setOffset(0x440);
        this->youkaiCam->setOffset(0x5EC);
        ui->befriendedGB->setTitle(tr("BEFRIENDED_BS"));
        ui->youkaiCamGB->setTitle(tr("BEFRIENDED_FS"));
    }

    this->seen->update();
    this->befriended->update();
    this->youkaiCam->update();
}

void MedalliumTab::apply()
{
    this->seen->apply();
    this->befriended->apply();
    this->youkaiCam->apply();
}
