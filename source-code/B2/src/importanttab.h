#ifndef IMPORTANTTAB_H
#define IMPORTANTTAB_H

#include <QCheckBox>
#include <QWidget>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_importanttabform.h"

class ImportantTab : public ListTab, private Ui::ImportantTabForm {
    Q_OBJECT

public:
    explicit ImportantTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~ImportantTab();

private:
    Ui::ImportantTabForm* form;
};

#endif // IMPORTANTTAB_H
