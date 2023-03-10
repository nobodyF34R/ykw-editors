#pragma execution_character_set("utf-8")

#include "mainwindow.h"
#include <QApplication>

int main(int argc, char* argv[])
{
    QApplication a(argc, argv);
    QTranslator appTranslator;
    if (!appTranslator.load(QLocale::system(), "app", "_", ":/translations/translations")) {
        appTranslator.load(":/translations/translations/app_en.qm");
    }
    a.installTranslator(&appTranslator);
    QTranslator sysTranslator;
    sysTranslator.load("qt_" + QLocale::system().name(), QLibraryInfo::location(QLibraryInfo::TranslationsPath));
    a.installTranslator(&sysTranslator);
    MainWindow w;
    w.show();

    return a.exec();
}
