#ifndef SECTION_H
#define SECTION_H

#include <QTreeWidgetItem>

class Section : public QTreeWidgetItem
{
public:
    enum {
        Type = QTreeWidgetItem::UserType + 1
    };
    Section(QTreeWidget *parent=0, quint8 id=0, quint32 size=0, quint32 offset = 0);
    quint8 getId() const;
    void setId(const quint8 &value);

    quint32 getSize() const;
    void setSize(const quint32 &value);

    quint32 getOffset() const;
    void setOffset(const quint32 &value);

    QString getPath() const;

    Section *child(int index);
    Section *nextSibling();
    Section *parent();
    ~Section();

private:
    quint8 id;
    quint32 size;
    quint32 offset;
};

#endif // SECTION_H
