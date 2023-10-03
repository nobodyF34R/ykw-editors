# -*- coding: utf-8 -*-

################################################################################
## Form generated from reading UI file 'guixHuffv.ui'
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
    QListWidget, QListWidgetItem, QMainWindow, QPushButton,
    QSizePolicy, QSpacerItem, QSpinBox, QTabWidget,
    QTimeEdit, QVBoxLayout, QWidget)

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        if not MainWindow.objectName():
            MainWindow.setObjectName(u"MainWindow")
        MainWindow.resize(555, 535)
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
        self.version_label.setText(u"1.0.0")

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
        self.groupBox_4.setGeometry(QRect(110, 0, 401, 171))
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
        self.groupBox_2.setGeometry(QRect(110, 170, 401, 251))
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
        self.setMaxStats.setGeometry(QRect(20, 220, 101, 32))
        self.advanced = QPushButton(self.groupBox_2)
        self.advanced.setObjectName(u"advanced")
        self.advanced.setGeometry(QRect(130, 220, 100, 32))
        self.tabWidget_2.addTab(self.yokaiTab, "")
        self.itemTab = QWidget()
        self.itemTab.setObjectName(u"itemTab")
        self.groupBox_5 = QGroupBox(self.itemTab)
        self.groupBox_5.setObjectName(u"groupBox_5")
        self.groupBox_5.setGeometry(QRect(130, 0, 381, 111))
        self.horizontalLayout_5 = QHBoxLayout(self.groupBox_5)
        self.horizontalLayout_5.setSpacing(6)
        self.horizontalLayout_5.setContentsMargins(11, 11, 11, 11)
        self.horizontalLayout_5.setObjectName(u"horizontalLayout_5")
        self.formLayout_3 = QFormLayout()
        self.formLayout_3.setSpacing(6)
        self.formLayout_3.setObjectName(u"formLayout_3")
        self.formLayout_3.setFieldGrowthPolicy(QFormLayout.FieldsStayAtSizeHint)
        self.formLayout_3.setFormAlignment(Qt.AlignHCenter|Qt.AlignTop)
        self.label_13 = QLabel(self.groupBox_5)
        self.label_13.setObjectName(u"label_13")

        self.formLayout_3.setWidget(0, QFormLayout.LabelRole, self.label_13)

        self.itemComboBox = QComboBox(self.groupBox_5)
        self.itemComboBox.setObjectName(u"itemComboBox")
        self.itemComboBox.setMinimumSize(QSize(180, 0))
        self.itemComboBox.setFocusPolicy(Qt.TabFocus)

        self.formLayout_3.setWidget(0, QFormLayout.FieldRole, self.itemComboBox)

        self.label_15 = QLabel(self.groupBox_5)
        self.label_15.setObjectName(u"label_15")

        self.formLayout_3.setWidget(1, QFormLayout.LabelRole, self.label_15)

        self.itemAmount = QSpinBox(self.groupBox_5)
        self.itemAmount.setObjectName(u"itemAmount")
        self.itemAmount.setMaximum(255)
        self.itemAmount.setValue(255)

        self.formLayout_3.setWidget(1, QFormLayout.FieldRole, self.itemAmount)


        self.horizontalLayout_5.addLayout(self.formLayout_3)

        self.itemList = QListWidget(self.itemTab)
        self.itemList.setObjectName(u"itemList")
        self.itemList.setGeometry(QRect(0, 0, 121, 421))
        self.itemList.setMinimumSize(QSize(100, 0))
        self.newItemButton = QPushButton(self.itemTab)
        self.newItemButton.setObjectName(u"newItemButton")
        self.newItemButton.setGeometry(QRect(130, 390, 100, 32))
        self.currentItemButton = QPushButton(self.itemTab)
        self.currentItemButton.setObjectName(u"currentItemButton")
        self.currentItemButton.setGeometry(QRect(240, 390, 100, 32))
        self.label_14 = QLabel(self.itemTab)
        self.label_14.setObjectName(u"label_14")
        self.label_14.setGeometry(QRect(220, 120, 201, 16))
        self.tabWidget_2.addTab(self.itemTab, "")
        self.equipmentTab = QWidget()
        self.equipmentTab.setObjectName(u"equipmentTab")
        self.newEquipmentButton = QPushButton(self.equipmentTab)
        self.newEquipmentButton.setObjectName(u"newEquipmentButton")
        self.newEquipmentButton.setGeometry(QRect(130, 390, 100, 32))
        self.groupBox_6 = QGroupBox(self.equipmentTab)
        self.groupBox_6.setObjectName(u"groupBox_6")
        self.groupBox_6.setGeometry(QRect(130, 0, 381, 111))
        self.horizontalLayout_7 = QHBoxLayout(self.groupBox_6)
        self.horizontalLayout_7.setSpacing(6)
        self.horizontalLayout_7.setContentsMargins(11, 11, 11, 11)
        self.horizontalLayout_7.setObjectName(u"horizontalLayout_7")
        self.formLayout_6 = QFormLayout()
        self.formLayout_6.setSpacing(6)
        self.formLayout_6.setObjectName(u"formLayout_6")
        self.label_17 = QLabel(self.groupBox_6)
        self.label_17.setObjectName(u"label_17")

        self.formLayout_6.setWidget(0, QFormLayout.LabelRole, self.label_17)

        self.equipmentComboBox = QComboBox(self.groupBox_6)
        self.equipmentComboBox.setObjectName(u"equipmentComboBox")
        self.equipmentComboBox.setMinimumSize(QSize(180, 0))

        self.formLayout_6.setWidget(0, QFormLayout.FieldRole, self.equipmentComboBox)

        self.label_21 = QLabel(self.groupBox_6)
        self.label_21.setObjectName(u"label_21")

        self.formLayout_6.setWidget(1, QFormLayout.LabelRole, self.label_21)

        self.equipmentAmount = QSpinBox(self.groupBox_6)
        self.equipmentAmount.setObjectName(u"equipmentAmount")
        self.equipmentAmount.setMaximum(255)
        self.equipmentAmount.setValue(255)

        self.formLayout_6.setWidget(1, QFormLayout.FieldRole, self.equipmentAmount)


        self.horizontalLayout_7.addLayout(self.formLayout_6)

        self.currentEquipmentButton = QPushButton(self.equipmentTab)
        self.currentEquipmentButton.setObjectName(u"currentEquipmentButton")
        self.currentEquipmentButton.setGeometry(QRect(240, 390, 100, 32))
        self.equipmentList = QListWidget(self.equipmentTab)
        self.equipmentList.setObjectName(u"equipmentList")
        self.equipmentList.setGeometry(QRect(0, 0, 121, 421))
        self.equipmentList.setMinimumSize(QSize(100, 0))
        self.label_16 = QLabel(self.equipmentTab)
        self.label_16.setObjectName(u"label_16")
        self.label_16.setGeometry(QRect(220, 120, 201, 16))
        self.tabWidget_2.addTab(self.equipmentTab, "")
        self.importantTab = QWidget()
        self.importantTab.setObjectName(u"importantTab")
        self.importantList = QListWidget(self.importantTab)
        self.importantList.setObjectName(u"importantList")
        self.importantList.setGeometry(QRect(0, 0, 121, 421))
        self.importantList.setMinimumSize(QSize(100, 0))
        self.groupBox_7 = QGroupBox(self.importantTab)
        self.groupBox_7.setObjectName(u"groupBox_7")
        self.groupBox_7.setGeometry(QRect(130, 0, 381, 81))
        self.horizontalLayout_8 = QHBoxLayout(self.groupBox_7)
        self.horizontalLayout_8.setSpacing(6)
        self.horizontalLayout_8.setContentsMargins(11, 11, 11, 11)
        self.horizontalLayout_8.setObjectName(u"horizontalLayout_8")
        self.formLayout_7 = QFormLayout()
        self.formLayout_7.setSpacing(6)
        self.formLayout_7.setObjectName(u"formLayout_7")
        self.label_22 = QLabel(self.groupBox_7)
        self.label_22.setObjectName(u"label_22")

        self.formLayout_7.setWidget(0, QFormLayout.LabelRole, self.label_22)

        self.importantComboBox = QComboBox(self.groupBox_7)
        self.importantComboBox.setObjectName(u"importantComboBox")
        self.importantComboBox.setMinimumSize(QSize(180, 0))

        self.formLayout_7.setWidget(0, QFormLayout.FieldRole, self.importantComboBox)


        self.horizontalLayout_8.addLayout(self.formLayout_7)

        self.currentImportantButton = QPushButton(self.importantTab)
        self.currentImportantButton.setObjectName(u"currentImportantButton")
        self.currentImportantButton.setGeometry(QRect(240, 390, 100, 32))
        self.newImportantButton = QPushButton(self.importantTab)
        self.newImportantButton.setObjectName(u"newImportantButton")
        self.newImportantButton.setGeometry(QRect(130, 390, 100, 32))
        self.label_30 = QLabel(self.importantTab)
        self.label_30.setObjectName(u"label_30")
        self.label_30.setGeometry(QRect(220, 90, 201, 16))
        self.tabWidget_2.addTab(self.importantTab, "")
        self.medalliumTab = QWidget()
        self.medalliumTab.setObjectName(u"medalliumTab")
        self.groupBox_11 = QGroupBox(self.medalliumTab)
        self.groupBox_11.setObjectName(u"groupBox_11")
        self.groupBox_11.setGeometry(QRect(0, 0, 161, 421))
        self.seenList = QListWidget(self.groupBox_11)
        self.seenList.setObjectName(u"seenList")
        self.seenList.setGeometry(QRect(0, 20, 161, 311))
        self.seenList.setFocusPolicy(Qt.StrongFocus)
        self.seenCheckAll_2 = QPushButton(self.groupBox_11)
        self.seenCheckAll_2.setObjectName(u"seenCheckAll_2")
        self.seenCheckAll_2.setGeometry(QRect(30, 340, 100, 32))
        self.seenUncheckAll_2 = QPushButton(self.groupBox_11)
        self.seenUncheckAll_2.setObjectName(u"seenUncheckAll_2")
        self.seenUncheckAll_2.setGeometry(QRect(30, 380, 100, 32))
        self.groupBox_12 = QGroupBox(self.medalliumTab)
        self.groupBox_12.setObjectName(u"groupBox_12")
        self.groupBox_12.setGeometry(QRect(180, 0, 161, 421))
        self.befriendedList = QListWidget(self.groupBox_12)
        self.befriendedList.setObjectName(u"befriendedList")
        self.befriendedList.setGeometry(QRect(0, 20, 161, 311))
        self.befriendedUncheckAll_2 = QPushButton(self.groupBox_12)
        self.befriendedUncheckAll_2.setObjectName(u"befriendedUncheckAll_2")
        self.befriendedUncheckAll_2.setGeometry(QRect(30, 380, 100, 32))
        self.befriendedCheckAll_2 = QPushButton(self.groupBox_12)
        self.befriendedCheckAll_2.setObjectName(u"befriendedCheckAll_2")
        self.befriendedCheckAll_2.setGeometry(QRect(30, 340, 100, 32))
        self.groupBox_13 = QGroupBox(self.medalliumTab)
        self.groupBox_13.setObjectName(u"groupBox_13")
        self.groupBox_13.setGeometry(QRect(360, 0, 161, 421))
        self.cameraList = QListWidget(self.groupBox_13)
        self.cameraList.setObjectName(u"cameraList")
        self.cameraList.setGeometry(QRect(0, 20, 161, 311))
        self.cameraUncheckAll = QPushButton(self.groupBox_13)
        self.cameraUncheckAll.setObjectName(u"cameraUncheckAll")
        self.cameraUncheckAll.setGeometry(QRect(30, 380, 100, 32))
        self.cameraCheckAll = QPushButton(self.groupBox_13)
        self.cameraCheckAll.setObjectName(u"cameraCheckAll")
        self.cameraCheckAll.setGeometry(QRect(30, 340, 100, 32))
        self.tabWidget_2.addTab(self.medalliumTab, "")
        self.miscTab = QWidget()
        self.miscTab.setObjectName(u"miscTab")
        self.groupBox_14 = QGroupBox(self.miscTab)
        self.groupBox_14.setObjectName(u"groupBox_14")
        self.groupBox_14.setGeometry(QRect(0, 0, 251, 71))
        self.layoutWidget_2 = QWidget(self.groupBox_14)
        self.layoutWidget_2.setObjectName(u"layoutWidget_2")
        self.layoutWidget_2.setGeometry(QRect(10, 30, 231, 31))
        self.formLayout_8 = QFormLayout(self.layoutWidget_2)
        self.formLayout_8.setSpacing(6)
        self.formLayout_8.setContentsMargins(11, 11, 11, 11)
        self.formLayout_8.setObjectName(u"formLayout_8")
        self.formLayout_8.setContentsMargins(0, 0, 0, 0)
        self.label_24 = QLabel(self.layoutWidget_2)
        self.label_24.setObjectName(u"label_24")

        self.formLayout_8.setWidget(0, QFormLayout.LabelRole, self.label_24)

        self.timeEdit = QTimeEdit(self.layoutWidget_2)
        self.timeEdit.setObjectName(u"timeEdit")
        self.timeEdit.setFocusPolicy(Qt.WheelFocus)

        self.formLayout_8.setWidget(0, QFormLayout.FieldRole, self.timeEdit)

        self.groupBox_15 = QGroupBox(self.miscTab)
        self.groupBox_15.setObjectName(u"groupBox_15")
        self.groupBox_15.setGeometry(QRect(270, 0, 251, 71))
        self.layoutWidget_3 = QWidget(self.groupBox_15)
        self.layoutWidget_3.setObjectName(u"layoutWidget_3")
        self.layoutWidget_3.setGeometry(QRect(10, 30, 236, 31))
        self.formLayout_9 = QFormLayout(self.layoutWidget_3)
        self.formLayout_9.setSpacing(6)
        self.formLayout_9.setContentsMargins(11, 11, 11, 11)
        self.formLayout_9.setObjectName(u"formLayout_9")
        self.formLayout_9.setContentsMargins(0, 0, 0, 0)
        self.label_25 = QLabel(self.layoutWidget_3)
        self.label_25.setObjectName(u"label_25")

        self.formLayout_9.setWidget(0, QFormLayout.LabelRole, self.label_25)

        self.locationComboBox = QComboBox(self.layoutWidget_3)
        self.locationComboBox.setObjectName(u"locationComboBox")
        self.locationComboBox.setMinimumSize(QSize(180, 0))

        self.formLayout_9.setWidget(0, QFormLayout.FieldRole, self.locationComboBox)

        self.groupBox_16 = QGroupBox(self.miscTab)
        self.groupBox_16.setObjectName(u"groupBox_16")
        self.groupBox_16.setGeometry(QRect(270, 70, 251, 121))
        self.layoutWidget_4 = QWidget(self.groupBox_16)
        self.layoutWidget_4.setObjectName(u"layoutWidget_4")
        self.layoutWidget_4.setGeometry(QRect(10, 30, 236, 85))
        self.formLayout_10 = QFormLayout(self.layoutWidget_4)
        self.formLayout_10.setSpacing(6)
        self.formLayout_10.setContentsMargins(11, 11, 11, 11)
        self.formLayout_10.setObjectName(u"formLayout_10")
        self.formLayout_10.setContentsMargins(0, 0, 0, 0)
        self.label_26 = QLabel(self.layoutWidget_4)
        self.label_26.setObjectName(u"label_26")

        self.formLayout_10.setWidget(0, QFormLayout.LabelRole, self.label_26)

        self.label_27 = QLabel(self.layoutWidget_4)
        self.label_27.setObjectName(u"label_27")

        self.formLayout_10.setWidget(1, QFormLayout.LabelRole, self.label_27)

        self.label_2 = QLabel(self.layoutWidget_4)
        self.label_2.setObjectName(u"label_2")

        self.formLayout_10.setWidget(2, QFormLayout.LabelRole, self.label_2)

        self.xEdit = QLineEdit(self.layoutWidget_4)
        self.xEdit.setObjectName(u"xEdit")

        self.formLayout_10.setWidget(0, QFormLayout.FieldRole, self.xEdit)

        self.yEdit = QLineEdit(self.layoutWidget_4)
        self.yEdit.setObjectName(u"yEdit")

        self.formLayout_10.setWidget(1, QFormLayout.FieldRole, self.yEdit)

        self.zEdit = QLineEdit(self.layoutWidget_4)
        self.zEdit.setObjectName(u"zEdit")

        self.formLayout_10.setWidget(2, QFormLayout.FieldRole, self.zEdit)

        self.groupBox_17 = QGroupBox(self.miscTab)
        self.groupBox_17.setObjectName(u"groupBox_17")
        self.groupBox_17.setGeometry(QRect(0, 70, 251, 121))
        self.layoutWidget_5 = QWidget(self.groupBox_17)
        self.layoutWidget_5.setObjectName(u"layoutWidget_5")
        self.layoutWidget_5.setGeometry(QRect(10, 30, 231, 71))
        self.formLayout_11 = QFormLayout(self.layoutWidget_5)
        self.formLayout_11.setSpacing(6)
        self.formLayout_11.setContentsMargins(11, 11, 11, 11)
        self.formLayout_11.setObjectName(u"formLayout_11")
        self.formLayout_11.setContentsMargins(0, 0, 0, 0)
        self.label_29 = QLabel(self.layoutWidget_5)
        self.label_29.setObjectName(u"label_29")

        self.formLayout_11.setWidget(0, QFormLayout.LabelRole, self.label_29)

        self.moneyEdit = QLineEdit(self.layoutWidget_5)
        self.moneyEdit.setObjectName(u"moneyEdit")

        self.formLayout_11.setWidget(0, QFormLayout.FieldRole, self.moneyEdit)

        self.label_23 = QLabel(self.groupBox_17)
        self.label_23.setObjectName(u"label_23")
        self.label_23.setGeometry(QRect(10, 60, 223, 28))
        self.label_28 = QLabel(self.miscTab)
        self.label_28.setObjectName(u"label_28")
        self.label_28.setGeometry(QRect(40, 400, 441, 16))
        self.tabWidget_2.addTab(self.miscTab, "")

        self.verticalLayout.addWidget(self.tabWidget_2)


        self.gridLayout.addLayout(self.verticalLayout, 0, 0, 1, 1)

        MainWindow.setCentralWidget(self.centralWidget)

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
        self.groupBox_5.setTitle(QCoreApplication.translate("MainWindow", u"General", None))
        self.label_13.setText(QCoreApplication.translate("MainWindow", u"Item", None))
        self.label_15.setText(QCoreApplication.translate("MainWindow", u"Amount", None))
        self.newItemButton.setText(QCoreApplication.translate("MainWindow", u"Set New", None))
        self.currentItemButton.setText(QCoreApplication.translate("MainWindow", u"Set Current", None))
        self.label_14.setText(QCoreApplication.translate("MainWindow", u"set current to blank to remove it", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.itemTab), QCoreApplication.translate("MainWindow", u"Item", None))
        self.newEquipmentButton.setText(QCoreApplication.translate("MainWindow", u"Set New", None))
        self.groupBox_6.setTitle(QCoreApplication.translate("MainWindow", u"General", None))
        self.label_17.setText(QCoreApplication.translate("MainWindow", u"Equipment", None))
        self.label_21.setText(QCoreApplication.translate("MainWindow", u"Amount", None))
        self.currentEquipmentButton.setText(QCoreApplication.translate("MainWindow", u"Set Current", None))
        self.label_16.setText(QCoreApplication.translate("MainWindow", u"set current to blank to remove it", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.equipmentTab), QCoreApplication.translate("MainWindow", u"Equipment", None))
        self.groupBox_7.setTitle(QCoreApplication.translate("MainWindow", u"General", None))
        self.label_22.setText(QCoreApplication.translate("MainWindow", u"Important", None))
        self.currentImportantButton.setText(QCoreApplication.translate("MainWindow", u"Set Current", None))
        self.newImportantButton.setText(QCoreApplication.translate("MainWindow", u"Set New", None))
        self.label_30.setText(QCoreApplication.translate("MainWindow", u"set current to blank to remove it", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.importantTab), QCoreApplication.translate("MainWindow", u"Important", None))
        self.groupBox_11.setTitle(QCoreApplication.translate("MainWindow", u"Seen", None))
        self.seenCheckAll_2.setText(QCoreApplication.translate("MainWindow", u"Check All", None))
        self.seenUncheckAll_2.setText(QCoreApplication.translate("MainWindow", u"Uncheck All", None))
        self.groupBox_12.setTitle(QCoreApplication.translate("MainWindow", u"Befriended", None))
        self.befriendedUncheckAll_2.setText(QCoreApplication.translate("MainWindow", u"Uncheck All", None))
        self.befriendedCheckAll_2.setText(QCoreApplication.translate("MainWindow", u"Check All", None))
        self.groupBox_13.setTitle(QCoreApplication.translate("MainWindow", u"Camera", None))
        self.cameraUncheckAll.setText(QCoreApplication.translate("MainWindow", u"Uncheck All", None))
        self.cameraCheckAll.setText(QCoreApplication.translate("MainWindow", u"Check All", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.medalliumTab), QCoreApplication.translate("MainWindow", u"Medallium", None))
        self.groupBox_14.setTitle(QCoreApplication.translate("MainWindow", u"Time", None))
        self.label_24.setText(QCoreApplication.translate("MainWindow", u"Time", None))
        self.timeEdit.setDisplayFormat(QCoreApplication.translate("MainWindow", u"hh:mm", None))
        self.groupBox_15.setTitle(QCoreApplication.translate("MainWindow", u"Location", None))
        self.label_25.setText(QCoreApplication.translate("MainWindow", u"Location", None))
        self.groupBox_16.setTitle(QCoreApplication.translate("MainWindow", u"Position", None))
        self.label_26.setText(QCoreApplication.translate("MainWindow", u"X", None))
        self.label_27.setText(QCoreApplication.translate("MainWindow", u"Y", None))
        self.label_2.setText(QCoreApplication.translate("MainWindow", u"Z", None))
        self.groupBox_17.setTitle(QCoreApplication.translate("MainWindow", u"General", None))
        self.label_29.setText(QCoreApplication.translate("MainWindow", u"Money", None))
        self.label_23.setText(QCoreApplication.translate("MainWindow", u" TODO: add Gatcha and auto position.", None))
        self.label_28.setText(QCoreApplication.translate("MainWindow", u"WARNING: randomly editing you position will seriously mess up your save.", None))
        self.tabWidget_2.setTabText(self.tabWidget_2.indexOf(self.miscTab), QCoreApplication.translate("MainWindow", u"Misc", None))
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
        MainWindow.resize(550, 500)
        ui.version_label.setText('1.0.0')
        ui.nicknameEdit.setValidator(ByteValidator(60))
        ui.yokaiComboBox.addItems([f"{i:03d}: {name}" for i, name in enumerate(indexs[1:], start=1)])
        ui.itemComboBox.addItems([""] + [value for value in items.values()])
        ui.equipmentComboBox.addItems([""] + [value for value in equipments.values()])
        ui.importantComboBox.addItems([""] + [value for value in importants.values()])
        locationList = [value for value in locations.values()]
        ui.locationComboBox.addItems(locationList)
        ui.attitudeComboBox.addItems(attitudes)
        ui.setMaxStats.clicked.connect(setMaxStatsClicked)
        ui.listWidget.addItems([yokais[y["yokai"]] for y in yokailist])
        ui.itemList.addItems([items[i["item"]] for i in itemlist])
        ui.equipmentList.addItems([equipments[e["equipment"]] for e in equipmentlist])
        ui.importantList.addItems([importants[i["important"]] for i in importantlist])
        for s in statWigits:
            s.valueChanged.connect(updateStats)
        ui.listWidget.itemClicked.connect(setCurrentYokai)
        ui.listWidget.setCurrentRow(0)
        setCurrentYokai()
        ui.advanced.clicked.connect(advancedClicked)
        ui.yokaiComboBox.activated.connect(updateYokai)
        ui.attitudeComboBox.activated.connect(updateAttitude)
        ui.nicknameEdit.textChanged.connect(updateNickname)
        ui.newItemButton.clicked.connect(newItemClicked)
        ui.currentItemButton.clicked.connect(currentItemClicked)
        ui.newEquipmentButton.clicked.connect(newEquipmentClicked)
        ui.currentEquipmentButton.clicked.connect(currentEquipmentClicked)
        ui.newImportantButton.clicked.connect(newImportantClicked)
        ui.currentImportantButton.clicked.connect(currentImportantClicked)
        ui.locationComboBox.setCurrentIndex(locationList.index(locations[location]))
        ui.locationComboBox.activated.connect(updateLocation)
        ui.moneyEdit.setValidator(intValidator(4294967295))
        ui.moneyEdit.setFixedWidth(87)
        ui.xEdit.setValidator(intValidator(4294967295))
        ui.xEdit.setFixedWidth(87)
        ui.yEdit.setValidator(intValidator(4294967295))
        ui.yEdit.setFixedWidth(87)
        ui.zEdit.setValidator(intValidator(4294967295))
        ui.zEdit.setFixedWidth(87)
        ui.moneyEdit.setText(str(money))
        ui.xEdit.setText(str(position[0]))
        ui.yEdit.setText(str(position[1]))
        ui.zEdit.setText(str(position[2]))

        realtime = (sun*360)+((time/65535)*360) #in minutes
        ui.timeEdit.setTime(QTime(int(realtime/60), round(realtime%60))) #forget about seconds. no need to be so specific

        for index, inner_list in enumerate(indexs[1:]):
            item_seen = QListWidgetItem(ui.seenList)
            item_befriended = QListWidgetItem(ui.befriendedList)
            item_camera = QListWidgetItem(ui.cameraList)

            checkbox_seen = QCheckBox(inner_list)
            checkbox_befriended = QCheckBox(inner_list)
            checkbox_camera = QCheckBox(inner_list)

            checkbox_seen.setChecked(medalliumlist[0][index+1])
            checkbox_befriended.setChecked(medalliumlist[1][index+1])
            checkbox_camera.setChecked(medalliumlist[3][index+1])

            checkbox_seen.stateChanged.connect(lambda state, i=index, l1=checkbox_befriended, l2=checkbox_camera: checkbox_changed(state, i, l1, l2, 0))
            checkbox_befriended.stateChanged.connect(lambda state, i=index, l1=checkbox_seen, l2=checkbox_camera: checkbox_changed(state, i, l1, l2, 1))
            checkbox_camera.stateChanged.connect(lambda state, i=index, l1=checkbox_seen, l2=checkbox_befriended: checkbox_changed(state, i, l1, l2, 3))

            ui.seenList.setItemWidget(item_seen, checkbox_seen)
            ui.befriendedList.setItemWidget(item_befriended, checkbox_befriended)
            ui.cameraList.setItemWidget(item_camera, checkbox_camera)

        ui.seenCheckAll_2.clicked.connect(lambda: checkAll(0))
        ui.befriendedCheckAll_2.clicked.connect(lambda: checkAll(1))
        ui.cameraCheckAll.clicked.connect(lambda: checkAll(3))

        ui.seenUncheckAll_2.clicked.connect(lambda: unCheckAll(0))
        ui.befriendedUncheckAll_2.clicked.connect(lambda: unCheckAll(1))
        ui.cameraUncheckAll.clicked.connect(lambda: unCheckAll(3))

def checkAll(sublist):
    global ui, medalliumlist
    if sublist == 0:
        item = ui.seenList
    elif sublist == 1:
        item = ui.befriendedList
    else:
        for index in range(ui.cameraList.count()):
            ui.cameraList.itemWidget(ui.cameraList.item(index)).setChecked(True)
        for i in range(1, len(medalliumlist[sublist]) - 7):
            medalliumlist[sublist][i] = True
        return
    for index in range(item.count()):
        item.itemWidget(item.item(index)).setChecked(True)
    for i in range(1, len(medalliumlist[sublist]) - 7):
        medalliumlist[sublist][i] = True
    for i in range(224, len(medalliumlist[sublist]) - 7):
        medalliumlist[0][i] = True
        medalliumlist[1][i] = True

def unCheckAll(sublist):
    global ui, medalliumlist
    if sublist == 0:
        item = ui.seenList
    elif sublist == 1:
        item = ui.befriendedList
    else:
        for index in range(ui.cameraList.count()):
            ui.cameraList.itemWidget(ui.cameraList.item(index)).setChecked(False)
        for i in range(1, len(medalliumlist[sublist]) - 7):
            medalliumlist[sublist][i] = False
        return
    for index in range(item.count()):
        item.itemWidget(item.item(index)).setChecked(False)
    for i in range(1, len(medalliumlist[sublist]) - 7):
        medalliumlist[sublist][i] = False
    for i in range(224, len(medalliumlist[sublist]) - 7):
        medalliumlist[0][i] = False
        medalliumlist[1][i] = False

def checkbox_changed(state, index, l1, l2, sublist):
    if index >= 223:
        if sublist == 0:
            medalliumlist[1][index+1] = (state == 2)
            l1.setChecked(medalliumlist[1][index+1])
        elif sublist == 1:
            medalliumlist[0][index+1] = (state == 2)
            l1.setChecked(medalliumlist[0][index+1])
    medalliumlist[sublist][index+1] = (state == 2)

def updateLocation():
    global ui, location

    location = reverse_locations[ui.locationComboBox.currentText().lower()]

def updateAttitude():
    global ui, yokailist

    yokailist[ui.listWidget.currentRow()]["attitude"] = ui.attitudeComboBox.currentIndex()

def updateNickname():
    global ui, yokailist

    yokailist[ui.listWidget.currentRow()]["nickname"] = ui.nicknameEdit.text()

def updateYokai():
    global ui, yokailist

    index = ui.listWidget.currentRow()

    yokailist[index]["yokai"] = reverse_yokais[indexs[ui.yokaiComboBox.currentIndex()+1].lower()]
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
        item.item(index).setText(yokais[yokailist[index]["yokai"]])
        ui.yokaiComboBox.setCurrentIndex(indexs.index(yokais[yokailist[index]["yokai"]])-1)
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

def newItemClicked():
    global ui, itemlist

    item = ui.itemList

    itemName = ui.itemComboBox.currentText().lower()

    if itemName != "":
        itemlist = edit_item(itemlist, -1, reverse_items[itemName], ui.itemAmount.value())
        item.addItems([items[itemlist[-1]["item"]]])

def currentItemClicked():
    global ui, itemlist

    item = ui.itemList
    index = item.currentRow()

    itemName = ui.itemComboBox.currentText().lower()

    if index != -1:
        if itemName == "":
            itemlist.pop(index) #may need to update num1 and num2
            item.takeItem(index)
        else:
            itemlist = edit_item(itemlist, index, reverse_items[itemName], ui.itemAmount.value())
            item.item(index).setText(items[itemlist[index]["item"]])

def newEquipmentClicked():
    global ui, equipmentlist

    item = ui.equipmentList

    equipmentName = ui.equipmentComboBox.currentText().lower()

    if equipmentName != "":
        equipmentlist = edit_equipment(equipmentlist, -1, reverse_equipments[equipmentName], ui.equipmentAmount.value())
        item.addItems([equipments[equipmentlist[-1]["equipment"]]])

def currentEquipmentClicked():
    global ui, equipmentlist

    item = ui.equipmentList
    index = item.currentRow()

    equipmentName = ui.equipmentComboBox.currentText().lower()

    if index != -1:
        if equipmentName == "":
            equipmentlist.pop(index) #may need to update num1 and num2
            item.takeItem(index)
        else:
            equipmentlist = edit_equipment(equipmentlist, index, reverse_equipments[equipmentName], ui.equipmentAmount.value())
            item.item(index).setText(equipments[equipmentlist[index]["equipment"]])

def newImportantClicked():
    global ui, importantlist

    item = ui.importantList

    importantName = ui.importantComboBox.currentText().lower()

    if importantName != "":
        importantlist = edit_important(importantlist, -1, reverse_importants[importantName])
        item.addItems([importants[importantlist[-1]["important"]]])

def currentImportantClicked():
    global ui, importantlist

    item = ui.importantList
    index = item.currentRow()

    importantName = ui.importantComboBox.currentText().lower()

    if index != -1:
        if importantName == "":
            importantlist.pop(index) #may need to update num1 and num2
            item.takeItem(index)
        else:
            importantlist = edit_important(importantlist, index, reverse_importants[importantName])
            item.item(index).setText(importants[importantlist[index]["important"]])

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
            f.write(yw_save.yw_proc(main(decrypted, edit), True))
            decrypted.close() #redundant?
        else:
            main(f, edit)

        f.close()
        return True
    except Exception as e:
        # raise e
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

    globals()["money"] = int(ui.moneyEdit.text())
    globals()["position"] = [int(ui.xEdit.text()), int(ui.yEdit.text()), int(ui.zEdit.text())]

    globals()["sun"] = ui.timeEdit.time().hour()//6
    globals()["time"] = round((((ui.timeEdit.time().hour()%6)*60 + ui.timeEdit.time().minute())/360)*65535)

    return globals()["time"], globals()["sun"], globals()["position"], globals()["location"], globals()["money"], globals()["yokailist"], globals()["itemlist"], globals()["equipmentlist"], globals()["importantlist"], globals()["medalliumlist"] #the immutables such as time must be in the global format, but the lists don't have to be. i just made it this way for consistancy

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
from PySide6.QtWidgets import QFileDialog, QMessageBox, QDialog, QTextEdit, QCheckBox
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