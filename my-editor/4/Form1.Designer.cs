
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Another_YW_4_Save_Editor
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.foodRemove = new System.Windows.Forms.Button();
            this.foodReplace = new System.Windows.Forms.Button();
            this.foodQtdNbox = new System.Windows.Forms.NumericUpDown();
            this.label36 = new System.Windows.Forms.Label();
            this.foodCbox = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.foodItemList = new System.Windows.Forms.ListView();
            this.foodIdColumn1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.foodIdColumn2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.foodOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.foodItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.foodQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.mainCharacterViewList = new System.Windows.Forms.ListView();
            this.mainCharacterColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.removeMainCharacter = new System.Windows.Forms.Button();
            this.saveMainCharacterChanges = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.characterOrderIdNbox = new System.Windows.Forms.NumericUpDown();
            this.characterId2Nbox = new System.Windows.Forms.NumericUpDown();
            this.characterId1Nbox = new System.Windows.Forms.NumericUpDown();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.characterIdNbox = new System.Windows.Forms.NumericUpDown();
            this.label40 = new System.Windows.Forms.Label();
            this.mainCharacterCbox = new System.Windows.Forms.ComboBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.characterExpNbox = new System.Windows.Forms.NumericUpDown();
            this.characterYpNbox = new System.Windows.Forms.NumericUpDown();
            this.characterPGNbox = new System.Windows.Forms.NumericUpDown();
            this.characterHpNbox = new System.Windows.Forms.NumericUpDown();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.characterLevelNbox = new System.Windows.Forms.NumericUpDown();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.characterSkillLoaderBtn = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.characterExSkl3Cbox = new System.Windows.Forms.ComboBox();
            this.characterExSkl4Cbox = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.characterExSkl2Cbox = new System.Windows.Forms.ComboBox();
            this.characterExSklCbox = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.characterSpSklCbox = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.characterBAtkCbox = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.characterStNbox = new System.Windows.Forms.NumericUpDown();
            this.characterYpPlusNbox = new System.Windows.Forms.NumericUpDown();
            this.characterHpPlusNbox = new System.Windows.Forms.NumericUpDown();
            this.characterSdNbox = new System.Windows.Forms.NumericUpDown();
            this.characterPdNbox = new System.Windows.Forms.NumericUpDown();
            this.characterSpNbox = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.katieNameTbox = new System.Windows.Forms.TextBox();
            this.nateNameTbox = new System.Windows.Forms.TextBox();
            this.jackNameTbox = new System.Windows.Forms.TextBox();
            this.akinoriNameTbox = new System.Windows.Forms.TextBox();
            this.summerNameTbox = new System.Windows.Forms.TextBox();
            this.toumaNameTbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.positionZNbox = new System.Windows.Forms.NumericUpDown();
            this.positionYNbox = new System.Windows.Forms.NumericUpDown();
            this.positionXNbox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mapCbox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gatchaMax = new System.Windows.Forms.NumericUpDown();
            this.gatchaDaily = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.moneyNbox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.yokaiTab = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.yokaiTbox = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.yokaiOrderNbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiId2Nbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiId1Nbox = new System.Windows.Forms.NumericUpDown();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.yokaiIdNbox = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.yokaiCbox = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.yokaiExpNbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiYpNbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiPgNbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiHpNbox = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.isAdvancedList = new System.Windows.Forms.CheckBox();
            this.yokaiLevelNbox = new System.Windows.Forms.NumericUpDown();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.yokaiExSkl3Nbox = new System.Windows.Forms.ComboBox();
            this.yokaiExSkl4Nbox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.yokaiExSkl2Nbox = new System.Windows.Forms.ComboBox();
            this.yokaiExSklNbox = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.yokaiSpSklCbox = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.yokaiBAtkCbox = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.yokaiStPlusNbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiYpPlusNbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiHpPlusNbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiSdPlusNbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiPdPlusNbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiSpPlusNbox = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.yokaiUnknown4Nbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiUnknown9Nbox = new System.Windows.Forms.NumericUpDown();
            this.label59 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.yokaiUnknown1Nbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiUnknown8Nbox = new System.Windows.Forms.NumericUpDown();
            this.label68 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.yokaiUnknown10Nbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiUnknown7Nbox = new System.Windows.Forms.NumericUpDown();
            this.label69 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.yokaiUnknown11Nbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiUnknown6Nbox = new System.Windows.Forms.NumericUpDown();
            this.label70 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.yokaiUnknown12Nbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiUnknown5Nbox = new System.Windows.Forms.NumericUpDown();
            this.label71 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.yokaiUnknown13Nbox = new System.Windows.Forms.NumericUpDown();
            this.label72 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.yokaiUnknown14Nbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiUnknown3Nbox = new System.Windows.Forms.NumericUpDown();
            this.label73 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.yokaiUnknown15Nbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiUnknown2Nbox = new System.Windows.Forms.NumericUpDown();
            this.label74 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.yokaiUnknown16Nbox = new System.Windows.Forms.NumericUpDown();
            this.yokaiUnknown17Nbox = new System.Windows.Forms.NumericUpDown();
            this.label75 = new System.Windows.Forms.Label();
            this.yokaiListView = new System.Windows.Forms.ListView();
            this.yokaiSig = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.removeEquipBtn = new System.Windows.Forms.Button();
            this.replaceEquipBtn = new System.Windows.Forms.Button();
            this.equipQtNbox = new System.Windows.Forms.NumericUpDown();
            this.label76 = new System.Windows.Forms.Label();
            this.equipCbox = new System.Windows.Forms.ComboBox();
            this.label77 = new System.Windows.Forms.Label();
            this.equipListView = new System.Windows.Forms.ListView();
            this.equipIdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.equipId2Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.equipOrderColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.equipNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.equipQtColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodQtdNbox)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.characterOrderIdNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterId2Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterId1Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterIdNbox)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.characterExpNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterYpNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterPGNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterHpNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterLevelNbox)).BeginInit();
            this.tabPage8.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.characterStNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterYpPlusNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterHpPlusNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterSdNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterPdNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterSpNbox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionZNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionYNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionXNbox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gatchaMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gatchaDaily)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyNbox)).BeginInit();
            this.yokaiTab.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiOrderNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiId2Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiId1Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiIdNbox)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiExpNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiYpNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiPgNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiHpNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiLevelNbox)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiStPlusNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiYpPlusNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiHpPlusNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiSdPlusNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiPdPlusNbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiSpPlusNbox)).BeginInit();
            this.tabPage10.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown4Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown9Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown1Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown8Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown10Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown7Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown11Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown6Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown12Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown5Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown13Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown14Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown3Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown15Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown2Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown16Nbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown17Nbox)).BeginInit();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipQtNbox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.foodRemove);
            this.tabPage2.Controls.Add(this.foodReplace);
            this.tabPage2.Controls.Add(this.foodQtdNbox);
            this.tabPage2.Controls.Add(this.label36);
            this.tabPage2.Controls.Add(this.foodCbox);
            this.tabPage2.Controls.Add(this.label35);
            this.tabPage2.Controls.Add(this.foodItemList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(499, 294);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Foods/Consumables";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // foodRemove
            // 
            this.foodRemove.Location = new System.Drawing.Point(418, 30);
            this.foodRemove.Name = "foodRemove";
            this.foodRemove.Size = new System.Drawing.Size(64, 20);
            this.foodRemove.TabIndex = 5;
            this.foodRemove.Text = "Remove";
            this.foodRemove.UseVisualStyleBackColor = true;
            this.foodRemove.Click += new System.EventHandler(this.foodRemove_Click);
            // 
            // foodReplace
            // 
            this.foodReplace.Location = new System.Drawing.Point(341, 30);
            this.foodReplace.Name = "foodReplace";
            this.foodReplace.Size = new System.Drawing.Size(64, 20);
            this.foodReplace.TabIndex = 5;
            this.foodReplace.Text = "Replace";
            this.foodReplace.UseVisualStyleBackColor = true;
            this.foodReplace.Click += new System.EventHandler(this.foodReplace_Click);
            // 
            // foodQtdNbox
            // 
            this.foodQtdNbox.Location = new System.Drawing.Point(261, 30);
            this.foodQtdNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.foodQtdNbox.Name = "foodQtdNbox";
            this.foodQtdNbox.Size = new System.Drawing.Size(67, 20);
            this.foodQtdNbox.TabIndex = 4;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(207, 32);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(49, 13);
            this.label36.TabIndex = 3;
            this.label36.Text = "Quantity:";
            // 
            // foodCbox
            // 
            this.foodCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.foodCbox.FormattingEnabled = true;
            this.foodCbox.Items.AddRange(new object[] {
            "",
            "Plum Rice Ball                       ",
            "Salmon Rice Ball                     ",
            "Burger Rice Ball                     ",
            "Roe Rice Ball                        ",
            "Shrimp Rice Ball                     ",
            "Big Bomb Sushi                       ",
            "Sandwich                             ",
            "Custard Bread                        ",
            "Anko                                 ",
            "Curry Bread                          ",
            "Soba Sandwich                        ",
            "Baguette                             ",
            "Blehgel                              ",
            "Drill Croissant                      ",
            "Humdrum Gum                          ",
            "Inazuma Black                        ",
            "Gooey Candy                          ",
            "Giant Cracker                        ",
            "Opulent Caramel                      ",
            "Fruit Drops                          ",
            "Candy Apple                          ",
            "Milk                                 ",
            "Coffee Milk                          ",
            "Strawberry Milk                      ",
            "Fruit Milk                           ",
            "Amazing Milk                         ",
            "Y-Cola                               ",
            "Soul Tea                             ",
            "Ramune                               ",
            "Oshiruko Soup                        ",
            "Doctor Rapper                        ",
            "Aristocrat Tea                       ",
            "Big Boss Coffee                      ",
            "VoltXtreme                           ",
            "Hamburger                            ",
            "Cheeseburger                         ",
            "Teriyaki Chicken Burger              ",
            "Double Burger                        ",
            "Nom Burger                           ",
            "Extreme Star Burg.                   ",
            "MogMog Giant                         ",
            "Ramen Cup                            ",
            "Instant Ramen                        ",
            "Pork Ramen                           ",
            "Miso Corn Ramen                      ",
            "Ajitsuke Tamago Ramen                ",
            "Noodle King                          ",
            "Everything Ramen                     ",
            "Saburo Hell Ramen                    ",
            "Cucumber Roll                        ",
            "Shrimp Sushi                         ",
            "Egg Sushi                            ",
            "Fin Sushi                            ",
            "Salmon Roe Sushi                     ",
            "Fatty Tuna Sushi                     ",
            "Sea Urchin Sushi                     ",
            "Sushi Set                            ",
            "High-End Sushi                       ",
            "Banana                               ",
            "Grapes                               ",
            "Mandarin Orange                      ",
            "Apple                                ",
            "Pineapple                            ",
            "Giant Strawberry                     ",
            "Melon Queen                          ",
            "Carrot                               ",
            "Cucumber                             ",
            "Avocado                              ",
            "Bamboo Shoot                         ",
            "Ripe Tomatoes                        ",
            "Matsutake                            ",
            "Chicken Thigh                        ",
            "Ground Meat Cutlet                   ",
            "Salad Chicken                        ",
            "Beef Tongue                          ",
            "Marbled Beef                         ",
            "Sirloin Steak                        ",
            "Chateaubriand                        ",
            "Dried Mackerel                       ",
            "Yellowtail                           ",
            "Grilled Squid                        ",
            "Grilled Ayu                          ",
            "Kind Salmon                          ",
            "Choice Tuna                          ",
            "Supreme Urchin Bowl                  ",
            "Chicken Curry                        ",
            "Lamb Curry                           ",
            "Green Curry                          ",
            "Seafood Curry                        ",
            "Keema Curry                          ",
            "Megaton Cutlet Curry                 ",
            "Spirit Doughnut                      ",
            "Soul Soughnut                        ",
            "Big Imagawayaki                      ",
            "Cheesecake                           ",
            "Tiramisu                             ",
            "Siberia                              ",
            "Shortcake                            ",
            "Sakura Mochi On Leaf                 ",
            "Royal Pancakes                       ",
            "Strawberry Princess Parfait          ",
            "Shirayuki Daifuku                    ",
            "Red Bean Jelly                       ",
            "Luxury Castella                      ",
            "Soba Saemon                          ",
            "Soba Noodles                         ",
            "Noodles in Broth                     ",
            "Fishy Noodles                        ",
            "Duck Noodles                         ",
            "Yukisuke Noodles                     ",
            "Maruten Noodles                      ",
            "Meat Noodles                         ",
            "Curry Noodles                        ",
            "Tempura Noodles                      ",
            "Lettuce Taro                         ",
            "Lucky Bean                           ",
            "Potato Chips                         ",
            "Tasty Nibbles                        ",
            "Spicy Chips                          ",
            "Cheesy Chips                         ",
            "Melty Pizza Chips                    ",
            "Snow-Pea Snack                       ",
            "Chocobar                             ",
            "Gorigori                             ",
            "Ice Cream                            ",
            "Macha Softcream                      ",
            "Sakura Softcream                     ",
            "King of Monaka                       ",
            "Black Everest                        ",
            "Special Sundae                       ",
            "Royal Gelato                         ",
            "Doughnut                             ",
            "Choco. Doughnut                      ",
            "Soy Milk Kinako Donut                ",
            "Mochirin roll                        ",
            "Angel Ring                           ",
            "Cosmic Doughnut                      ",
            "Eggplant Tempura                     ",
            "Pumpkin Tempura                      ",
            "Chicken Tempura                      ",
            "Fish Tempura                         ",
            "Squid Tempura                        ",
            "Eel Tempura                          ",
            "Jumbo Shri.Temp                      ",
            "Deluxe Tempura                       ",
            "Sukiyaki Lunchbox                    ",
            "Chicken Sukiyaki                     ",
            "Beef Sukiyaki                        ",
            "Double Sukiyaki                      ",
            "Spec. Marbled Suki.                  ",
            "Chankonabe                           ",
            "Yakuzen Cookies                      ",
            "Yoki Drop                            ",
            "Chocodrug                            ",
            "Nasty Medicine                       ",
            "Bitter Medicine                      ",
            "Mighty Medicine                      ",
            "Miracle Medicine                     ",
            "Yo-lixir Shakkirin                   ",
            "Yo-lixir Yamihaler                   ",
            "Yo-lixir Numericole                  ",
            "Yo-lixir Dimininar                   ",
            "Yo-lixir Nerawarer                   ",
            "Yo-lixir Fusilaren                   ",
            "Getaway Plush                        ",
            "Mini Exporb                          ",
            "Small Exporb                         ",
            "Medium Exporb                        ",
            "Large Exporb                         ",
            "Mega Exporb                          ",
            "Holy Exporb                          ",
            "Iron Doll                            ",
            "Bronze Doll                          ",
            "Silver Doll                          ",
            "Golden Doll                          ",
            "Platinum Doll                        ",
            "Black Doll                           ",
            "Yo-Gourt                             ",
            "Music Card                           ",
            "Oni Egg S                            ",
            "Oni Egg M                            ",
            "Oni Egg L                            ",
            "Super Orb                            ",
            "Ultra Orb                            ",
            "Super Orb B                          ",
            "Crank-a-coin                         ",
            "One-star Coin                        ",
            "Five-star Coin                       ",
            "Special Coin                         ",
            "Rusted Coin                          ",
            "Oni Coin                             ",
            "Oni Coin Super                       ",
            "Oni Coin Ultra                       ",
            "Y Coin                               ",
            "Sealed Goriki Keystone               ",
            "Sealed Onnen Keystone                ",
            "Sealed Mononoke Keystone             ",
            "Sealed Tsukumono Keystone            ",
            "Sealed Uwanosora Keystone            ",
            "Sealed Omamori Keystone              ",
            "Rainbow Keystone                     ",
            "Five-star Keystone                   ",
            "One-chance Keystone                  ",
            "Suzaku Devil Keystone                ",
            "Xuanwu Devil Keystone                ",
            "White Tiger Devil Keystone           ",
            "Ashura Devil Keystone                ",
            "Acala Devil Keystone                 ",
            "Ming Dynasty Devil Keystone          ",
            "Nightshade Enma Keystone             ",
            "Nightshade Enma Keystone (S)         ",
            "God King Keystone                    ",
            "God King Keystone (S)                ",
            "Whisper Hair Gel                     ",
            "Whisper Diary                        ",
            "Ogg-Tog-Mog Toys                     ",
            "Jarboe Ore                           ",
            "Cuny Hair Clip                       ",
            "Hareonna Cloud                       ",
            "Guribobo Fang                        ",
            "Mirapo Fragments                     ",
            "Junior Rare Cards                    ",
            "Hinizall Proposal                    ",
            "Lord Ananta Perfume                  ",
            "Thurston Sakazaki                    ",
            "Hora Kiyoshi Griding Wheels          ",
            "Zazel Brush                          ",
            "Fudo Myoo Hair Decoration            ",
            "Insomni Eye Drops                    ",
            "Blizzaria Hair Fastener              ",
            "Blazion Flame                        ",
            "Burly Wristband                      ",
            "Illuminoct Light                     ",
            "Noko Shedded Skin                    ",
            "Reunight Flag                        ",
            "Corptain Flag                        ",
            "Baku Pillow                          ",
            "Darkyubi Comb                        ",
            "Robonyan Oil                         ",
            "Shirokuma Honey Bottle               ",
            "Punkupine Needle                     ",
            "Zashiki-warashi Mirror               ",
            "Ushioni Eye                          ",
            "The Inevitable Belt                  ",
            "Dameboy Gloves                       ",
            "Demuncher Bead                       ",
            "GHz Orb                              ",
            "Shmoopie Heart                       ",
            "Smogmella Smoke                      ",
            "Tongman Rope                         ",
            "Tongman Super Rope                   ",
            "Gargaros Horn                        ",
            "Gargaros Super Horn                  ",
            "Ogralus Horn                         ",
            "Ogralus Super Horn                   ",
            "Orcanos Horn                         ",
            "Orcanos Super Horn                   ",
            "Sproink Bath Tub                     ",
            "Sproink Gilded Tub                   ",
            "Demuncher Teeth                      ",
            "Demuncher Wisdom Teeth               ",
            "McKraken Smear                       ",
            "McKraken Special Smear               ",
            "Wobblewok Feather Kettle             ",
            "Wobblewok Pure Gold Feather Kettle   ",
            "Hinozall Servants                    ",
            "Hinozall Senior Servants             "});
            this.foodCbox.Location = new System.Drawing.Point(52, 30);
            this.foodCbox.Name = "foodCbox";
            this.foodCbox.Size = new System.Drawing.Size(151, 21);
            this.foodCbox.TabIndex = 2;
            this.foodCbox.SelectedIndexChanged += new System.EventHandler(this.comboBox9_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(18, 32);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(30, 13);
            this.label35.TabIndex = 1;
            this.label35.Text = "Item:";
            // 
            // foodItemList
            // 
            this.foodItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.foodIdColumn1,
            this.foodIdColumn2,
            this.foodOrder,
            this.foodItemName,
            this.foodQuantity});
            this.foodItemList.FullRowSelect = true;
            this.foodItemList.GridLines = true;
            this.foodItemList.HideSelection = false;
            this.foodItemList.Location = new System.Drawing.Point(18, 74);
            this.foodItemList.Name = "foodItemList";
            this.foodItemList.Size = new System.Drawing.Size(465, 179);
            this.foodItemList.TabIndex = 0;
            this.foodItemList.UseCompatibleStateImageBehavior = false;
            this.foodItemList.View = System.Windows.Forms.View.Details;
            this.foodItemList.SelectedIndexChanged += new System.EventHandler(this.foodItemList_SelectedIndexChanged);
            // 
            // foodIdColumn1
            // 
            this.foodIdColumn1.Text = "ID1";
            // 
            // foodIdColumn2
            // 
            this.foodIdColumn2.Text = "ID2";
            // 
            // foodOrder
            // 
            this.foodOrder.Text = "Order";
            // 
            // foodItemName
            // 
            this.foodItemName.Text = "Item Name";
            this.foodItemName.Width = 270;
            // 
            // foodQuantity
            // 
            this.foodQuantity.Text = "Quantity";
            this.foodQuantity.Width = 80;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.mainCharacterViewList);
            this.tabPage3.Controls.Add(this.tabControl3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(499, 294);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Main Characters";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // mainCharacterViewList
            // 
            this.mainCharacterViewList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mainCharacterColumn});
            this.mainCharacterViewList.FullRowSelect = true;
            this.mainCharacterViewList.GridLines = true;
            this.mainCharacterViewList.HideSelection = false;
            this.mainCharacterViewList.Location = new System.Drawing.Point(5, 5);
            this.mainCharacterViewList.Name = "mainCharacterViewList";
            this.mainCharacterViewList.Size = new System.Drawing.Size(122, 286);
            this.mainCharacterViewList.TabIndex = 10;
            this.mainCharacterViewList.UseCompatibleStateImageBehavior = false;
            this.mainCharacterViewList.View = System.Windows.Forms.View.Details;
            this.mainCharacterViewList.SelectedIndexChanged += new System.EventHandler(this.mainCharacterViewList_SelectedIndexChanged);
            // 
            // mainCharacterColumn
            // 
            this.mainCharacterColumn.Text = "Main Character Slots";
            this.mainCharacterColumn.Width = 150;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Controls.Add(this.tabPage9);
            this.tabControl3.Location = new System.Drawing.Point(132, 5);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(363, 285);
            this.tabControl3.TabIndex = 9;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.removeMainCharacter);
            this.tabPage7.Controls.Add(this.saveMainCharacterChanges);
            this.tabPage7.Controls.Add(this.groupBox9);
            this.tabPage7.Controls.Add(this.characterIdNbox);
            this.tabPage7.Controls.Add(this.label40);
            this.tabPage7.Controls.Add(this.mainCharacterCbox);
            this.tabPage7.Controls.Add(this.groupBox10);
            this.tabPage7.Controls.Add(this.label45);
            this.tabPage7.Controls.Add(this.characterLevelNbox);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(355, 259);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Main";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // removeMainCharacter
            // 
            this.removeMainCharacter.Location = new System.Drawing.Point(180, 234);
            this.removeMainCharacter.Name = "removeMainCharacter";
            this.removeMainCharacter.Size = new System.Drawing.Size(69, 20);
            this.removeMainCharacter.TabIndex = 12;
            this.removeMainCharacter.Text = "Remove";
            this.removeMainCharacter.UseVisualStyleBackColor = true;
            this.removeMainCharacter.Click += new System.EventHandler(this.removeMainCharacter_Click);
            // 
            // saveMainCharacterChanges
            // 
            this.saveMainCharacterChanges.Location = new System.Drawing.Point(255, 234);
            this.saveMainCharacterChanges.Name = "saveMainCharacterChanges";
            this.saveMainCharacterChanges.Size = new System.Drawing.Size(85, 20);
            this.saveMainCharacterChanges.TabIndex = 13;
            this.saveMainCharacterChanges.Text = "Save Changes";
            this.saveMainCharacterChanges.UseVisualStyleBackColor = true;
            this.saveMainCharacterChanges.Click += new System.EventHandler(this.saveMainCharacterChanges_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.characterOrderIdNbox);
            this.groupBox9.Controls.Add(this.characterId2Nbox);
            this.groupBox9.Controls.Add(this.characterId1Nbox);
            this.groupBox9.Controls.Add(this.label37);
            this.groupBox9.Controls.Add(this.label38);
            this.groupBox9.Controls.Add(this.label39);
            this.groupBox9.Location = new System.Drawing.Point(15, 170);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(324, 59);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Control Params";
            // 
            // characterOrderIdNbox
            // 
            this.characterOrderIdNbox.Enabled = false;
            this.characterOrderIdNbox.Location = new System.Drawing.Point(261, 23);
            this.characterOrderIdNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.characterOrderIdNbox.Name = "characterOrderIdNbox";
            this.characterOrderIdNbox.ReadOnly = true;
            this.characterOrderIdNbox.Size = new System.Drawing.Size(48, 20);
            this.characterOrderIdNbox.TabIndex = 1;
            // 
            // characterId2Nbox
            // 
            this.characterId2Nbox.Enabled = false;
            this.characterId2Nbox.Location = new System.Drawing.Point(147, 23);
            this.characterId2Nbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.characterId2Nbox.Name = "characterId2Nbox";
            this.characterId2Nbox.ReadOnly = true;
            this.characterId2Nbox.Size = new System.Drawing.Size(48, 20);
            this.characterId2Nbox.TabIndex = 1;
            // 
            // characterId1Nbox
            // 
            this.characterId1Nbox.Enabled = false;
            this.characterId1Nbox.Location = new System.Drawing.Point(42, 23);
            this.characterId1Nbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.characterId1Nbox.Name = "characterId1Nbox";
            this.characterId1Nbox.ReadOnly = true;
            this.characterId1Nbox.Size = new System.Drawing.Size(65, 20);
            this.characterId1Nbox.TabIndex = 1;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(209, 26);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(50, 13);
            this.label37.TabIndex = 0;
            this.label37.Text = "Order ID:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(119, 26);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(27, 13);
            this.label38.TabIndex = 0;
            this.label38.Text = "ID2:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(15, 26);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(27, 13);
            this.label39.TabIndex = 0;
            this.label39.Text = "ID1:";
            // 
            // characterIdNbox
            // 
            this.characterIdNbox.Location = new System.Drawing.Point(73, 18);
            this.characterIdNbox.Maximum = new decimal(new int[] {
            817,
            0,
            0,
            0});
            this.characterIdNbox.Name = "characterIdNbox";
            this.characterIdNbox.Size = new System.Drawing.Size(48, 20);
            this.characterIdNbox.TabIndex = 3;
            this.characterIdNbox.ValueChanged += new System.EventHandler(this.characterIdNbox_ValueChanged);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(36, 47);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(36, 13);
            this.label40.TabIndex = 7;
            this.label40.Text = "Level:";
            // 
            // mainCharacterCbox
            // 
            this.mainCharacterCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mainCharacterCbox.FormattingEnabled = true;
            this.mainCharacterCbox.Items.AddRange(new object[] {
            "",
            "Touma",
            "Summer ",
            "Akinori",
            "Akinori (Fit)",
            "Jack",
            "Nate",
            "Katie",
            "Himoji (Lightside)",
            "Himoji (Shadowside)",
            "Himoji Shadow Boss",
            "Pakkun (Lightside)",
            "Pakkun (Shadowside)",
            "Pakkun Shadow Boss",
            "Kyunshii (Lightside)",
            "Kyunshii (Shadowside)",
            "Kyunshii Shadow Boss",
            "Hare-onna (Lightside)",
            "Hare-onna (Shadowside)",
            "Choky (Lightside)",
            "Choky (Shadowside)",
            "Fubuki-hime (Lightside)",
            "Fubuki-hime (Shadowside)",
            "Fubuki-hime Shadow Boss",
            "Merameraion (Lightside)",
            "Merameraion (Shadowside)",
            "Merameraion Shadow Boss",
            "Orochi (Lightside)",
            "Orochi (Shadowside)",
            "Orochi Shadow Boss",
            "Honmaguro-taishou (Lightside)",
            "Honmaguro-taishou (Shadowside)",
            "Honmaguro-taishou Shadow Boss",
            "Semicolon (Lightside)",
            "Semicolon (Shadowside)",
            "Semicolon Shadow Boss",
            "Komasan (Lightside)",
            "Komasan (Shadowside)",
            "Komajiro (Lightside)",
            "Komajiro (Shadowside)",
            "Komajiro Shadow Boss",
            "Banchou (Lightside)",
            "Banchou (Shadowside)",
            "Banchou Shadow Boss",
            "Seiryuu (Lightside)",
            "Seiryuu (Shadowside)",
            "Fuu-kun (Lightside)",
            "Fuu-kun (Shadowside)",
            "Fuu-kun Shadow Boss",
            "Rai-chan (Lightside)",
            "Rai-chan (Shadowside)",
            "Rai-chan Shadow Boss",
            "Hamham (Lightside)",
            "Hamham (Shadowside)",
            "Jibanyan (Lightside)",
            "Jibanyan (Shadowside)",
            "Uribou (Lightside)",
            "Uribou (Shadowside)",
            "Kyubi (Lightside)",
            "Kyubi (Shadowside)",
            "Kyubi Shadow Boss",
            "Charlie (Lightside)",
            "Charlie (Shadowside)",
            "Zundoumaru (Lightside)",
            "Zundoumaru (Shadowside)",
            "Zundoumaru Shadow Boss",
            "Ungaikyo (Lightside)",
            "Ungaikyo (Shadowside)",
            "Jinta (Lightside)",
            "Jinta (Shadowside)",
            "Jinta Shadow Boss",
            "Kantaro (Lightside)",
            "Kantaro (Shadowside)",
            "Kantaro Shadow Boss",
            "Kiborikkuma (Lightside)",
            "Kiborikkuma (Shadowside)",
            "Junior (Lightside)",
            "Junior (Shadowside)",
            "Micchy (Lightside)",
            "Micchy (Shadowside)",
            "Micchy Hyper (Lightside)",
            "Micchy Hyper (Shadowside)",
            "Hi no Shin (Lightside)",
            "Hi no Shin (Shadowside)",
            "Hungramps",
            "Dimmy",
            "Tattletell",
            "Dismarelda",
            "Hidabat",
            "Frostina",
            "Insomni",
            "Insomni (Boss)",
            "Blizzaria",
            "Damona",
            "Little Charrmer",
            "Roughraff",
            "Roughraff (Boss)",
            "Mochismo",
            "Blazion",
            "Blazion (Boss)",
            "Sgt. Burly",
            "Venoct",
            "Illuminoct",
            "Shadow Venoct",
            "Shogunyan",
            "Snartle",
            "Snartle (Boss)",
            "Arachnus",
            "Arachnus (Boss)",
            "Komashura",
            "Noko",
            "Komasan",
            "Komajiro",
            "Happierre",
            "Hovernyan",
            "Reuknight",
            "Reuknight Boss",
            "Corptain",
            "Toadal Dude",
            "Toadal Dude Boss",
            "Silver Lining",
            "Manjimutt",
            "Manjimutt Boss",
            "Jibanyan",
            "Krystal Fox",
            "Baku",
            "Kyubi",
            "Darkyubi",
            "Master Nyada",
            "Noway",
            "Sandmeh",
            "Mimikin",
            "Mimikin Boss",
            "Mirapo",
            "Robonyan",
            "Goldenyan",
            "Wiglin",
            "Steppa",
            "Rhyth",
            "Walkappa",
            "Nosirs",
            "Cornfused",
            "Whisper",
            "Swelton",
            "Usapyon",
            "Usapyon",
            "Spoilerina",
            "Sighborg Y",
            "Wobblewok",
            "Deadcool",
            "Gargaros",
            "Ogralus",
            "Orcanos",
            "Gilgaros",
            "Shirokuma",
            "Punkupine",
            "Sorrypus",
            "Jabow",
            "Beetall",
            "Cruncha",
            "Rhinormous",
            "Hornaplenty",
            "Mad Mountain",
            "Lava Lord",
            "Faux Kappa",
            "McKraken",
            "Suu-san",
            "Yamanba",
            "Tamamo",
            "Gyuuki",
            "Narigama",
            "Blobgoblin",
            "Nekomata Neko\'ou Bastet",
            "Kappa Kappa\'ou Sagojou",
            "Zashiki-warashi Tengu\'ou Kurama",
            "Kawauso",
            "Enma",
            "Lord Ananta",
            "Douketsu",
            "Douketsu",
            "Shutendoji",
            "Ogu Togu Mogu",
            "Nurarihyon",
            "Fudou Myouou Boy",
            "Whisper",
            "Enma Awakened",
            "Yami Enma",
            "Kaibyou Kamaitachi",
            "Neko\'ou Bastet",
            "Kappa Kappa\'ou Sagojou",
            "Zashiki-warashi Tengu\'ou Kurama",
            "Touma Omatsu",
            "Touma Yoshitsune",
            "Touma Goemon",
            "Touma Benkei",
            "Suzaku (Sword Bearer)",
            "Genbu (Sword Bearer)",
            "Byakko (Sword Bearer)",
            "Kirin ",
            "Souryuu",
            "Gunshin Susanoo",
            "Touma Fudou Myouou",
            "Touma Fudou Myouou Ten",
            "Touma Suzaku",
            "Touma Genbu 2",
            "Touma Byakko",
            "Touma Ashura",
            "Shuka Natsume (Summer)",
            "[DONT_WORK]",
            "Jinta Shadow (boss)",
            "Micchy Shadow (boss)",
            "Micchy Eye Ball (boss)",
            "Jorogumo (boss)",
            "Shinmagunjin Fukurou (boss)",
            "Overseer",
            "Overseer 2",
            "Overseer 3",
            "Diamond ",
            "Yami Enma",
            "Enma",
            "Maten Soranaki",
            "Gilgaros",
            "Illuminoct",
            "Blizzaria",
            "Sgt. Burly",
            "Damona",
            "Manjimutt",
            "Enma Awoken",
            "Raidenryu",
            "Fudou Myouou",
            "Fudou Myouou",
            "Suzaku (Celestial)",
            "Suzaku big",
            "Genbu (Celestial)",
            "Genbu big",
            "Byakko (Celestial)",
            "Byakko big",
            "Ashura",
            "Ashura big",
            "Douketsu",
            "Douketsu",
            "Shutendoji",
            "Yamamba",
            "Tamamo no Mae",
            "Shien",
            "Shinma Kaira",
            "Shinma Kaira",
            "Jinta Shadow",
            "Jinta Shadow",
            "Jinta Shadow",
            "Jinta Shadow",
            "Mitsumata Nozuchi",
            "Mitsumata Nozuchi",
            "Mitsumata Nozuchi",
            "Mitsumata Nozuchi",
            "Micchy Eye Ball",
            "Micchy Eye Ball",
            "Micchy Eye Ball",
            "Micchy Eye Ball",
            "Jorogumo",
            "Jorogumo",
            "Jorogumo",
            "Jorogumo",
            "Shinmagunjin Fukurou",
            "Shinmagunjin Fukurou",
            "Shinmagunjin Fukurou",
            "Shinmagunjin Fukurou",
            "Overseer",
            "Overseer",
            "Overseer",
            "Overseer",
            "Overseer giant",
            "Overseer giant",
            "Diamond ",
            "Enma",
            "Overseer giant",
            "Overseer giant",
            "Diamond ",
            "Enma",
            "Overseer giant",
            "Overseer giant",
            "Diamond ",
            "Enma",
            "Overseer giant",
            "Overseer giant",
            "Diamond ",
            "Enma",
            "Maten Soranaki",
            "Maten Soranaki",
            "Maten Soranaki",
            "Maten Soranaki",
            "Maten Soranaki",
            "Gilgaros",
            "Illuminoct",
            "Blizzaria",
            "Sgt. Burly",
            "Damona",
            "Manjimutt",
            "Gilgaros",
            "Illuminoct",
            "Blizzaria",
            "Sgt. Burly",
            "Damona",
            "Manjimutt",
            "Gilgaros",
            "Illuminoct",
            "Blizzaria",
            "Sgt. Burly",
            "Damona",
            "Manjimutt",
            "Gilgaros",
            "Illuminoct",
            "Blizzaria",
            "Sgt. Burly",
            "Damona",
            "Manjimutt",
            "Gilgaros",
            "Illuminoct",
            "Blizzaria",
            "Sgt. Burly",
            "Damona",
            "Manjimutt",
            "Shien",
            "Shien",
            "Shien",
            "Shien",
            "Fudou Myouou",
            "Fudou Myouou-kai",
            "Suzaku (Celestial)",
            "Suzaku big",
            "Genbu (Celestial)",
            "Genbu big",
            "Byakko (Celestial)",
            "Byakko big",
            "Ashura",
            "Yami Enma",
            "Nekomata Neko\'ou Bastet",
            "Kappa Kappa\'ou Sagojou",
            "Zashiki-warashi Tengu\'ou Kurama",
            "McKraken",
            "Seiryuu Shadow",
            "Jinta Shadow (boss)",
            "Hi no Shin Shadow",
            "Lord Ananta",
            "Fuu-kun (Lightside)",
            "Fuu-kun (Shadowside)",
            "Rai-chan (Lightside)",
            "Rai-chan (Shadowside)",
            "Arachnus",
            "Toadal Dude",
            "Orochi (Lightside)",
            "Orochi (Shadowside)",
            "Kyubi (Lightside)",
            "Kyubi (Shadowside)",
            "Deadcool",
            "Hovernyan",
            "Little Charrmer",
            "Micchy (Lightside)",
            "Micchy (Shadowside)",
            "Fudou Myouou Boy",
            "Shogunyan",
            "Komashura",
            "Gilgaros",
            "Hi no Shin Shadow",
            "Neko\'ou Bastet",
            "Kappa\'ou Sagojou",
            "Tengu\'ou Kurama",
            "Lord Ananta Shadow",
            "Yasha Enma",
            "Fukurou",
            "Shuka",
            "Gentou",
            "Hakushu",
            "Kuuten",
            "Jinta (boss)",
            "Jinta (boss)",
            "Kakurenbou (Lightside)",
            "Kakurenbou (Shadowside)",
            "Hyakki-hime (Lightside)",
            "Hyakki-hime (Shadowside)",
            "Daniel (Lightside)",
            "Daniel (Shadowside)",
            "Itashikatanshi (Lightside)",
            "Itashikatanshi (Shadowside)",
            "Saya (Lightside)",
            "Saya (Shadowside)",
            "Rai Oton (Lightside)",
            "Rai Oton (Shadowside)",
            "Kage Orochi (Lightside)",
            "Kage Orochi (Shadowside)",
            "Bushinyan (Lightside)",
            "Bushinyan (Shadowside)",
            "Shurakoma (Lightside)",
            "Shurakoma (Shadowside)",
            "Tsuchigumo (Lightside)",
            "Tsuchigumo (Shadowside)",
            "Tsuchinoko (Lightside)",
            "Tsuchinoko (Shadowside)",
            "Ogama (Lightside)",
            "Ogama (Shadowside)",
            "Doyapon (Lightside)",
            "Doyapon (Shadowside)",
            "Inugami (Lightside)",
            "Inugami (Shadowside)",
            "Kezurin (Lightside)",
            "Kezurin (Shadowside)",
            "Robonyan 00 (Lightside)",
            "Robonyan 00 (Shadowside)",
            "Becchan (Lightside)",
            "Becchan (Shadowside)",
            "Dameboy (Lightside)",
            "Dameboy (Shadowside)",
            "Awevil",
            "Demuncher",
            "Slicenrice",
            "Signiton",
            "Molar Petite",
            "Shmoopie",
            "Lie-in Heart",
            "Wazzat",
            "Nekidspeed",
            "Count Zapaway",
            "B3-NK1",
            "Rocky Badboya",
            "Smogmella",
            "Drizzelda",
            "Poofessor",
            "Ray O\'Light",
            "Legsit",
            "Snottle",
            "Jibanyan B",
            "Komasan B",
            "Usapyon B",
            "Kukuri-hime",
            "Azukiarai",
            "Shien",
            "Yamamba (Boss)",
            "Tamamo (Boss)",
            "Fukurou",
            "Shuka",
            "Gentou",
            "Hakushu",
            "Kuuten",
            "Yasha Enma",
            "Kenshin Amaterasu",
            "Gesshin Tsukuyomi",
            "Touma Fudou Myouou-kai",
            "Himoji (Lightside)",
            "Himoji (Shadowside)",
            "Pakkun (Lightside)",
            "Pakkun (Shadowside)",
            "Kyunshii (Lightside)",
            "Kyunshii (Shadowside)",
            "Hare-onna (Lightside)",
            "Hare-onna (Shadowside)",
            "Choky (Lightside)",
            "Choky C(Shadowside)",
            "Fubuki-hime (Lightside)",
            "Fubuki-hime (Shadowside)",
            "Merameraion (Lightside)",
            "Merameraion (Shadowside)",
            "Orochi (Lightside)",
            "Orochi (Shadowside)",
            "Honmaguro-taishou (Lightside)",
            "Honmaguro-taishou (Shadowside)",
            "Semicolon (Lightside)",
            "Semicolon (Shadowside)",
            "Komasan (Lightside)",
            "Komasan (Shadowside)",
            "Komajiro (Lightside)",
            "Komajiro (Shadowside)",
            "Banchou (Lightside)",
            "Banchou (Shadowside)",
            "Seiryuu (Lightside)",
            "Seiryuu (Shadowside)",
            "Fuu-kun (Lightside)",
            "Fuu-kun (Shadowside)",
            "Rai-chan (Lightside)",
            "Rai-chan (Shadowside)",
            "Hamham (Lightside)",
            "Hamham (Shadowside)",
            "Jibanyan (Lightside)",
            "Jibanyan (Shadowside)",
            "Uribou (Lightside)",
            "Uribou (Shadowside)",
            "Kyubi (Lightside)",
            "Kyubi (Shadowside)",
            "Charlie (Lightside)",
            "Charlie (Shadowside)",
            "Zundoumaru (Lightside)",
            "Zundoumaru (Shadowside)",
            "Ungaikyo (Lightside)",
            "Ungaikyo (Shadowside)",
            "Jinta (Lightside)",
            "Jinta (Shadowside)",
            "Kantaro (Lightside)",
            "Kantaro (Shadowside)",
            "Kiborikkuma (Lightside)",
            "Kiborikkuma (Shadowside)",
            "Junior (Lightside)",
            "Junior (Shadowside)",
            "Micchy (Lightside)",
            "Micchy (Shadowside)",
            "Hyper Micchy (Lightside)",
            "Hyper Micchy (Shadowside)",
            "Hi no Shin (Lightside)",
            "Hi no Shin (Shadowside)",
            "Hungramps",
            "Dimmy",
            "Tattletell",
            "Dismarelda",
            "Hidabat",
            "Frostina",
            "Insomni",
            "Blizzaria",
            "Damona",
            "Little Charrmer",
            "Roughraff",
            "Mochismo",
            "Blazion",
            "Sgt. Burly",
            "Venoct",
            "Illuminoct",
            "Shadow Venoct",
            "Shogunyan",
            "Snartle",
            "Arachnus",
            "Komashura",
            "Noko",
            "Komasan",
            "Komajiro",
            "Happierre",
            "Hovernyan",
            "Reuknight",
            "Corptain",
            "Toadal Dude",
            "Silver Lining",
            "Manjimutt",
            "Jibanyan",
            "Krystal Fox",
            "Baku",
            "Kyubi",
            "Darkyubi",
            "Master Nyada",
            "Noway",
            "Sandmeh",
            "Mimikin",
            "Mirapo",
            "Robonyan",
            "Goldenyan",
            "Wiglin",
            "Steppa",
            "Rhyth",
            "Walkappa",
            "Nosirs",
            "Cornfused",
            "Whisper",
            "Swelton",
            "Usapyon",
            "Spoilerina",
            "Sighborg Y",
            "Wobblewok",
            "Deadcool",
            "Gargaros",
            "Ogralus",
            "Orcanos",
            "Gilgaros",
            "Shirokuma",
            "Punkupine",
            "Sorrypus",
            "Jabow",
            "Beetall",
            "Cruncha",
            "Rhinormous",
            "Hornaplenty",
            "Mad Mountain",
            "Lava Lord",
            "Faux Kappa",
            "Suu-san",
            "Yamanba",
            "Tamamo",
            "Gyuuki",
            "Narigama",
            "Blobgoblin",
            "Nekomata/Gusto Neko\'ou Bastet",
            "Kappa Kappa\'ou Sagojou",
            "Zashiki-warashi Tengu\'ou Kurama",
            "Kawauso",
            "Enma",
            "Lord Ananta",
            "Douketsu",
            "Shutendoji",
            "Ogu Togu Mogu",
            "Nurarihyon",
            "Fudou Myouou Boy",
            "Whisper",
            "Enma Awakened",
            "Yami Enma",
            "Nekomata/Gusto Neko\'ou Bastet",
            "Kappa Kappa\'ou Sagojou",
            "Zashiki-warashi Tengu\'ou Kurama",
            "Fudou Myouou Ten",
            "Suzaku (Sword Bearer)",
            "Genbu (Sword Bearer)",
            "Byakko (Sword Bearer)",
            "Ashura (Sword Bearer)",
            "Kakurenbou (Lightside)",
            "Kakurenbou (Shadowside)",
            "Hyakki-hime (Lightside)",
            "Hyakki-hime (Shadowside)",
            "Daniel (Lightside)",
            "Daniel (Shadowside)",
            "Itashikatanshi (Lightside)",
            "Itashikatanshi (Shadowside)",
            "Saya (Lightside)",
            "Saya (Shadowside)",
            "Rai Oton (Lightside)",
            "Rai Oton (Shadowside)",
            "Kage Orochi (Lightside)",
            "Kage Orochi (Shadowside)",
            "Bushinyan (Lightside)",
            "Bushinyan (Shadowside)",
            "Shurakoma (Lightside)",
            "Shurakoma (Shadowside)",
            "Tsuchigumo (Lightside)",
            "Tsuchigumo (Shadowside)",
            "Tsuchinoko (Lightside)",
            "Tsuchinoko (Shadowside)",
            "Ogama (Lightside)",
            "Ogama (Shadowside)",
            "Doyapon (Lightside)",
            "Doyapon (Shadowside)",
            "Inugami (Lightside)",
            "Inugami (Shadowside)",
            "Kezurin (Lightside)",
            "Kezurin (Shadowside)",
            "Robonyan 00 (Lightside)",
            "Robonyan 00 (Shadowside)",
            "Becchan (Lightside)",
            "Becchan (Shadowside)",
            "Dameboy (Lightside)",
            "Dameboy (Shadowside)",
            "Awevil",
            "Demuncher",
            "Slicenrice",
            "Signiton",
            "Molar Petite",
            "Shmoopie",
            "Lie-in Heart",
            "Wazzat",
            "Nekidspeed",
            "Count Zapaway",
            "B3-NK1",
            "Rocky Badboya",
            "Smogmella",
            "Drizzelda",
            "Poofessor",
            "Ray O\'Light",
            "Legsit",
            "Snottle",
            "Kukuri-hime",
            "Azukiarai",
            "Fukurou",
            "Kenshin Amaterasu",
            "Gesshin Tsukuyomi",
            "Sproink",
            "Sproink",
            "Sproink",
            "Sproink",
            "Sproink",
            "Sproink",
            "Sproink",
            "Sproink",
            "Sproink",
            "Sproink",
            "Hoggles",
            "Hoggles",
            "Hoggles",
            "Hoggles",
            "Hoggles",
            "Hoggles",
            "Hoggles",
            "Hoggles",
            "Raidenryu",
            "Raidenryu",
            "Raidenryu",
            "Wobblewok",
            "Wobblewok",
            "Wobblewok",
            "Wobblewok",
            "Wobblewok",
            "Wobblewok",
            "Gargaros",
            "Gargaros",
            "Gargaros",
            "Gargaros",
            "Gargaros",
            "Gargaros",
            "Ogralus",
            "Ogralus",
            "Ogralus",
            "Ogralus",
            "Ogralus",
            "Ogralus",
            "Orcanos",
            "Orcanos",
            "Orcanos",
            "Orcanos",
            "Orcanos",
            "Orcanos",
            "McKraken",
            "McKraken",
            "McKraken",
            "McKraken",
            "McKraken",
            "McKraken",
            "Demuncher",
            "Demuncher",
            "Demuncher",
            "Demuncher",
            "Demuncher",
            "Demuncher",
            "Hi no Shin Shadow",
            "Hi no Shin Shadow",
            "Hi no Shin Shadow",
            "Hi no Shin Shadow",
            "Hi no Shin Shadow",
            "Hi no Shin Shadow",
            "Fudou Myouou 1",
            "Fudou Myouou 2",
            "Fudou Myouou 3",
            "Suzaku (Sword Bearer)",
            "Suzaku (Celestial)",
            "Genbu (Sword Bearer)",
            "Genbu (Celestial)",
            "Byakko (Sword Bearer)",
            "Byakko (Celestial)",
            "Asura (Sword Bearer)",
            "Yamamba",
            "Yamamba",
            "Yamamba",
            "Yamamba",
            "Yamamba",
            "Yamamba",
            "Tamamo no Mae",
            "Tamamo no Mae",
            "Tamamo no Mae",
            "Tamamo no Mae",
            "Tamamo no Mae",
            "Tamamo no Mae",
            "Shien",
            "Rocky Badboya",
            "Snartle",
            "Damona (Shadowside)",
            "Jinta (Shadowside)",
            "Dameboy (Shadowside)",
            "Bushinyan (Shadowside)",
            "Lie-in Heart",
            "Signiton",
            "Robonyan",
            "Goldenyan",
            "Sighborg Y",
            "Robonyan00",
            "Jibanyan B",
            "Komasan B",
            "Usapyon B",
            "Hovernyan",
            "Sgt. Burly",
            "Slimamander (Shadowside) (Hyper)",
            "Kenshin Amaterasu",
            "Gesshin Tsukuyomi",
            "Neko\'ou Bastet",
            "Kappa\'ou Sagojou",
            "Tengu\'ou Kurama",
            "Tamamo",
            "Hamham (Shadowside)",
            "Wiglin",
            "Roughraff",
            "Kakurenbou (Shadowside)",
            "Sproink",
            "Legsit",
            "Doyapon",
            "Jibanyan B",
            "Komasan B",
            "Usapyon B",
            "Fubuki-hime (Shadowside)",
            "Hyakki-hime (Shadowside)",
            "Touma",
            "Summer",
            "Akinori",
            "Jack",
            "Nate",
            "Katie",
            "Hailey Anne",
            "Blonde Guy (Alt) (NPC)",
            "Formal Guy (Alt) (NPC)",
            "Blonde Guy (Alt) (NPC)",
            "Formal Guy (Alt) (NPC)",
            "Monk Guy",
            "CowBoy Guy",
            "Smart Monkey",
            "Jinpei Jiba",
            "Shiba Dog",
            "Black Shiba Dog",
            "Yellow Shiba Dog",
            "Mitsue",
            "Alien",
            "Honmaguro-taishou (Shadowside) (No clouds)",
            "Touma (Horse)",
            "Touma (Horse) (Alt)",
            "Touma (Horse) (Alt)",
            "Katie (Horse)",
            "Old Guy",
            "Yamakasa Demon",
            "Yamakasa Demon",
            "Tsuchinoko (Normal)",
            "Tsuchinoko (Lightside)",
            "Tsuchinoko (Shadowside)"});
            this.mainCharacterCbox.Location = new System.Drawing.Point(126, 18);
            this.mainCharacterCbox.Name = "mainCharacterCbox";
            this.mainCharacterCbox.Size = new System.Drawing.Size(213, 21);
            this.mainCharacterCbox.TabIndex = 1;
            this.mainCharacterCbox.SelectedIndexChanged += new System.EventHandler(this.comboBox10_SelectedIndexChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label41);
            this.groupBox10.Controls.Add(this.label42);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.characterExpNbox);
            this.groupBox10.Controls.Add(this.characterYpNbox);
            this.groupBox10.Controls.Add(this.characterPGNbox);
            this.groupBox10.Controls.Add(this.characterHpNbox);
            this.groupBox10.Controls.Add(this.label44);
            this.groupBox10.Location = new System.Drawing.Point(15, 77);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(323, 88);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Actual Stats";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(164, 24);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(75, 13);
            this.label41.TabIndex = 9;
            this.label41.Text = "Power Gauge:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(164, 52);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(31, 13);
            this.label42.TabIndex = 8;
            this.label42.Text = "EXP:";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(15, 54);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(57, 13);
            this.label43.TabIndex = 7;
            this.label43.Text = "Actual YP:";
            // 
            // characterExpNbox
            // 
            this.characterExpNbox.Location = new System.Drawing.Point(237, 52);
            this.characterExpNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.characterExpNbox.Name = "characterExpNbox";
            this.characterExpNbox.Size = new System.Drawing.Size(69, 20);
            this.characterExpNbox.TabIndex = 6;
            // 
            // characterYpNbox
            // 
            this.characterYpNbox.Location = new System.Drawing.Point(74, 50);
            this.characterYpNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.characterYpNbox.Name = "characterYpNbox";
            this.characterYpNbox.Size = new System.Drawing.Size(69, 20);
            this.characterYpNbox.TabIndex = 6;
            // 
            // characterPGNbox
            // 
            this.characterPGNbox.Location = new System.Drawing.Point(237, 23);
            this.characterPGNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.characterPGNbox.Name = "characterPGNbox";
            this.characterPGNbox.Size = new System.Drawing.Size(69, 20);
            this.characterPGNbox.TabIndex = 6;
            // 
            // characterHpNbox
            // 
            this.characterHpNbox.Location = new System.Drawing.Point(74, 23);
            this.characterHpNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.characterHpNbox.Name = "characterHpNbox";
            this.characterHpNbox.Size = new System.Drawing.Size(69, 20);
            this.characterHpNbox.TabIndex = 6;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(15, 24);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(58, 13);
            this.label44.TabIndex = 5;
            this.label44.Text = "Actual HP:";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(15, 20);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(56, 13);
            this.label45.TabIndex = 2;
            this.label45.Text = "Character:";
            // 
            // characterLevelNbox
            // 
            this.characterLevelNbox.Location = new System.Drawing.Point(73, 45);
            this.characterLevelNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.characterLevelNbox.Name = "characterLevelNbox";
            this.characterLevelNbox.Size = new System.Drawing.Size(48, 20);
            this.characterLevelNbox.TabIndex = 3;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.characterSkillLoaderBtn);
            this.tabPage8.Controls.Add(this.groupBox11);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(355, 259);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Skills";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // characterSkillLoaderBtn
            // 
            this.characterSkillLoaderBtn.Location = new System.Drawing.Point(249, 225);
            this.characterSkillLoaderBtn.Name = "characterSkillLoaderBtn";
            this.characterSkillLoaderBtn.Size = new System.Drawing.Size(93, 20);
            this.characterSkillLoaderBtn.TabIndex = 5;
            this.characterSkillLoaderBtn.Text = "Load Yokai Skills";
            this.characterSkillLoaderBtn.UseVisualStyleBackColor = true;
            this.characterSkillLoaderBtn.Click += new System.EventHandler(this.characterSkillLoaderBtn_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.characterExSkl3Cbox);
            this.groupBox11.Controls.Add(this.characterExSkl4Cbox);
            this.groupBox11.Controls.Add(this.label46);
            this.groupBox11.Controls.Add(this.label47);
            this.groupBox11.Controls.Add(this.characterExSkl2Cbox);
            this.groupBox11.Controls.Add(this.characterExSklCbox);
            this.groupBox11.Controls.Add(this.label48);
            this.groupBox11.Controls.Add(this.characterSpSklCbox);
            this.groupBox11.Controls.Add(this.label49);
            this.groupBox11.Controls.Add(this.characterBAtkCbox);
            this.groupBox11.Controls.Add(this.label50);
            this.groupBox11.Controls.Add(this.label51);
            this.groupBox11.Location = new System.Drawing.Point(15, 13);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(217, 232);
            this.groupBox11.TabIndex = 3;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Skill Set";
            // 
            // characterExSkl3Cbox
            // 
            this.characterExSkl3Cbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterExSkl3Cbox.FormattingEnabled = true;
            this.characterExSkl3Cbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.characterExSkl3Cbox.Location = new System.Drawing.Point(86, 154);
            this.characterExSkl3Cbox.Name = "characterExSkl3Cbox";
            this.characterExSkl3Cbox.Size = new System.Drawing.Size(104, 21);
            this.characterExSkl3Cbox.TabIndex = 2;
            // 
            // characterExSkl4Cbox
            // 
            this.characterExSkl4Cbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterExSkl4Cbox.FormattingEnabled = true;
            this.characterExSkl4Cbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.characterExSkl4Cbox.Location = new System.Drawing.Point(86, 188);
            this.characterExSkl4Cbox.Name = "characterExSkl4Cbox";
            this.characterExSkl4Cbox.Size = new System.Drawing.Size(104, 21);
            this.characterExSkl4Cbox.TabIndex = 2;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(9, 26);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(70, 13);
            this.label46.TabIndex = 0;
            this.label46.Text = "Basic Attack:";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(9, 59);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(67, 13);
            this.label47.TabIndex = 0;
            this.label47.Text = "Special Skill:";
            // 
            // characterExSkl2Cbox
            // 
            this.characterExSkl2Cbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterExSkl2Cbox.FormattingEnabled = true;
            this.characterExSkl2Cbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.characterExSkl2Cbox.Location = new System.Drawing.Point(86, 122);
            this.characterExSkl2Cbox.Name = "characterExSkl2Cbox";
            this.characterExSkl2Cbox.Size = new System.Drawing.Size(104, 21);
            this.characterExSkl2Cbox.TabIndex = 2;
            // 
            // characterExSklCbox
            // 
            this.characterExSklCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterExSklCbox.FormattingEnabled = true;
            this.characterExSklCbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.characterExSklCbox.Location = new System.Drawing.Point(86, 88);
            this.characterExSklCbox.Name = "characterExSklCbox";
            this.characterExSklCbox.Size = new System.Drawing.Size(104, 21);
            this.characterExSklCbox.TabIndex = 2;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(9, 91);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(56, 13);
            this.label48.TabIndex = 1;
            this.label48.Text = "Extra Skill:";
            // 
            // characterSpSklCbox
            // 
            this.characterSpSklCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterSpSklCbox.FormattingEnabled = true;
            this.characterSpSklCbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.characterSpSklCbox.Location = new System.Drawing.Point(86, 55);
            this.characterSpSklCbox.Name = "characterSpSklCbox";
            this.characterSpSklCbox.Size = new System.Drawing.Size(104, 21);
            this.characterSpSklCbox.TabIndex = 2;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(9, 127);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(65, 13);
            this.label49.TabIndex = 1;
            this.label49.Text = "Extra Skill 2:";
            // 
            // characterBAtkCbox
            // 
            this.characterBAtkCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterBAtkCbox.FormattingEnabled = true;
            this.characterBAtkCbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.characterBAtkCbox.Location = new System.Drawing.Point(86, 23);
            this.characterBAtkCbox.Name = "characterBAtkCbox";
            this.characterBAtkCbox.Size = new System.Drawing.Size(104, 21);
            this.characterBAtkCbox.TabIndex = 2;
            this.characterBAtkCbox.SelectedIndexChanged += new System.EventHandler(this.comboBox16_SelectedIndexChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(9, 158);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(65, 13);
            this.label50.TabIndex = 1;
            this.label50.Text = "Extra Skill 3:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(9, 192);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(65, 13);
            this.label51.TabIndex = 1;
            this.label51.Text = "Extra Skill 4:";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.groupBox12);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(355, 259);
            this.tabPage9.TabIndex = 2;
            this.tabPage9.Text = "Stats Enhancement";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.characterStNbox);
            this.groupBox12.Controls.Add(this.characterYpPlusNbox);
            this.groupBox12.Controls.Add(this.characterHpPlusNbox);
            this.groupBox12.Controls.Add(this.characterSdNbox);
            this.groupBox12.Controls.Add(this.characterPdNbox);
            this.groupBox12.Controls.Add(this.characterSpNbox);
            this.groupBox12.Controls.Add(this.label52);
            this.groupBox12.Controls.Add(this.label53);
            this.groupBox12.Controls.Add(this.label54);
            this.groupBox12.Controls.Add(this.label55);
            this.groupBox12.Controls.Add(this.label56);
            this.groupBox12.Controls.Add(this.label57);
            this.groupBox12.Location = new System.Drawing.Point(14, 14);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(227, 230);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Stats";
            // 
            // characterStNbox
            // 
            this.characterStNbox.Location = new System.Drawing.Point(105, 87);
            this.characterStNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.characterStNbox.Name = "characterStNbox";
            this.characterStNbox.Size = new System.Drawing.Size(87, 20);
            this.characterStNbox.TabIndex = 1;
            // 
            // characterYpPlusNbox
            // 
            this.characterYpPlusNbox.Location = new System.Drawing.Point(105, 55);
            this.characterYpPlusNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.characterYpPlusNbox.Name = "characterYpPlusNbox";
            this.characterYpPlusNbox.Size = new System.Drawing.Size(87, 20);
            this.characterYpPlusNbox.TabIndex = 1;
            // 
            // characterHpPlusNbox
            // 
            this.characterHpPlusNbox.Location = new System.Drawing.Point(105, 23);
            this.characterHpPlusNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.characterHpPlusNbox.Name = "characterHpPlusNbox";
            this.characterHpPlusNbox.Size = new System.Drawing.Size(87, 20);
            this.characterHpPlusNbox.TabIndex = 1;
            // 
            // characterSdNbox
            // 
            this.characterSdNbox.Location = new System.Drawing.Point(105, 186);
            this.characterSdNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.characterSdNbox.Name = "characterSdNbox";
            this.characterSdNbox.Size = new System.Drawing.Size(87, 20);
            this.characterSdNbox.TabIndex = 1;
            // 
            // characterPdNbox
            // 
            this.characterPdNbox.Location = new System.Drawing.Point(105, 153);
            this.characterPdNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.characterPdNbox.Name = "characterPdNbox";
            this.characterPdNbox.Size = new System.Drawing.Size(87, 20);
            this.characterPdNbox.TabIndex = 1;
            // 
            // characterSpNbox
            // 
            this.characterSpNbox.Location = new System.Drawing.Point(105, 120);
            this.characterSpNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.characterSpNbox.Name = "characterSpNbox";
            this.characterSpNbox.Size = new System.Drawing.Size(87, 20);
            this.characterSpNbox.TabIndex = 1;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(16, 188);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(88, 13);
            this.label52.TabIndex = 0;
            this.label52.Text = "Special Defense:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(16, 154);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(92, 13);
            this.label53.TabIndex = 0;
            this.label53.Text = "Physical Defense:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(16, 122);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(78, 13);
            this.label54.TabIndex = 0;
            this.label54.Text = "Special Power:";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(16, 89);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(83, 13);
            this.label55.TabIndex = 0;
            this.label55.Text = "Strength Power:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(16, 55);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(73, 13);
            this.label56.TabIndex = 0;
            this.label56.Text = "Yo-Kai Points:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(16, 28);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(55, 13);
            this.label57.TabIndex = 0;
            this.label57.Text = "Hit Points:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(528, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPage1);
            this.mainTabControl.Controls.Add(this.yokaiTab);
            this.mainTabControl.Controls.Add(this.tabPage2);
            this.mainTabControl.Controls.Add(this.tabPage3);
            this.mainTabControl.Controls.Add(this.tabPage11);
            this.mainTabControl.Enabled = false;
            this.mainTabControl.Location = new System.Drawing.Point(10, 23);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(507, 320);
            this.mainTabControl.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(499, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Misc";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.katieNameTbox);
            this.groupBox1.Controls.Add(this.nateNameTbox);
            this.groupBox1.Controls.Add(this.jackNameTbox);
            this.groupBox1.Controls.Add(this.akinoriNameTbox);
            this.groupBox1.Controls.Add(this.summerNameTbox);
            this.groupBox1.Controls.Add(this.toumaNameTbox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(285, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 182);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Characters Name";
            // 
            // katieNameTbox
            // 
            this.katieNameTbox.Location = new System.Drawing.Point(72, 150);
            this.katieNameTbox.Name = "katieNameTbox";
            this.katieNameTbox.Size = new System.Drawing.Size(97, 20);
            this.katieNameTbox.TabIndex = 4;
            this.katieNameTbox.TextChanged += new System.EventHandler(this.katieNameTbox_TextChanged);
            // 
            // nateNameTbox
            // 
            this.nateNameTbox.Location = new System.Drawing.Point(72, 125);
            this.nateNameTbox.Name = "nateNameTbox";
            this.nateNameTbox.Size = new System.Drawing.Size(97, 20);
            this.nateNameTbox.TabIndex = 4;
            this.nateNameTbox.TextChanged += new System.EventHandler(this.nateNameTbox_TextChanged);
            // 
            // jackNameTbox
            // 
            this.jackNameTbox.Location = new System.Drawing.Point(72, 100);
            this.jackNameTbox.Name = "jackNameTbox";
            this.jackNameTbox.Size = new System.Drawing.Size(97, 20);
            this.jackNameTbox.TabIndex = 4;
            this.jackNameTbox.TextChanged += new System.EventHandler(this.jackNameTbox_TextChanged);
            // 
            // akinoriNameTbox
            // 
            this.akinoriNameTbox.Location = new System.Drawing.Point(72, 75);
            this.akinoriNameTbox.Name = "akinoriNameTbox";
            this.akinoriNameTbox.Size = new System.Drawing.Size(97, 20);
            this.akinoriNameTbox.TabIndex = 4;
            this.akinoriNameTbox.TextChanged += new System.EventHandler(this.akinoriNameTbox_TextChanged);
            // 
            // summerNameTbox
            // 
            this.summerNameTbox.Location = new System.Drawing.Point(72, 49);
            this.summerNameTbox.Name = "summerNameTbox";
            this.summerNameTbox.Size = new System.Drawing.Size(97, 20);
            this.summerNameTbox.TabIndex = 4;
            this.summerNameTbox.TextChanged += new System.EventHandler(this.summerNameTbox_TextChanged);
            // 
            // toumaNameTbox
            // 
            this.toumaNameTbox.Location = new System.Drawing.Point(72, 24);
            this.toumaNameTbox.Name = "toumaNameTbox";
            this.toumaNameTbox.Size = new System.Drawing.Size(97, 20);
            this.toumaNameTbox.TabIndex = 4;
            this.toumaNameTbox.TextChanged += new System.EventHandler(this.toumaNameTbox_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 153);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Katie:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Nate:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Jack:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Akinori:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Summer:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Touma:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.positionZNbox);
            this.groupBox4.Controls.Add(this.positionYNbox);
            this.groupBox4.Controls.Add(this.positionXNbox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.mapCbox);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(13, 100);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(258, 182);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Local";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Position Z:";
            // 
            // positionZNbox
            // 
            this.positionZNbox.DecimalPlaces = 6;
            this.positionZNbox.Location = new System.Drawing.Point(81, 103);
            this.positionZNbox.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.positionZNbox.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.positionZNbox.Name = "positionZNbox";
            this.positionZNbox.Size = new System.Drawing.Size(102, 20);
            this.positionZNbox.TabIndex = 2;
            this.positionZNbox.ValueChanged += new System.EventHandler(this.positionZNbox_ValueChanged);
            // 
            // positionYNbox
            // 
            this.positionYNbox.DecimalPlaces = 6;
            this.positionYNbox.Location = new System.Drawing.Point(81, 78);
            this.positionYNbox.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.positionYNbox.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.positionYNbox.Name = "positionYNbox";
            this.positionYNbox.Size = new System.Drawing.Size(102, 20);
            this.positionYNbox.TabIndex = 2;
            this.positionYNbox.ValueChanged += new System.EventHandler(this.positionYNbox_ValueChanged);
            // 
            // positionXNbox
            // 
            this.positionXNbox.DecimalPlaces = 6;
            this.positionXNbox.Location = new System.Drawing.Point(80, 53);
            this.positionXNbox.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.positionXNbox.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.positionXNbox.Name = "positionXNbox";
            this.positionXNbox.Size = new System.Drawing.Size(103, 20);
            this.positionXNbox.TabIndex = 2;
            this.positionXNbox.ValueChanged += new System.EventHandler(this.positionXNbox_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Position Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Position X:";
            // 
            // mapCbox
            // 
            this.mapCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapCbox.FormattingEnabled = true;
            this.mapCbox.Items.AddRange(new object[] {
            "",
            "Adams House (Future)",
            "Shop 1",
            "Tatsumi-kawabata - North",
            "Kasumidai",
            "Gasha Land",
            "Sakuragi Hills ",
            "Shop 2",
            "Sakuragi Hills 2",
            "Tatsumi-kawabata - South",
            "Mount Wildwood",
            "Sakura Motomachi ",
            "The yo-kai world",
            "Dark Springdale",
            "Enma Palace",
            "Ghost World",
            "Sakuragi hills 3 ",
            "Shop 3",
            "Reikenrin",
            "Yo-kai Detective Agency Office",
            "Shop 4",
            "Soukenzan",
            "Sakuragi Hills 4",
            "Motomachi Shopping Area",
            "Sakura High School",
            "Houkenden",
            "Yokai Sumo Ring",
            "Sakuragi Hills",
            "Adams Hause (Past)",
            "Kodama hause",
            "Shop 5",
            "Dandanzaka",
            "Sakuragi Hills",
            "Sakura New Town",
            "Shop 6",
            "Snow Girl Shop",
            "Enma Palace",
            "Enma tournament - oni arena",
            "Hells Kichen",
            "Sakuragi Hills",
            "Busters Hell Hole",
            "Sakuragi Hills",
            "Enma Palace",
            "Takashiro Manor",
            "Mount Wildwood 2"});
            this.mapCbox.Location = new System.Drawing.Point(80, 24);
            this.mapCbox.Name = "mapCbox";
            this.mapCbox.Size = new System.Drawing.Size(159, 21);
            this.mapCbox.TabIndex = 1;
            this.mapCbox.SelectedIndexChanged += new System.EventHandler(this.mapCbox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Actual Map:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gatchaMax);
            this.groupBox3.Controls.Add(this.gatchaDaily);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(235, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(253, 87);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Crank-a-kai";
            // 
            // gatchaMax
            // 
            this.gatchaMax.Location = new System.Drawing.Point(147, 49);
            this.gatchaMax.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.gatchaMax.Name = "gatchaMax";
            this.gatchaMax.Size = new System.Drawing.Size(81, 20);
            this.gatchaMax.TabIndex = 2;
            this.gatchaMax.ValueChanged += new System.EventHandler(this.gatchaMax_ValueChanged);
            // 
            // gatchaDaily
            // 
            this.gatchaDaily.Location = new System.Drawing.Point(139, 23);
            this.gatchaDaily.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.gatchaDaily.Name = "gatchaDaily";
            this.gatchaDaily.Size = new System.Drawing.Size(89, 20);
            this.gatchaDaily.TabIndex = 2;
            this.gatchaDaily.ValueChanged += new System.EventHandler(this.gatchaDaily_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Maximum Daily Attempts:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Avaiable Daily Attempts:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.moneyNbox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 87);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Capital";
            // 
            // moneyNbox
            // 
            this.moneyNbox.Location = new System.Drawing.Point(59, 25);
            this.moneyNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.moneyNbox.Name = "moneyNbox";
            this.moneyNbox.Size = new System.Drawing.Size(123, 20);
            this.moneyNbox.TabIndex = 1;
            this.moneyNbox.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Money:";
            // 
            // yokaiTab
            // 
            this.yokaiTab.Controls.Add(this.tabControl2);
            this.yokaiTab.Controls.Add(this.yokaiListView);
            this.yokaiTab.Location = new System.Drawing.Point(4, 22);
            this.yokaiTab.Name = "yokaiTab";
            this.yokaiTab.Padding = new System.Windows.Forms.Padding(3);
            this.yokaiTab.Size = new System.Drawing.Size(499, 294);
            this.yokaiTab.TabIndex = 1;
            this.yokaiTab.Text = "Yo-kai Collection";
            this.yokaiTab.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Location = new System.Drawing.Point(132, 5);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(363, 285);
            this.tabControl2.TabIndex = 8;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.saveButton);
            this.tabPage4.Controls.Add(this.yokaiTbox);
            this.tabPage4.Controls.Add(this.label58);
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.yokaiIdNbox);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.yokaiCbox);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.isAdvancedList);
            this.tabPage4.Controls.Add(this.yokaiLevelNbox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(355, 259);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Main";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(179, 232);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 20);
            this.button4.TabIndex = 11;
            this.button4.Text = "Remove";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(255, 232);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 20);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // yokaiTbox
            // 
            this.yokaiTbox.Location = new System.Drawing.Point(180, 45);
            this.yokaiTbox.Name = "yokaiTbox";
            this.yokaiTbox.Size = new System.Drawing.Size(159, 20);
            this.yokaiTbox.TabIndex = 10;
            this.yokaiTbox.TextChanged += new System.EventHandler(this.yokaiTbox_TextChanged);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(111, 47);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(69, 13);
            this.label58.TabIndex = 9;
            this.label58.Text = "Given Name:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.yokaiOrderNbox);
            this.groupBox8.Controls.Add(this.yokaiId2Nbox);
            this.groupBox8.Controls.Add(this.yokaiId1Nbox);
            this.groupBox8.Controls.Add(this.label34);
            this.groupBox8.Controls.Add(this.label33);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Location = new System.Drawing.Point(15, 170);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(324, 57);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Control Params";
            // 
            // yokaiOrderNbox
            // 
            this.yokaiOrderNbox.Enabled = false;
            this.yokaiOrderNbox.Location = new System.Drawing.Point(261, 23);
            this.yokaiOrderNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.yokaiOrderNbox.Name = "yokaiOrderNbox";
            this.yokaiOrderNbox.ReadOnly = true;
            this.yokaiOrderNbox.Size = new System.Drawing.Size(48, 20);
            this.yokaiOrderNbox.TabIndex = 1;
            // 
            // yokaiId2Nbox
            // 
            this.yokaiId2Nbox.Enabled = false;
            this.yokaiId2Nbox.Location = new System.Drawing.Point(147, 23);
            this.yokaiId2Nbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.yokaiId2Nbox.Name = "yokaiId2Nbox";
            this.yokaiId2Nbox.ReadOnly = true;
            this.yokaiId2Nbox.Size = new System.Drawing.Size(48, 20);
            this.yokaiId2Nbox.TabIndex = 1;
            // 
            // yokaiId1Nbox
            // 
            this.yokaiId1Nbox.Enabled = false;
            this.yokaiId1Nbox.Location = new System.Drawing.Point(42, 23);
            this.yokaiId1Nbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.yokaiId1Nbox.Name = "yokaiId1Nbox";
            this.yokaiId1Nbox.ReadOnly = true;
            this.yokaiId1Nbox.Size = new System.Drawing.Size(65, 20);
            this.yokaiId1Nbox.TabIndex = 1;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(209, 25);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(50, 13);
            this.label34.TabIndex = 0;
            this.label34.Text = "Order ID:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(119, 25);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(27, 13);
            this.label33.TabIndex = 0;
            this.label33.Text = "ID2:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(15, 25);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(27, 13);
            this.label32.TabIndex = 0;
            this.label32.Text = "ID1:";
            // 
            // yokaiIdNbox
            // 
            this.yokaiIdNbox.Location = new System.Drawing.Point(57, 18);
            this.yokaiIdNbox.Maximum = new decimal(new int[] {
            817,
            0,
            0,
            0});
            this.yokaiIdNbox.Name = "yokaiIdNbox";
            this.yokaiIdNbox.Size = new System.Drawing.Size(48, 20);
            this.yokaiIdNbox.TabIndex = 3;
            this.yokaiIdNbox.ValueChanged += new System.EventHandler(this.yokaiIdNbox_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "Level:";
            // 
            // yokaiCbox
            // 
            this.yokaiCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yokaiCbox.FormattingEnabled = true;
            this.yokaiCbox.Items.AddRange(new object[] {
            "",
            "Arachnus  ",
            "Arachnus (Lightside)",
            "Ashura  ",
            "Ashura big  ",
            "Awevil  ",
            "Azukiarai  ",
            "B3-NK1  ",
            "Baku  ",
            "Banchou (Lightside)",
            "Becchan (Lightside)",
            "Beetall  ",
            "Benkei  ",
            "Blazion  ",
            "Blizzaria  ",
            "Blobgoblin  ",
            "Bushinyan (Lightside)",
            "Byakko  ",
            "Byakko  ",
            "Charlie (Lightside)",
            "Choky (Lightside)",
            "Cornfused  ",
            "Corptain  ",
            "Count Zapaway  ",
            "Cruncha  ",
            "Dameboy (Lightside)",
            "Damona  ",
            "Daniel (Lightside)",
            "Darkyubi  ",
            "Deadcool  ",
            "Demuncher  ",
            "Dimmy  ",
            "Dismarelda  ",
            "Douketsu  ",
            "Doyapon (Lightside)",
            "Drizzelda  ",
            "Enma  ",
            "Enma Awoken  ",
            "Faux Kappa  ",
            "Frostina  ",
            "Fubuki-hime (Lightside)",
            "Fudou Myouou  ",
            "Fudou Myouou Boy  ",
            "Fudou Myouou Ten  ",
            "Fudou Myouou-kai  ",
            "Fukurou  ",
            "Fuu-kun (Lightside)",
            "Gargaros  ",
            "Genbu  ",
            "Genbu 2  ",
            "Gentou  ",
            "Gesshin Tsukuyomi  ",
            "Gilgaros  ",
            "Goemon  ",
            "Goldenyan  ",
            "Gunshin Susanoo  ",
            "Gyuuki  ",
            "Hakushu  ",
            "Hamham (Lightside)",
            "Happierre  ",
            "Hare-onna (Lightside)",
            "Hi no Shin (Lightside)",
            "Hidabat  ",
            "Himoji (Lightside)",
            "Honmaguro-taishou (Lightside)",
            "Hornaplenty  ",
            "Hovernyan  ",
            "Hungramps  ",
            "Hyakki-hime (Lightside)",
            "Illuminoct  ",
            "Insomni  ",
            "Inugami (Lightside)",
            "Itashikatanshi (Lightside)",
            "Jabow  ",
            "Jibanyan  (Lightside)",
            "Jibanyan  ",
            "Jibanyan B  ",
            "Jinta (Lightside)",
            "Junior (Lightside)",
            "Kage Orochi (Lightside)",
            "Kaibyou Kamaitachi  ",
            "Kakurenbou (Lightside)",
            "Kantaro (Lightside)",
            "Kappa  ",
            "Kappa\'ou Sagojou  ",
            "Kawauso  ",
            "Kenshin Amaterasu  ",
            "Kezurin (Lightside)",
            "Kiborikkuma (Lightside)",
            "Kirin  ",
            "Komajiro (Lightside)",
            "Komajiro  ",
            "Komasan  (Lightside)",
            "Komasan  ",
            "Komasan B  ",
            "Komashura  ",
            "Krystal Fox  ",
            "Kukuri-hime  ",
            "Kuuten  ",
            "Kyubi  (Lightside)",
            "Kyubi  ",
            "Kyunshii (Lightside)",
            "Lava Lord  ",
            "Legsit  ",
            "Lie-in Heart  ",
            "Little Charrmer  ",
            "Lord Ananta  ",
            "Mad Mountain  ",
            "Manjimutt  ",
            "Master Nyada  ",
            "McKraken  ",
            "Merameraion (Lightside)",
            "Micchy (Lightside)",
            "Micchy Hyper (Lightside)",
            "Mimikin  ",
            "Mirapo  ",
            "Mochismo  ",
            "Molar Petite  ",
            "Narigama  ",
            "Nekidspeed  ",
            "Neko\'ou Bastet  ",
            "Nekomata  ",
            "Noko  ",
            "Nosirs  ",
            "Noway  ",
            "Nurarihyon  ",
            "Ogama (Lightside)",
            "Ogralus  ",
            "Ogu Togu Mogu  ",
            "Omatsu  ",
            "Orcanos  ",
            "Orochi (Lightside)",
            "Pakkun (Lightside)",
            "Poofessor  ",
            "Punkupine  ",
            "Rai Oton (Lightside)",
            "Rai-chan (Lightside)",
            "Raidenryu  ",
            "Ray O\'Light  ",
            "Reuknight  ",
            "Rhinormous  ",
            "Robonyan  ",
            "Robonyan 00 (Lightside)",
            "Rocky Badboya  ",
            "Roughraff  ",
            "Sandmeh  ",
            "Saya (Lightside)",
            "Seiryuu (Lightside)",
            "Semicolon (Lightside)",
            "Sgt. Burly  ",
            "Shadow Venoct  ",
            "Shien  ",
            "Shirokuma  ",
            "Shmoopie  ",
            "Shogunyan  ",
            "Shuka  ",
            "Shuka Natsume  ",
            "Shurakoma (Lightside)",
            "Shutendoji  ",
            "Sighborg Y  ",
            "Signiton  ",
            "Silver Lining  ",
            "Slicenrice  ",
            "Smogmella  ",
            "Snartle  ",
            "Snottle  ",
            "Sorrypus  ",
            "Souryuu  ",
            "Spoilerina  ",
            "Steppa  ",
            "Suu-san  ",
            "Suzaku  ",
            "Suzaku  2",
            "Swelton  ",
            "Tamamo  ",
            "Tattletell  ",
            "Tengu\'ou Kurama  ",
            "Toadal Dude  ",
            "Tsuchigumo (Lightside)",
            "Tsuchinoko (Lightside)",
            "Ungaikyo (Lightside)",
            "Uribou (Lightside)",
            "Usapyon  ",
            "Usapyon (2)  ",
            "Usapyon B  ",
            "Venoct  ",
            "Walkappa  ",
            "Wazzat  ",
            "Whisper  ",
            "Whisper (Future)  ",
            "Wiglin  ",
            "Wobblewok  ",
            "Yamanba  ",
            "Yami Enma  ",
            "Yasha Enma  ",
            "Yoshitsune  ",
            "Zashiki-warashi  ",
            "Zundoumaru (Lightside)"});
            this.yokaiCbox.Location = new System.Drawing.Point(111, 18);
            this.yokaiCbox.Name = "yokaiCbox";
            this.yokaiCbox.Size = new System.Drawing.Size(138, 21);
            this.yokaiCbox.TabIndex = 1;
            this.yokaiCbox.SelectedIndexChanged += new System.EventHandler(this.yokaiCbox_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.yokaiExpNbox);
            this.groupBox5.Controls.Add(this.yokaiYpNbox);
            this.groupBox5.Controls.Add(this.yokaiPgNbox);
            this.groupBox5.Controls.Add(this.yokaiHpNbox);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(15, 77);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(323, 88);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Actual Stats";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(164, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "Power Gauge:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(164, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "EXP:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Actual YP:";
            // 
            // yokaiExpNbox
            // 
            this.yokaiExpNbox.Location = new System.Drawing.Point(237, 52);
            this.yokaiExpNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.yokaiExpNbox.Name = "yokaiExpNbox";
            this.yokaiExpNbox.Size = new System.Drawing.Size(69, 20);
            this.yokaiExpNbox.TabIndex = 6;
            // 
            // yokaiYpNbox
            // 
            this.yokaiYpNbox.Location = new System.Drawing.Point(72, 50);
            this.yokaiYpNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.yokaiYpNbox.Name = "yokaiYpNbox";
            this.yokaiYpNbox.Size = new System.Drawing.Size(69, 20);
            this.yokaiYpNbox.TabIndex = 6;
            // 
            // yokaiPgNbox
            // 
            this.yokaiPgNbox.Location = new System.Drawing.Point(237, 23);
            this.yokaiPgNbox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.yokaiPgNbox.Name = "yokaiPgNbox";
            this.yokaiPgNbox.Size = new System.Drawing.Size(69, 20);
            this.yokaiPgNbox.TabIndex = 6;
            // 
            // yokaiHpNbox
            // 
            this.yokaiHpNbox.Location = new System.Drawing.Point(72, 23);
            this.yokaiHpNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.yokaiHpNbox.Name = "yokaiHpNbox";
            this.yokaiHpNbox.Size = new System.Drawing.Size(69, 20);
            this.yokaiHpNbox.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Actual HP:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Yo-kai:";
            // 
            // isAdvancedList
            // 
            this.isAdvancedList.AutoSize = true;
            this.isAdvancedList.Location = new System.Drawing.Point(255, 21);
            this.isAdvancedList.Name = "isAdvancedList";
            this.isAdvancedList.Size = new System.Drawing.Size(93, 17);
            this.isAdvancedList.TabIndex = 4;
            this.isAdvancedList.Text = "Unhealthy List";
            this.isAdvancedList.UseVisualStyleBackColor = true;
            this.isAdvancedList.CheckedChanged += new System.EventHandler(this.isAdvancedList_CheckedChanged);
            // 
            // yokaiLevelNbox
            // 
            this.yokaiLevelNbox.Location = new System.Drawing.Point(57, 45);
            this.yokaiLevelNbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.yokaiLevelNbox.Name = "yokaiLevelNbox";
            this.yokaiLevelNbox.Size = new System.Drawing.Size(48, 20);
            this.yokaiLevelNbox.TabIndex = 3;
            this.yokaiLevelNbox.ValueChanged += new System.EventHandler(this.yokaiLevelNbox_ValueChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button5);
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(355, 259);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Skills";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(249, 225);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 20);
            this.button5.TabIndex = 4;
            this.button5.Text = "Load Yokai Skills";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.yokaiExSkl3Nbox);
            this.groupBox6.Controls.Add(this.yokaiExSkl4Nbox);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.yokaiExSkl2Nbox);
            this.groupBox6.Controls.Add(this.yokaiExSklNbox);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.yokaiSpSklCbox);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.yokaiBAtkCbox);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Location = new System.Drawing.Point(15, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(217, 232);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Skill Set";
            // 
            // yokaiExSkl3Nbox
            // 
            this.yokaiExSkl3Nbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yokaiExSkl3Nbox.FormattingEnabled = true;
            this.yokaiExSkl3Nbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.yokaiExSkl3Nbox.Location = new System.Drawing.Point(86, 154);
            this.yokaiExSkl3Nbox.Name = "yokaiExSkl3Nbox";
            this.yokaiExSkl3Nbox.Size = new System.Drawing.Size(104, 21);
            this.yokaiExSkl3Nbox.TabIndex = 2;
            // 
            // yokaiExSkl4Nbox
            // 
            this.yokaiExSkl4Nbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yokaiExSkl4Nbox.FormattingEnabled = true;
            this.yokaiExSkl4Nbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.yokaiExSkl4Nbox.Location = new System.Drawing.Point(86, 188);
            this.yokaiExSkl4Nbox.Name = "yokaiExSkl4Nbox";
            this.yokaiExSkl4Nbox.Size = new System.Drawing.Size(104, 21);
            this.yokaiExSkl4Nbox.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Basic Attack:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 59);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Special Skill:";
            // 
            // yokaiExSkl2Nbox
            // 
            this.yokaiExSkl2Nbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yokaiExSkl2Nbox.FormattingEnabled = true;
            this.yokaiExSkl2Nbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.yokaiExSkl2Nbox.Location = new System.Drawing.Point(86, 122);
            this.yokaiExSkl2Nbox.Name = "yokaiExSkl2Nbox";
            this.yokaiExSkl2Nbox.Size = new System.Drawing.Size(104, 21);
            this.yokaiExSkl2Nbox.TabIndex = 2;
            // 
            // yokaiExSklNbox
            // 
            this.yokaiExSklNbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yokaiExSklNbox.FormattingEnabled = true;
            this.yokaiExSklNbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.yokaiExSklNbox.Location = new System.Drawing.Point(86, 88);
            this.yokaiExSklNbox.Name = "yokaiExSklNbox";
            this.yokaiExSklNbox.Size = new System.Drawing.Size(104, 21);
            this.yokaiExSklNbox.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 91);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 13);
            this.label24.TabIndex = 1;
            this.label24.Text = "Extra Skill:";
            // 
            // yokaiSpSklCbox
            // 
            this.yokaiSpSklCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yokaiSpSklCbox.FormattingEnabled = true;
            this.yokaiSpSklCbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.yokaiSpSklCbox.Location = new System.Drawing.Point(86, 55);
            this.yokaiSpSklCbox.Name = "yokaiSpSklCbox";
            this.yokaiSpSklCbox.Size = new System.Drawing.Size(104, 21);
            this.yokaiSpSklCbox.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 127);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 13);
            this.label23.TabIndex = 1;
            this.label23.Text = "Extra Skill 2:";
            // 
            // yokaiBAtkCbox
            // 
            this.yokaiBAtkCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yokaiBAtkCbox.FormattingEnabled = true;
            this.yokaiBAtkCbox.Items.AddRange(new object[] {
            "",
            "Greatification",
            "Shadowside",
            "Vader Mode",
            "Awakening",
            "Change",
            "Change",
            "Change",
            "Change",
            "God Side",
            "Hyper Transformation",
            "Hyper Transformation",
            "Target pin",
            "Target pin",
            "Magic Steal",
            "Friendship atsu mail",
            "Magic Pikohan I",
            "Magic Pikohan II",
            "Magic Pikohan III",
            "Magic Harisen I",
            "Magic Harisen II",
            "Magic Harisen III ",
            "Magic Naginata I",
            "Magic Naginata II",
            "Magic Naginata III ",
            "Magic Sword I",
            "Magic Sword II",
            "Magic Sword III ",
            "Magic Cudge I",
            "Magic Cudge II",
            "Magic Cudge III ",
            "Magic Bat I",
            "Magic Bat II",
            "Magic Bat III ",
            "Heal Okur I",
            "Heal Okur II",
            "Heal Okur III",
            "Magic Okur I",
            "Magic Okur II",
            "Magic Okur III",
            "The Art of Shadow-Sewing I",
            "The Art of Shadow-Sewing II",
            "The Art of Shadow-Sewing III",
            "Oharai Beam I",
            "Oharai Beam II",
            "Oharai Beam III",
            "Tsuranuki Spiral I",
            "Tsuranuki Spiral II",
            "Tsuranuki Spiral III ",
            "Battle Doron I",
            "Battle Doron II",
            "Battle Doron III",
            "Magic Shot I",
            "Magic Shot II",
            "Magic Shot III",
            "Warding Dome I",
            "Warding Dome II",
            "Warding Dome III",
            "Oni Spirit Bullet I",
            "Oni Spirit Bullet II",
            "Oni Spirit Bullet III",
            "Magic Hanabi I",
            "Magic Hanabi II",
            "Magic Hanabi III",
            "Appeal I",
            "Appeal II",
            "Appeal III",
            "Oni\'s Hand I",
            "Oni\'s Hand II",
            "Oni\'s Hand III",
            "Puching",
            "Puching",
            "Puching",
            "Oni Hand, release",
            "Dance of compassion I",
            "Dance of compassion II",
            "Dance of compassion III",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Possesion - Omatsu",
            "Oni\'s melody I",
            "Oni\'s melody II",
            "Oni\'s melody III",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Possesion - Yoshitsune",
            "Ascension Dance Slash I",
            "Ascension Dance Slash II",
            "Ascension Dance Slash III",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Possesion - Goemon",
            "Fist-pumping Wave I",
            "Fist-pumping Wave II",
            "Fist-pumping Wave III",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Possesion - Benkei",
            "Everybody Attack Up I",
            "Everybody Attack Up II",
            "Everybody Attack Up III",
            "Speed Up",
            "Speed UpI",
            "Speed UpII",
            "Everyone\'s Defense Up I",
            "Everyone\'s Defense Up II",
            "Everyone\'s Defense Up III",
            "Everyone Healing I",
            "Everyone Healing II",
            "Everyone Healing III ",
            "The art of avalanche I",
            "The art of avalanche II",
            "The art of avalanche III",
            "Shuriken Rush I",
            "Shuriken Rush II",
            "Shuriken Rush III",
            "Watch Wave Motion Gun I",
            "Watch Wave Motion Gun II",
            "Watch Wave Motion Gun III",
            "Oni Flash",
            "Dance of Compassion",
            "Melody of the Oni",
            "Dance of the Rising Sun",
            "Study Fist Wave",
            "Damage Plus I",
            "Damage Plus II",
            "Damage Plus III",
            "Speed Down I",
            "Speed Down II",
            "Speed Down III",
            "[NO_NAME]",
            "[NO_NAME]",
            "[NO_NAME]",
            "Defense Down I",
            "Defense Down II",
            "Defense Down III",
            "HP Drain I",
            "HP Drain II",
            "HP Drain III",
            "Chain Wave I",
            "Chain Wave II",
            "Chain Wave III",
            "Float I",
            "Float II",
            "Float III",
            "Possession Summoning",
            "Possession Fudo Myoo",
            "Possession Fudo Myoo Heaven",
            "Possession Fudo Myoo World",
            "Possession Suzaku",
            "Possession Genbu",
            "Possession White Tiger",
            "Possession Asura",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Soten jujutsu",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Spirit Spear Fang King Flash",
            "Minna Henge [ATK]",
            "Minna Genge [DEF]",
            "Minna Henge [HEAL]",
            "Minna Henge [REVIVE]",
            "Summoning Friends Heaven",
            "Summoning Friends Spirit",
            "Onirime Awakening",
            "Senbon Onizakura",
            "Summoning Beast",
            "Summoning Beast Kirin",
            "Summoning Beast Suzaku",
            "Summoning Beast Suzaku",
            "Summoning Beast Genbu",
            "Summoning Beast White Tiger",
            "Summoning Beast Soryu",
            "Ten-i Muhou no Breath",
            "Flying Wind Wings",
            "Gouma Roaring Water Formation",
            "Big Fang Break Rock Attack",
            "Blue Annihilation Wave",
            "Summoning God of War",
            "Oni Slayer",
            "Spinning",
            "Biting",
            "Cratching",
            "Hitting",
            "Slashing",
            "Burst Shot",
            "Freeze Shot",
            "Oni Shot",
            "Flaming Shot",
            "Icicle Shot",
            "Oni Shuriken",
            "Beam Shot",
            "Vader Lazer",
            "5 Shots",
            "Triple Shot",
            "Triple Bolt",
            "Triple Wind",
            "Triple Water",
            "Triple Dark",
            "Explosive Shot",
            "Kiki no Ippo",
            "Charge Attack",
            "Big Break Shot",
            "Impact Stamp",
            "God Speed Attack",
            "Gale Step",
            "Gale Shot",
            "Torch Tackle",
            "Sword Hunt",
            "Armor Crusher",
            "Shin strike",
            "Super Sword Hunt",
            "Super Slashing",
            "Super shin-bashing",
            "Shield-breaking",
            "Super Shield-Burning",
            "Scarecrow\'s shield",
            "Shield of the Scarecrow",
            "Scarecrow I",
            "Scarecrow II",
            "Scarecrow III",
            "Scarecrow",
            "Shield of Absorbtion",
            "Oni protection eard",
            "Oni\'s Great Warding",
            "Counter",
            "The Art of Recovery",
            "The Art of Paradise",
            "Healing Dome",
            "Super Healing Dome",
            "Onigiri no Jutsu",
            "The Art of the Super Rice",
            "Camp of Recovery",
            "Oharai no Jin",
            "Bushim no Jin",
            "Poison Squad",
            "Jin of Curse",
            "Yasuragi Jisu I",
            "Yasuragi Jisu II",
            "Yasuragi Jisu III",
            "Yasuragi Jizu",
            "Omamori Jizo I",
            "Omamori Jizo II",
            "Omamori Jizo III",
            "Fukiya Jizo I",
            "Fukiya Jizo II",
            "Fukiya Jizo III",
            "Minagari Jizo",
            "Achi Achi Jizo",
            "Lukewarm Jizo",
            "Sluggish Jizo",
            "Increased Attack",
            "Super Attack!",
            "More Protection",
            "Super defense",
            "Speed Up",
            "Super Speed Up",
            "Whole Body Spirit",
            "Martial Arts",
            "Art of Protection",
            "The Art of Divine Speed",
            "The Art of the Oni God",
            "Conspicuous Evil",
            "The art of stealth",
            "Bakugami no Jutsu",
            "Oni Mine I",
            "Oni Mine II",
            "Oni Mine III",
            "Oni Mine",
            "Poison Mine",
            "Darkness Mine",
            "Petrification I",
            "Petrification II",
            "Petrification III",
            "Petrifying Mine",
            "The Art fo the Spark",
            "The Art of the Flame",
            "The Art of the Water Splash",
            "The Art of the Big Wave",
            "The Art of the Eletric",
            "The Art of the Raikage",
            "The art of cracks in the Earth",
            "Falling stone technique",
            "Snowflake technique",
            "Freeze technique",
            "Whirlwiird technique",
            "Tornado Technique",
            "The Art of the Ray of Light",
            "The Art of Darkness",
            "Arrow Rain",
            "Homing Bomb",
            "Recovery Stalk",
            "Super Recovery Sting",
            "The Art of Absorbtion",
            "The Art of Darkness",
            "Yo-kai Wave",
            "Attack Down",
            "Super Attack down",
            "Defense down",
            "Super defense down",
            "Speed Sown",
            "Super speed down",
            "Full power Down",
            "Venomous Technique",
            "Confusion",
            "Spell Sealing",
            "The Art of Darkness",
            "Mega Hit Beam",
            "Splash Beam",
            "Mitchie Beam",
            "Rocket Punch",
            "Rocket Punch",
            "Ranbu - Red Flower",
            "Gorgeous Snow",
            "God\'s Blade",
            "Ikasa Oni Bullet",
            "Squidward Bea",
            "High King Enma Ball",
            "Magic Eye Hell Destroying",
            "Evil flame sword sance",
            "Snake King Rebellion Wave",
            "Snake King Rebellion Wave",
            "Black Flame Gale Wave",
            "Oni Shigure",
            "Oni Oni The Grudge",
            "Hungry Hungry Ghosts",
            "Shokumushi SHOCK",
            "Kaisei Love Zukkyun",
            "Kaisei Love Zukkyun",
            "Okiyome Weather Rain",
            "Onibaba no De-ba Knife",
            "Tsubameki Blizzard",
            "Judgment Super Wave",
            "Melamera Shishi Gouken",
            "Dead Snake Bolt",
            "Dokkan Thundering Slash",
            "Great Rough Tuna Wave",
            "Kesshi no Cicada Final",
            "Hedato Ranreki Slash",
            "Falling Dog Rock",
            "Falling Frog Rock",
            "Melo Melo Distressing Beat",
            "Hanki Straight Punch",
            "Yaman Taman Baa!",
            "God\'s Great River",
            "Big Snake Mountain Festival",
            "Wind, blow, blow!",
            "Be struck by lightning!",
            "Hundred Cats",
            "One hit, one Kill!",
            "The Spirit of Killing",
            "A fierce attack!",
            "Kon-kon-kisei miasma",
            "Nine Red Lotus Bullets",
            "Hell\'s Special Poison Soup",
            "High Speed Standing Kogi",
            "Kama Nari Blunt Don",
            "Boiling Muscle",
            "Let\'s go to the mirror world",
            "Shattered bones bobomber",
            "Bonanza de tada de tada!",
            "Burning Meteor",
            "Hofupe no Nupe",
            "Mitsumata Kairisen",
            "Charisma Butler Breath",
            "Sara Lehman Willow",
            "Gidugira Gekko-sen",
            "Five-star Stardust",
            "Himoji impact",
            "Jimmi na Ippatsu",
            "Slap of Love",
            "Hiki Komori Uta",
            "Yukinko Sherbet",
            "Tonight Mo Nemure Night",
            "Kira Kira Yukikake",
            "Tokimeri Hyakkiyakou",
            "Tokimeri Hyakkiyakou",
            "Age Age Fire",
            "Tsutsuri Menchi",
            "Mochimochi Ken",
            "Seiken Burning",
            "Victorian!",
            "Yamata no Orochi",
            "Senko Dragon Rush",
            "Shadow Style Yamata no Orochi",
            "Katsuo Bushi Slash",
            "Bad Boy Enegar",
            "Tsuchigumo (Earth Spider)",
            "Tsuchinoko Smile",
            "Hitodama Ranbu",
            "Kazarai Thunder",
            "Dogenashi Straight Meatball",
            "Genma Zan",
            "Yomei Ochuri",
            "Toad Slayer, Super Tongue",
            "Shari BAAAN!",
            "Ossan Kami Max",
            "Hundreds of Meatballs",
            "Soul of a Heel",
            "NEMUKEMURI",
            "Red Lotus Hell",
            "Owarinohajimari",
            "Infinite Horsepower",
            "Firm Guard",
            "Sunao\'s Honest Sand",
            "Mane of the Grardian God",
            "Kagami yo Kagami",
            "Bo-Gyo Mode Nyan",
            "Golden Nyander",
            "Famous Wakame Ondo",
            "Kumbu de Mambo",
            "Passionate Mekabu Samba!",
            "Mega Taki Otoshi",
            "A story that doesn\'t ring a bell",
            "Mouthfuls of Breath",
            "Super Thick USA Beam",
            "Navel Beam",
            "Makuro Dondoron",
            "Warunori Ohuza Sword",
            "Golden Rod od Rage",
            "Cold-hearted Gold Bar",
            "Gold Bar of Nightmare",
            "Golden rod of Legend",
            "Badass Chikyuu",
            "Hari Hari Rolling",
            "Sorry Storm",
            "Shura Shush Shush",
            "Magic Eye Hell Destroying",
            "Zan Mu Issen",
            "Polar Hurricane Meatball",
            "Bastet\'s Hundred Fist",
            "Shocking Blackmail wave",
            "Heavenly Oni Grand Whirlwind",
            "Shiwomaneku Scissors",
            "Oily Abura",
            "Chalapokodon",
            "Onikiri Bear Rush",
            "Don Yori Gun",
            "Heartwarming Field",
            "Nose Hair Nayo",
            "Soggy Wall",
            "Spoiler Finale",
            "Spoiler Finale",
            "Hell Scissors",
            "The Great Amputation",
            "Runaway hornbill break",
            "Explosive Antle Final",
            "Ultra Hiko Fumi",
            "Yozakura Shiko Fumi",
            "Kappanha!",
            "Ikari MAX Cannon",
            "Iyashi no Warabi Uta",
            "Kirameki Darkness",
            "Hachikire Big D",
            "By all means no flash",
            "Absolute Magic Sword",
            "Thunderbolt of Rage",
            "Darkness Exorcism Snake Wave",
            "Zanshin Katsuo Musha",
            "Shura-ju-na-ga-bun",
            "Open Earth Cannon",
            "Unlucky Smile",
            "Fate No Mawari Ito",
            "Fate No Mawari Ito",
            "Toadstoll Kill",
            "Slash with a smug look",
            "Shinui Shinkou",
            "Shinui Shinkou",
            "Nerve Scraping",
            "Rocket M Tackle",
            "Shakashaka ShakaShaka",
            "The Arrow of Poison",
            "Absolutely Survive Man",
            "Suck, suck, suck",
            "Curse of Everlasting Darkness",
            "The Great Wheel",
            "Oni Kiri Issen",
            "Denjin Thunder",
            "Hadaka Deva Heal",
            "Kyun to the Heart!",
            "Kaigen, Shishi Battou",
            "Suguwasure~ru",
            "Bakuratsu Start Dash",
            "Kutte ni Kawaru Channel",
            "Karakuri Machine Gun",
            "I knew it would turn out this way",
            "Mekuru Tornado",
            "My Love is Rainy",
            "I\'m fed up with all this crap",
            "Sunny Fire",
            "Escape Dash to GO!",
            "Hoji Hoji Hoji",
            "Akaneko B Launcher",
            "Shiroinu B Healing",
            "Get B Launcher",
            "Thundering mallet slash",
            "Senbon Onizakura",
            "Onikage Burial Claw",
            "Wailing Gouken",
            "Flyng Tenchu Killing",
            "Oni\'s Jaw",
            "Tensho Kourin",
            "Dream Moonlight",
            "Dream Moonlight",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Doro Doro Doro",
            "Doro Doro Doro",
            "Gale Attack",
            "Drunken Fist",
            "Attack",
            "Back Attack",
            "Double Sword Slash",
            "Mountain Blade",
            "Water Blade Slash",
            "Hellfire Attack",
            "Claw of the Fox",
            "White blade slash",
            "High King Slash",
            "High King Slash",
            "Bright light slash",
            "Bright light slash",
            "Flame Dance Slash",
            "Furious light slash",
            "Evil flame slash",
            "Flame Slash",
            "Fiery Slash",
            "Night fork slash",
            "Everlasting darkness",
            "Art of the Red Lotus",
            "No Ten Stab",
            "No Ten Stab",
            "Spiritual Angle Magic Hash",
            "Spiritural angle magic Hash",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Bird\'s eye gust",
            "Water Turning Slash",
            "Water Turning Slash",
            "Asura Karma",
            "Asura Karma",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Oni\'s Bamboo Forest",
            "Thundering Wave",
            "Thundering Wave",
            "Lightining Dance",
            "Lightining Dance",
            "Stone axe attack",
            "Phantom Serpert",
            "Uzumaki of hellfire",
            "Uzumaki of hellfire",
            "White spear with fangs",
            "White spear with fangs",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Ascending dragon slash",
            "Snake king slash",
            "Snake king slash",
            "The Art of the Absorbing Soul",
            "The Art of the Absorbing Soul",
            "The Art of Darkness",
            "The Art of Darkness",
            "Flying Wind Wings",
            "Gouma Roaring Water Format",
            "Big Fang Break Rock Attack",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Thundering mallet slash",
            "Houzen Danjaku Zan",
            "High King\'s Blade",
            "Golden Rod Tornado",
            "Golden Rod Tornado",
            "Golden Rod Tornado Whirlpoll",
            "Golden Bat Tornado Black",
            "Mega Hit Beam",
            "Mega Hit Beam",
            "Squidward Beam",
            "Ikasa Oni Bullet",
            "Ikasa Oni Bullet",
            "Ins\'t it a bit cold?",
            "Oni Pesha Stamp",
            "Oni Pesha Stamp",
            "Shocking Cauldron",
            "Impact Stamp",
            "Stone Drop",
            "Stone Drop",
            "Start",
            "Lunch meeting",
            "Enter key if decision",
            "Spell Sealing",
            "Super slashing",
            "Triple Dark",
            "Flames of Rage",
            "The Great Waterfall",
            "Sandstorm of Nightmare",
            "Muscle Dissection Upper",
            "Fist Bone Hammer Kong",
            "Anatomy Teaching",
            "[NO_NAME]",
            "Cranial Destructions",
            "Cranial Destructions",
            "Visceral Ga...Naisou!",
            "Shattered bones bobomber!",
            "Nuttiness Stamp",
            "Petrification B~M",
            "Petrification B~M",
            "Petrification B~M",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Oopeshot!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Namebirou!",
            "Dota Dota Ran",
            "Bitter Darkness",
            "Grudge Gebonage",
            "Grudge Dango",
            "Bummuke Uppun Dango",
            "Belly Gloom Vacuum",
            "Fire Grudge Buns",
            "Fire Grudge Buns",
            "Thunder Grudge Buns",
            "Thunder Grudge Buns",
            "Demon Soap Bubble",
            "Demon Soap Bubble",
            "Stain Bomb Gerundoron",
            "Stain Bomb Gerundoron",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Maboroshi Satsukashi",
            "Poisoned Feet",
            "Destroying And Killing",
            "Destroying And Killing",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Yamino-Me Swallowtail",
            "Death Rattle Spider Web",
            "Yohen Guru Mawarashi",
            "Empty Eyes",
            "Stone Spell Ray",
            "Empty Sky Killing",
            "Splitting A Sword With A Helmet",
            "Cleave The Sword",
            "Cleave The Sword",
            "Spell Sword",
            "Spell Ball",
            "Spell Ball",
            "Bile Sucking",
            "Hand Of Sorrow",
            "Hand Of Sorrow",
            "Black Grudge Flash",
            "Crush Rock Blood",
            "Devil\'s Blink",
            "Shadow Of The Demon Sword",
            "Shadow Of The Demon Sword",
            "Shoryuuma Zan",
            "Underworld Demons",
            "Zanmu Demon Cross",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Grudge Palm Break",
            "Black Flame Barrage",
            "Thundering mallet slash",
            "Soten jujutsu",
            "High King\'s Blade",
            "Houzen Danjaku Zan",
            "Spirit Spear Fang King Flash",
            "Wailing In The Sky",
            "Hundred Lightning Thrusts",
            "Super yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Hundred Lightning Thrusts",
            "Super Yomogi Step",
            "Dragon Harate",
            "Rapid Thunder Hackyoi",
            "Shinrinari Drop",
            "Oke De Kappon",
            "Tonman Fire",
            "Spacoon The Tub",
            "Zappan From Ass",
            "Zappan From Ass",
            "Slippery Soap",
            "Slippery Soap",
            "Burning In The Tub",
            "Burning In The Tub",
            "Burning In The Tub",
            "Viva! Boil Up!",
            "Water Release",
            "Black Ton Flame",
            "Spooning In A Tub",
            "Spacoon The Tub",
            "Bark",
            "A simple Nudge",
            "Yokken Red Fist",
            "Monk\'s Pint Press",
            "Treasure Upper",
            "Handsome Flash",
            "The Art of Floating Demons",
            "Soaking In The Bath",
            "Ukiwki Shake",
            "Tuna Dawn!",
            "Whoopee!",
            "Whoopee!",
            "Beat Camp",
            "Doro-n Summon!",
            "Oni\'s Hand III",
            "Everyone Attack Up III",
            "Retribution bullet III",
            "Petrifying Mine III",
            "Tsuranuki Spiral III",
            "Everyone Healing III"});
            this.yokaiBAtkCbox.Location = new System.Drawing.Point(86, 23);
            this.yokaiBAtkCbox.Name = "yokaiBAtkCbox";
            this.yokaiBAtkCbox.Size = new System.Drawing.Size(104, 21);
            this.yokaiBAtkCbox.TabIndex = 2;
            this.yokaiBAtkCbox.SelectedIndexChanged += new System.EventHandler(this.yokaiBAtkCbox_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(9, 158);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 13);
            this.label25.TabIndex = 1;
            this.label25.Text = "Extra Skill 3:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 192);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 13);
            this.label26.TabIndex = 1;
            this.label26.Text = "Extra Skill 4:";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox7);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(355, 259);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Stats Enhancement";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.yokaiStPlusNbox);
            this.groupBox7.Controls.Add(this.yokaiYpPlusNbox);
            this.groupBox7.Controls.Add(this.yokaiHpPlusNbox);
            this.groupBox7.Controls.Add(this.yokaiSdPlusNbox);
            this.groupBox7.Controls.Add(this.yokaiPdPlusNbox);
            this.groupBox7.Controls.Add(this.yokaiSpPlusNbox);
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.label29);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Controls.Add(this.label27);
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Location = new System.Drawing.Point(14, 14);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(227, 230);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Stats";
            // 
            // yokaiStPlusNbox
            // 
            this.yokaiStPlusNbox.Location = new System.Drawing.Point(105, 87);
            this.yokaiStPlusNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.yokaiStPlusNbox.Name = "yokaiStPlusNbox";
            this.yokaiStPlusNbox.Size = new System.Drawing.Size(87, 20);
            this.yokaiStPlusNbox.TabIndex = 1;
            // 
            // yokaiYpPlusNbox
            // 
            this.yokaiYpPlusNbox.Location = new System.Drawing.Point(105, 55);
            this.yokaiYpPlusNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.yokaiYpPlusNbox.Name = "yokaiYpPlusNbox";
            this.yokaiYpPlusNbox.Size = new System.Drawing.Size(87, 20);
            this.yokaiYpPlusNbox.TabIndex = 1;
            // 
            // yokaiHpPlusNbox
            // 
            this.yokaiHpPlusNbox.Location = new System.Drawing.Point(105, 23);
            this.yokaiHpPlusNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.yokaiHpPlusNbox.Name = "yokaiHpPlusNbox";
            this.yokaiHpPlusNbox.Size = new System.Drawing.Size(87, 20);
            this.yokaiHpPlusNbox.TabIndex = 1;
            // 
            // yokaiSdPlusNbox
            // 
            this.yokaiSdPlusNbox.Location = new System.Drawing.Point(105, 186);
            this.yokaiSdPlusNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.yokaiSdPlusNbox.Name = "yokaiSdPlusNbox";
            this.yokaiSdPlusNbox.Size = new System.Drawing.Size(87, 20);
            this.yokaiSdPlusNbox.TabIndex = 1;
            // 
            // yokaiPdPlusNbox
            // 
            this.yokaiPdPlusNbox.Location = new System.Drawing.Point(105, 153);
            this.yokaiPdPlusNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.yokaiPdPlusNbox.Name = "yokaiPdPlusNbox";
            this.yokaiPdPlusNbox.Size = new System.Drawing.Size(87, 20);
            this.yokaiPdPlusNbox.TabIndex = 1;
            // 
            // yokaiSpPlusNbox
            // 
            this.yokaiSpPlusNbox.Location = new System.Drawing.Point(105, 120);
            this.yokaiSpPlusNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.yokaiSpPlusNbox.Name = "yokaiSpPlusNbox";
            this.yokaiSpPlusNbox.Size = new System.Drawing.Size(87, 20);
            this.yokaiSpPlusNbox.TabIndex = 1;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(16, 188);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(88, 13);
            this.label31.TabIndex = 0;
            this.label31.Text = "Special Defense:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 154);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(92, 13);
            this.label30.TabIndex = 0;
            this.label30.Text = "Physical Defense:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(16, 122);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(78, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Special Power:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(16, 89);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(83, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Strength Power:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 55);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "Yo-Kai Power:";
            this.label27.Click += new System.EventHandler(this.label27_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Hit Points:";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.groupBox13);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(355, 259);
            this.tabPage10.TabIndex = 3;
            this.tabPage10.Text = "Under Research";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.yokaiUnknown4Nbox);
            this.groupBox13.Controls.Add(this.yokaiUnknown9Nbox);
            this.groupBox13.Controls.Add(this.label59);
            this.groupBox13.Controls.Add(this.label67);
            this.groupBox13.Controls.Add(this.yokaiUnknown1Nbox);
            this.groupBox13.Controls.Add(this.yokaiUnknown8Nbox);
            this.groupBox13.Controls.Add(this.label68);
            this.groupBox13.Controls.Add(this.label66);
            this.groupBox13.Controls.Add(this.yokaiUnknown10Nbox);
            this.groupBox13.Controls.Add(this.yokaiUnknown7Nbox);
            this.groupBox13.Controls.Add(this.label69);
            this.groupBox13.Controls.Add(this.label65);
            this.groupBox13.Controls.Add(this.yokaiUnknown11Nbox);
            this.groupBox13.Controls.Add(this.yokaiUnknown6Nbox);
            this.groupBox13.Controls.Add(this.label70);
            this.groupBox13.Controls.Add(this.label64);
            this.groupBox13.Controls.Add(this.yokaiUnknown12Nbox);
            this.groupBox13.Controls.Add(this.yokaiUnknown5Nbox);
            this.groupBox13.Controls.Add(this.label71);
            this.groupBox13.Controls.Add(this.label63);
            this.groupBox13.Controls.Add(this.yokaiUnknown13Nbox);
            this.groupBox13.Controls.Add(this.label72);
            this.groupBox13.Controls.Add(this.label62);
            this.groupBox13.Controls.Add(this.yokaiUnknown14Nbox);
            this.groupBox13.Controls.Add(this.yokaiUnknown3Nbox);
            this.groupBox13.Controls.Add(this.label73);
            this.groupBox13.Controls.Add(this.label61);
            this.groupBox13.Controls.Add(this.yokaiUnknown15Nbox);
            this.groupBox13.Controls.Add(this.yokaiUnknown2Nbox);
            this.groupBox13.Controls.Add(this.label74);
            this.groupBox13.Controls.Add(this.label60);
            this.groupBox13.Controls.Add(this.yokaiUnknown16Nbox);
            this.groupBox13.Controls.Add(this.yokaiUnknown17Nbox);
            this.groupBox13.Controls.Add(this.label75);
            this.groupBox13.Location = new System.Drawing.Point(10, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(336, 250);
            this.groupBox13.TabIndex = 2;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Fields";
            // 
            // yokaiUnknown4Nbox
            // 
            this.yokaiUnknown4Nbox.Location = new System.Drawing.Point(67, 94);
            this.yokaiUnknown4Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown4Nbox.Name = "yokaiUnknown4Nbox";
            this.yokaiUnknown4Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown4Nbox.TabIndex = 1;
            // 
            // yokaiUnknown9Nbox
            // 
            this.yokaiUnknown9Nbox.Location = new System.Drawing.Point(67, 219);
            this.yokaiUnknown9Nbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.yokaiUnknown9Nbox.Name = "yokaiUnknown9Nbox";
            this.yokaiUnknown9Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown9Nbox.TabIndex = 1;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(24, 21);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(41, 13);
            this.label59.TabIndex = 0;
            this.label59.Text = "Field 1:";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(24, 222);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(41, 13);
            this.label67.TabIndex = 0;
            this.label67.Text = "Field 9:";
            // 
            // yokaiUnknown1Nbox
            // 
            this.yokaiUnknown1Nbox.Location = new System.Drawing.Point(67, 18);
            this.yokaiUnknown1Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown1Nbox.Name = "yokaiUnknown1Nbox";
            this.yokaiUnknown1Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown1Nbox.TabIndex = 1;
            // 
            // yokaiUnknown8Nbox
            // 
            this.yokaiUnknown8Nbox.Location = new System.Drawing.Point(67, 194);
            this.yokaiUnknown8Nbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.yokaiUnknown8Nbox.Minimum = new decimal(new int[] {
            -1,
            0,
            0,
            -2147483648});
            this.yokaiUnknown8Nbox.Name = "yokaiUnknown8Nbox";
            this.yokaiUnknown8Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown8Nbox.TabIndex = 1;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(176, 20);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(47, 13);
            this.label68.TabIndex = 0;
            this.label68.Text = "Field 10:";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(24, 197);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(41, 13);
            this.label66.TabIndex = 0;
            this.label66.Text = "Field 8:";
            // 
            // yokaiUnknown10Nbox
            // 
            this.yokaiUnknown10Nbox.Location = new System.Drawing.Point(224, 18);
            this.yokaiUnknown10Nbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.yokaiUnknown10Nbox.Name = "yokaiUnknown10Nbox";
            this.yokaiUnknown10Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown10Nbox.TabIndex = 1;
            // 
            // yokaiUnknown7Nbox
            // 
            this.yokaiUnknown7Nbox.Location = new System.Drawing.Point(67, 169);
            this.yokaiUnknown7Nbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.yokaiUnknown7Nbox.Minimum = new decimal(new int[] {
            -1,
            0,
            0,
            -2147483648});
            this.yokaiUnknown7Nbox.Name = "yokaiUnknown7Nbox";
            this.yokaiUnknown7Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown7Nbox.TabIndex = 1;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(176, 45);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(47, 13);
            this.label69.TabIndex = 0;
            this.label69.Text = "Field 11:";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(24, 172);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(41, 13);
            this.label65.TabIndex = 0;
            this.label65.Text = "Field 7:";
            // 
            // yokaiUnknown11Nbox
            // 
            this.yokaiUnknown11Nbox.Location = new System.Drawing.Point(224, 43);
            this.yokaiUnknown11Nbox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.yokaiUnknown11Nbox.Minimum = new decimal(new int[] {
            -1,
            0,
            0,
            -2147483648});
            this.yokaiUnknown11Nbox.Name = "yokaiUnknown11Nbox";
            this.yokaiUnknown11Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown11Nbox.TabIndex = 1;
            // 
            // yokaiUnknown6Nbox
            // 
            this.yokaiUnknown6Nbox.Location = new System.Drawing.Point(67, 144);
            this.yokaiUnknown6Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown6Nbox.Name = "yokaiUnknown6Nbox";
            this.yokaiUnknown6Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown6Nbox.TabIndex = 1;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(176, 70);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(47, 13);
            this.label70.TabIndex = 0;
            this.label70.Text = "Field 12:";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(24, 146);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(41, 13);
            this.label64.TabIndex = 0;
            this.label64.Text = "Field 6:";
            // 
            // yokaiUnknown12Nbox
            // 
            this.yokaiUnknown12Nbox.Location = new System.Drawing.Point(224, 68);
            this.yokaiUnknown12Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown12Nbox.Name = "yokaiUnknown12Nbox";
            this.yokaiUnknown12Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown12Nbox.TabIndex = 1;
            // 
            // yokaiUnknown5Nbox
            // 
            this.yokaiUnknown5Nbox.Location = new System.Drawing.Point(67, 119);
            this.yokaiUnknown5Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown5Nbox.Name = "yokaiUnknown5Nbox";
            this.yokaiUnknown5Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown5Nbox.TabIndex = 1;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(176, 95);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(47, 13);
            this.label71.TabIndex = 0;
            this.label71.Text = "Field 13:";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(24, 121);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(41, 13);
            this.label63.TabIndex = 0;
            this.label63.Text = "Field 5:";
            // 
            // yokaiUnknown13Nbox
            // 
            this.yokaiUnknown13Nbox.Location = new System.Drawing.Point(224, 94);
            this.yokaiUnknown13Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown13Nbox.Name = "yokaiUnknown13Nbox";
            this.yokaiUnknown13Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown13Nbox.TabIndex = 1;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(176, 120);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(47, 13);
            this.label72.TabIndex = 0;
            this.label72.Text = "Field 14:";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(24, 96);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(41, 13);
            this.label62.TabIndex = 0;
            this.label62.Text = "Field 4:";
            // 
            // yokaiUnknown14Nbox
            // 
            this.yokaiUnknown14Nbox.Location = new System.Drawing.Point(224, 119);
            this.yokaiUnknown14Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown14Nbox.Name = "yokaiUnknown14Nbox";
            this.yokaiUnknown14Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown14Nbox.TabIndex = 1;
            // 
            // yokaiUnknown3Nbox
            // 
            this.yokaiUnknown3Nbox.Location = new System.Drawing.Point(67, 68);
            this.yokaiUnknown3Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown3Nbox.Name = "yokaiUnknown3Nbox";
            this.yokaiUnknown3Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown3Nbox.TabIndex = 1;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(176, 146);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(47, 13);
            this.label73.TabIndex = 0;
            this.label73.Text = "Field 15:";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(24, 71);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(41, 13);
            this.label61.TabIndex = 0;
            this.label61.Text = "Field 3:";
            // 
            // yokaiUnknown15Nbox
            // 
            this.yokaiUnknown15Nbox.Location = new System.Drawing.Point(224, 144);
            this.yokaiUnknown15Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown15Nbox.Name = "yokaiUnknown15Nbox";
            this.yokaiUnknown15Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown15Nbox.TabIndex = 1;
            // 
            // yokaiUnknown2Nbox
            // 
            this.yokaiUnknown2Nbox.Location = new System.Drawing.Point(67, 43);
            this.yokaiUnknown2Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown2Nbox.Name = "yokaiUnknown2Nbox";
            this.yokaiUnknown2Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown2Nbox.TabIndex = 1;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(176, 171);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(47, 13);
            this.label74.TabIndex = 0;
            this.label74.Text = "Field 16:";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(24, 46);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(41, 13);
            this.label60.TabIndex = 0;
            this.label60.Text = "Field 2:";
            // 
            // yokaiUnknown16Nbox
            // 
            this.yokaiUnknown16Nbox.Location = new System.Drawing.Point(224, 169);
            this.yokaiUnknown16Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown16Nbox.Name = "yokaiUnknown16Nbox";
            this.yokaiUnknown16Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown16Nbox.TabIndex = 1;
            // 
            // yokaiUnknown17Nbox
            // 
            this.yokaiUnknown17Nbox.Location = new System.Drawing.Point(224, 194);
            this.yokaiUnknown17Nbox.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.yokaiUnknown17Nbox.Name = "yokaiUnknown17Nbox";
            this.yokaiUnknown17Nbox.Size = new System.Drawing.Size(88, 20);
            this.yokaiUnknown17Nbox.TabIndex = 1;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(176, 196);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(47, 13);
            this.label75.TabIndex = 0;
            this.label75.Text = "Field 17:";
            // 
            // yokaiListView
            // 
            this.yokaiListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.yokaiSig});
            this.yokaiListView.FullRowSelect = true;
            this.yokaiListView.GridLines = true;
            this.yokaiListView.HideSelection = false;
            this.yokaiListView.Location = new System.Drawing.Point(5, 5);
            this.yokaiListView.MultiSelect = false;
            this.yokaiListView.Name = "yokaiListView";
            this.yokaiListView.Size = new System.Drawing.Size(122, 286);
            this.yokaiListView.TabIndex = 0;
            this.yokaiListView.UseCompatibleStateImageBehavior = false;
            this.yokaiListView.View = System.Windows.Forms.View.Details;
            this.yokaiListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // yokaiSig
            // 
            this.yokaiSig.Text = "Yo-kai Slots";
            this.yokaiSig.Width = 300;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.removeEquipBtn);
            this.tabPage11.Controls.Add(this.replaceEquipBtn);
            this.tabPage11.Controls.Add(this.equipQtNbox);
            this.tabPage11.Controls.Add(this.label76);
            this.tabPage11.Controls.Add(this.equipCbox);
            this.tabPage11.Controls.Add(this.label77);
            this.tabPage11.Controls.Add(this.equipListView);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(499, 294);
            this.tabPage11.TabIndex = 4;
            this.tabPage11.Text = "Equipment";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // removeEquipBtn
            // 
            this.removeEquipBtn.Location = new System.Drawing.Point(418, 30);
            this.removeEquipBtn.Name = "removeEquipBtn";
            this.removeEquipBtn.Size = new System.Drawing.Size(64, 20);
            this.removeEquipBtn.TabIndex = 11;
            this.removeEquipBtn.Text = "Remove";
            this.removeEquipBtn.UseVisualStyleBackColor = true;
            this.removeEquipBtn.Click += new System.EventHandler(this.removeEquipBtn_Click);
            // 
            // replaceEquipBtn
            // 
            this.replaceEquipBtn.Location = new System.Drawing.Point(341, 30);
            this.replaceEquipBtn.Name = "replaceEquipBtn";
            this.replaceEquipBtn.Size = new System.Drawing.Size(64, 20);
            this.replaceEquipBtn.TabIndex = 12;
            this.replaceEquipBtn.Text = "Replace";
            this.replaceEquipBtn.UseVisualStyleBackColor = true;
            this.replaceEquipBtn.Click += new System.EventHandler(this.replaceEquipBtn_Click);
            // 
            // equipQtNbox
            // 
            this.equipQtNbox.Location = new System.Drawing.Point(261, 30);
            this.equipQtNbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.equipQtNbox.Name = "equipQtNbox";
            this.equipQtNbox.Size = new System.Drawing.Size(67, 20);
            this.equipQtNbox.TabIndex = 10;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(207, 32);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(49, 13);
            this.label76.TabIndex = 9;
            this.label76.Text = "Quantity:";
            // 
            // equipCbox
            // 
            this.equipCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.equipCbox.FormattingEnabled = true;
            this.equipCbox.Items.AddRange(new object[] {
            "",
            "Beginner Sword                          ",
            "Great Skills Sword                      ",
            "Swordsman Sword                         ",
            "Warrior God Sword                       ",
            "Bloodstained Sword                      ",
            "Sage Sword                              ",
            "Wild Sword                              ",
            "Great Thief Sword                       ",
            "Demon Sword                             ",
            "Demon King Sword                        ",
            "Sword of Destruction                    ",
            "Fang Of The Great Demon Serpent         ",
            "Black Iron Vajra Ball                   ",
            "Dangerous Hammer                        ",
            "Very Dangerous Hammer                   ",
            "Death Black Hammer                      ",
            "Rocket Hammer                           ",
            "Mega Manbo Smash                        ",
            "Mega Manbo Crash                        ",
            "Demon Axe                               ",
            "Axe of the Demon God                    ",
            "Axe of the Evil God                     ",
            "Practice Glove                          ",
            "Fire Punch                              ",
            "Burning Knuckles                        ",
            "Volcano Upper                           ",
            "Sharp Claws                             ",
            "Brutal Claw                             ",
            "Thousand-Armed Spider Claw              ",
            "A Thousand-Handed Spider Claw           ",
            "Spear of the Great Tree                 ",
            "Divine Spear Red Cross                  ",
            "Strange Sword                           ",
            "Death of a Strange Sword                ",
            "Kusanagi                                ",
            "Holy Blade                              ",
            "Demon God Kuzanagi Sword                ",
            "Yosha Hyo Flame Dance                   ",
            "High-Blade Yasha Ice Flame Dance        ",
            "Enma Hellfire Sword                     ",
            "Lord Ananta Wind-Thunder Sword          ",
            "Twisted Wand                            ",
            "Yo-kai Wand                             ",
            "Wonders Wand                            ",
            "Ghost Wand                              ",
            "Evil Wand                               ",
            "Radiant Wand                            ",
            "Crr Wand                                ",
            "Zzz Wand                                ",
            "Bzz Wand                                ",
            "Brr Wand                                ",
            "Wand Of The Marquis                     ",
            "True Magic Owl Wand                     ",
            "True Magic Owl-Kai Wand                 ",
            "Amaterasu Wand                          ",
            "Amaterasu The Divine Wand               ",
            "Amaterasu The Goddess Wand              ",
            "Reincarnation Wand                      ",
            "Wonderful Wand                          ",
            "Blue Ballade                            ",
            "Golden Rose                             ",
            "Rainbow Rose Walking Stick              ",
            "Fancy Fan                               ",
            "Spectral Fan                            ",
            "Yo-Kai\'s War Coat                       ",
            "Yo-Gun                                  ",
            "Premium Yo-Gun                          ",
            "Yo-Gun 2.0                              ",
            "Yo-Magnum                               ",
            "Sniper Shot                             ",
            "Sniper Shokai                           ",
            "Demon Rifle                             ",
            "Torrent Gun Splash T                    ",
            "Flamenca                                ",
            "Enma Awoken Flute                       ",
            "Demon\'s Jaw Of Darkness                 ",
            "Fudo Kenjaku                            ",
            "Immovable Kutani Sword                  ",
            "Clawed Weasel                           ",
            "Quick Clawed Weasel                     ",
            "Cat King\'s Mirror                       ",
            "Kappa King\'s Mirror                     ",
            "Tengu King\'s Mirror                     ",
            "Demon Blade                             ",
            "Super Demon Blade                       ",
            "Black Claw Nekomata                     ",
            "Triple Nyan Claw                        ",
            "Triple Nyanyan Claw                     ",
            "Enma Yasha Sealed Sword                 ",
            "Enma Yasha Sealed Prison Blade          ",
            "Enma Karma Double Blade                 ",
            "Enma Karma Violent Double Blade         ",
            "Enma Naraku Knife                       ",
            "Enma Naraku Cutting Knife               ",
            "Akaneko Kouren-maru                     ",
            "Akaneko Kouren-maru - Flame             ",
            "Shiroinu Silver Sword                   ",
            "Shiroinu Silver Sword - Blue Flame      ",
            "Get Golden Gun                          ",
            "Get Golden Gun Universe                 ",
            "Phantom Beast Holy Spear                ",
            "Fudo Kaimei Ken                         ",
            "Cat Fist Jiva Jiva Nyakuru              ",
            "Basterds Hell Launcher                  ",
            "Spirit Sword                            ",
            "Lion King Knuckle                       ",
            "Whis Hammer                             ",
            "Whis Hammer II                          ",
            "Whis Hammer III                         ",
            "Demon\'s Claw                            ",
            "Demon\'s Claw Type-2                     ",
            "Demon\'s Claw Type-3                     ",
            "Crimson Halberd                         ",
            "Demon Blade Halberd                     ",
            "Onihime Halberd                         ",
            "Love Mitchy Fan                         ",
            "Mitsumata Fork                          ",
            "Whis Pointer                            ",
            "Whis Pointing Stick                     ",
            "Red Slash                               ",
            "Magic Flame Fist                        ",
            "Ice Flower Fan                          ",
            "Great Fox Fan                           ",
            "Blue Dragon Wand                        ",
            "Seminaire                               ",
            "Three Kendama Brothers                  ",
            "Giant Snake Pickaxe                     ",
            "Old Demon Wand                          ",
            "Cuddly Bills                            ",
            "The Weather Scissors                    ",
            "Giant Snake Dagger                      ",
            "Mon Puke Fist                           ",
            "Wind Cloud Drum                         ",
            "Thunder Cloud Drum                      ",
            "Mountain God Fang                       ",
            "Chain Whip                              ",
            "Buroron Stick                           ",
            "Judgement Wand                          ",
            "Enma Blade                              ",
            "Lord Ananta\'s Sword                     ",
            "True Lord Ananta\'s Sword                ",
            "Yo-Kai Blade                            ",
            "Flame Demon Sword                       ",
            "Chairman\'s Staff                        ",
            "Fudou Thunderbolt Sword Boy             ",
            "Hundred Flowers Fan                     ",
            "Chu Chu Tick Claw                       ",
            "Lost Sword                              ",
            "Zuto Shinya                             ",
            "Shadow Snake Fang                       ",
            "Mangetsu Maru                           ",
            "Spider Cutlass                          ",
            "Shin Toad\'s Great Spear                 ",
            "Masakuni Doudanuki                      ",
            "Giraffe Pencil                          ",
            "Pika Pika Stick                         ",
            "Magic Tube - Mimizuku                   ",
            "Oni Sakura Fan                          ",
            "Demon Weeping Sword                     ",
            "Demon\'s Sword                           ",
            "Onniwa Cudgel                           ",
            "Hungry Wand                             ",
            "Dimmy Ninjitsu                          ",
            "Tattletell Microphone                   ",
            "Hidabat Shuriken                        ",
            "Frostina Fan                            ",
            "Insomnia Wand                           ",
            "Blizzaria Fan                           ",
            "Damona Fan                              ",
            "Nail Bat                                ",
            "Blazion Punch                           ",
            "Burly Dumbbell                          ",
            "Venoct Blade                            ",
            "Illuminoct Blade                        ",
            "Shadow Venoct Blade                     ",
            "Moonlight Pills                         ",
            "Snartle Blade                           ",
            "Spider Sword                            ",
            "Komasan Wand                            ",
            "Komajiro Punch                          ",
            "Hovernyan Knuckle                       ",
            "Reuknight Spear                         ",
            "Yomi Hirasaka Magic Spear               ",
            "Ebisu Great Spear                       ",
            "Magic Claw Akaneko                      ",
            "Mie Mie Stick                           ",
            "Kyubi Fan                               ",
            "Darkyubi Fan                            ",
            "Masternyada Hose                        ",
            "Nyan Style Super Gravuty Gun            ",
            "Golden Particle Cannon                  ",
            "Bottomles Bottle                        ",
            "Unknown Cane                            ",
            "Bunny Blaster                           ",
            "Oni Crush                               ",
            "Demon Rattle                            ",
            "Machibari Stick                         ",
            "Fire Demon Crusher                      ",
            "Water Demon Crusher                     ",
            "Earth Demon Crusher                     ",
            "Komashura Fist                          ",
            "Maul Attachment                         ",
            "Vise Scissors                           ",
            "Baikiki Scissors                        ",
            "Squisker Tentacles                      ",
            "Wicked Staff - Yamiaro                  ",
            "Demon Cutter                            ",
            "Den Punch                               ",
            "Secret Sword                            ",
            "Karakuri Zambara                        ",
            "An No Jolt Blow                         ",
            "Shiname Kiseru                          ",
            "Sunny Stick                             ",
            "Poop Stick                              ",
            "Nightmare Slingshot                     ",
            "B Akaneko Launcher                      ",
            "B Shiroinu Launcher                     ",
            "B Rabbit Launcher                       ",
            "Heroes Bamboo Sword                     ",
            "Fan of Wind                             ",
            "Cane of Stregth                         ",
            "Nekomata Claws                          ",
            "Bewitching Lipstick                     ",
            "Kichizuchi Nari Gama                    ",
            "Kappa\'s Gourd                           ",
            "Amateru Staff Hiizuru                   ",
            "B Kamunagi                              ",
            "Shura No Ou Fang                        ",
            "Staff Of Liberation                     ",
            "Demon\'s Staff                           ",
            "Demolition Wand                         ",
            "Demolition Wand                         ",
            "Musou Knuckle                           ",
            "Tenka Musou Knuckle                     ",
            "Tenjo Tenka Musou Knuckle               ",
            "Fan Of Shakugo                          ",
            "Shakugo No Yoki Fan                     ",
            "Shakugo No Genjyo Fan                   ",
            "Magic Bullet Rifle                      ",
            "High Pressure Migic Bullet Rifle        ",
            "New Style Magic Bullet Rifle            ",
            "Crushing Hammer                         ",
            "Super Crushing Hammer                   ",
            "Ultimate Crushing Hammer                ",
            "Spear Of Annihilation                   ",
            "The Great Spear Of Annihilation         ",
            "Roaring Spear Of Annihilation           ",
            "Kibitsu Sword                           ",
            "Kibitsu Sword - Shiver                  ",
            "Kibitsu Sword - Fuma                    ",
            "Zanma Sword                             ",
            "Zanma\'s Spirit Sword                    ",
            "Zanma King\'s Great Spirit Sword         ",
            "Demon Jade Sword                        ",
            "Demon Jade Treasure Sword               ",
            "Demon Jade Secret Sword                 ",
            "Race Soul Hammer                        ",
            "Race Soul Hammer - Good Luck            ",
            "Race Soul Hammer - Great Luck           ",
            "Petit Petit Wand                        ",
            "Petit Petit Wise Wand                   ",
            "Petit Petit King Wand                   ",
            "Discipline Fan                          ",
            "Discipline Fan 2                        ",
            "Secret Fan                              ",
            "Round Shield                            ",
            "Study Shield                            ",
            "Alloy Shield                            ",
            "Black Iron Shield                       ",
            "Scarlet Sky Shield                      ",
            "Blue Sea Shield                         ",
            "Iron Shield                             ",
            "Silver Shield                           ",
            "Stripes Shield                          ",
            "Evil Shield                             ",
            "Glory Shield                            ",
            "Warty Shield                            ",
            "Flashy Shield                           ",
            "Holy Shield                             ",
            "Divine Shield                           ",
            "Holy & Divine Shield                    ",
            "Sproink Tub                             ",
            "Sproink Scorching Tub                   ",
            "Black Tong Tub                          ",
            "Black Tong Lava Tub                     ",
            "Ashigaru Armour                         ",
            "Bannerman Armour                        ",
            "Commander Armour                        ",
            "Feudal Lord Armour                      ",
            "Samurai Armour                          ",
            "General Armour                          ",
            "Holy Armour                             ",
            "Divine Armour                           ",
            "Carbide Ticking Mail                    ",
            "Indigo Dragon Armour                    ",
            "Ronin Hakama                            ",
            "Swordsman Hakama                        ",
            "Master Hakama                           ",
            "High King Robe                          ",
            "High King Fire Robe                     ",
            "Clean Cloak                             ",
            "Elite Cloak                             ",
            "Dark Night Cloak                        ",
            "Hero Cloak                              ",
            "Bat Cloak                               ",
            "Vampire Cloak                           ",
            "Suzaku Gauntlets                        ",
            "Suzaku Great Gauntlets                  ",
            "Genbu Gauntlets                         ",
            "Genbu Great Gauntlets                   ",
            "White Tiger Gauntlets                   ",
            "White Tiger Great Gauntlets             ",
            "Asura Gauntlets                         ",
            "Asura Great Gauntlets                   ",
            "Fudo Myoo Gauntlets                     ",
            "Fudo Myoo Great Gauntlets               ",
            "Simple Amulet                           ",
            "Clean Amulet                            ",
            "Dark Amulet                             ",
            "Night Sky Amulet                        ",
            "Galaxy Amulet                           ",
            "Starlight Amulet                        ",
            "Flower Charm                            ",
            "Aurora Charm                            ",
            "Mirage Charm                            ",
            "Dawn cHARM                              ",
            "Twilight Charm                          ",
            "Cheerful Charm                          ",
            "Pulsating Charm                         ",
            "Courage Charm                           ",
            "Fiend Charm                             ",
            "Fever Pendant                           ",
            "Passion Pendant                         ",
            "Fighting Spirit Pedant                  ",
            "Tsugihagi Charm                         ",
            "Good Smell Charm                        ",
            "Lucky Charm                             ",
            "Good Luck Charm                         ",
            "Quick Charm                             ",
            "Speedy Charm                            ",
            "Healing Charm                           ",
            "Myo Robe                                ",
            "Momoiro Bow                             ",
            "Cute Bow                                ",
            "Pretty Bow                              ",
            "Demon Skater                            ",
            "Custom Demon Skater                     ",
            "Super Demon Skater                      ",
            "Handmade Scarf                          ",
            "Handmade Sincerity Scarf                ",
            "Handmade Love Scarf                     ",
            "Mitchy Meat Bag                         ",
            "Mitchy Love Diary                       ",
            "Mitchy Life-Size Panel                  ",
            "Hyper Suit                              ",
            "Super Hyper Suit                        ",
            "Hyper Dress                             ",
            "Super Hyper Dress                       ",
            "Komadog Charm                           ",
            "Cool Hat                                ",
            "Bankara Jacket                          ",
            "Green Amulet                            ",
            "Sushi Chief Soul                        ",
            "Sacred Kettle                           ",
            "Time And Space Shield                   ",
            "Cloak From A Can                        ",
            "Giant Choccie                           ",
            "Specially Selected Meat Loincloth       ",
            "Onikuma Make-Up                         ",
            "Frostail Coat                           ",
            "Double 0 Armour                         ",
            "Purr Armor                              ",
            "Hide and Seek Charm                     ",
            "Extreme Charm                           ",
            "Betsukari Charm                         ",
            "Little Charrmer\'s Robe                  ",
            "Mochiri Guard                           ",
            "Noko Charm                              ",
            "Silver Lining Cloak                     ",
            "Prison Handcuffs                        ",
            "Sleeping Charm                          ",
            "Noway Tile                              ",
            "Sandmeh\'s Charm                         ",
            "Special Loincloth                       ",
            "Transfiguration Shield                  ",
            "Tokoyami Lid                            ",
            "Evil Cloak                              ",
            "Wiglin Happi                            ",
            "Steppa Happi                            ",
            "Rhyth Happi                             ",
            "So-Sorry Earpiece                       ",
            "Dismarelda Headband                     ",
            "Happierre Beard                         ",
            "Nosirs Glasses                          ",
            "Jituri Loincloth                        ",
            "Spoilerina Toe Shoes                    ",
            "Horned Helmet                           ",
            "Giant Horned Helmet                     ",
            "Fujiya Belt                             ",
            "Sakuraji Belt                           ",
            "Monk Robe                               ",
            "First Class Lady Pouch                  ",
            "Kyunkyun Karoshi Hat                    ",
            "Wazzhat                                 ",
            "Fast Sneakers                           ",
            "Concealment Cloak                       ",
            "Red Cassock                             ",
            "Emergency Disaster Bag                  ",
            "Faux Kappa Bag                          ",
            "Cow Devil\'s Charm                       ",
            "Nukeboshi Hatchet                       ",
            "Borororin Braided Hat                   ",
            "Kukurihime Braid                        ",
            "Red Bean Colander                       ",
            "Moon Poet Hair Ornament                 "});
            this.equipCbox.Location = new System.Drawing.Point(52, 30);
            this.equipCbox.Name = "equipCbox";
            this.equipCbox.Size = new System.Drawing.Size(151, 21);
            this.equipCbox.TabIndex = 8;
            this.equipCbox.SelectedIndexChanged += new System.EventHandler(this.equipCbox_SelectedIndexChanged);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(18, 32);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(30, 13);
            this.label77.TabIndex = 7;
            this.label77.Text = "Item:";
            // 
            // equipListView
            // 
            this.equipListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.equipIdColumn,
            this.equipId2Column,
            this.equipOrderColumn,
            this.equipNameColumn,
            this.equipQtColumn});
            this.equipListView.FullRowSelect = true;
            this.equipListView.GridLines = true;
            this.equipListView.HideSelection = false;
            this.equipListView.Location = new System.Drawing.Point(18, 74);
            this.equipListView.Name = "equipListView";
            this.equipListView.Size = new System.Drawing.Size(465, 179);
            this.equipListView.TabIndex = 6;
            this.equipListView.UseCompatibleStateImageBehavior = false;
            this.equipListView.View = System.Windows.Forms.View.Details;
            this.equipListView.SelectedIndexChanged += new System.EventHandler(this.equipListView_SelectedIndexChanged);
            // 
            // equipIdColumn
            // 
            this.equipIdColumn.Text = "ID1";
            // 
            // equipId2Column
            // 
            this.equipId2Column.Text = "ID2";
            // 
            // equipOrderColumn
            // 
            this.equipOrderColumn.Text = "Order";
            // 
            // equipNameColumn
            // 
            this.equipNameColumn.Text = "Item Name";
            this.equipNameColumn.Width = 270;
            // 
            // equipQtColumn
            // 
            this.equipQtColumn.Text = "Quantity";
            this.equipQtColumn.Width = 80;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 355);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Another YW4 Save Editor 0.3.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodQtdNbox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.characterOrderIdNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterId2Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterId1Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterIdNbox)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.characterExpNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterYpNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterPGNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterHpNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterLevelNbox)).EndInit();
            this.tabPage8.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.characterStNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterYpPlusNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterHpPlusNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterSdNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterPdNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterSpNbox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionZNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionYNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionXNbox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gatchaMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gatchaDaily)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moneyNbox)).EndInit();
            this.yokaiTab.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiOrderNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiId2Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiId1Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiIdNbox)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiExpNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiYpNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiPgNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiHpNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiLevelNbox)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiStPlusNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiYpPlusNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiHpPlusNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiSdPlusNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiPdPlusNbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiSpPlusNbox)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown4Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown9Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown1Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown8Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown10Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown7Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown11Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown6Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown12Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown5Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown13Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown14Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown3Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown15Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown2Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown16Nbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yokaiUnknown17Nbox)).EndInit();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipQtNbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private TabControl mainTabControl;
        private TabPage tabPage1;
        private GroupBox groupBox4;
        private Label label7;
        private NumericUpDown positionZNbox;
        private NumericUpDown positionYNbox;
        private NumericUpDown positionXNbox;
        private Label label6;
        private Label label5;
        private ComboBox mapCbox;
        private Label label4;
        private GroupBox groupBox3;
        private NumericUpDown gatchaMax;
        private NumericUpDown gatchaDaily;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private NumericUpDown moneyNbox;
        private Label label1;
        private TabPage yokaiTab;
        private TabPage tabPage2;
        private OpenFileDialog openFileDialog1;
        private TabPage tabPage3;
        private GroupBox groupBox1;
        private TextBox katieNameTbox;
        private TextBox nateNameTbox;
        private TextBox jackNameTbox;
        private TextBox akinoriNameTbox;
        private TextBox summerNameTbox;
        private TextBox toumaNameTbox;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private ListView yokaiListView;
        private ColumnHeader yokaiSig;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private NumericUpDown yokaiIdNbox;
        private Label label19;
        private ComboBox yokaiCbox;
        private GroupBox groupBox5;
        private Label label18;
        private Label label17;
        private Label label16;
        private NumericUpDown yokaiExpNbox;
        private NumericUpDown yokaiYpNbox;
        private NumericUpDown yokaiPgNbox;
        private NumericUpDown yokaiHpNbox;
        private Label label15;
        private Label label14;
        private CheckBox isAdvancedList;
        private NumericUpDown yokaiLevelNbox;
        private TabPage tabPage5;
        private GroupBox groupBox6;
        private ComboBox yokaiExSkl3Nbox;
        private ComboBox yokaiExSkl4Nbox;
        private Label label20;
        private Label label21;
        private ComboBox yokaiExSkl2Nbox;
        private ComboBox yokaiExSklNbox;
        private Label label24;
        private ComboBox yokaiSpSklCbox;
        private Label label23;
        private ComboBox yokaiBAtkCbox;
        private Label label25;
        private Label label26;
        private TabPage tabPage6;
        private GroupBox groupBox7;
        private NumericUpDown yokaiStPlusNbox;
        private NumericUpDown yokaiYpPlusNbox;
        private NumericUpDown yokaiHpPlusNbox;
        private NumericUpDown yokaiSdPlusNbox;
        private NumericUpDown yokaiPdPlusNbox;
        private NumericUpDown yokaiSpPlusNbox;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label22;
        private GroupBox groupBox8;
        private NumericUpDown yokaiOrderNbox;
        private NumericUpDown yokaiId2Nbox;
        private NumericUpDown yokaiId1Nbox;
        private Label label34;
        private Label label33;
        private Label label32;
        private NumericUpDown foodQtdNbox;
        private Label label36;
        private ComboBox foodCbox;
        private Label label35;
        private ListView foodItemList;
        private ColumnHeader foodIdColumn1;
        private ColumnHeader foodIdColumn2;
        private ColumnHeader foodItemName;
        private ColumnHeader foodQuantity;
        private ListView mainCharacterViewList;
        private ColumnHeader mainCharacterColumn;
        private TabControl tabControl3;
        private TabPage tabPage7;
        private GroupBox groupBox9;
        private NumericUpDown characterOrderIdNbox;
        private NumericUpDown characterId2Nbox;
        private NumericUpDown characterId1Nbox;
        private Label label37;
        private Label label38;
        private Label label39;
        private NumericUpDown characterIdNbox;
        private Label label40;
        private ComboBox mainCharacterCbox;
        private GroupBox groupBox10;
        private Label label41;
        private Label label42;
        private Label label43;
        private NumericUpDown characterExpNbox;
        private NumericUpDown characterYpNbox;
        private NumericUpDown characterPGNbox;
        private NumericUpDown characterHpNbox;
        private Label label44;
        private Label label45;
        private NumericUpDown characterLevelNbox;
        private TabPage tabPage8;
        private GroupBox groupBox11;
        private ComboBox characterExSkl3Cbox;
        private ComboBox characterExSkl4Cbox;
        private Label label46;
        private Label label47;
        private ComboBox characterExSkl2Cbox;
        private ComboBox characterExSklCbox;
        private Label label48;
        private ComboBox characterSpSklCbox;
        private Label label49;
        private ComboBox characterBAtkCbox;
        private Label label50;
        private Label label51;
        private TabPage tabPage9;
        private GroupBox groupBox12;
        private NumericUpDown characterStNbox;
        private NumericUpDown characterYpPlusNbox;
        private NumericUpDown characterHpPlusNbox;
        private NumericUpDown characterSdNbox;
        private NumericUpDown characterPdNbox;
        private NumericUpDown characterSpNbox;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label57;
        private Button foodRemove;
        private Button foodReplace;
        private TextBox yokaiTbox;
        private Label label58;
        private Button button4;
        private Button saveButton;
        private Button button5;
        private TabPage tabPage10;
        private Label label59;
        private NumericUpDown yokaiUnknown8Nbox;
        private Label label66;
        private NumericUpDown yokaiUnknown7Nbox;
        private Label label65;
        private NumericUpDown yokaiUnknown6Nbox;
        private Label label64;
        private NumericUpDown yokaiUnknown5Nbox;
        private Label label63;
        private NumericUpDown yokaiUnknown4Nbox;
        private Label label62;
        private NumericUpDown yokaiUnknown3Nbox;
        private Label label61;
        private NumericUpDown yokaiUnknown2Nbox;
        private Label label60;
        private NumericUpDown yokaiUnknown1Nbox;
        private NumericUpDown yokaiUnknown9Nbox;
        private Label label67;
        private NumericUpDown yokaiUnknown17Nbox;
        private Label label75;
        private NumericUpDown yokaiUnknown16Nbox;
        private Label label74;
        private NumericUpDown yokaiUnknown15Nbox;
        private Label label73;
        private NumericUpDown yokaiUnknown14Nbox;
        private Label label72;
        private NumericUpDown yokaiUnknown13Nbox;
        private Label label71;
        private NumericUpDown yokaiUnknown12Nbox;
        private Label label70;
        private NumericUpDown yokaiUnknown11Nbox;
        private Label label69;
        private NumericUpDown yokaiUnknown10Nbox;
        private Label label68;
        private GroupBox groupBox13;
        private SaveFileDialog saveFileDialog1;
        private ColumnHeader foodOrder;
        private Button removeMainCharacter;
        private Button saveMainCharacterChanges;
        private Button characterSkillLoaderBtn;
        private ToolStripMenuItem donateToolStripMenuItem;
        private TabPage tabPage11;
        private Button removeEquipBtn;
        private Button replaceEquipBtn;
        private NumericUpDown equipQtNbox;
        private Label label76;
        private ComboBox equipCbox;
        private Label label77;
        private ListView equipListView;
        private ColumnHeader equipIdColumn;
        private ColumnHeader equipId2Column;
        private ColumnHeader equipOrderColumn;
        private ColumnHeader equipNameColumn;
        private ColumnHeader equipQtColumn;
    }
}

