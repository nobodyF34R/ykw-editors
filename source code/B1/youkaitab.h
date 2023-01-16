#ifndef YOUKAITAB_H
#define YOUKAITAB_H

#include <QCheckBox>
#include <QtCore>

#include "gameconfig.h"
#include "gamedata.h"
#include "listtab.h"

#include "ui_youkaitabform.h"

class YoukaiTab : public ListTab {
    Q_OBJECT

public:
    explicit YoukaiTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~YoukaiTab();
    void setLocale(SaveManager::GameLocale locale);

public slots:
    void updateList();
    void loadItemAt(int row);
    void writeItemAt(int row);
    void loadCurrentItem();
    void writeCurrentItem();
    void updateYoukaiCount();
    void updateID();
    void fixIVs();
    void loadDefaultAttacks();

private:
    Ui::YoukaiTabForm* form;
    QList<QCheckBox*> flagCBs;
    int nicknameLen;
    const static int itemSizeJP = 0x48;
    const static int itemSizeNONJP = 0x4C;
    const static int nicknameLenJP = 0x18;
    const static int nicknameNONJP = 0x1C;
};

#endif // YOUKAITAB_H
