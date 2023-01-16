#include <cmath>

#include "section242tab.h"
#include "ui_section242tab.h"
#include <QMessageBox>

Section242Tab::Section242Tab(SaveManager* mgr, QWidget* parent, int sectionId)
    : Tab(mgr, parent, sectionId)
    , ui(new Ui::Section242Tab)
{
    ui->setupUi(this);
    /* intert items into combobox */
    foreach (const dataentry_t& it, GameData::getInstance().getData("map")) {
        ui->mapCB->addItem(it.second.value("name"), it.first);
    }
    foreach (const dataentry_t& it, GameData::getInstance().getData("map")) {
        ui->mapFCB->addItem(it.second.value("name"), it.first);
    }
    ui->mapCB->setCurrentIndex(-1);
    ui->mapFCB->setCurrentIndex(-1);
    connect(ui->resetButton, SIGNAL(clicked(bool)), SLOT(update()));
    connect(ui->applyButton, SIGNAL(clicked(bool)), SLOT(apply()));
}

Section242Tab::~Section242Tab()
{
    delete ui;
}

void Section242Tab::update()
{
    quint32 wantedPoint = this->read<quint32>(0x54);
    quint32 mapId = this->read<quint32>(0x128);
    quint32 mapFId = this->read<quint32>(0x188);
    ui->WPCB->setValue(wantedPoint);
    ui->mapCB->setCurrentIndex(ui->mapCB->findData(mapId));
    ui->mapFCB->setCurrentIndex(ui->mapFCB->findData(mapFId));

    float x_m = this->read<float>(0x118);
    float y_m = this->read<float>(0x120);
    float z_m = this->read<float>(0x11C);
    float x_f = this->read<float>(0x178);
    float y_f = this->read<float>(0x180);
    float z_f = this->read<float>(0x17C);

    ui->posXSB->setValue(x_m);
    ui->posYSB->setValue(y_m);
    ui->posZSB->setValue(z_m);
    ui->posXFSB->setValue(x_f);
    ui->posYFSB->setValue(y_f);
    ui->posZFSB->setValue(z_f);

    quint32 frame = this->getMgr()->readSection<quint32>(0x8, 0x2);
    ui->timeSB->setValue(frameToPos(frame));

    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
}

void Section242Tab::apply()
{
    if (ui->mapCB->currentIndex() >= 0) {
        this->write<quint32>(
            ui->mapCB->currentData().value<quint32>(),
            0x128);
    }
    if (ui->mapFCB->currentIndex() >= 0) {
        this->write<quint32>(
            ui->mapFCB->currentData().value<quint32>(),
            0x188);
    }

    this->write<quint32>(ui->WPCB->value(), 0x54);
    this->write<float>(ui->posXSB->value(), 0x118);
    this->write<float>(ui->posYSB->value(), 0x120);
    this->write<float>(ui->posZSB->value(), 0x11C);
    this->write<float>(ui->posXFSB->value(), 0x178);
    this->write<float>(ui->posYFSB->value(), 0x180);
    this->write<float>(ui->posZFSB->value(), 0x17C);

    float pos = static_cast<float>(ui->timeSB->value());
    this->getMgr()->writeSection<quint32>(posToFrame(pos), 0x8, 0x2);

    this->update();
}

float Section242Tab::frameToPos(quint32 frame)
{
    // 60.0 frames per second
    // 60 seconds per minute
    // 6 minutes per "pos"
    return std::fmod(frame / 60.0 / 60.0 / 6.0 + 9, 12);
}

quint32 Section242Tab::posToFrame(float pos)
{
    pos = std::fmod(pos + 3, 12);
    return static_cast<quint32>(pos * 6.0 * 60.0 * 60.0);
}
