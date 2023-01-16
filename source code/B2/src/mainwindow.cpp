#include "mainwindow.h"
#include "ui_mainwindow.h"

#include <QIcon>
#include <QMessageBox>

MainWindow::MainWindow(QWidget* parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
    , mgr(new SaveManager)
    , manualEdit(new ManualEditDialog(this, mgr))
    , cheatEdit(new CheatCodeDialog(this, mgr))
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
    connect(ui->actionCheatCode_Edit, SIGNAL(triggered(bool)), SLOT(showCheatEditor()));

    this->setAcceptDrops(true);

    this->manualEdit->setTreeWidget(this->mgr->getTw());

    YoukaiTab* yt = new YoukaiTab(this->mgr, this, 0x07);
    Section1Tab* s1t = new Section1Tab(this->mgr, this, 0x01);
    //    Section242Tab* s242t = new Section242Tab(this->mgr, this, 0xF2);
    //    GashaTab* gt = new GashaTab(this->mgr, this, 0x0E);

    // the item box
    QTabWidget* itemboxTab = new QTabWidget(this->ui->tabWidget);
    BattleItemTab* bit_ib = new BattleItemTab(this->mgr, this, 0x100); // battle item
    EquipmentTab* et_ib = new EquipmentTab(this->mgr, 0x1000, GameConfig::HackslashEquipmentCountMax, this, 0x101); // equipment (both armor and protector)
    ConsumeTab* cot_ib = new ConsumeTab(this->mgr, this, 0x102); // consume
    ImportantTab* imt_ib = new ImportantTab(this->mgr, this, 0x103); // important
    itemboxTab->addTab(bit_ib, tr("BATTLE_ITEM"));
    itemboxTab->addTab(et_ib, tr("EQUIPMENT"));
    itemboxTab->addTab(cot_ib, tr("ITEM"));
    itemboxTab->addTab(imt_ib, tr("IMPORTANT"));

    ItemTab* bit = new ItemTab(this->mgr, this, 0x25);
    EquipmentTab* et = new EquipmentTab(this->mgr, 0x5000, GameConfig::EquipmentCountMax, this, 0x26);
    EquipmentTab* e2t = new EquipmentTab(this->mgr, 0x6000, GameConfig::EquipmentCountMax, this, 0x30);
    MedaliumTab* mt = new MedaliumTab(this->mgr, this, 0x01, 0x774);
    Section9Tab* s9t = new Section9Tab(this->mgr, this, 0x09);

    this->ui->tabWidget->addTab(yt, tr("YOKAI"));
    this->ui->tabWidget->addTab(s1t, tr("INFO1"));
    //    this->ui->tabWidget->addTab(s242t, tr("INFO2"));
    //    this->ui->tabWidget->addTab(gt, tr("CRANK_A_KAI"));

    this->ui->tabWidget->addTab(itemboxTab, tr("ITEMBOX"));

    this->ui->tabWidget->addTab(bit, tr("BATTLE_ITEM"));
    this->ui->tabWidget->addTab(et, tr("WEAPON"));
    this->ui->tabWidget->addTab(e2t, tr("PROTECTOR"));
    //    this->ui->tabWidget->addTab(imt, tr("IMPORTANT"));
    this->ui->tabWidget->addTab(mt, tr("MEDALLIUM"));
    //    this->ui->tabWidget->addTab(ht, tr("HACKSLASH_BATTLE"));
    this->ui->tabWidget->addTab(s9t, tr("INFO2"));

    this->sectionTabs.append(yt);

    this->sectionTabs.append(bit_ib);
    this->sectionTabs.append(et_ib);
    this->sectionTabs.append(cot_ib);
    this->sectionTabs.append(imt_ib);

    this->sectionTabs.append(bit);
    this->sectionTabs.append(et);
    this->sectionTabs.append(e2t);
    //    this->sectionTabs.append(imt);
    this->sectionTabs.append(mt);
    //    this->sectionTabs.append(ht);
    this->sectionTabs.append(s1t);
    this->sectionTabs.append(s9t);
    //    this->sectionTabs.append(s242t);
    //    this->sectionTabs.append(gt);
}

MainWindow::~MainWindow()
{
    delete ui;
    delete mgr;
}

Error::ErrorCode MainWindow::openFileWithError(const QString& file, bool encrypted)
{
    if (file.isEmpty()) {
        return Error::IO_ERROR;
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
        ui->actionCheatCode_Edit->setEnabled(true);
        this->updateTabs();
    }
    if (status == Error::SUCCESS) {
        this->setWindowTitle(this->mgr->getFilepath() + " - Yo-kai Editor B2");
    }
    return status;
}

void MainWindow::openFileWithPath(const QString& file, bool encrypted)
{
    Error::ErrorCode status;
    if ((status = openFileWithError(file, encrypted)) != Error::SUCCESS) {
        QMessageBox::critical(this, tr("ERROR"), QString(tr("ERROR (%1)")).arg(status));
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
        QMessageBox::critical(this, tr("ERROR"), QString(tr("ERROR (%1)")).arg(status));
    }
}

void MainWindow::dragEnterEvent(QDragEnterEvent* e)
{
    e->acceptProposedAction();
}

void MainWindow::dropEvent(QDropEvent* e)
{
    Error::ErrorCode s1, s2;
    if (e->mimeData()->hasUrls()) {
        QString path = e->mimeData()->urls().first().toLocalFile();
        if (path.endsWith(".ywd")) {
            this->openFileWithPath(path, false);
        } else {
            if ((s1 = this->openFileWithError(path, true)) != Error::SUCCESS
                && (s2 = this->openFileWithError(path, false)) != Error::SUCCESS) {
                /* 暗号化済み・復号済みとみなしてもともに失敗した */
                QMessageBox::critical(this, tr("ERROR"), QString(tr("ERROR (%1-%2)")).arg(s1).arg(s2));
                return;
            }
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
        filter = QString(tr("YO-KAI_WATCH_SAVEDATA (*.yw)"));
    } else {
        filter = QString(tr("YO-KAI_WATCH_DECRYPTED_SAVEDATA (*.ywd *.yw)"));
    }
    file = QFileDialog::getOpenFileName(this, tr("SELECT_FILE_TO_OPEN"),
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
            filter = QString(tr("YO-KAI_WATCH_SAVEDATA (*.yw)"));
        } else {
            filter = QString(tr("YO-KAI_WATCH_DECRYPTED_SAVEDATA (*.ywd *.yw)"));
        }
        file = QFileDialog::getSaveFileName(this, tr("INPUT_FILENAME"),
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

void MainWindow::showCheatEditor()
{
    this->setAcceptDrops(false);
    this->cheatEdit->exec();
    if (this->cheatEdit->getIsDirty()) {
        this->updateTabs();
    }
    this->setAcceptDrops(true);
}

void MainWindow::updateTabs()
{
    for (QList<Tab*>::const_iterator it = this->sectionTabs.constBegin();
         it != this->sectionTabs.constEnd();
         ++it) {
        (*it)->update();
    }
}
