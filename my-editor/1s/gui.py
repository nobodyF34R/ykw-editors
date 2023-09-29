# -*- coding: utf-8 -*-

################################################################################
## Form generated from reading UI file 'guiTHYtKK.ui'
##
## Created by: Qt User Interface Compiler version 6.5.2
##
## WARNING! All changes made in this file will be lost when recompiling UI file!
################################################################################

from PySide6.QtCore import (QCoreApplication, QDate, QDateTime, QLocale,
    QMetaObject, QObject, QPoint, QRect,
    QSize, QTime, QUrl, Qt)
from PySide6.QtGui import (QAction, QBrush, QColor, QConicalGradient,
    QCursor, QFont, QFontDatabase, QGradient,
    QIcon, QImage, QKeySequence, QLinearGradient,
    QPainter, QPalette, QPixmap, QRadialGradient,
    QTransform)
from PySide6.QtWidgets import (QApplication, QComboBox, QFormLayout, QGridLayout,
    QGroupBox, QHBoxLayout, QLabel, QLineEdit,
    QListWidget, QListWidgetItem, QMainWindow, QMenu,
    QMenuBar, QPushButton, QSizePolicy, QSpacerItem,
    QSpinBox, QTabWidget, QVBoxLayout, QWidget)

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        if not MainWindow.objectName():
            MainWindow.setObjectName(u"MainWindow")
        MainWindow.resize(547, 532)
        MainWindow.setWindowTitle(u"Yo-kai Editor 1s")
        self.actionOpen = QAction(MainWindow)
        self.actionOpen.setObjectName(u"actionOpen")
        self.actionSave = QAction(MainWindow)
        self.actionSave.setObjectName(u"actionSave")
        self.actionSave.setEnabled(False)
        self.actionOpenDecrypted = QAction(MainWindow)
        self.actionOpenDecrypted.setObjectName(u"actionOpenDecrypted")
        self.actionSaveDecrypted = QAction(MainWindow)
        self.actionSaveDecrypted.setObjectName(u"actionSaveDecrypted")
        self.actionSaveDecrypted.setEnabled(False)
        self.centralWidget = QWidget(MainWindow)
        self.centralWidget.setObjectName(u"centralWidget")
        self.gridLayout = QGridLayout(self.centralWidget)
        self.gridLayout.setSpacing(6)
        self.gridLayout.setContentsMargins(11, 11, 11, 11)
        self.gridLayout.setObjectName(u"gridLayout")
        self.verticalLayout = QVBoxLayout()
        self.verticalLayout.setSpacing(6)
        self.verticalLayout.setObjectName(u"verticalLayout")
        self.horizontalLayout = QHBoxLayout()
        self.horizontalLayout.setSpacing(6)
        self.horizontalLayout.setObjectName(u"horizontalLayout")
        self.title_label = QLabel(self.centralWidget)
        self.title_label.setObjectName(u"title_label")
        font = QFont()
        font.setBold(True)
        self.title_label.setFont(font)
        self.title_label.setText(u"Yo-kai Editor 1s")

        self.horizontalLayout.addWidget(self.title_label)

        self.horizontalSpacer = QSpacerItem(40, 20, QSizePolicy.Expanding, QSizePolicy.Minimum)

        self.horizontalLayout.addItem(self.horizontalSpacer)

        self.label = QLabel(self.centralWidget)
        self.label.setObjectName(u"label")

        self.horizontalLayout.addWidget(self.label)

        self.version_label = QLabel(self.centralWidget)
        self.version_label.setObjectName(u"version_label")
        self.version_label.setText(u"null")

        self.horizontalLayout.addWidget(self.version_label)


        self.verticalLayout.addLayout(self.horizontalLayout)

        self.tabWidget_2 = QTabWidget(self.centralWidget)
        self.tabWidget_2.setObjectName(u"tabWidget_2")
        self.tabWidget_2.setTabShape(QTabWidget.Rounded)
        self.yokaiTab = QWidget()
        self.yokaiTab.setObjectName(u"yokaiTab")
        self.listWidget = QListWidget(self.yokaiTab)
        self.listWidget.setObjectName(u"listWidget")
        self.listWidget.setGeometry(QRect(0, 0, 100, 421))
        self.listWidget.setMinimumSize(QSize(100, 0))
        self.groupBox_4 = QGroupBox(self.yokaiTab)
        self.groupBox_4.setObjectName(u"groupBox_4")
        self.groupBox_4.setGeometry(QRect(110, 0, 396, 171))
        self.horizontalLayout_4 = QHBoxLayout(self.groupBox_4)
        self.horizontalLayout_4.setSpacing(6)
        self.horizontalLayout_4.setContentsMargins(11, 11, 11, 11)
        self.horizontalLayout_4.setObjectName(u"horizontalLayout_4")
        self.formLayout = QFormLayout()
        self.formLayout.setSpacing(6)
        self.formLayout.setObjectName(u"formLayout")
        self.label_3 = QLabel(self.groupBox_4)
        self.label_3.setObjectName(u"label_3")

        self.formLayout.setWidget(0, QFormLayout.LabelRole, self.label_3)

        self.attitudeLabel = QLabel(self.groupBox_4)
        self.attitudeLabel.setObjectName(u"attitudeLabel")

        self.formLayout.setWidget(1, QFormLayout.LabelRole, self.attitudeLabel)

        self.label_4 = QLabel(self.groupBox_4)
        self.label_4.setObjectName(u"label_4")

        self.formLayout.setWidget(2, QFormLayout.LabelRole, self.label_4)

        self.yokaiComboBox = QComboBox(self.groupBox_4)
        self.yokaiComboBox.setObjectName(u"yokaiComboBox")
        self.yokaiComboBox.setMinimumSize(QSize(180, 0))

        self.formLayout.setWidget(0, QFormLayout.FieldRole, self.yokaiComboBox)

        self.attitudeComboBox = QComboBox(self.groupBox_4)
        self.attitudeComboBox.setObjectName(u"attitudeComboBox")

        self.formLayout.setWidget(1, QFormLayout.FieldRole, self.attitudeComboBox)

        self.nicknameEdit = QLineEdit(self.groupBox_4)
        self.nicknameEdit.setObjectName(u"nicknameEdit")
        self.nicknameEdit.setMinimumSize(QSize(170, 0))
        self.nicknameEdit.setMaxLength(60)

        self.formLayout.setWidget(2, QFormLayout.FieldRole, self.nicknameEdit)

        self.label_5 = QLabel(self.groupBox_4)
        self.label_5.setObjectName(u"label_5")

        self.formLayout.setWidget(3, QFormLayout.LabelRole, self.label_5)

        self.level = QSpinBox(self.groupBox_4)
        self.level.setObjectName(u"level")
        self.level.setMaximum(255)
        self.level.setValue(255)

        self.formLayout.setWidget(3, QFormLayout.FieldRole, self.level)


        self.horizontalLayout_4.addLayout(self.formLayout)

        self.groupBox_2 = QGroupBox(self.yokaiTab)
        self.groupBox_2.setObjectName(u"groupBox_2")
        self.groupBox_2.setGeometry(QRect(110, 170, 398, 251))
        self.layoutWidget = QWidget(self.groupBox_2)
        self.layoutWidget.setObjectName(u"layoutWidget")
        self.layoutWidget.setGeometry(QRect(10, 20, 381, 201))
        self.horizontalLayout_3 = QHBoxLayout(self.layoutWidget)
        self.horizontalLayout_3.setSpacing(6)
        self.horizontalLayout_3.setContentsMargins(11, 11, 11, 11)
        self.horizontalLayout_3.setObjectName(u"horizontalLayout_3")
        self.horizontalLayout_3.setContentsMargins(0, 0, 0, 0)
        self.groupBox = QGroupBox(self.layoutWidget)
        self.groupBox.setObjectName(u"groupBox")
        sizePolicy = QSizePolicy(QSizePolicy.Fixed, QSizePolicy.Fixed)
        sizePolicy.setHorizontalStretch(0)
        sizePolicy.setVerticalStretch(0)
        sizePolicy.setHeightForWidth(self.groupBox.sizePolicy().hasHeightForWidth())
        self.groupBox.setSizePolicy(sizePolicy)
        self.verticalLayout_6 = QVBoxLayout(self.groupBox)
        self.verticalLayout_6.setSpacing(6)
        self.verticalLayout_6.setContentsMargins(11, 11, 11, 11)
        self.verticalLayout_6.setObjectName(u"verticalLayout_6")
        self.formLayout_2 = QFormLayout()
        self.formLayout_2.setSpacing(6)
        self.formLayout_2.setObjectName(u"formLayout_2")
        self.label_6 = QLabel(self.groupBox)
        self.label_6.setObjectName(u"label_6")

        self.formLayout_2.setWidget(0, QFormLayout.LabelRole, self.label_6)

        self.IV_HP = QSpinBox(self.groupBox)
        self.IV_HP.setObjectName(u"IV_HP")
        self.IV_HP.setMaximum(10)
        self.IV_HP.setValue(2)

        self.formLayout_2.setWidget(0, QFormLayout.FieldRole, self.IV_HP)

        self.label_8 = QLabel(self.groupBox)
        self.label_8.setObjectName(u"label_8")

        self.formLayout_2.setWidget(1, QFormLayout.LabelRole, self.label_8)

        self.IV_STR = QSpinBox(self.groupBox)
        self.IV_STR.setObjectName(u"IV_STR")
        self.IV_STR.setMaximum(10)
        self.IV_STR.setValue(2)

        self.formLayout_2.setWidget(1, QFormLayout.FieldRole, self.IV_STR)

        self.label_9 = QLabel(self.groupBox)
        self.label_9.setObjectName(u"label_9")

        self.formLayout_2.setWidget(2, QFormLayout.LabelRole, self.label_9)

        self.IV_SPR = QSpinBox(self.groupBox)
        self.IV_SPR.setObjectName(u"IV_SPR")
        self.IV_SPR.setMaximum(10)
        self.IV_SPR.setValue(2)

        self.formLayout_2.setWidget(2, QFormLayout.FieldRole, self.IV_SPR)

        self.label_11 = QLabel(self.groupBox)
        self.label_11.setObjectName(u"label_11")

        self.formLayout_2.setWidget(3, QFormLayout.LabelRole, self.label_11)

        self.IV_DEF = QSpinBox(self.groupBox)
        self.IV_DEF.setObjectName(u"IV_DEF")
        self.IV_DEF.setMaximum(10)
        self.IV_DEF.setValue(2)

        self.formLayout_2.setWidget(3, QFormLayout.FieldRole, self.IV_DEF)

        self.label_12 = QLabel(self.groupBox)
        self.label_12.setObjectName(u"label_12")

        self.formLayout_2.setWidget(4, QFormLayout.LabelRole, self.label_12)

        self.IV_SPD = QSpinBox(self.groupBox)
        self.IV_SPD.setObjectName(u"IV_SPD")
        self.IV_SPD.setMaximum(10)
        self.IV_SPD.setValue(2)

        self.formLayout_2.setWidget(4, QFormLayout.FieldRole, self.IV_SPD)


        self.verticalLayout_6.addLayout(self.formLayout_2)


        self.horizontalLayout_3.addWidget(self.groupBox)

        self.groupBox_3 = QGroupBox(self.layoutWidget)
        self.groupBox_3.setObjectName(u"groupBox_3")
        sizePolicy.setHeightForWidth(self.groupBox_3.sizePolicy().hasHeightForWidth())
        self.groupBox_3.setSizePolicy(sizePolicy)
        self.verticalLayout_8 = QVBoxLayout(self.groupBox_3)
        self.verticalLayout_8.setSpacing(6)
        self.verticalLayout_8.setContentsMargins(11, 11, 11, 11)
        self.verticalLayout_8.setObjectName(u"verticalLayout_8")
        self.formLayout_4 = QFormLayout()
        self.formLayout_4.setSpacing(6)
        self.formLayout_4.setObjectName(u"formLayout_4")
        self.label_7 = QLabel(self.groupBox_3)
        self.label_7.setObjectName(u"label_7")

        self.formLayout_4.setWidget(0, QFormLayout.LabelRole, self.label_7)

        self.EV_HP = QSpinBox(self.groupBox_3)
        self.EV_HP.setObjectName(u"EV_HP")
        self.EV_HP.setMaximum(20)
        self.EV_HP.setValue(4)

        self.formLayout_4.setWidget(0, QFormLayout.FieldRole, self.EV_HP)

        self.label_10 = QLabel(self.groupBox_3)
        self.label_10.setObjectName(u"label_10")

        self.formLayout_4.setWidget(1, QFormLayout.LabelRole, self.label_10)

        self.EV_STR = QSpinBox(self.groupBox_3)
        self.EV_STR.setObjectName(u"EV_STR")
        self.EV_STR.setMaximum(20)
        self.EV_STR.setValue(4)

        self.formLayout_4.setWidget(1, QFormLayout.FieldRole, self.EV_STR)

        self.label_18 = QLabel(self.groupBox_3)
        self.label_18.setObjectName(u"label_18")

        self.formLayout_4.setWidget(2, QFormLayout.LabelRole, self.label_18)

        self.EV_SPR = QSpinBox(self.groupBox_3)
        self.EV_SPR.setObjectName(u"EV_SPR")
        self.EV_SPR.setMaximum(20)
        self.EV_SPR.setValue(4)

        self.formLayout_4.setWidget(2, QFormLayout.FieldRole, self.EV_SPR)

        self.label_19 = QLabel(self.groupBox_3)
        self.label_19.setObjectName(u"label_19")

        self.formLayout_4.setWidget(3, QFormLayout.LabelRole, self.label_19)

        self.EV_DEF = QSpinBox(self.groupBox_3)
        self.EV_DEF.setObjectName(u"EV_DEF")
        self.EV_DEF.setMaximum(20)
        self.EV_DEF.setValue(4)

        self.formLayout_4.setWidget(3, QFormLayout.FieldRole, self.EV_DEF)

        self.label_20 = QLabel(self.groupBox_3)
        self.label_20.setObjectName(u"label_20")

        self.formLayout_4.setWidget(4, QFormLayout.LabelRole, self.label_20)

        self.EV_SPD = QSpinBox(self.groupBox_3)
        self.EV_SPD.setObjectName(u"EV_SPD")
        self.EV_SPD.setMaximum(20)
        self.EV_SPD.setValue(4)

        self.formLayout_4.setWidget(4, QFormLayout.FieldRole, self.EV_SPD)


        self.verticalLayout_8.addLayout(self.formLayout_4)


        self.horizontalLayout_3.addWidget(self.groupBox_3)

        self.setMaxStats = QPushButton(self.groupBox_2)
        self.setMaxStats.setObjectName(u"setMaxStats")
        self.setMaxStats.setGeometry(QRect(10, 220, 101, 32))
        self.advanced = QPushButton(self.groupBox_2)
        self.advanced.setObjectName(u"advanced")
        self.advanced.setGeometry(QRect(120, 220, 100, 32))
        self.tabWidget_2.addTab(self.yokaiTab, "")
        self.itemTab = QWidget()
        self.itemTab.setObjectName(u"itemTab")
        self.tabWidget_2.addTab(self.itemTab, "")
        self.equipmentTab = QWidget()
        self.equipmentTab.setObjectName(u"equipmentTab")
        self.tabWidget_2.addTab(self.equipmentTab, "")
        self.importantTab = QWidget()
        self.importantTab.setObjectName(u"importantTab")
        self.tabWidget_2.addTab(self.importantTab, "")
        self.medalliumTab = QWidget()
        self.medalliumTab.setObjectName(u"medalliumTab")
        self.tabWidget_2.addTab(self.medalliumTab, "")
        self.miscTab = QWidget()
        self.miscTab.setObjectName(u"miscTab")
        self.tabWidget_2.addTab(self.miscTab, "")

        self.verticalLayout.addWidget(self.tabWidget_2)


        self.gridLayout.addLayout(self.verticalLayout, 0, 0, 1, 1)

        MainWindow.setCentralWidget(self.centralWidget)
        self.menuBar = QMenuBar(MainWindow)
        self.menuBar.setObjectName(u"menuBar")
        self.menuBar.setGeometry(QRect(0, 0, 547, 24))
        self.menuFile = QMenu(self.menuBar)
        self.menuFile.setObjectName(u"menuFile")
        MainWindow.setMenuBar(self.menuBar)

        self.menuBar.addAction(self.menuFile.menuAction())
        self.menuFile.addAction(self.actionOpen)
        self.menuFile.addAction(self.actionSave)
        self.menuFile.addSeparator()
        self.menuFile.addAction(self.actionOpenDecrypted)
        self.menuFile.addAction(self.actionSaveDecrypted)

        self.retranslateUi(MainWindow)

        self.tabWidget_2.setCurrentIndex(0)


        QMetaObject.connectSlotsByName(MainWindow)
    # setupUi

    def retranslateUi(self, MainWindow):
        self.actionOpen.setText(QCoreApplication.translate("MainWindow", u"Open...", None))
        #if QT_CONFIG(shortcut)
        self.actionOpen.setShortcut(QCoreApplication.translate("MainWindow", u"Ctrl+O", None))
        #endif // QT_CONFIG(shortcut)
        self.actionSave.setText(QCoreApplication.translate("MainWindow", u"Save As...", None))
        #if QT_CONFIG(shortcut)
        self.actionSave.setShortcut(QCoreApplication.translate("MainWindow", u"Ctrl+S", None))
        #endif // QT_CONFIG(shortcut)
        self.actionOpenDecrypted.setText(QCoreApplication.translate("MainWindow", u"Open decrypted...", None))
        #if QT_CONFIG(shortcut)
        self.actionOpenDecrypted.setShortcut(QCoreApplication.translate("MainWindow", u"Ctrl+Shift+O", None))
        #endif // QT_CONFIG(shortcut)
        self.actionSaveDecrypted.setText(QCoreApplication.translate("MainWindow", u"Save decrypted As...", None))
        #if QT_CONFIG(shortcut)
        self.actionSaveDecrypted.setShortcut(QCoreApplication.translate("MainWindow", u"Ctrl+Shift+S", None))
        #endif // QT_CONFIG(shortcut)
        self.label.setText(QCoreApplication.translate("MainWindow", u"Version", None))
        self.groupBox_4.setTitle(QCoreApplication.translate("MainWindow", u"General", None))
        self.label_3.setText(QCoreApplication.translate("MainWindow", u"Yokai", None))
        self.attitudeLabel.setText(QCoreApplication.translate("MainWindow", u"Attitude", None))
        self.label_4.setText(QCoreApplication.translate("MainWindow", u"Nickname", None))
        self.label_5.setText(QCoreApplication.translate("MainWindow", u"Level", None))
        self.groupBox_2.setTitle(QCoreApplication.translate("MainWindow", u"Stats", None))
        self.groupBox.setTitle(QCoreApplication.translate("MainWindow", u" IV", None))
        self.label_6.setText(QCoreApplication.translate("MainWindow", u"HP", None))
        self.label_8.setText(QCoreApplication.translate("MainWindow", u"Str", None))
        self.label_9.setText(QCoreApplication.translate("MainWindow", u"Spr", None))
        self.label_11.setText(QCoreApplication.translate("MainWindow", u"Def", None))
        self.label_12.setText(QCoreApplication.translate("MainWindow", u"Spd", None))
        self.groupBox_3.setTitle(QCoreApplication.translate("MainWindow", u"EV", None))
        self.label_7.setText(QCoreApplication.translate("MainWindow", u"HP", None))
        self.label_10.setText(QCoreApplication.translate("MainWindow", u"Str", None))
        self.label_18.setText(QCoreApplication.translate("MainWindow", u"Spr", None))
        self.label_19.setText(QCoreApplication.translate("MainWindow", u"Def", None))
        self.label_20.setText(QCoreApplication.translate("MainWindow", u"Spd", None))
        self.setMaxStats.setText(QCoreApplication.translate("MainWindow", u"Set Max Stats", None))
        self.advanced.setText(QCoreApplication.translate("MainWindow", u"Advanced", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.yokaiTab), QCoreApplication.translate("MainWindow", u"Yokai", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.itemTab), QCoreApplication.translate("MainWindow", u"Item", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.equipmentTab), QCoreApplication.translate("MainWindow", u"Equipment", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.importantTab), QCoreApplication.translate("MainWindow", u"Important", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.medalliumTab), QCoreApplication.translate("MainWindow", u"Medallium", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.miscTab), QCoreApplication.translate("MainWindow", u"Misc", None))
        self.menuFile.setTitle(QCoreApplication.translate("MainWindow", u"File", None))
        pass
    # retranslateUi

    def setUi(self, MainWindow):
        globals()["statWigits"] = [
            ui.IV_HP, 
            ui.IV_STR, 
            ui.IV_SPR, 
            ui.IV_DEF, 
            ui.IV_SPD, 
            ui.EV_HP, 
            ui.EV_STR, 
            ui.EV_SPR, 
            ui.EV_DEF, 
            ui.EV_SPD, 
        ]
        globals()["iv"] = [
            (ui.IV_HP, "iv1_hp"),
            (ui.IV_STR, "iv1_str"),
            (ui.IV_SPR, "iv1_spr"),
            (ui.IV_DEF, "iv1_def"),
            (ui.IV_SPD, "iv1_spd"),
        ]
        globals()["ev"] = [
            (ui.EV_HP, "ev_hp"),
            (ui.EV_STR, "ev_str"),
            (ui.EV_SPR, "ev_spr"),
            (ui.EV_DEF, "ev_def"),
            (ui.EV_SPD, "ev_spd"),
        ]
        MainWindow.resize(541, 500)
        ui.version_label.setText('1.0.0')
        ui.nicknameEdit.setValidator(ByteValidator(60))
        ui.yokaiComboBox.addItems([indexs[0]] + [f"{i:03d}: {name}" for i, name in enumerate(indexs[1:], start=1)])
        ui.attitudeComboBox.addItems(attitudes)
        ui.setMaxStats.clicked.connect(setMaxStatsClicked)
        ui.listWidget.addItems([yokais[y["yokai"]] for y in yokailist])
        for s in statWigits:
            s.valueChanged.connect(updateStats)
        ui.listWidget.itemClicked.connect(setCurrentYokai)
        ui.listWidget.setCurrentRow(0)
        # globals()["index"] = ui.listWidget.currentRow()
        setCurrentYokai()
        ui.advanced.clicked.connect(advancedClicked)
        ui.yokaiComboBox.activated.connect(updateYokai)
        ui.attitudeComboBox.activated.connect(updateAttitude)
        ui.nicknameEdit.textChanged.connect(updateNickname)
        # app.aboutToQuit.connect(lambda x: print("quitting..."))

def updateAttitude():
    global ui, yokailist

    yokailist[ui.listWidget.currentRow()]["attitude"] = ui.attitudeComboBox.currentIndex()

def updateNickname():
    global ui, yokailist

    yokailist[ui.listWidget.currentRow()]["nickname"] = ui.nicknameEdit.text()

def updateYokai():
    global ui, yokailist

    index = ui.listWidget.currentRow()

    yokailist[index]["yokai"] = reverse_yokais[indexs[ui.yokaiComboBox.currentIndex()].lower()]
    ui.listWidget.item(index).setText(yokais[yokailist[index]["yokai"]])

def updateStats():
    global ui, yokailist, ev, iv
    index = ui.listWidget.currentRow()

    if sum([ui.IV_HP.value(), ui.IV_STR.value(), ui.IV_SPR.value(), ui.IV_DEF.value(), ui.IV_SPD.value()]) != 10:
        print("iv must add to 10") #TODO make this an alert
    else:
        for widget, data_key in iv:
            yokailist[index]["stats"][data_key] = widget.value()
    if sum([ui.EV_HP.value(), ui.EV_STR.value(), ui.EV_SPR.value(), ui.EV_DEF.value(), ui.EV_SPD.value()]) > 20:
        print("ev must be less than 20") #TODO make this an alert
    else:
        for widget, data_key in ev:
            yokailist[index]["stats"][data_key] = widget.value()

previousItem = None
def setCurrentYokai():
    global ui, previousItem, yokailist, statWigits, ev, iv
    item = ui.listWidget
    index = item.currentRow()
    
    if index != previousItem: #then set all the data
        ui.listWidget.item(index).setText(yokais[yokailist[index]["yokai"]])
        ui.yokaiComboBox.setCurrentIndex(indexs.index(yokais[yokailist[index]["yokai"]]))
        ui.nicknameEdit.setText(yokailist[index]["nickname"])
        ui.attitudeComboBox.setCurrentIndex(yokailist[index]["attitude"])
        ui.level.setValue(yokailist[index]["level"])
        for s in statWigits:
            s.valueChanged.disconnect()
        for widget, data_key in iv:
            widget.setValue(yokailist[index]["stats"][data_key])
        for widget, data_key in ev:
            widget.setValue(yokailist[index]["stats"][data_key])
        for s in statWigits:
            s.valueChanged.connect(updateStats)
    previousItem = index

def setMaxStatsClicked():
    global ui, yokailist

    index = ui.listWidget.currentRow()

    yokailist = edit_yokai(yokailist, index,level=yokailist[index]["level"])
    updateStats() #to undo to 2,2,2,2,2 iv/ 4,4,4,4,4 edit
    print("stats updated")

def advancedClicked():
    global ui, yokailist
    index = ui.listWidget.currentRow()
    def saveData():
        global previousItem, yokailist
        previousItem = None
        try: #TODO add a bad-data checker here
            parsed_data = json.loads(text_edit.toPlainText())
            yokailist[index] = parsed_data
            setCurrentYokai()
            popup.accept()  # Close the dialog after saving
        except json.JSONDecodeError:
            print("Invalid data.")

    popup = QDialog()
    popup.setWindowTitle("Advanced Editing")
    popup.setGeometry(100, 100, 400, 660)

    layout = QVBoxLayout(popup)

    text_edit = QTextEdit(popup)
    layout.addWidget(text_edit)

    text_edit.setPlainText(json.dumps(yokailist[index], indent=4))  # Display JSON data

    save_button = QPushButton("Save", popup)
    layout.addWidget(save_button)
    save_button.clicked.connect(saveData)

    result = popup.exec()  # Run the dialog and wait for it to be closed

def verifyFile(infile):
    try:
        f = open(infile, "r+b")

        if infile.endswith(".yw"):
            from pathlib import Path
            import sys
            try:
                sys.path.insert(0, str(Path(__file__).resolve().parent.parent.parent)+"/save-tools")
            except:
                sys.path.insert(0, str(Path(__file__).resolve().parent.parent.parent)+"\\save-tools") #windows jank
            import yw_save

            import io
            decrypted = io.BytesIO(yw_save.yw_proc(f.read(), False))
            f.seek(0)
            f.write(yw_save.yw_proc(main(f, edit), True))
            decrypted.close() #redundant?
        else:
            main(f, edit)

        f.close()
        return True
    except Exception as e:
        print(e)
        return False

def openFileSelectorAndVerify():
    options = QFileDialog.Options()
    file_dialog = QFileDialog()
    file_dialog.setFileMode(QFileDialog.ExistingFile)
    file_dialog.setNameFilter("Yo-kai Watch Save Files (*.yw *.ywd);;All Files (*)")

    if file_dialog.exec():
        infile = file_dialog.selectedFiles()[0]
        if infile:
            if verifyFile(infile):
                print("successfully saved")
            else:
                QMessageBox.critical(None, "Error", "Invalid file format. Please select a valid Yo-kai Watch save file.")
                openFileSelectorAndVerify()
    #any other error will just end the program

def edit(time, sun, position, location, money, yokailist, itemlist, equipmentlist, importantlist, medalliumlist):
    globals()["time"], globals()["sun"], globals()["position"], globals()["location"], globals()["money"], globals()["yokailist"], globals()["itemlist"], globals()["equipmentlist"], globals()["importantlist"], globals()["medalliumlist"] = time, sun, position, location, money, yokailist, itemlist, equipmentlist, importantlist, medalliumlist #sloppy
    ui.setUi(MainWindow)
    MainWindow.show()
    app.exec()

    return time, sun, position, location, money, yokailist, itemlist, equipmentlist, importantlist, medalliumlist

def savePrompt():
    reply = QMessageBox.question(
        MainWindow,
        'Save Changes',
        'Do you want to save your changes before quitting?',
        QMessageBox.Yes | QMessageBox.No
    )

    if reply == QMessageBox.Yes:
        return True
    return False

from dump1s import *
import json
import sys
from PySide6.QtWidgets import QFileDialog, QMessageBox, QDialog, QTextEdit
from PySide6.QtGui import QValidator

class intValidator(QValidator):
    def __init__(self, maximum, minimum=0, parent=None):
        super().__init__(parent)
        self.maximum = int(maximum)
        self.minimum = int(minimum)
    
    def validate(self, input_str, pos):
        if input_str == "" or input_str.isdigit() and self.minimum <= int(input_str) <= self.maximum:
            return (QValidator.State.Acceptable, input_str, pos)
        return (QValidator.State.Invalid, input_str, pos)

class ByteValidator(QValidator):
    def __init__(self, max_bytes, parent=None):
        super().__init__(parent)
        self.max_bytes = max_bytes

    def validate(self, input_str, pos):
        if len(input_str.encode("utf-8")) <= self.max_bytes:
            return (QValidator.State.Acceptable, input_str, pos)
        return (QValidator.Invalid, input_str, pos)

if not QApplication.instance():
    app = QApplication(sys.argv)
else:
    app = QApplication.instance()
MainWindow = QMainWindow()
ui = Ui_MainWindow()
ui.setupUi(MainWindow)

openFileSelectorAndVerify()

#here is the code for my project, i want you to edit it, KEEP ALL FUNCTIONALITY and make including but not limited to making a class for all the update functions, making index a global, fixing the global variable implimentation. also, complete the TODOs and add helpful inline comments (don't be too excessive). recall that this is not pyqt5, it is pyqt6. add functionality where the data only writes back to the file if the user agrees to do so (using a popup on closure). overall try to make the code neater and uniform, using good python programming practices