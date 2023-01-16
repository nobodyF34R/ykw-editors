#pragma execution_character_set("utf-8")

#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include "busters_equipmenttab.h"
#include "busters_hiddentreasuretab.h"
#include "busters_itemtab.h"
#include "cheatcodedialog.h"
#include "equipmenttab.h"
#include "error.h"
#include "gashatab.h"
#include "hackslashtab.h"
#include "importanttab.h"
#include "itemtab.h"
#include "manualeditdialog.h"
#include "medaliumtab.h"
#include "savemanager.h"
#include "section1tab.h"
#include "section242tab.h"
#include "section9tab.h"
#include "soultab.h"
#include "version.h"
#include "version_dialog.h"
#include "youkaitab.h"
#include <QDropEvent>
#include <QFileDialog>
#include <QMainWindow>
#include <QTreeWidget>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow {
    Q_OBJECT

public:
    explicit MainWindow(QWidget* parent = 0);
    ~MainWindow();
    void openFileWithPath(const QString& path, bool encrypted);
    void saveFileWithPath(const QString& path, bool encrypted);
public slots:
    void showVersionDialog();
    void openFile(bool encrypted = true);
    void saveFile(bool encrypted = true);
    void openDecryptedFile();
    void saveDecryptedFile();
    void showHexEditor();
    void showCheatEditor();
    void dragEnterEvent(QDragEnterEvent* e);
    void dropEvent(QDropEvent* e);

private:
    Ui::MainWindow* ui;
    SaveManager* mgr;
    ManualEditDialog* manualEdit;
    CheatCodeDialog* cheatEdit;
    QList<Tab*> sectionTabs;
    Error::ErrorCode openFileWithError(const QString& file, bool encrypted);
    void updateTabs();
};

#endif // MAINWINDOW_H
