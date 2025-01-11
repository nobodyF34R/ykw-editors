#-------------------------------------------------
#
# Project created by QtCreator 2016-03-15T09:45:07
#
#-------------------------------------------------

QT       += core gui

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = "Yo-kai Editor 3"
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
    medaliumtab.cpp \
    youkaichecklist.cpp \
    section242tab.cpp \
    hackslashtab.cpp \
    gashatab.cpp \
    gashalot.cpp \
    checklist.cpp \
    flagchecklist.cpp \
    trophychecklist.cpp \
    cheatcodedialog.cpp \
    cybercode/AddCode.cpp \
    cybercode/CyberCode.cpp \
    cybercode/CyberCodeParser.cpp \
    cybercode/LoopCode.cpp \
    cybercode/OffsetCode.cpp \
    cybercode/SearchCode.cpp \
    cybercode/SectionWriteCode.cpp \
    cybercode/WriteCode.cpp \
    busters_equipmenttab.cpp \
    busters_itemtab.cpp \
    busters_hiddentreasuretab.cpp \
    cybercode/SectionOffsetCode.cpp \
    dataeditor/dataeditor.cpp \
    dataeditor/integereditor.cpp \
    dataeditor/biteditor.cpp \
    dataeditor/stringeditor.cpp \
    dataeditor/listeditor.cpp \
    dataeditor/hexintegereditor.cpp \
    gashastate.cpp

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
    medaliumtab.h \
    youkaichecklist.h \
    section242tab.h \
    hackslashtab.h \
    gashatab.h \
    gashalot.h \
    checklist.h \
    flagchecklist.h \
    trophychecklist.h \
    cheatcodedialog.h \
    cybercode/AddCode.h \
    cybercode/CyberCode.h \
    cybercode/CyberCodeParser.h \
    cybercode/LoopCode.h \
    cybercode/OffsetCode.h \
    cybercode/SearchCode.h \
    cybercode/SectionWriteCode.h \
    cybercode/WriteCode.h \
    busters_equipmenttab.h \
    busters_itemtab.h \
    busters_hiddentreasuretab.h \
    cybercode/SectionOffsetCode.h \
    dataeditor/dataeditor.h \
    dataeditor/integereditor.h \
    dataeditor/biteditor.h \
    dataeditor/stringeditor.h \
    dataeditor/listeditor.h \
    dataeditor/hexintegereditor.h \
    gashastate.h

FORMS    += mainwindow.ui \
    version_dialog.ui \
    manualeditdialog.ui \
    section1tab.ui \
    section9tab.ui \
    medaliumtab.ui \
    listtab.ui \
    youkaitabform.ui \
    itemtabform.ui \
    soultabform.ui \
    equipmenttabform.ui \
    importanttabform.ui \
    section242tab.ui \
    hackslashtabform.ui \
    gashatab.ui \
    cheatcodedialog.ui \
    busters_equipmenttabform.ui \
    busters_itemtabform.ui \
    busters_hiddentreasuretabform.ui

TRANSLATIONS = $$PWD/translations/app_ja.ts \
$$PWD/translations/app_en.ts

macx {
APPBUNDLE = "Yo-kai Editor 3.app"
ICON = icon.icns
INCLUDEPATH += $$PWD/cryptopp
LIBS += $$PWD/cryptopp/libcryptopp.a
INCLUDEPATH += $$PWD/../../local/include
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
