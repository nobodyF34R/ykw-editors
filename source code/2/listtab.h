#pragma execution_character_set("utf-8")

#ifndef LISTTAB_H
#define LISTTAB_H

#include <QWidget>
#include "tab.h"
#include "ui_listtab.h"

namespace Ui {
class ListTab;
}

class ListTab : public Tab
{
    Q_OBJECT

public:
    explicit ListTab(SaveManager *mgr, QWidget *parent=0, int sectionId=-1);
    ~ListTab();
    int getItemsCount() const;
    void setItemsCount(int value);
    void setButtonsEnabled(bool s);
    int getNum1Offset() const;
    void setNum1Offset(int value);
    int getItemSize() const;
    void setItemSize(int value);

public slots:
    virtual void loadCurrentItem();
    virtual void loadItemAt(int row) = 0;
    virtual void writeCurrentItem();
    virtual void writeItemAt(int row) = 0;
    void updateFilter(QString term);
    void clearFilter();
    void automaticNumbering();
private:
    int itemsCount;
    int num1Offset;
    int itemSize;
    void hideAll();
protected:
    Ui::ListTab *ui;
};

#endif // LISTTAB_H
