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
    void setLocale(SaveManager::GameLocale locale);
public slots:
    void updateList();
    void loadItemAt(int row);
    void writeItemAt(int row);
    void loadCurrentItem();
    void writeCurrentItem();

private:
    Ui::ImportantTabForm* form;
};

#endif // IMPORTANTTAB_H
