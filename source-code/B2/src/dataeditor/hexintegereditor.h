#ifndef HEXINTEGEREDITOR_H
#define HEXINTEGEREDITOR_H

#include "dataeditor/dataeditor.h"
#include <QLineEdit>

class HexIntegerEditor : public DataEditor {
    Q_OBJECT
public:
    explicit HexIntegerEditor(ListTab* tab, QLabel* label, QLineEdit* editor, int pos, int bits);
    void load(int offset);
    void apply(int offset);
    void clear();

private:
    QLineEdit* editor;
    int bits;
};

#endif // HEXINTEGEREDITOR_H
