#include "cheatcodedialog.h"
#include "ui_cheatcodedialog.h"
#include <QMessageBox>
#include <QPushButton>

CheatCodeDialog::CheatCodeDialog(QWidget* parent, SaveManager* mgr)
    : QDialog(parent)
    , ui(new Ui::CheatCodeDialog)
    , mgr(mgr)
    , offset(0)
{
    this->parser = new CyberCodeParser(this);
    ui->setupUi(this);
    ui->cheatCodeEdit->setFont(QFont("Courier"));
    connect(ui->buttonBox->button(QDialogButtonBox::Apply), SIGNAL(clicked()), this, SLOT(applyCheatCode()));
}

CheatCodeDialog::~CheatCodeDialog()
{
    delete ui;
}

void CheatCodeDialog::applyCheatCode()
{
    this->offset = 0;
    this->isDirty = false;
    CyberCodeParser::ReturnCode r = this->parser->parseString(ui->cheatCodeEdit->toPlainText());
    if (r != CyberCodeParser::ReturnCode::SUCCESS) {
        QMessageBox::critical(this, tr("CHEAT_CODE_ERROR"), this->parser->getErrorMessage());
    } else {
        foreach (auto c, parser->getCodes()) {
            (*c).execute(mgr, this->offset);
        }
        this->isDirty = true;
    }
}
bool CheatCodeDialog::getIsDirty() const
{
    return isDirty;
}
