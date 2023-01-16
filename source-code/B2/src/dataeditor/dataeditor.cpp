#include "dataeditor.h"

DataEditor::DataEditor(ListTab* tab, QWidget* label, int pos)
    : tab(tab)
    , pos(pos)
    , dirty(false)
{
    this->label = label;
    itemSize = tab->getItemSize();
}

DataEditor::~DataEditor()
{
}

bool DataEditor::canProceed()
{
    return dirty;
}

void DataEditor::markAsDirty()
{
    label->setStyleSheet("QLabel{font-weight: bold;} QCheckBox{font-weight: bold;}");
    this->dirty = true;
}

bool DataEditor::getDirty() const
{
    return dirty;
}

void DataEditor::markAsClean()
{
    label->setStyleSheet("QLabel{font-weight: normal;} QCheckBox{font-weight: normal;}");
    this->dirty = false;
}
