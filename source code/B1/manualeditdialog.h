#ifndef MANUALEDITDIALOG_H
#define MANUALEDITDIALOG_H

#include <QDialog>
#include <QTreeWidget>
#include "savemanager.h"
#include "QHexEdit/qhexeditdata.h"
#include "QHexEdit/qhexeditdatareader.h"

namespace Ui {
class ManualEditDialog;
}

class ManualEditDialog : public QDialog
{
    Q_OBJECT

public:
    explicit ManualEditDialog(SaveManager *mgr, QWidget *parent = 0);
    ~ManualEditDialog();
    void setSections();
    void load(quint8 section);
    void setMgr(SaveManager *value);
    void setTreeWidget(QTreeWidget *t);

public slots:
    void loadCurrentSection();
    void saveCurrentSection();
    int exec();

private:
    Ui::ManualEditDialog *ui;
    QList<quint8> sections;
    SaveManager *mgr;
    QHexEditData *myData;
    QTreeWidget *tree;
};

#endif // MANUALEDITDIALOG_H
