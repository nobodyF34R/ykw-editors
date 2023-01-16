#ifndef DATAEDITOR_H
#define DATAEDITOR_H

#include <QLabel>
#include <QtGui>

#include "listtab.h"

class DataEditor : public QObject {
    Q_OBJECT
public:
    explicit DataEditor(ListTab* tab, QWidget* label, int pos);
    virtual ~DataEditor();
    virtual void load(int offset) = 0;
    virtual void apply(int offset) = 0;
    virtual void clear() = 0;
    bool canProceed();
    bool getDirty() const;

public slots:
    void markAsClean();
    void markAsDirty();

protected:
    ListTab* tab;
    int itemSize;
    int pos;
    QWidget* label;
    bool dirty;
};

#endif // DATAEDITOR_H
