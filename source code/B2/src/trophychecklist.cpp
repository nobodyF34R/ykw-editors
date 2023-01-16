#include "trophychecklist.h"

TrophyCheckList::TrophyCheckList(int sectionId, int offset, SaveManager* mgr, QWidget* parent)
    : CheckList(sectionId, offset, mgr, parent)
{
    /* intert items into list */
    QListWidgetItem* i = new QListWidgetItem("", this);
    i->setCheckState(Qt::Unchecked);
    i->setHidden(true);
    foreach (QJsonValue v, GameData::getInstance().getJSONArrayData("trophy")) {
        QListWidgetItem* ia = new QListWidgetItem(v.toObject()["name"].toString(), this);
        ia->setFlags(ia->flags() | Qt::ItemIsUserCheckable);
        ia->setCheckState(Qt::Unchecked);
        ia->setData(Qt::UserRole, v.toObject()["type"].toVariant());
    }
}

void TrophyCheckList::apply()
{
    CheckList::apply();
    int bronze = 0, silver = 0, gold = 0;
    for (int i = 0; i < this->count(); ++i) {
        if (this->item(i)->checkState() == Qt::Checked) {
            switch (this->item(i)->data(Qt::UserRole).toInt()) {
            case 0:
                bronze++;
                break;
            case 1:
                silver++;
                break;
            case 2:
                gold++;
                break;
            default:
                break;
            }
        }
    }
    this->getMgr()->writeSection<quint8>(bronze, 0x48, 20);
    this->getMgr()->writeSection<quint8>(silver, 0x49, 20);
    this->getMgr()->writeSection<quint8>(gold, 0x4A, 20);
}
