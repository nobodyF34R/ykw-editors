#ifndef YOUKAITAB_H
#define YOUKAITAB_H

#include <QCheckBox>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_youkaitabform.h"

class YoukaiTab : public ListTab, private Ui::YoukaiTabForm {
    Q_OBJECT

public:
    explicit YoukaiTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~YoukaiTab();
    void setButtonsEnabled(bool s) override;
public slots:
    void updateYoukaiCount();
    void updateID();
    void fixIVs();
    void loadDefaultAttacks();

private:
    Ui::YoukaiTabForm* form;
};

#endif // YOUKAITAB_H
