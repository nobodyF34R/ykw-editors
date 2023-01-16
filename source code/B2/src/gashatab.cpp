#include "gashatab.h"
#include "ui_gashatab.h"

#include <QPushButton>
#include <algorithm>

GashaTab::GashaTab(SaveManager* mgr, QWidget* parent, int sectionId)
    : Tab(mgr, parent, sectionId)
    , ui(new Ui::GashaTab)
    , st(new GashaState())
{
    ui->setupUi(this);
    QJsonArray gashaArray = GameData::getInstance().getJSONArrayData("gashaData");
    int i = 0;
    ui->gashaTable->setHorizontalHeaderItem(0, new QTableWidgetItem(tr("NEXT_JAPAN")));
    ui->gashaTable->setHorizontalHeaderItem(1, new QTableWidgetItem(tr("NEXT_USA")));
    ui->gashaTable->setHorizontalHeaderItem(2, new QTableWidgetItem(tr("ADVANCE")));
    foreach (const QJsonValue& v, gashaArray) {
        ui->gashaTable->insertRow(ui->gashaTable->rowCount());
        // v.toObject()["id"].toInt() results signed integer
        quint32 id = v.toObject()["id"].toVariant().toUInt();

        QTableWidgetItem* item;
        if (id == 0) {
            item = new QTableWidgetItem(tr("TERROR_TIME"));
        } else if (id == 10) {
            item = new QTableWidgetItem(tr("GAMECOIN"));
        } else {
            const QList<dataentry_t> d = GameData::getInstance().getData("consume");
            QList<dataentry_t>::const_iterator it = std::find_if(d.constBegin(), d.constEnd(), [=](const dataentry_t& d) { return d.first == id; });
            if (it == d.constEnd()) {
                item = new QTableWidgetItem(QString("%1").arg(id));
            } else {
                item = new QTableWidgetItem((*it).second.value("name"));
            }
        }
        ui->gashaTable->setVerticalHeaderItem(i, item);

        GashaLot* gl = new GashaLot(v.toObject(), this->st);
        ui->gashaTable->setItem(i, 0, new QTableWidgetItem(QString()));
        ui->gashaTable->setItem(i, 1, new QTableWidgetItem(QString()));

        QPushButton* pb = new QPushButton(tr("ADVANCE"));
        pb->setEnabled(false);
        connect(pb, &QPushButton::clicked, [=] {
            gl->advance();
            this->updateLots();
        });
        ui->gashaTable->setCellWidget(i, 2, pb);
        this->lots.append(gl);
        i++;
    }
    ui->gashaTable->setRowCount(i);
    connect(ui->applyButton, SIGNAL(clicked(bool)), this, SLOT(apply()));
    connect(ui->resetButton, SIGNAL(clicked(bool)), this, SLOT(update()));
}

GashaTab::~GashaTab()
{
    delete ui;
    foreach (GashaLot* l, this->lots) {
        delete l;
    }
    delete st;
}

void GashaTab::updateLots()
{
    int i = 0;
    foreach (GashaLot* l, this->lots) {
        ui->gashaTable->item(i, 0)->setText(l->lotName(false));
        ui->gashaTable->item(i, 1)->setText(l->lotName(true));
        ui->gashaTable->cellWidget(i, 2)->setEnabled(true);
        i++;
    }
}

void GashaTab::update()
{
    ui->applyButton->setEnabled(true);
    ui->resetButton->setEnabled(true);
    this->st->setState(this->getSectionData());
    this->updateLots();
}

void GashaTab::apply()
{
    this->setSectionData(this->st->stateData());
    this->update();
}
