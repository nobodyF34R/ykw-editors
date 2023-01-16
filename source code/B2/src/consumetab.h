#ifndef CONSUMETAB_H
#define CONSUMETAB_H

#include <QCheckBox>
#include <QWidget>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_consumetabform.h"

class ConsumeTab : public ListTab, private Ui::ConsumeTabForm {
    Q_OBJECT

public:
    explicit ConsumeTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~ConsumeTab();
public slots:
    virtual void update();

private:
    Ui::ConsumeTabForm* form;
};

#endif // CONSUMETAB_H
