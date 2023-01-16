#ifndef CHEATCODEDIALOG_H
#define CHEATCODEDIALOG_H

#include "cybercode/CyberCodeParser.h"
#include "savemanager.h"
#include <QDialog>

namespace Ui {
class CheatCodeDialog;
}

class CheatCodeDialog : public QDialog {
    Q_OBJECT

public:
    explicit CheatCodeDialog(QWidget* parent, SaveManager* mgr);
    ~CheatCodeDialog();
    bool getIsDirty() const;

public slots:
    void applyCheatCode();

private:
    Ui::CheatCodeDialog* ui;
    SaveManager* mgr;
    CyberCodeParser* parser;
    int offset;
    bool isDirty;
};

#endif // CHEATCODEDIALOG_H
