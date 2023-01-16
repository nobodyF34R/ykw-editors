#include "manualeditdialog.h"
#include "ui_manualeditdialog.h"

ManualEditDialog::ManualEditDialog(QWidget* parent, SaveManager* mgr)
    : QDialog(parent)
    , ui(new Ui::ManualEditDialog)
    , mgr(mgr)
    , myData(0)
    , tree(0)
{
    ui->setupUi(this);
    connect(ui->buttonBox->button(QDialogButtonBox::Save), SIGNAL(clicked(bool)), SLOT(saveCurrentSection()));
}

ManualEditDialog::~ManualEditDialog()
{
    delete ui;
}

int ManualEditDialog::exec()
{
    if (this->tree) {
        this->tree->setCurrentItem(this->tree->topLevelItem(0));
        this->loadCurrentSection();
    }
    return QDialog::exec();
}

void ManualEditDialog::loadCurrentSection()
{
    if (this->tree && this->tree->currentItem()) {
        this->load(this->tree->currentItem()->text(0).toInt());
    }
}

void ManualEditDialog::saveCurrentSection()
{
    if (this->tree && this->tree->currentItem()) {
        quint32 sectionId = this->tree->currentItem()->text(0).toInt();
        QByteArray data = ui->frame->document()->read(0, this->mgr->getSectionById(sectionId)->getSize());
        this->mgr->setSectionData(data, sectionId);
    }
}

void ManualEditDialog::setMgr(SaveManager* value)
{
    mgr = value;
}

void ManualEditDialog::setTreeWidget(QTreeWidget* t)
{
    this->tree = t;
    ui->horizontalLayout->addWidget(t);
    connect(t, SIGNAL(currentItemChanged(QTreeWidgetItem*, QTreeWidgetItem*)),
        SLOT(loadCurrentSection()));
}

void ManualEditDialog::load(quint32 section)
{
    QHexDocument* old = this->myData;
    if (this->tree) {
        this->myData = QHexDocument::fromMemory(this->mgr->getSectionData(section));
        ui->frame->setDocument(this->myData);
        if (old) {
            // The destructor of QHexDocument is private,
            // so call the destructor by making it a child of ephemeral QObject,
            // and deleting the parent QObject immediately.
            QObject tmp;
            old->setParent(&tmp);
        }
    }
}
