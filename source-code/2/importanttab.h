#pragma execution_character_set("utf-8")

#ifndef IMPORTANTTAB_H
#define IMPORTANTTAB_H

#include <QWidget>
#include <QtCore>
#include <QCheckBox>

#include "listtab.h"
#include "gameconfig.h"
#include "gamedata.h"

#include "ui_importanttabform.h"

class ImportantTab : public ListTab, private Ui::ImportantTabForm
{
    Q_OBJECT

public:
    explicit ImportantTab(SaveManager *mgr, QWidget *parent=0, int sectionId=-1);
    ~ImportantTab();
public slots:
    void update();
    void loadItemAt(int row);
    void writeItemAt(int row);
    void loadCurrentItem();
    void writeCurrentItem();

private:
    Ui::ImportantTabForm *form;
};

#endif // IMPORTANTTAB_H
