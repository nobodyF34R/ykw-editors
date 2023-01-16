#pragma execution_character_set("utf-8")

#ifndef BUSTERS_HIDDEN_TREASURE_TAB_H
#define BUSTERS_HIDDEN_TREASURE_TAB_H

#include <QCheckBox>
#include <QWidget>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_busters_hiddentreasuretabform.h"

class BustersHiddenTreasureTab : public ListTab, private Ui::BustersHiddenTreasureTabForm {
    Q_OBJECT

public:
    explicit BustersHiddenTreasureTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~BustersHiddenTreasureTab();

private:
    Ui::BustersHiddenTreasureTabForm* form;
};

#endif // BUSTERS_HIDDEN_TREASURE_TAB_H
