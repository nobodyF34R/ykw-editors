#include "section1tab.h"
#include "ui_section1tab.h"

Section1Tab::Section1Tab(SaveManager* mgr, QWidget* parent, int sectionId)
    : Tab(mgr, parent, sectionId)
    , ui(new Ui::Section1Tab)
{
    ui->setupUi(this);
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(update()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(apply()));
}

Section1Tab::~Section1Tab()
{
    delete ui;
}

void Section1Tab::setLocale(SaveManager::GameLocale)
{
}

void Section1Tab::update()
{
    quint8 gashaRemaining = this->read<quint8>(0x142);
    quint8 gashaMax = this->read<quint8>(0x143);
    ui->gashaRemainingCB->setValue(gashaRemaining);
    ui->gashaMaxCB->setValue(gashaMax);
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
}

void Section1Tab::apply()
{
    this->write<quint8>(ui->gashaRemainingCB->value(), 0x142); // gashaRemaining
    this->write<quint8>(ui->gashaMaxCB->value(), 0x143); // gashaMax
}
