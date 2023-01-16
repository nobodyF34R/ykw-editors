#include "hexintegereditor.h"

HexIntegerEditor::HexIntegerEditor(ListTab* tab, QLabel* label, QLineEdit* editor, int pos, int bits)
    : DataEditor(tab, label, pos)
    , editor(editor)
    , bits(bits)
{
    if (bits != 8 && bits != 16 && bits != 32) {
        this->bits = 32;
    }
    connect(this->editor, &QLineEdit::textEdited, this, &HexIntegerEditor::markAsDirty);
}

void HexIntegerEditor::load(int offset)
{
    quint32 data;
    switch (bits) {
    case 8:
        data = this->tab->read<quint8>(offset * this->itemSize + this->pos);
        break;
    case 16:
        data = this->tab->read<quint16>(offset * this->itemSize + this->pos);
        break;
    case 32:
        data = this->tab->read<quint32>(offset * this->itemSize + this->pos);
        break;
    }
    this->editor->setText(QString::number(data, 16));
}

void HexIntegerEditor::apply(int offset)
{
    if (!canProceed()) {
        return;
    }
    quint32 data = this->editor->text().toUInt(0, 16);
    switch (bits) {
    case 8:
        this->tab->write<quint8>(data, offset * this->itemSize + this->pos);
        break;
    case 16:
        this->tab->write<quint16>(data, offset * this->itemSize + this->pos);
        break;
    case 32:
        this->tab->write<quint32>(data, offset * this->itemSize + this->pos);
        break;
    }
}

void HexIntegerEditor::clear()
{
    this->editor->clear();
}
