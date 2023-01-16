#pragma execution_character_set("utf-8")

#ifndef MANUALEDITDIALOG_H
#define MANUALEDITDIALOG_H

#include "QHexEdit/qhexeditdata.h"
#include "QHexEdit/qhexeditdatareader.h"
#include "savemanager.h"
#include <QDialog>
#include <QTreeWidget>

namespace Ui {
class ManualEditDialog;
}

class ManualEditDialog : public QDialog {
    Q_OBJECT

public:
    explicit ManualEditDialog(QWidget* parent, SaveManager* mgr);
    ~ManualEditDialog();
    void setSections();
    void load(quint8 section);
    void setMgr(SaveManager* value);
    void setTreeWidget(QTreeWidget* t);

public slots:
    void loadCurrentSection();
    void saveCurrentSection();
    int exec();

private:
    Ui::ManualEditDialog* ui;
    QList<quint8> sections;
    SaveManager* mgr;
    QHexEditData* myData;
    QTreeWidget* tree;
};

#endif // MANUALEDITDIALOG_H
