#ifndef SOULTAB_H
#define SOULTAB_H

#include <QWidget>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_soultabform.h"

class SoulTab : public ListTab, private Ui::SoulTabForm {
    Q_OBJECT

public:
    explicit SoulTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~SoulTab();
    void setLocale(SaveManager::GameLocale locale);
public slots:
    void updateList();
    void loadItemAt(int row);
    void writeItemAt(int row);
    void loadCurrentItem();
    void writeCurrentItem();

private:
    Ui::SoulTabForm* form;
};

#endif // SOULTAB_H
