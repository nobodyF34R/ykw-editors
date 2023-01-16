#include "version_dialog.h"
#include "ui_version_dialog.h"

#include <QMessageBox>

Version_Dialog::Version_Dialog(QWidget* parent)
    : QDialog(parent)
    , ui(new Ui::Version_Dialog)
{
    ui->setupUi(this);
    ui->version->setText(QString(VERSION_STRING));
    QFile licenseInformation(":/appInfo/AUTHORS.txt");
    licenseInformation.open(QIODevice::ReadOnly);
    QTextStream in(&licenseInformation);
    in.setCodec("UTF-8");
    QString line = in.readAll();
    licenseInformation.close();

    ui->licenceInfo->setText(line);
}

Version_Dialog::~Version_Dialog()
{
    delete ui;
}

void Version_Dialog::on_aboutQtButton_clicked()
{
    QMessageBox::aboutQt(this);
}
