#include "stringeditor.h"

StringEditor::StringEditor(ListTab* tab, QLabel* label, QLineEdit* editor, int pos, int len)
    : DataEditor(tab, label, pos)
    , editor(editor)
    , len(len)
{
    connect(this->editor, &QLineEdit::textEdited, this, &StringEditor::markAsDirty);
}

void StringEditor::load(int offset)
{
    QString data;
    data = this->tab->readString(offset * this->itemSize + this->pos, len - 1);
    this->editor->setText(data);
}

void StringEditor::apply(int offset)
{
    if (!canProceed()) {
        return;
    }

    QString data = this->editor->text();
    this->tab->writeString(data, offset * this->itemSize + this->pos, len - 1);
}

void StringEditor::clear()
{
    this->editor->clear();
}
