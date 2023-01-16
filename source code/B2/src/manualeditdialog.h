#ifndef MANUALEDITDIALOG_H
#define MANUALEDITDIALOG_H

#include "QHexEdit/qhexedit.h"
#include "savemanager.h"
#include <QDialog>
#include <QPushButton>
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
    void load(quint32 section);
    void setMgr(SaveManager* value);
    void setTreeWidget(QTreeWidget* t);

public slots:
    void loadCurrentSection();
    void saveCurrentSection();
    int exec();

private:
    Ui::ManualEditDialog* ui;
    QList<quint32> sections;
    SaveManager* mgr;
    QHexDocument* myData;
    QTreeWidget* tree;
};

#endif // MANUALEDITDIALOG_H
