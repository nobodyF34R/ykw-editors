#ifndef LISTEDITOR_H
#define LISTEDITOR_H

#include "dataeditor/dataeditor.h"
#include <QComboBox>

class ListEditor : public DataEditor {
    Q_OBJECT
public:
    explicit ListEditor(ListTab* tab, QLabel* label, QComboBox* editor, int pos, int bits, bool lower = true);
    void load(int offset);
    void apply(int offset);
    void clear();
    QString text(int offset);
    quint32 comboboxData(int index);
    int count() const;

private:
    quint32 data(int offset);
    QComboBox* editor;
    int bits;
    bool lower;
};

#endif // LISTEDITOR_H
