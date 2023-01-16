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
    /* intert items into list */
    this->seen = new YoukaiCheckList(sectionId, 0x400, mgr);
    this->befriended = new YoukaiCheckList(sectionId, 0x420, mgr);
    this->youkaiCam = new YoukaiCheckList(sectionId, 0x460, mgr);
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
    this->seen->update();
    this->befriended->update();
    this->youkaiCam->update();
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
    ui->seenCheckAll->setEnabled(true);
    ui->seenUncheckAll->setEnabled(true);
    ui->befriendedCheckAll->setEnabled(true);
    ui->befriendedUncheckAll->setEnabled(true);
    ui->youkaiCamCheckAll->setEnabled(true);
    ui->youkaiCamUncheckAll->setEnabled(true);
}

void MedalliumTab::apply()
{
    this->seen->apply();
    this->befriended->apply();
    this->youkaiCam->apply();
}
