#ifndef VERSION_DIALOG_H
#define VERSION_DIALOG_H

#include "version.h"
#include <QDialog>
#include <QtCore>

namespace Ui {
class Version_Dialog;
}

class Version_Dialog : public QDialog {
    Q_OBJECT

public:
    explicit Version_Dialog(QWidget* parent = 0);
    ~Version_Dialog();

private slots:
    void on_aboutQtButton_clicked();

private:
    Ui::Version_Dialog* ui;
};

#endif // VERSION_DIALOG_H
