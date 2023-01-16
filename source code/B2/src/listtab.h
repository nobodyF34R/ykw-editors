#ifndef LISTTAB_H
#define LISTTAB_H

#include "tab.h"
#include "ui_listtab.h"
#include <QComboBox>
#include <QWidget>

class DataEditor;
class ListEditor;

namespace Ui {
class ListTab;
}

class ListTab : public Tab {
    Q_OBJECT

public:
    explicit ListTab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    ~ListTab();
    int getItemsCount() const;
    void setItemsCount(int value);
    virtual void setButtonsEnabled(bool s);
    int getNum1Offset() const;
    void setNum1Offset(int value);
    int getItemSize() const;
    void setItemSize(int value);
    ListEditor* getPrimaryEditor() const;
    void setPrimaryEditor(ListEditor* value);

public slots:
    virtual void update();
    void loadCurrentItem();
    void writeSelectedItem();
    void updateFilter(QString term);
    void clearFilter();
    virtual void automaticNumbering();
    void clearData();
    void insertAllItems();

private:
    int itemsCount;
    int num1Offset;
    int itemSize;
    void hideAll();
    ListEditor* primaryEditor;

protected:
    Ui::ListTab* ui;
    QVector<DataEditor*> editors;
};

#endif // LISTTAB_H
