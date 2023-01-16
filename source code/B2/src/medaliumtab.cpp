#include "medaliumtab.h"
#include "ui_medaliumtab.h"

MedaliumTab::MedaliumTab(SaveManager* mgr, QWidget* parent, int sectionId, int offset)
    : Tab(mgr, parent, sectionId)
    , ui(new Ui::MedaliumTab)
{
    ui->setupUi(this);
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(update()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(apply()));
    /* intert items into list */
    this->seen = new YoukaiCheckList(sectionId, offset, mgr);
    this->befriended = new YoukaiCheckList(sectionId, offset + 0x80, mgr);
    ui->seenLayout->insertWidget(0, this->seen);
    ui->befriendedLayout->insertWidget(0, this->befriended);
    connect(ui->seenCheckAll, SIGNAL(clicked(bool)), this->seen, SLOT(setAllChecked()));
    connect(ui->seenUncheckAll, SIGNAL(clicked(bool)), this->seen, SLOT(setAllUnchecked()));
    connect(ui->befriendedCheckAll, SIGNAL(clicked(bool)), this->befriended, SLOT(setAllChecked()));
    connect(ui->befriendedUncheckAll, SIGNAL(clicked(bool)), this->befriended, SLOT(setAllUnchecked()));
}

MedaliumTab::~MedaliumTab()
{
    delete ui;
}

void MedaliumTab::update()
{
    this->seen->update();
    this->befriended->update();
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
    ui->seenCheckAll->setEnabled(true);
    ui->seenUncheckAll->setEnabled(true);
    ui->befriendedCheckAll->setEnabled(true);
    ui->befriendedUncheckAll->setEnabled(true);
}

void MedaliumTab::apply()
{
    this->seen->apply();
    this->befriended->apply();
}
