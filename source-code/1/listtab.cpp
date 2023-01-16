#pragma execution_character_set("utf-8")

#include "listtab.h"

ListTab::ListTab(SaveManager *mgr, QWidget *parent, int sectionId) :
    Tab(mgr, parent, sectionId),
    itemsCount(0)
{

}

int ListTab::getItemsCount() const
{
    return itemsCount;
}

void ListTab::setItemsCount(int value)
{
    itemsCount = value;
}
