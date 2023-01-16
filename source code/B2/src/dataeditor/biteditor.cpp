#include "biteditor.h"

BitEditor::BitEditor(ListTab* tab, QCheckBox* editor, int pos, int bit_pos)
    : DataEditor(tab, editor, pos)
    , editor(editor)
    , bit_pos(bit_pos)
{
    connect(this->editor, &QCheckBox::stateChanged, this, &BitEditor::markAsDirty);
}

void BitEditor::load(int offset)
{
    quint8 data;
    data = this->tab->read<quint8>(offset * this->itemSize + this->pos);
    this->editor->setChecked(data & (1 << bit_pos));
}

void BitEditor::apply(int offset)
{
    if (!canProceed()) {
        return;
    }
    quint8 data;
    data = this->tab->read<quint8>(offset * this->itemSize + this->pos);
    bool is_checked = this->editor->isChecked();
    if (is_checked) {
        data |= 1 << bit_pos;
    } else {
        data &= ~(1 << bit_pos);
    }
    this->tab->write<quint8>(data, offset * this->itemSize + this->pos);
}

void BitEditor::clear()
{
    this->editor->setChecked(false);
}
