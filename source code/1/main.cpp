#pragma execution_character_set("utf-8")

#include "mainwindow.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    QTranslator qtTranslator;
    qtTranslator.load(":/translations/translations/qt_" + QLocale().name(), QLibraryInfo::location(QLibraryInfo::TranslationsPath));
    a.installTranslator(&qtTranslator);
    MainWindow w;
    w.show();

    return a.exec();
}
