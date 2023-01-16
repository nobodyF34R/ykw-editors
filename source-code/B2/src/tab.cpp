#include "tab.h"

Tab::Tab(SaveManager* mgr, QWidget* parent, int sectionId)
    : QWidget(parent)
    , sectionId(sectionId)
    , mgr(mgr)
{
}

// explicit instantiations
template float Tab::read(int offset);
template qint32 Tab::read(int offset);
template quint32 Tab::read(int offset);
template qint16 Tab::read(int offset);
template quint16 Tab::read(int offset);
template qint8 Tab::read(int offset);
template quint8 Tab::read(int offset);
template void Tab::write(float val, int offset);
template void Tab::write(qint32 val, int offset);
template void Tab::write(quint32 val, int offset);
template void Tab::write(qint16 val, int offset);
template void Tab::write(quint16 val, int offset);
template void Tab::write(qint8 val, int offset);
template void Tab::write(quint8 val, int offset);

template <class V>
void Tab::write(V val, int offset)
{
    if (mgr) {
        this->mgr->writeSection<V>(val, offset, this->sectionId);
    }
}

template <class V>
V Tab::read(int offset)
{
    if (mgr) {
        return this->mgr->readSection<V>(offset, this->sectionId);
    }
    return V(0);
}

QString Tab::readString(int offset, int lenInBytes)
{
    if (mgr) {
        return this->mgr->readString(offset, lenInBytes, this->sectionId);
    }
    return QString("");
}

void Tab::writeString(QString in, int offset, int lenInBytes)
{
    if (mgr) {
        return this->mgr->writeString(in, offset, lenInBytes, this->sectionId);
    }
}

QByteArray Tab::getSectionData()
{
    return this->mgr->getSectionData(this->sectionId, false);
}

void Tab::setSectionData(QByteArray in)
{
    this->mgr->setSectionData(in, this->sectionId);
}

SaveManager* Tab::getMgr() const
{
    return mgr;
}

void Tab::setMgr(SaveManager* value)
{
    mgr = value;
}

int Tab::getSectionId() const
{
    return sectionId;
}

void Tab::setSectionId(int value)
{
    sectionId = value;
}
