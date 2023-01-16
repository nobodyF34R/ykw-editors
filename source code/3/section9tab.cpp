#pragma execution_character_set("utf-8")

#include "section9tab.h"
#include "ui_section9tab.h"

Section9Tab::Section9Tab(SaveManager* mgr, QWidget* parent, int sectionId)
    : Tab(mgr, parent, sectionId)
    , ui(new Ui::Section9Tab)
{
    ui->setupUi(this);
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(update()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(apply()));
}

Section9Tab::~Section9Tab()
{
    delete ui;
}

void Section9Tab::update()
{
    quint32 money = this->read<quint32>(0x0);
    quint32 JP = this->read<quint32>(0x4);
    quint32 GP = this->read<quint32>(0x8);
    ui->moneyCB->setValue(money);
    ui->JPCB->setValue(JP);
    ui->GPCB->setValue(GP);
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
}

void Section9Tab::apply()
{
    this->write<quint32>(ui->moneyCB->value(), 0x00); // money
    this->write<quint32>(ui->JPCB->value(), 0x04); // JP
    this->write<quint32>(ui->GPCB->value(), 0x08); // GP
}
