#ifndef BITEDITOR_H
#define BITEDITOR_H

#include "dataeditor/dataeditor.h"
#include <QCheckBox>

class BitEditor : public DataEditor {
    Q_OBJECT
public:
    explicit BitEditor(ListTab* tab, QCheckBox* editor, int pos, int bit_pos);
    void load(int offset);
    void apply(int offset);
    void clear();

private:
    QCheckBox* editor;
    int bit_pos;
};

#endif // BITEDITOR_H
