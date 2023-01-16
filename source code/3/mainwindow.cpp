#pragma execution_character_set("utf-8")

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

    // character tabs
    QTabWidget* commonTab = new QTabWidget(this);
    QTabWidget* maleTab = new QTabWidget(this);
    QTabWidget* femaleTab = new QTabWidget(this);
    QTabWidget* bustersTab = new QTabWidget(this);

    // common
    Section1Tab* s1t = new Section1Tab(this->mgr, this, 0x01);
    Section242Tab* s242t = new Section242Tab(this->mgr, this, 0xF2);
    GashaTab* gt = new GashaTab(this->mgr, this, 0x0E);

    // Male main character (Keta)
    YoukaiTab* yt = new YoukaiTab(this->mgr, this, 0x07);
    ItemTab* it = new ItemTab(this->mgr, this, 0x04);
    EquipmentTab* et = new EquipmentTab(this->mgr, this, 0x05);
    SoulTab* st = new SoulTab(this->mgr, this, 0x13);
    ImportantTab* imt = new ImportantTab(this->mgr, this, 0x06);
    Section9Tab* s9t = new Section9Tab(this->mgr, this, 0x09);
    MedaliumTab* mt = new MedaliumTab(this->mgr, this, 0x01, 0x774);
    HackSlashTab* ht = new HackSlashTab(this->mgr, this, 0x27); // 0x27 for item box, 0x28 for backpack items

    // Female main character (Inaho)
    ItemTab* itF = new ItemTab(this->mgr, this, 0x04 + 21);
    EquipmentTab* etF = new EquipmentTab(this->mgr, this, 0x05 + 21);
    //SoulTab *stF = new SoulTab(this->mgr, this, 0x13 + 21);
    ImportantTab* imtF = new ImportantTab(this->mgr, this, 0x06 + 21);
    Section9Tab* s9tF = new Section9Tab(this->mgr, this, 0x09 + 21);
    MedaliumTab* mtF = new MedaliumTab(this->mgr, this, 0x01, 0xB24);

    // Treasure Busters (available in version 2.0 or later)
    BustersEquipmentTab* b_et_w = new BustersEquipmentTab(this->mgr, 0x2000, this, 0x26);
    BustersEquipmentTab* b_et_e = new BustersEquipmentTab(this->mgr, 0x3000, this, 0x30);
    BustersItemTab* b_ibt = new BustersItemTab(this->mgr, this, 0x24, true);
    BustersItemTab* b_ipt = new BustersItemTab(this->mgr, this, 0x25, false);
    BustersHiddenTreasureTab* b_htt = new BustersHiddenTreasureTab(this->mgr, this, 0x32);

    commonTab->addTab(yt, tr("YOKAI"));
    commonTab->addTab(s1t, tr("INFO1"));
    commonTab->addTab(s242t, tr("INFO2"));
    commonTab->addTab(gt, tr("CRANK_A_KAI"));

    maleTab->addTab(it, tr("ITEM"));
    maleTab->addTab(et, tr("EQUIPMENT"));
    maleTab->addTab(st, tr("SOUL"));
    maleTab->addTab(imt, tr("IMPORTANT"));
    maleTab->addTab(mt, tr("MEDALLIUM"));
    maleTab->addTab(ht, tr("HACKSLASH_BATTLE"));
    maleTab->addTab(s9t, tr("INFO"));

    femaleTab->addTab(itF, tr("ITEM"));
    femaleTab->addTab(etF, tr("EQUIPMENT"));
    //femaleTab->addTab(stF, tr("SOUL"));
    femaleTab->addTab(imtF, tr("IMPORTANT"));
    femaleTab->addTab(mtF, tr("MEDALLIUM"));
    femaleTab->addTab(s9tF, tr("INFO"));

    bustersTab->addTab(b_et_w, tr("BUSTERS_WEAPON"));
    bustersTab->addTab(b_et_e, tr("BUSTERS_EQUIPMENT"));
    bustersTab->addTab(b_ibt, tr("BUSTERS_ITEMBOX"));
    bustersTab->addTab(b_ipt, tr("BUSTERS_ITEMPOUCH"));
    bustersTab->addTab(b_htt, tr("BUSTERS_HIDDENTREASURE"));

    this->sectionTabs.append(yt);
    this->sectionTabs.append(it);
    this->sectionTabs.append(et);
    this->sectionTabs.append(st);
    this->sectionTabs.append(imt);
    this->sectionTabs.append(mt);
    this->sectionTabs.append(ht);
    this->sectionTabs.append(s1t);
    this->sectionTabs.append(s9t);
    this->sectionTabs.append(itF);
    this->sectionTabs.append(etF);
    //this->sectionTabs.append(stF);
    this->sectionTabs.append(imtF);
    this->sectionTabs.append(mtF);
    this->sectionTabs.append(s9tF);
    this->sectionTabs.append(s242t);
    this->sectionTabs.append(gt);
    this->sectionTabs.append(b_et_e);
    this->sectionTabs.append(b_et_w);
    this->sectionTabs.append(b_ibt);
    this->sectionTabs.append(b_ipt);
    this->sectionTabs.append(b_htt);

    this->ui->tabWidget->addTab(commonTab, tr("COMMON_TABS"));
    this->ui->tabWidget->addTab(maleTab, tr("MALE_TABS"));
    this->ui->tabWidget->addTab(femaleTab, tr("FEMALE_TABS"));
    this->ui->tabWidget->addTab(bustersTab, tr("BUSTERS_TABS"));
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
        this->setWindowTitle(this->mgr->getFilepath() + " - Yo-kai Editor 3");
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
