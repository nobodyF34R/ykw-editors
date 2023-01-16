#ifndef GASHATAB_H
#define GASHATAB_H

#include "gamedata.h"
#include "gashalot.h"
#include "gashastate.h"
#include "tab.h"
#include <QWidget>

namespace Ui {
class GashaTab;
}

class GashaTab : public Tab {
    Q_OBJECT

public:
    explicit GashaTab(SaveManager* mgr, QWidget* parent, int sectionId = -1);
    ~GashaTab();
    void updateLots();
public slots:
    void update();
    void apply();

private:
    Ui::GashaTab* ui;
    QVector<GashaLot*> lots;
    GashaState* st;
};

#endif // GASHATAB_H
