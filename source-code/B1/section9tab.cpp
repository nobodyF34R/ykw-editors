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

void Section9Tab::setLocale(SaveManager::GameLocale)
{
}

void Section9Tab::update()
{
    quint32 onidama = this->read<quint32>(0x0C);
    quint32 badge = this->read<quint32>(0x9C);
    ui->onidamaCB->setValue(onidama);
    ui->badgeSB->setValue(badge);
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
}

void Section9Tab::apply()
{
    this->write<quint32>(ui->onidamaCB->value(), 0x0C); // onidama
    this->write<quint32>(ui->badgeSB->value(), 0x9C); // badge
}
