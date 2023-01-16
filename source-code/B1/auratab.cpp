#include "auratab.h"
#include "ui_auratab.h"

AuraTab::AuraTab(SaveManager* mgr, QWidget* parent, int sectionId)
    : Tab(mgr, parent, sectionId)
    , ui(new Ui::AuraTab)
{
    ui->setupUi(this);
    /* intert items into combobox */
    foreach (const dataentry_t& it, GameData::getInstance().getData("aura")) {
        ui->auraCB->addItem(it.second.value("name"), it.first);
    }

    ui->auraCB->setCurrentIndex(-1);
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(update()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(apply()));
}

AuraTab::~AuraTab()
{
    delete ui;
}

void AuraTab::setLocale(SaveManager::GameLocale)
{
}

void AuraTab::update()
{
    quint16 num1 = this->read<quint16>(0x00);
    quint16 num2 = this->read<quint16>(0x02);
    quint32 aura = this->read<quint32>(0x04);
    ui->num1SB->setValue(num1);
    ui->num2SB->setValue(num2);
    ui->auraCB->setCurrentIndex(ui->auraCB->findData(aura));
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
}

void AuraTab::apply()
{
    this->write<quint16>(ui->num1SB->value(), 0x00); // num1
    this->write<quint16>(ui->num2SB->value(), 0x02); // num2
    if (ui->auraCB->currentIndex() >= 0) {
        this->write<quint32>(
            ui->auraCB->currentData().value<quint32>(),
            0x04); // aura
    }
}
