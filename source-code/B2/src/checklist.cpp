#include "checklist.h"

CheckList::CheckList(int sectionId, int offset, SaveManager* mgr, QWidget* parent)
    : QListWidget(parent)
    , sectionId(sectionId)
    , offset(offset)
    , mgr(mgr)
{
}

void CheckList::update()
{
    QVector<bool> vb = this->mgr->readBoolVector(this->offset, this->count(), this->sectionId);
    for (int i = 0; i < this->count(); ++i) {
        if (vb.at(i)) {
            this->item(i)->setCheckState(Qt::Checked);
        } else {
            this->item(i)->setCheckState(Qt::Unchecked);
        }
    }
}

void CheckList::apply()
{
    QVector<bool> vb;
    for (int i = 0; i < this->count(); ++i) {
        if (this->item(i)->checkState() == Qt::Checked) {
            vb.append(true);
        } else {
            vb.append(false);
        }
    }
    this->mgr->writeBoolVector(vb, this->offset, this->sectionId);
}

void CheckList::setAllState(bool isChecked)
{
    if (isChecked) {
        for (int i = 0; i < this->count(); ++i) {
            if (!this->item(i)->isHidden()) {
                this->item(i)->setCheckState(Qt::Checked);
            }
        }
    } else {
        for (int i = 0; i < this->count(); ++i) {
            if (!this->item(i)->isHidden()) {
                this->item(i)->setCheckState(Qt::Unchecked);
            }
        }
    }
}

void CheckList::setAllChecked()
{
    this->setAllState(true);
}

void CheckList::setAllUnchecked()
{
    this->setAllState(false);
}
SaveManager* CheckList::getMgr() const
{
    return mgr;
}
