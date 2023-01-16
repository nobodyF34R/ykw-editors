#include "integereditor.h"

IntegerEditor::IntegerEditor(ListTab* tab, QLabel* label, QSpinBox* editor, int pos, int bits, bool is_signed, bool lower)
    : DataEditor(tab, label, pos)
    , editor(editor)
    , bits(bits)
    , is_signed(is_signed)
    , lower(lower)
{
    if (bits != 4 && bits != 8 && bits != 16 && bits != 32) {
        this->bits = 32;
    }
    if (bits == 4) {
        this->is_signed = false;
    }

    connect(this->editor, static_cast<void (QSpinBox::*)(int)>(&QSpinBox::valueChanged), this, &IntegerEditor::markAsDirty);
}

void IntegerEditor::load(int offset)
{
    if (is_signed) {
        qint32 data;
        switch (bits) {
        case 8:
            data = this->tab->read<qint8>(offset * this->itemSize + this->pos);
            break;
        case 16:
            data = this->tab->read<qint16>(offset * this->itemSize + this->pos);
            break;
        case 32:
            data = this->tab->read<qint32>(offset * this->itemSize + this->pos);
            break;
        }
        this->editor->setValue(data);
    } else {
        quint32 data;
        switch (bits) {
        case 4:
            data = this->tab->read<quint8>(offset * this->itemSize + this->pos);
            if (lower) {
                data &= 0x0F;
            } else {
                data >>= 4;
            }
            break;
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
        this->editor->setValue(data);
    }
}

void IntegerEditor::apply(int offset)
{
    if (!canProceed()) {
        return;
    }
    if (is_signed) {
        qint32 data = this->editor->value();
        switch (bits) {
        case 8:
            this->tab->write<qint8>(data, offset * this->itemSize + this->pos);
            break;
        case 16:
            this->tab->write<qint16>(data, offset * this->itemSize + this->pos);
            break;
        case 32:
            this->tab->write<qint32>(data, offset * this->itemSize + this->pos);
            break;
        }
    } else {
        quint32 data = this->editor->value();
        switch (bits) {
        case 4:
            if (lower) {
                data &= 0x0F;
                data |= this->tab->read<quint8>(offset * this->itemSize + this->pos) & 0xF0;
                this->tab->write<quint8>(data, offset * this->itemSize + this->pos);
            } else {
                data &= 0x0F;
                data <<= 4;
                data |= this->tab->read<quint8>(offset * this->itemSize + this->pos) & 0x0F;
                this->tab->write<quint8>(data, offset * this->itemSize + this->pos);
            }
            break;
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
}

void IntegerEditor::clear()
{
    this->editor->setValue(0);
}
