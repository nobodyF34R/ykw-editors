#pragma execution_character_set("utf-8")

#ifndef MEDALIUMTAB_H
#define MEDALIUMTAB_H

#include <QWidget>
#include "tab.h"
#include "youkaichecklist.h"

namespace Ui {
class MedalliumTab;
}

class MedalliumTab : public Tab
{
    Q_OBJECT

public:
    explicit MedalliumTab(SaveManager *mgr, QWidget *parent=0, int sectionId=-1);
    ~MedalliumTab();
public slots:
    void update();
    void apply();
private:
    Ui::MedalliumTab *ui;
    YoukaiCheckList *seen;
    YoukaiCheckList *befriended;
    YoukaiCheckList *youkaiCam;

};

#endif // MEDALIUMTAB_H
