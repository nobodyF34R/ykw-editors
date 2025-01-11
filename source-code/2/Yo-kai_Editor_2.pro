#-------------------------------------------------
#
# Project created by QtCreator 2016-03-15T09:45:07
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = "Yo-kai Editor 2"
TEMPLATE = app

CONFIG += c++11

SOURCES += main.cpp\
        mainwindow.cpp \
    version_dialog.cpp \
    savemanager.cpp \
    xorshift.cpp \
    ywcipher.cpp \
    ccmcipher.cpp \
    crc32.cpp \
    error.cpp \
    tab.cpp \
    listtab.cpp \
    youkaitab.cpp \
    gamedata.cpp \
    gameconfig.cpp \
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
    section1tab.cpp \
    section.cpp \
    section9tab.cpp \
    soultab.cpp \
    youkaichecklist.cpp \
    medalliumtab.cpp

HEADERS  += mainwindow.h \
    version.h \
    version_dialog.h \
    savemanager.h \
    gameconfig.h \
    xorshift.h \
    ywcipher.h \
    ccmcipher.h \
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
    section1tab.h \
    section.h \
    section9tab.h \
    soultab.h \
    youkaichecklist.h \
    medalliumtab.h

FORMS    += mainwindow.ui \
    version_dialog.ui \
    manualeditdialog.ui \
    section1tab.ui \
    section9tab.ui \
    equipmenttabform.ui \
    importanttabform.ui \
    itemtabform.ui \
    youkaitabform.ui \
    soultabform.ui \
    listtab.ui \
    medalliumtab.ui

TRANSLATIONS = $$PWD/translations/app_ja.ts \
$$PWD/translations/app_en.ts

macx {
APPBUNDLE = "Yo-kai Editor 2.app"
ICON = icon.icns
INCLUDEPATH += $$PWD/cryptopp
LIBS += $$PWD/cryptopp/libcryptopp.a
QMAKE_CXXFLAGS_WARN_ON += -Wno-unknown-pragmas
QMAKE_TARGET_BUNDLE_PREFIX = jp.togenyan
}

win32:LIBS += -L$$PWD/../lib/ -lcryptlib

win32:INCLUDEPATH += $$PWD/../include
win32:DEPENDPATH += $$PWD/../include

#Follow directions in cryptopp/install.txt to add to path.
unix:!macx {
    INCLUDEPATH += $$PWD/cryptopp
    LIBS += -L$$PWD/cryptopp -lcryptopp
}

RESOURCES += \
    resources.qrc
RC_FILE = app.rc

