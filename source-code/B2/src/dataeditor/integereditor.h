#ifndef INTEGEREDITOR_H
#define INTEGEREDITOR_H

#include "dataeditor/dataeditor.h"
#include <QSpinBox>

class IntegerEditor : public DataEditor {
    Q_OBJECT
public:
    explicit IntegerEditor(ListTab* tab, QLabel* label, QSpinBox* editor, int pos, int bits, bool is_signed = false, bool lower = true);
    void load(int offset);
    void apply(int offset);
    void clear();

private:
    QSpinBox* editor;
    int bits;
    bool is_signed;
    bool lower;
};

#endif // INTEGEREDITOR_H
