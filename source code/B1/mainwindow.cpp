#include "mainwindow.h"
#include "ui_mainwindow.h"

#include <QIcon>
#include <QMessageBox>

MainWindow::MainWindow(QWidget* parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
    , mgr(new SaveManager)
    , manualEdit(new ManualEditDialog(mgr, this))
{
    QIcon icon(":/appInfo/small_icon.png");
    ui->setupUi(this);
    this->setWindowIcon(icon);
    ui->version_label->setText(QString(VERSION_STRING));
    connect(ui->actionVersion_information, SIGNAL(triggered()), SLOT(showVersionDialog()));
    connect(ui->actionOpen, SIGNAL(triggered()), SLOT(openFile()));
    connect(ui->actionSave, SIGNAL(triggered()), SLOT(saveFile()));
    connect(ui->actionOpenDecrypted, SIGNAL(triggered()), SLOT(openDecryptedFile()));
    connect(ui->actionSaveDecrypted, SIGNAL(triggered()), SLOT(saveDecryptedFile()));
    connect(ui->actionManual_Edit, SIGNAL(triggered(bool)), SLOT(showHexEditor()));

    this->setAcceptDrops(true);

    this->manualEdit->setTreeWidget(this->mgr->getTw());

    // tabs
    YoukaiTab* yt = new YoukaiTab(this->mgr, this, 0x07);
    ItemTab* it = new ItemTab(this->mgr, this, 0x04);
    EquipmentTab* et = new EquipmentTab(this->mgr, this, 0x05);
    ImportantTab* imt = new ImportantTab(this->mgr, this, 0x06);
    Section1Tab* s1t = new Section1Tab(this->mgr, this, 0x01);
    Section9Tab* s9t = new Section9Tab(this->mgr, this, 0x09);
    AuraTab* at = new AuraTab(this->mgr, this, 0x13);
    SoulTab* st = new SoulTab(this->mgr, this, 0x11);
    MedaliumTab* mt = new MedaliumTab(this->mgr, this, 0x01, 0x240);
    this->sectionTabs.append(yt);
    this->sectionTabs.append(it);
    this->sectionTabs.append(et);
    this->sectionTabs.append(st);
    this->sectionTabs.append(imt);
    this->sectionTabs.append(s1t);
    this->sectionTabs.append(s9t);
    this->sectionTabs.append(mt);
    this->sectionTabs.append(at);
    ui->tabWidget->addTab(yt, tr("妖怪"));
    ui->tabWidget->addTab(it, tr("どうぐ・そざい"));
    ui->tabWidget->addTab(et, tr("バトル・そうび"));
    ui->tabWidget->addTab(st, tr("魂"));
    ui->tabWidget->addTab(imt, tr("だいじなもの"));
    ui->tabWidget->addTab(at, tr("オーラ"));
    ui->tabWidget->addTab(mt, tr("妖怪大辞典"));
    ui->tabWidget->addTab(s1t, tr("情報1"));
    ui->tabWidget->addTab(s9t, tr("情報2"));
}

MainWindow::~MainWindow()
{
    delete ui;
    delete mgr;
}

void MainWindow::openFileWithPath(const QString& file, bool encrypted)
{
    if (file.isEmpty()) {
        return;
    }
    Error::ErrorCode status;

    if (encrypted) {
        status = this->mgr->loadFile(file);
    } else {
        status = this->mgr->loadDecryptedFile(file);
    }
    if (this->mgr->loaded()) {
        ui->actionSave->setEnabled(true);
        ui->actionSaveDecrypted->setEnabled(true);
        ui->actionManual_Edit->setEnabled(true);
        this->updateTabs();
    }
    if (status != Error::SUCCESS) {
        QMessageBox::critical(this, tr("エラー"), QString("Error (%1)").arg(status));
    }
}

void MainWindow::saveFileWithPath(const QString& file, bool encrypted)
{
    if (file.isEmpty()) {
        return;
    }
    Error::ErrorCode status;
    if (encrypted) {
        status = this->mgr->writeFile(file);
    } else {
        status = this->mgr->writeDecryptedFile(file);
    }
    if (status != Error::SUCCESS) {
        QMessageBox::critical(this, tr("エラー"), QString("Error (%1)").arg(status));
    }
}

void MainWindow::dragEnterEvent(QDragEnterEvent* e)
{
    e->acceptProposedAction();
}

void MainWindow::dropEvent(QDropEvent* e)
{
    if (e->mimeData()->hasUrls()) {
        QString path = e->mimeData()->urls().first().toLocalFile();
        if (path.endsWith(".ywd")) {
            this->openFileWithPath(path, false);
        } else {
            this->openFileWithPath(path, true);
        }
    }
}

void MainWindow::showVersionDialog()
{
    Version_Dialog* dlg;
    dlg = new Version_Dialog(this);
    dlg->exec();
}

void MainWindow::openFile(bool encrypted)
{
    QString file;
    QString filter;

    if (encrypted) {
        filter = QString(tr("妖怪ウォッチ セーブデータ(*.yw *.yw_g)"));
    } else {
        filter = QString(tr("妖怪ウォッチ 復号済みセーブデータ(*.ywd)"));
    }
    file = QFileDialog::getOpenFileName(this, tr("開くファイルを選択"),
        this->mgr->getFilepath(), filter);
    if (file.isEmpty()) {
        return;
    }
    openFileWithPath(file, encrypted);
}

void MainWindow::saveFile(bool encrypted)
{
    QString file;
    QString filter;

    if (this->mgr->loaded()) {
        if (encrypted) {
            filter = QString(tr("妖怪ウォッチ セーブデータ(*.yw *.yw_g)"));
        } else {
            filter = QString(tr("妖怪ウォッチ 復号済みセーブデータ(*.ywd)"));
        }
        file = QFileDialog::getSaveFileName(this, tr("ファイル名を入力"),
            this->mgr->getFilepath(), filter);

        if (file.isEmpty()) {
            return;
        }
        saveFileWithPath(file, encrypted);
    }
}

void MainWindow::openDecryptedFile()
{
    this->openFile(false);
}

void MainWindow::saveDecryptedFile()
{
    this->saveFile(false);
}

void MainWindow::showHexEditor()
{
    this->setAcceptDrops(false);
    int st = this->manualEdit->exec();
    if (st == QDialog::Accepted) {
        this->updateTabs();
    }
    this->setAcceptDrops(true);
}

void MainWindow::updateTabs()
{
    for (QList<Tab*>::const_iterator it = this->sectionTabs.constBegin();
         it != this->sectionTabs.constEnd();
         ++it) {
        (*it)->setLocale(this->mgr->getCurrentLocale());
        (*it)->update();
    }
}
