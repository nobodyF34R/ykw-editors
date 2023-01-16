#include "flagchecklist.h"

FlagCheckList::FlagCheckList(int sectionId, int offset, SaveManager* mgr, QWidget* parent)
    : CheckList(sectionId, offset, mgr, parent)
{
    /* intert items into list */
    foreach (const dataentry_t& it, GameData::getInstance().getData("flags")) {
        quint32 index = it.first;
        QListWidgetItem* ia = new QListWidgetItem(QString("%1 %2").arg(index, 3, 10, QChar('0')).arg(it.second.value("name")), this);
        ia->setFlags(ia->flags() | Qt::ItemIsUserCheckable);
        ia->setCheckState(Qt::Unchecked);
    }
}
