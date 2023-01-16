#pragma execution_character_set("utf-8")

#include "section1tab.h"
#include "ui_section1tab.h"

Section1Tab::Section1Tab(SaveManager *mgr, QWidget *parent, int sectionId) :
    Tab(mgr, parent, sectionId),
    ui(new Ui::Section1Tab)
{
    ui->setupUi(this);
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(update()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(apply()));
}

Section1Tab::~Section1Tab()
{
    delete ui;
}

void Section1Tab::update()
{
    quint8 gashaRemaining = this->read<quint8>(0x150);
    ui->gashaRemainingCB->setValue(gashaRemaining);
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
}

void Section1Tab::apply()
{
    this->write<quint8>(ui->gashaRemainingCB->value(), 0x150); // gashaRemaining
}
