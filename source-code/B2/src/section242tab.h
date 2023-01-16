#ifndef SECTION242TAB_H
#define SECTION242TAB_H

#include "gamedata.h"
#include "tab.h"
#include <QWidget>

namespace Ui {
class Section242Tab;
}

class Section242Tab : public Tab {
    Q_OBJECT

public:
    explicit Section242Tab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~Section242Tab();
public slots:
    void update();
    void apply();

private:
    Ui::Section242Tab* ui;
    float frameToPos(quint32 frame);
    quint32 posToFrame(float pos);
};

#endif // SECTION242TAB_H
