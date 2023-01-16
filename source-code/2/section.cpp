#include "section.h"

Section::Section(QTreeWidget *parent, quint8 id, quint32 size, quint32 offset) :
    QTreeWidgetItem(parent, Section::Type),
    id(id),
    size(size),
    offset(offset)
{
    this->setText(0, QString::number(id));
}

Section::~Section()
{
}

quint8 Section::getId() const
{
    return id;
}

void Section::setId(const quint8 &value)
{
    id = value;
}
quint32 Section::getSize() const
{
    return size;
}

void Section::setSize(const quint32 &value)
{
    size = value;
}
quint32 Section::getOffset() const
{
    return offset;
}

void Section::setOffset(const quint32 &value)
{
    offset = value;
}

QString Section::getPath() const
{
    const QTreeWidgetItem *t = this;
    QStringList l;
    do {
        l.prepend(t->text(0));
    } while ((t = t->parent()));
    return l.join("/");
}

Section *Section::child(int index)
{
    QTreeWidgetItem *child = this->QTreeWidgetItem::child(index);
    if (child && child->type() == Section::Type) {
        return static_cast<Section*>(child);
    }
    return 0;
}

Section *Section::nextSibling()
{
    QTreeWidgetItem *parent = this->parent();
    QTreeWidgetItem *nextSibling;
    if (parent) {
        nextSibling = parent->child(parent->indexOfChild(this)+1);
    } else {
        QTreeWidget *treeWidget = this->treeWidget();
        nextSibling = treeWidget->topLevelItem(treeWidget->indexOfTopLevelItem(this)+1);
    }

    if (nextSibling && nextSibling->type() == Section::Type) {
        return static_cast<Section*>(nextSibling);
    }
    return 0;
}

Section *Section::parent()
{
    QTreeWidgetItem *parent = this->QTreeWidgetItem::parent();
    if (parent && parent->type() == Section::Type) {
        return static_cast<Section*>(parent);
    }
    return 0;
}
