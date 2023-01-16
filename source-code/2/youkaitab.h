#pragma execution_character_set("utf-8")

#ifndef YOUKAITAB_H
#define YOUKAITAB_H

#include <QtCore>
#include <QCheckBox>

#include "listtab.h"
#include "gameconfig.h"
#include "gamedata.h"

#include "ui_youkaitabform.h"

class YoukaiTab : public ListTab
{
    Q_OBJECT

public:
    explicit YoukaiTab(SaveManager *mgr, QWidget *parent=0, int sectionId=-1);
    ~YoukaiTab();
public slots:
    void update();
    void loadItemAt(int row);
    void writeItemAt(int row);
    void loadCurrentItem();
    void writeCurrentItem();
    void updateYoukaiCount();
    void updateID();
    void fixIVs();

private:
    Ui::YoukaiTabForm *form;
    QList<QCheckBox *> flagCBs;
};

#endif // YOUKAITAB_H
