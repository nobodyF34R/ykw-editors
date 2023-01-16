#ifndef AURATAB_H
#define AURATAB_H

#include "gamedata.h"
#include "tab.h"
#include <QWidget>

namespace Ui {
class AuraTab;
}

class AuraTab : public Tab {
    Q_OBJECT

public:
    explicit AuraTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~AuraTab();
    void setLocale(SaveManager::GameLocale locale);
public slots:
    void update();
    void apply();

private:
    Ui::AuraTab* ui;
};

#endif // AURATAB_H
