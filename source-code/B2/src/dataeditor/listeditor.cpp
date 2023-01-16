#include "listeditor.h"

ListEditor::ListEditor(ListTab* tab, QLabel* label, QComboBox* editor, int pos, int bits, bool lower)
    : DataEditor(tab, label, pos)
    , editor(editor)
    , bits(bits)
    , lower(lower)
{
    if (bits != 4 && bits != 8 && bits != 16 && bits != 32) {
        this->bits = 32;
    }
    connect(this->editor, static_cast<void (QComboBox::*)(int)>(&QComboBox::currentIndexChanged), this, &ListEditor::markAsDirty);
}

quint32 ListEditor::data(int offset)
{
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
    return data;
}

void ListEditor::load(int offset)
{
    quint32 data = this->data(offset);
    this->editor->setCurrentIndex(this->editor->findData(data));
}

void ListEditor::apply(int offset)
{
    if (!canProceed()) {
        return;
    }

    if (this->editor->currentIndex() < 0) {
        return;
    }

    quint32 data;
    switch (bits) {
    case 4:
        if (lower) {
            data = this->editor->currentData().value<quint8>() & 0x0F;
            data |= this->tab->read<quint8>(offset * this->itemSize + this->pos) & 0xF0;
            this->tab->write<quint8>(data, offset * this->itemSize + this->pos);
        } else {
            data = this->editor->currentData().value<quint8>() & 0x0F;
            data <<= 4;
            data |= this->tab->read<quint8>(offset * this->itemSize + this->pos) & 0x0F;
            this->tab->write<quint8>(data, offset * this->itemSize + this->pos);
        }
        break;
    case 8:
        this->tab->write<quint8>(this->editor->currentData().value<quint8>(), offset * this->itemSize + this->pos);
        break;
    case 16:
        this->tab->write<quint16>(this->editor->currentData().value<quint16>(), offset * this->itemSize + this->pos);
        break;
    case 32:
        this->tab->write<quint32>(this->editor->currentData().value<quint32>(), offset * this->itemSize + this->pos);
        break;
    }
}

void ListEditor::clear()
{
    this->editor->setCurrentIndex(-1);
}

QString ListEditor::text(int offset)
{
    quint32 data = this->data(offset);
    int index;
    if ((index = this->editor->findData(data)) >= 0) {
        return this->editor->itemText(index);
    }
    return tr("UNKNOWN");
}

quint32 ListEditor::comboboxData(int index)
{
    if (!this->editor)
        return 0;
    if (index >= this->editor->count() || index < 0)
        return 0;
    QVariant v = this->editor->itemData(index);
    return v.toUInt();
}

int ListEditor::count() const
{
    if (!this->editor)
        return 0;
    return this->editor->count();
}
