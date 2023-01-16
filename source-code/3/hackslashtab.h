#pragma execution_character_set("utf-8")

#ifndef HACKSLASHTAB_H
#define HACKSLASHTAB_H

#include <QWidget>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_hackslashtabform.h"

class HackSlashTab : public ListTab, private Ui::HackSlashTabForm {
    Q_OBJECT

public:
    explicit HackSlashTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~HackSlashTab();

private:
    Ui::HackSlashTabForm* form;
};

#endif // HACKSLASHTAB_H
