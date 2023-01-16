#pragma execution_character_set("utf-8")

#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QFileDialog>
#include <QDropEvent>
#include <QTreeWidget>
#include "version.h"
#include "version_dialog.h"
#include "savemanager.h"
#include "error.h"
#include "youkaitab.h"
#include "itemtab.h"
#include "equipmenttab.h"
#include "importanttab.h"
#include "section9tab.h"
#include "manualeditdialog.h"
#include "medalliumtab.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    void openFileWithPath(const QString &path, bool encrypted);
    void saveFileWithPath(const QString &path, bool encrypted);

public slots:
    void showVersionDialog();
    void openFile(bool encrypted=true);
    void saveFile(bool encrypted=true);
    void openDecryptedFile();
    void saveDecryptedFile();
    void showHexEditor();
    void dragEnterEvent(QDragEnterEvent *e);
    void dropEvent(QDropEvent *e);

private:
    Ui::MainWindow *ui;
    SaveManager *mgr;
    ManualEditDialog *manualEdit;
    QList<Tab*> sectionTabs;
    void updateTabs();
};

#endif // MAINWINDOW_H
