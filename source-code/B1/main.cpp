#include "mainwindow.h"
#include <QApplication>

int main(int argc, char* argv[])
{
    QApplication a(argc, argv);
    QTranslator appTranslator;
    bool localTS = appTranslator.load(QLocale::system(), "app", "_", ":/translations/translations", ".qm");
    if (!localTS) {
        // fallback to English
        localTS = appTranslator.load(":/translations/translations/app_en.qm");
    }
    if (localTS) {
        a.installTranslator(&appTranslator);
    }
    QTranslator sysTranslator;
    localTS = sysTranslator.load("qt_" + QLocale::system().name(), QLibraryInfo::location(QLibraryInfo::TranslationsPath));
    if (localTS) {
        a.installTranslator(&sysTranslator);
    }
    MainWindow w;
    w.show();

    return a.exec();
}
