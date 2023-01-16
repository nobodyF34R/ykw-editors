#include "mainwindow.h"
#include <QApplication>

int main(int argc, char* argv[])
{
    QApplication a(argc, argv);
    QTranslator appTranslator;
    appTranslator.load(QLocale::system(), "app", "_", ":/translations/translations", ".qm");
    a.installTranslator(&appTranslator);
    QTranslator sysTranslator;
    sysTranslator.load("qt_" + QLocale::system().name(), QLibraryInfo::location(QLibraryInfo::TranslationsPath));
    a.installTranslator(&sysTranslator);
    MainWindow w;
    w.show();

    return a.exec();
}
