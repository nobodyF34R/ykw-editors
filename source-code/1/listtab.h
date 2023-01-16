#pragma execution_character_set("utf-8")

#ifndef LISTTAB_H
#define LISTTAB_H

#include "tab.h"

class ListTab : public Tab
{
    Q_OBJECT
public:
    ListTab(SaveManager *mgr, QWidget *parent=0, int sectionId=-1);
    int getItemsCount() const;
    void setItemsCount(int value);
public slots:
    virtual void loadItemAt(int row) = 0;
    virtual void writeItemAt(int row) = 0;
protected:
    int itemsCount;
};

#endif // LISTTAB_H
