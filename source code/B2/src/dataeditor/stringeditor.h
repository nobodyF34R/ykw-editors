#ifndef STRINGEDITOR_H
#define STRINGEDITOR_H

#include "dataeditor/dataeditor.h"
#include <QLineEdit>

class StringEditor : public DataEditor {
    Q_OBJECT
public:
    explicit StringEditor(ListTab* tab, QLabel* label, QLineEdit* editor, int pos, int len);
    void load(int offset);
    void apply(int offset);
    void clear();

private:
    QLineEdit* editor;
    int len;
};

#endif // STRINGEDITOR_H
