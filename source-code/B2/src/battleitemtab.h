#ifndef BATTLEITEMTAB_H
#define BATTLEITEMTAB_H

#include <QCheckBox>
#include <QWidget>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_battleitemtabform.h"

class BattleItemTab : public ListTab, private Ui::BattleItemTabForm {
    Q_OBJECT

public:
    explicit BattleItemTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~BattleItemTab();
public slots:
    virtual void update();

private:
    Ui::BattleItemTabForm* form;
};

#endif // BATTLEITEMTAB_H
