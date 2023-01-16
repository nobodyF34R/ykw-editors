#-------------------------------------------------
#
# Project created by QtCreator 2016-03-15T09:45:07
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = "Yo-kai Editor 1"
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    version_dialog.cpp \
    savemanager.cpp \
    xorshift.cpp \
    ywcipher.cpp \
    crc32.cpp \
    error.cpp \
    tab.cpp \
    listtab.cpp \
    youkaitab.cpp \
    gamedata.cpp \
    manualeditdialog.cpp \
    QHexEdit/qhexedit.cpp \
    QHexEdit/qhexeditcomments.cpp \
    QHexEdit/qhexeditdata.cpp \
    QHexEdit/qhexeditdatadevice.cpp \
    QHexEdit/qhexeditdatareader.cpp \
    QHexEdit/qhexeditdatawriter.cpp \
    QHexEdit/qhexedithighlighter.cpp \
    QHexEdit/qhexeditprivate.cpp \
    QHexEdit/sparserangemap.cpp \
    itemtab.cpp \
    equipmenttab.cpp \
    importanttab.cpp \
    section.cpp \
    section9tab.cpp \
    youkaichecklist.cpp \
    medalliumtab.cpp

HEADERS  += mainwindow.h \
    version.h \
    version_dialog.h \
    savemanager.h \
    gameconfig.h \
    xorshift.h \
    ywcipher.h \
    crc32.h \
    error.h \
    tab.h \
    listtab.h \
    youkaitab.h \
    gamedata.h \
    manualeditdialog.h \
    QHexEdit/qhexedit.h \
    QHexEdit/qhexeditcomments.h \
    QHexEdit/qhexeditdata.h \
    QHexEdit/qhexeditdatadevice.h \
    QHexEdit/qhexeditdatareader.h \
    QHexEdit/qhexeditdatawriter.h \
    QHexEdit/qhexedithighlighter.h \
    QHexEdit/qhexeditprivate.h \
    QHexEdit/sparserangemap.h \
    itemtab.h \
    equipmenttab.h \
    importanttab.h \
    section.h \
    section9tab.h \
    youkaichecklist.h \
    medalliumtab.h

FORMS    += mainwindow.ui \
    version_dialog.ui \
    youkaitab.ui \
    manualeditdialog.ui \
    itemtab.ui \
    equipmenttab.ui \
    importanttab.ui \
    section9tab.ui \
    medalliumtab.ui

TRANSLATIONS = $$PWD/translations/qt_ja_JP.ts \
$$PWD/translations/qt_fr_FR.ts \
$$PWD/translations/qt_es_ES.ts \
$$PWD/translations/qt_it_IT.ts \
$$PWD/translations/qt_de_DE.ts \
$$PWD/translations/qt_zh_CN.ts \
$$PWD/translations/qt_zh_TW.ts \
$$PWD/translations/qt_pt_BR.ts \
$$PWD/translations/qt_ko_KR.ts

macx {
APPBUNDLE = "Yo-kai Editor 1.app"
ICON = icon.icns
QMAKE_CXXFLAGS_WARN_ON += -Wno-unknown-pragmas
QMAKE_TARGET_BUNDLE_PREFIX = jp.togenyan
}

win32:LIBS += -L$$PWD/../lib/
win32:INCLUDEPATH += $$PWD/../include
win32:DEPENDPATH += $$PWD/../include

RESOURCES += \
    resources.qrc

RC_FILE = app.rc
