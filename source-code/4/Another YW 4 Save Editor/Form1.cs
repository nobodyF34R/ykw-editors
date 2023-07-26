using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Another_YW_4_Save_Editor
{
    public partial class Form1 : Form
    {
        private Stream openedFile;
        private MemoryStream workFile;
        private SaveFileParams saveFileParams;

        public Form1()
        {
            InitializeComponent();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) => this.saveFileParams.misc.Money = Convert.ToInt32(this.moneyNbox.Value);

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                using (this.openedFile = this.openFileDialog1.OpenFile())
                {
                    this.workFile = new MemoryStream();
                    this.openedFile.Seek(0L, SeekOrigin.Begin);
                    this.openedFile.CopyTo((Stream)this.workFile);
                    this.saveFileParams = new SaveFileParams();
                    this.saveFileParams.mapParams(this.openedFile);
                    if (this.yokaiListView.Items.Count > 0)
                        this.yokaiListView.Items.Clear();
                    if (this.foodItemList.Items.Count > 0)
                        this.foodItemList.Items.Clear();
                    if (this.mainCharacterViewList.Items.Count > 0)
                        this.mainCharacterViewList.Items.Clear();
                    if (this.equipListView.Items.Count > 0)
                        this.mainCharacterViewList.Items.Clear();
                    this.moneyNbox.Value = (Decimal)this.saveFileParams.misc.Money;
                    this.gatchaDaily.Value = (Decimal)this.saveFileParams.misc.Gatcha.gatchaTries;
                    this.gatchaMax.Value = (Decimal)this.saveFileParams.misc.Gatcha.gatchaMaxTries;
                    this.mapCbox.SelectedIndex = new GetMap().pickMapIndex(this.saveFileParams.misc.LocalParams.Map);
                    this.positionXNbox.Value = (Decimal)this.saveFileParams.misc.LocalParams.PositionX;
                    this.positionYNbox.Value = (Decimal)this.saveFileParams.misc.LocalParams.PositionY;
                    this.positionZNbox.Value = (Decimal)this.saveFileParams.misc.LocalParams.PositionZ;
                    this.nateNameTbox.Text = this.saveFileParams.misc.NateName;
                    this.katieNameTbox.Text = this.saveFileParams.misc.KatieName;
                    this.summerNameTbox.Text = this.saveFileParams.misc.SummerName;
                    this.toumaNameTbox.Text = this.saveFileParams.misc.ToumaName;
                    this.akinoriNameTbox.Text = this.saveFileParams.misc.AkinoriName;
                    this.jackNameTbox.Text = this.saveFileParams.misc.JackName;
                    foreach (YoKai userYoKai in this.saveFileParams.UserYoKaiList)
                        this.yokaiListView.Items.Add(new ListViewItem()
                        {
                            Text = new GetYokai().pickYokaiName(userYoKai.YoKai_Signature ?? "Invalid")
                        });
                    foreach (MainCharacter mainCharacter in this.saveFileParams.MainCharacterList)
                        this.mainCharacterViewList.Items.Add(new ListViewItem()
                        {
                            Text = new GetYokai().pickYokaiName(mainCharacter.Character_Signature ?? "Invalid")
                        });
                    foreach (Consumable consumable in this.saveFileParams.ConsumableList)
                    {
                        ListView.ListViewItemCollection items1 = this.foodItemList.Items;
                        int num = consumable.ID1;
                        string text = num.ToString();
                        ListViewItem.ListViewSubItemCollection subItems = items1.Add(text).SubItems;
                        string[] items2 = new string[4];
                        num = consumable.ID2;
                        items2[0] = num.ToString();
                        num = consumable.Order;
                        items2[1] = num.ToString();
                        items2[2] = new GetConsumable().pickConsumableName(consumable.ItemSignature ?? "Invalid");
                        num = consumable.Quantity;
                        items2[3] = num.ToString();
                        subItems.AddRange(items2);
                    }
                    foreach (Equipment equipment in this.saveFileParams.EquipmentList)
                    {
                        ListView.ListViewItemCollection items3 = this.equipListView.Items;
                        int num = equipment.ID1;
                        string text = num.ToString();
                        ListViewItem.ListViewSubItemCollection subItems = items3.Add(text).SubItems;
                        string[] items4 = new string[4];
                        num = equipment.ID2;
                        items4[0] = num.ToString();
                        num = equipment.Order;
                        items4[1] = num.ToString();
                        items4[2] = new GetEquipment().pickEquipmentName(equipment.ItemSignature ?? "Invalid");
                        num = equipment.Quantity;
                        items4[3] = num.ToString();
                        subItems.AddRange(items4);
                    }
                    this.yokaiListView.Items[0].Selected = true;
                    this.foodItemList.Items[0].Selected = true;
                    this.equipListView.Items[0].Selected = true;
                    this.mainCharacterViewList.Items[0].Selected = true;
                    this.saveAsToolStripMenuItem.Enabled = true;
                    this.mainTabControl.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Error message: " + ex.Message + "\n\nDetails:\n\n" + ex.StackTrace);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.yokaiListView.SelectedItems)
            {
                if (this.isAdvancedList.Checked)
                    this.yokaiCbox.SelectedIndex = new GetYokai().pickYokaiIDNumber(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Signature ?? "");
                else
                    this.yokaiCbox.SelectedIndex = new GetYokai().pickYokaiHealthyIndex(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Signature ?? "");
                this.yokaiIdNbox.Value = (Decimal)new GetYokai().pickYokaiIDNumber(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Signature ?? "");
                this.yokaiLevelNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Level;
                this.yokaiYpNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_YP;
                this.yokaiHpNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_HP;
                this.yokaiExpNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_XP;
                this.yokaiPgNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_PG;
                this.yokaiTbox.Text = this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Name;
                this.yokaiId1Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].ID1;
                this.yokaiId2Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].ID2;
                this.yokaiOrderNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Order;
                this.yokaiHpPlusNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_HPplus;
                this.yokaiYpPlusNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_YPplus;
                this.yokaiPdPlusNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_PAplus;
                this.yokaiSdPlusNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_SAplus;
                this.yokaiStPlusNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_STplus;
                this.yokaiSpPlusNbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_SPplus;
                this.yokaiBAtkCbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill1 ?? "");
                this.yokaiSpSklCbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill2 ?? "");
                this.yokaiExSklNbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill3 ?? "");
                this.yokaiExSkl2Nbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill4 ?? "");
                this.yokaiExSkl3Nbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill5 ?? "");
                this.yokaiExSkl4Nbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill6 ?? "");
                this.yokaiUnknown1Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown1;
                this.yokaiUnknown2Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown2;
                this.yokaiUnknown3Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown3;
                this.yokaiUnknown4Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown4;
                this.yokaiUnknown5Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown5;
                this.yokaiUnknown6Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown6;
                this.yokaiUnknown7Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown7;
                this.yokaiUnknown8Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown8;
                this.yokaiUnknown9Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown9;
                this.yokaiUnknown10Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown10;
                this.yokaiUnknown11Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown11;
                this.yokaiUnknown12Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown12;
                this.yokaiUnknown13Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown13;
                this.yokaiUnknown14Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown14;
                this.yokaiUnknown15Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown15;
                this.yokaiUnknown16Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown16;
                this.yokaiUnknown17Nbox.Value = (Decimal)this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown17;
            }
        }

        private void mapCbox_SelectedIndexChanged(object sender, EventArgs e) => this.saveFileParams.misc.LocalParams.Map = new SetMap().pickMapByte(this.mapCbox.SelectedIndex);

        private void isAdvancedList_CheckedChanged(object sender, EventArgs e)
        {
            if (this.isAdvancedList.Checked)
            {
                this.yokaiCbox.Items.Clear();
                this.yokaiCbox.Items.Add((object)"");
                this.yokaiCbox.Items.Add((object)"Touma                                         ");
                this.yokaiCbox.Items.Add((object)"Summer                                        ");
                this.yokaiCbox.Items.Add((object)"Akinori                                       ");
                this.yokaiCbox.Items.Add((object)"Akinori (Fit)                                 ");
                this.yokaiCbox.Items.Add((object)"Jack                                          ");
                this.yokaiCbox.Items.Add((object)"Nate                                          ");
                this.yokaiCbox.Items.Add((object)"Katie                                         ");
                this.yokaiCbox.Items.Add((object)"Himoji (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Himoji (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Himoji Shadow Boss                            ");
                this.yokaiCbox.Items.Add((object)"Pakkun (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Pakkun (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Pakkun Shadow Boss                            ");
                this.yokaiCbox.Items.Add((object)"Kyunshii (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Kyunshii (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Kyunshii Shadow Boss                          ");
                this.yokaiCbox.Items.Add((object)"Hare-onna (Lightside)                         ");
                this.yokaiCbox.Items.Add((object)"Hare-onna (Shadowside)                        ");
                this.yokaiCbox.Items.Add((object)"Choky (Lightside)                             ");
                this.yokaiCbox.Items.Add((object)"Choky (Shadowside)                            ");
                this.yokaiCbox.Items.Add((object)"Fubuki-hime (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Fubuki-hime (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Fubuki-hime Shadow Boss                       ");
                this.yokaiCbox.Items.Add((object)"Merameraion (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Merameraion (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Merameraion Shadow Boss                       ");
                this.yokaiCbox.Items.Add((object)"Orochi (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Orochi (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Orochi Shadow Boss                            ");
                this.yokaiCbox.Items.Add((object)"Honmaguro-taishou (Lightside)                 ");
                this.yokaiCbox.Items.Add((object)"Honmaguro-taishou (Shadowside)                ");
                this.yokaiCbox.Items.Add((object)"Honmaguro-taishou Shadow Boss                 ");
                this.yokaiCbox.Items.Add((object)"Semicolon (Lightside)                         ");
                this.yokaiCbox.Items.Add((object)"Semicolon (Shadowside)                        ");
                this.yokaiCbox.Items.Add((object)"Semicolon Shadow Boss                         ");
                this.yokaiCbox.Items.Add((object)"Komasan (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Komasan (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Komajiro (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Komajiro (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Komajiro Shadow Boss                          ");
                this.yokaiCbox.Items.Add((object)"Banchou (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Banchou (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Banchou Shadow Boss                           ");
                this.yokaiCbox.Items.Add((object)"Seiryuu (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Seiryuu (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Fuu-kun (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Fuu-kun (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Fuu-kun Shadow Boss                           ");
                this.yokaiCbox.Items.Add((object)"Rai-chan (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Rai-chan (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Rai-chan Shadow Boss                          ");
                this.yokaiCbox.Items.Add((object)"Hamham (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Hamham (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Jibanyan (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Jibanyan (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Uribou (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Uribou (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Kyubi (Lightside)                             ");
                this.yokaiCbox.Items.Add((object)"Kyubi (Shadowside)                            ");
                this.yokaiCbox.Items.Add((object)"Kyubi Shadow Boss                             ");
                this.yokaiCbox.Items.Add((object)"Charlie (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Charlie (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Zundoumaru (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Zundoumaru (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Zundoumaru Shadow Boss                        ");
                this.yokaiCbox.Items.Add((object)"Ungaikyo (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Ungaikyo (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Jinta (Lightside)                             ");
                this.yokaiCbox.Items.Add((object)"Jinta (Shadowside)                            ");
                this.yokaiCbox.Items.Add((object)"Jinta Shadow Boss                             ");
                this.yokaiCbox.Items.Add((object)"Kantaro (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Kantaro (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Kantaro Shadow Boss                           ");
                this.yokaiCbox.Items.Add((object)"Kiborikkuma (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Kiborikkuma (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Junior (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Junior (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Micchy (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Micchy (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Micchy Hyper (Lightside)                      ");
                this.yokaiCbox.Items.Add((object)"Micchy Hyper (Shadowside)                     ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Hungramps                                     ");
                this.yokaiCbox.Items.Add((object)"Dimmy                                         ");
                this.yokaiCbox.Items.Add((object)"Tattletell                                    ");
                this.yokaiCbox.Items.Add((object)"Dismarelda                                    ");
                this.yokaiCbox.Items.Add((object)"Hidabat                                       ");
                this.yokaiCbox.Items.Add((object)"Frostina                                      ");
                this.yokaiCbox.Items.Add((object)"Insomni                                       ");
                this.yokaiCbox.Items.Add((object)"Insomni (Boss)                                ");
                this.yokaiCbox.Items.Add((object)"Blizzaria                                     ");
                this.yokaiCbox.Items.Add((object)"Damona                                        ");
                this.yokaiCbox.Items.Add((object)"Little Charrmer                               ");
                this.yokaiCbox.Items.Add((object)"Roughraff                                     ");
                this.yokaiCbox.Items.Add((object)"Roughraff (Boss)                              ");
                this.yokaiCbox.Items.Add((object)"Mochismo                                      ");
                this.yokaiCbox.Items.Add((object)"Blazion                                       ");
                this.yokaiCbox.Items.Add((object)"Blazion (Boss)                                ");
                this.yokaiCbox.Items.Add((object)"Sgt. Burly                                    ");
                this.yokaiCbox.Items.Add((object)"Venoct                                        ");
                this.yokaiCbox.Items.Add((object)"Illuminoct                                    ");
                this.yokaiCbox.Items.Add((object)"Shadow Venoct                                 ");
                this.yokaiCbox.Items.Add((object)"Shogunyan                                     ");
                this.yokaiCbox.Items.Add((object)"Snartle                                       ");
                this.yokaiCbox.Items.Add((object)"Snartle (Boss)                                ");
                this.yokaiCbox.Items.Add((object)"Arachnus                                      ");
                this.yokaiCbox.Items.Add((object)"Arachnus (Boss)                               ");
                this.yokaiCbox.Items.Add((object)"Komashura                                     ");
                this.yokaiCbox.Items.Add((object)"Noko                                          ");
                this.yokaiCbox.Items.Add((object)"Komasan                                       ");
                this.yokaiCbox.Items.Add((object)"Komajiro                                      ");
                this.yokaiCbox.Items.Add((object)"Happierre                                     ");
                this.yokaiCbox.Items.Add((object)"Hovernyan                                     ");
                this.yokaiCbox.Items.Add((object)"Reuknight                                     ");
                this.yokaiCbox.Items.Add((object)"Reuknight Boss                                ");
                this.yokaiCbox.Items.Add((object)"Corptain                                      ");
                this.yokaiCbox.Items.Add((object)"Toadal Dude                                   ");
                this.yokaiCbox.Items.Add((object)"Toadal Dude Boss                              ");
                this.yokaiCbox.Items.Add((object)"Silver Lining                                 ");
                this.yokaiCbox.Items.Add((object)"Manjimutt                                     ");
                this.yokaiCbox.Items.Add((object)"Manjimutt Boss                                ");
                this.yokaiCbox.Items.Add((object)"Jibanyan                                      ");
                this.yokaiCbox.Items.Add((object)"Krystal Fox                                   ");
                this.yokaiCbox.Items.Add((object)"Baku                                          ");
                this.yokaiCbox.Items.Add((object)"Kyubi                                         ");
                this.yokaiCbox.Items.Add((object)"Darkyubi                                      ");
                this.yokaiCbox.Items.Add((object)"Master Nyada                                  ");
                this.yokaiCbox.Items.Add((object)"Noway                                         ");
                this.yokaiCbox.Items.Add((object)"Sandmeh                                       ");
                this.yokaiCbox.Items.Add((object)"Mimikin                                       ");
                this.yokaiCbox.Items.Add((object)"Mimikin Boss                                  ");
                this.yokaiCbox.Items.Add((object)"Mirapo                                        ");
                this.yokaiCbox.Items.Add((object)"Robonyan                                      ");
                this.yokaiCbox.Items.Add((object)"Goldenyan                                     ");
                this.yokaiCbox.Items.Add((object)"Wiglin                                        ");
                this.yokaiCbox.Items.Add((object)"Steppa                                        ");
                this.yokaiCbox.Items.Add((object)"Rhyth                                         ");
                this.yokaiCbox.Items.Add((object)"Walkappa                                      ");
                this.yokaiCbox.Items.Add((object)"Nosirs                                        ");
                this.yokaiCbox.Items.Add((object)"Cornfused                                     ");
                this.yokaiCbox.Items.Add((object)"Whisper                                       ");
                this.yokaiCbox.Items.Add((object)"Swelton                                       ");
                this.yokaiCbox.Items.Add((object)"Usapyon                                       ");
                this.yokaiCbox.Items.Add((object)"Usapyon                                       ");
                this.yokaiCbox.Items.Add((object)"Spoilerina                                    ");
                this.yokaiCbox.Items.Add((object)"Sighborg Y                                    ");
                this.yokaiCbox.Items.Add((object)"Wobblewok                                     ");
                this.yokaiCbox.Items.Add((object)"Deadcool                                      ");
                this.yokaiCbox.Items.Add((object)"Gargaros                                      ");
                this.yokaiCbox.Items.Add((object)"Ogralus                                       ");
                this.yokaiCbox.Items.Add((object)"Orcanos                                       ");
                this.yokaiCbox.Items.Add((object)"Gilgaros                                      ");
                this.yokaiCbox.Items.Add((object)"Shirokuma                                     ");
                this.yokaiCbox.Items.Add((object)"Punkupine                                     ");
                this.yokaiCbox.Items.Add((object)"Sorrypus                                      ");
                this.yokaiCbox.Items.Add((object)"Jabow                                         ");
                this.yokaiCbox.Items.Add((object)"Beetall                                       ");
                this.yokaiCbox.Items.Add((object)"Cruncha                                       ");
                this.yokaiCbox.Items.Add((object)"Rhinormous                                    ");
                this.yokaiCbox.Items.Add((object)"Hornaplenty                                   ");
                this.yokaiCbox.Items.Add((object)"Mad Mountain                                  ");
                this.yokaiCbox.Items.Add((object)"Lava Lord                                     ");
                this.yokaiCbox.Items.Add((object)"Faux Kappa                                    ");
                this.yokaiCbox.Items.Add((object)"McKraken                                      ");
                this.yokaiCbox.Items.Add((object)"Suu-san                                       ");
                this.yokaiCbox.Items.Add((object)"Yamanba                                       ");
                this.yokaiCbox.Items.Add((object)"Tamamo                                        ");
                this.yokaiCbox.Items.Add((object)"Gyuuki                                        ");
                this.yokaiCbox.Items.Add((object)"Narigama                                      ");
                this.yokaiCbox.Items.Add((object)"Blobgoblin                                    ");
                this.yokaiCbox.Items.Add((object)"Nekomata Neko'ou Bastet                       ");
                this.yokaiCbox.Items.Add((object)"Kappa Kappa'ou Sagojou                        ");
                this.yokaiCbox.Items.Add((object)"Zashiki-warashi Tengu'ou Kurama               ");
                this.yokaiCbox.Items.Add((object)"Kawauso                                       ");
                this.yokaiCbox.Items.Add((object)"Enma                                          ");
                this.yokaiCbox.Items.Add((object)"Lord Ananta                                   ");
                this.yokaiCbox.Items.Add((object)"Douketsu                                      ");
                this.yokaiCbox.Items.Add((object)"Douketsu                                      ");
                this.yokaiCbox.Items.Add((object)"Shutendoji                                    ");
                this.yokaiCbox.Items.Add((object)"Ogu Togu Mogu                                 ");
                this.yokaiCbox.Items.Add((object)"Nurarihyon                                    ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou Boy                              ");
                this.yokaiCbox.Items.Add((object)"Whisper                                       ");
                this.yokaiCbox.Items.Add((object)"Enma Awakened                                 ");
                this.yokaiCbox.Items.Add((object)"Yami Enma                                     ");
                this.yokaiCbox.Items.Add((object)"Kaibyou Kamaitachi                            ");
                this.yokaiCbox.Items.Add((object)"Neko'ou Bastet                                ");
                this.yokaiCbox.Items.Add((object)"Kappa Kappa'ou Sagojou                        ");
                this.yokaiCbox.Items.Add((object)"Zashiki-warashi Tengu'ou Kurama               ");
                this.yokaiCbox.Items.Add((object)"Touma Omatsu                                  ");
                this.yokaiCbox.Items.Add((object)"Touma Yoshitsune                              ");
                this.yokaiCbox.Items.Add((object)"Touma Goemon                                  ");
                this.yokaiCbox.Items.Add((object)"Touma Benkei                                  ");
                this.yokaiCbox.Items.Add((object)"Suzaku (Sword Bearer)                         ");
                this.yokaiCbox.Items.Add((object)"Genbu (Sword Bearer)                          ");
                this.yokaiCbox.Items.Add((object)"Byakko (Sword Bearer)                         ");
                this.yokaiCbox.Items.Add((object)"Kirin                                         ");
                this.yokaiCbox.Items.Add((object)"Souryuu                                       ");
                this.yokaiCbox.Items.Add((object)"Gunshin Susanoo                               ");
                this.yokaiCbox.Items.Add((object)"Touma Fudou Myouou                            ");
                this.yokaiCbox.Items.Add((object)"Touma Fudou Myouou Ten                        ");
                this.yokaiCbox.Items.Add((object)"Touma Suzaku                                  ");
                this.yokaiCbox.Items.Add((object)"Touma Genbu 2                                 ");
                this.yokaiCbox.Items.Add((object)"Touma Byakko                                  ");
                this.yokaiCbox.Items.Add((object)"Touma Ashura                                  ");
                this.yokaiCbox.Items.Add((object)"Shuka Natsume (Summer)                        ");
                this.yokaiCbox.Items.Add((object)"[DONT_WORK]                                   ");
                this.yokaiCbox.Items.Add((object)"Jinta Shadow (boss)                           ");
                this.yokaiCbox.Items.Add((object)"Micchy Shadow (boss)                          ");
                this.yokaiCbox.Items.Add((object)"Micchy Eye Ball (boss)                        ");
                this.yokaiCbox.Items.Add((object)"Jorogumo (boss)                               ");
                this.yokaiCbox.Items.Add((object)"Shinmagunjin Fukurou (boss)                   ");
                this.yokaiCbox.Items.Add((object)"Overseer                                      ");
                this.yokaiCbox.Items.Add((object)"Overseer 2                                    ");
                this.yokaiCbox.Items.Add((object)"Overseer 3                                    ");
                this.yokaiCbox.Items.Add((object)"Diamond                                       ");
                this.yokaiCbox.Items.Add((object)"Yami Enma                                     ");
                this.yokaiCbox.Items.Add((object)"Enma                                          ");
                this.yokaiCbox.Items.Add((object)"Maten Soranaki                                ");
                this.yokaiCbox.Items.Add((object)"Gilgaros                                      ");
                this.yokaiCbox.Items.Add((object)"Illuminoct                                    ");
                this.yokaiCbox.Items.Add((object)"Blizzaria                                     ");
                this.yokaiCbox.Items.Add((object)"Sgt. Burly                                    ");
                this.yokaiCbox.Items.Add((object)"Damona                                        ");
                this.yokaiCbox.Items.Add((object)"Manjimutt                                     ");
                this.yokaiCbox.Items.Add((object)"Enma Awoken                                   ");
                this.yokaiCbox.Items.Add((object)"Raidenryu                                     ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou                                  ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou                                  ");
                this.yokaiCbox.Items.Add((object)"Suzaku (Celestial)                            ");
                this.yokaiCbox.Items.Add((object)"Suzaku big                                    ");
                this.yokaiCbox.Items.Add((object)"Genbu (Celestial)                             ");
                this.yokaiCbox.Items.Add((object)"Genbu big                                     ");
                this.yokaiCbox.Items.Add((object)"Byakko (Celestial)                            ");
                this.yokaiCbox.Items.Add((object)"Byakko big                                    ");
                this.yokaiCbox.Items.Add((object)"Ashura                                        ");
                this.yokaiCbox.Items.Add((object)"Ashura big                                    ");
                this.yokaiCbox.Items.Add((object)"Douketsu                                      ");
                this.yokaiCbox.Items.Add((object)"Douketsu                                      ");
                this.yokaiCbox.Items.Add((object)"Shutendoji                                    ");
                this.yokaiCbox.Items.Add((object)"Yamamba                                       ");
                this.yokaiCbox.Items.Add((object)"Tamamo no Mae                                 ");
                this.yokaiCbox.Items.Add((object)"Shien                                         ");
                this.yokaiCbox.Items.Add((object)"Shinma Kaira                                  ");
                this.yokaiCbox.Items.Add((object)"Shinma Kaira                                  ");
                this.yokaiCbox.Items.Add((object)"Jinta Shadow                                  ");
                this.yokaiCbox.Items.Add((object)"Jinta Shadow                                  ");
                this.yokaiCbox.Items.Add((object)"Jinta Shadow                                  ");
                this.yokaiCbox.Items.Add((object)"Jinta Shadow                                  ");
                this.yokaiCbox.Items.Add((object)"Mitsumata Nozuchi                             ");
                this.yokaiCbox.Items.Add((object)"Mitsumata Nozuchi                             ");
                this.yokaiCbox.Items.Add((object)"Mitsumata Nozuchi                             ");
                this.yokaiCbox.Items.Add((object)"Mitsumata Nozuchi                             ");
                this.yokaiCbox.Items.Add((object)"Micchy Eye Ball                               ");
                this.yokaiCbox.Items.Add((object)"Micchy Eye Ball                               ");
                this.yokaiCbox.Items.Add((object)"Micchy Eye Ball                               ");
                this.yokaiCbox.Items.Add((object)"Micchy Eye Ball                               ");
                this.yokaiCbox.Items.Add((object)"Jorogumo                                      ");
                this.yokaiCbox.Items.Add((object)"Jorogumo                                      ");
                this.yokaiCbox.Items.Add((object)"Jorogumo                                      ");
                this.yokaiCbox.Items.Add((object)"Jorogumo                                      ");
                this.yokaiCbox.Items.Add((object)"Shinmagunjin Fukurou                          ");
                this.yokaiCbox.Items.Add((object)"Shinmagunjin Fukurou                          ");
                this.yokaiCbox.Items.Add((object)"Shinmagunjin Fukurou                          ");
                this.yokaiCbox.Items.Add((object)"Shinmagunjin Fukurou                          ");
                this.yokaiCbox.Items.Add((object)"Overseer                                      ");
                this.yokaiCbox.Items.Add((object)"Overseer                                      ");
                this.yokaiCbox.Items.Add((object)"Overseer                                      ");
                this.yokaiCbox.Items.Add((object)"Overseer                                      ");
                this.yokaiCbox.Items.Add((object)"Overseer giant                                ");
                this.yokaiCbox.Items.Add((object)"Overseer giant                                ");
                this.yokaiCbox.Items.Add((object)"Diamond                                       ");
                this.yokaiCbox.Items.Add((object)"Enma                                          ");
                this.yokaiCbox.Items.Add((object)"Overseer giant                                ");
                this.yokaiCbox.Items.Add((object)"Overseer giant                                ");
                this.yokaiCbox.Items.Add((object)"Diamond                                       ");
                this.yokaiCbox.Items.Add((object)"Enma                                          ");
                this.yokaiCbox.Items.Add((object)"Overseer giant                                ");
                this.yokaiCbox.Items.Add((object)"Overseer giant                                ");
                this.yokaiCbox.Items.Add((object)"Diamond                                       ");
                this.yokaiCbox.Items.Add((object)"Enma                                          ");
                this.yokaiCbox.Items.Add((object)"Overseer giant                                ");
                this.yokaiCbox.Items.Add((object)"Overseer giant                                ");
                this.yokaiCbox.Items.Add((object)"Diamond                                       ");
                this.yokaiCbox.Items.Add((object)"Enma                                          ");
                this.yokaiCbox.Items.Add((object)"Maten Soranaki                                ");
                this.yokaiCbox.Items.Add((object)"Maten Soranaki                                ");
                this.yokaiCbox.Items.Add((object)"Maten Soranaki                                ");
                this.yokaiCbox.Items.Add((object)"Maten Soranaki                                ");
                this.yokaiCbox.Items.Add((object)"Maten Soranaki                                ");
                this.yokaiCbox.Items.Add((object)"Gilgaros                                      ");
                this.yokaiCbox.Items.Add((object)"Illuminoct                                    ");
                this.yokaiCbox.Items.Add((object)"Blizzaria                                     ");
                this.yokaiCbox.Items.Add((object)"Sgt. Burly                                    ");
                this.yokaiCbox.Items.Add((object)"Damona                                        ");
                this.yokaiCbox.Items.Add((object)"Manjimutt                                     ");
                this.yokaiCbox.Items.Add((object)"Gilgaros                                      ");
                this.yokaiCbox.Items.Add((object)"Illuminoct                                    ");
                this.yokaiCbox.Items.Add((object)"Blizzaria                                     ");
                this.yokaiCbox.Items.Add((object)"Sgt. Burly                                    ");
                this.yokaiCbox.Items.Add((object)"Damona                                        ");
                this.yokaiCbox.Items.Add((object)"Manjimutt                                     ");
                this.yokaiCbox.Items.Add((object)"Gilgaros                                      ");
                this.yokaiCbox.Items.Add((object)"Illuminoct                                    ");
                this.yokaiCbox.Items.Add((object)"Blizzaria                                     ");
                this.yokaiCbox.Items.Add((object)"Sgt. Burly                                    ");
                this.yokaiCbox.Items.Add((object)"Damona                                        ");
                this.yokaiCbox.Items.Add((object)"Manjimutt                                     ");
                this.yokaiCbox.Items.Add((object)"Gilgaros                                      ");
                this.yokaiCbox.Items.Add((object)"Illuminoct                                    ");
                this.yokaiCbox.Items.Add((object)"Blizzaria                                     ");
                this.yokaiCbox.Items.Add((object)"Sgt. Burly                                    ");
                this.yokaiCbox.Items.Add((object)"Damona                                        ");
                this.yokaiCbox.Items.Add((object)"Manjimutt                                     ");
                this.yokaiCbox.Items.Add((object)"Gilgaros                                      ");
                this.yokaiCbox.Items.Add((object)"Illuminoct                                    ");
                this.yokaiCbox.Items.Add((object)"Blizzaria                                     ");
                this.yokaiCbox.Items.Add((object)"Sgt. Burly                                    ");
                this.yokaiCbox.Items.Add((object)"Damona                                        ");
                this.yokaiCbox.Items.Add((object)"Manjimutt                                     ");
                this.yokaiCbox.Items.Add((object)"Shien                                         ");
                this.yokaiCbox.Items.Add((object)"Shien                                         ");
                this.yokaiCbox.Items.Add((object)"Shien                                         ");
                this.yokaiCbox.Items.Add((object)"Shien                                         ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou                                  ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou-kai                              ");
                this.yokaiCbox.Items.Add((object)"Suzaku (Celestial)                            ");
                this.yokaiCbox.Items.Add((object)"Suzaku big                                    ");
                this.yokaiCbox.Items.Add((object)"Genbu (Celestial)                             ");
                this.yokaiCbox.Items.Add((object)"Genbu big                                     ");
                this.yokaiCbox.Items.Add((object)"Byakko (Celestial)                            ");
                this.yokaiCbox.Items.Add((object)"Byakko big                                    ");
                this.yokaiCbox.Items.Add((object)"Ashura                                        ");
                this.yokaiCbox.Items.Add((object)"Yami Enma                                     ");
                this.yokaiCbox.Items.Add((object)"Nekomata Neko'ou Bastet                       ");
                this.yokaiCbox.Items.Add((object)"Kappa Kappa'ou Sagojou                        ");
                this.yokaiCbox.Items.Add((object)"Zashiki-warashi Tengu'ou Kurama               ");
                this.yokaiCbox.Items.Add((object)"McKraken                                      ");
                this.yokaiCbox.Items.Add((object)"Seiryuu Shadow                                ");
                this.yokaiCbox.Items.Add((object)"Jinta Shadow (boss)                           ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin Shadow                             ");
                this.yokaiCbox.Items.Add((object)"Lord Ananta                                   ");
                this.yokaiCbox.Items.Add((object)"Fuu-kun (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Fuu-kun (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Rai-chan (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Rai-chan (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Arachnus                                      ");
                this.yokaiCbox.Items.Add((object)"Toadal Dude                                   ");
                this.yokaiCbox.Items.Add((object)"Orochi (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Orochi (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Kyubi (Lightside)                             ");
                this.yokaiCbox.Items.Add((object)"Kyubi (Shadowside)                            ");
                this.yokaiCbox.Items.Add((object)"Deadcool                                      ");
                this.yokaiCbox.Items.Add((object)"Hovernyan                                     ");
                this.yokaiCbox.Items.Add((object)"Little Charrmer                               ");
                this.yokaiCbox.Items.Add((object)"Micchy (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Micchy (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou Boy                              ");
                this.yokaiCbox.Items.Add((object)"Shogunyan                                     ");
                this.yokaiCbox.Items.Add((object)"Komashura                                     ");
                this.yokaiCbox.Items.Add((object)"Gilgaros                                      ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin Shadow                             ");
                this.yokaiCbox.Items.Add((object)"Neko'ou Bastet                                ");
                this.yokaiCbox.Items.Add((object)"Kappa'ou Sagojou                              ");
                this.yokaiCbox.Items.Add((object)"Tengu'ou Kurama                               ");
                this.yokaiCbox.Items.Add((object)"Lord Ananta Shadow                            ");
                this.yokaiCbox.Items.Add((object)"Yasha Enma                                    ");
                this.yokaiCbox.Items.Add((object)"Fukurou                                       ");
                this.yokaiCbox.Items.Add((object)"Shuka                                         ");
                this.yokaiCbox.Items.Add((object)"Gentou                                        ");
                this.yokaiCbox.Items.Add((object)"Hakushu                                       ");
                this.yokaiCbox.Items.Add((object)"Kuuten                                        ");
                this.yokaiCbox.Items.Add((object)"Jinta (boss)                                  ");
                this.yokaiCbox.Items.Add((object)"Jinta (boss)                                  ");
                this.yokaiCbox.Items.Add((object)"Kakurenbou (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Kakurenbou (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Hyakki-hime (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Hyakki-hime (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Daniel (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Daniel (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Itashikatanshi (Lightside)                    ");
                this.yokaiCbox.Items.Add((object)"Itashikatanshi (Shadowside)                   ");
                this.yokaiCbox.Items.Add((object)"Saya (Lightside)                              ");
                this.yokaiCbox.Items.Add((object)"Saya (Shadowside)                             ");
                this.yokaiCbox.Items.Add((object)"Rai Oton (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Rai Oton (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Kage Orochi (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Kage Orochi (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Bushinyan (Lightside)                         ");
                this.yokaiCbox.Items.Add((object)"Bushinyan (Shadowside)                        ");
                this.yokaiCbox.Items.Add((object)"Shurakoma (Lightside)                         ");
                this.yokaiCbox.Items.Add((object)"Shurakoma (Shadowside)                        ");
                this.yokaiCbox.Items.Add((object)"Tsuchigumo (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Tsuchigumo (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Tsuchinoko (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Tsuchinoko (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Ogama (Lightside)                             ");
                this.yokaiCbox.Items.Add((object)"Ogama (Shadowside)                            ");
                this.yokaiCbox.Items.Add((object)"Doyapon (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Doyapon (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Inugami (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Inugami (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Kezurin (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Kezurin (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Robonyan 00 (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Robonyan 00 (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Becchan (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Becchan (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Dameboy (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Dameboy (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Awevil                                        ");
                this.yokaiCbox.Items.Add((object)"Demuncher                                     ");
                this.yokaiCbox.Items.Add((object)"Slicenrice                                    ");
                this.yokaiCbox.Items.Add((object)"Signiton                                      ");
                this.yokaiCbox.Items.Add((object)"Molar Petite                                  ");
                this.yokaiCbox.Items.Add((object)"Shmoopie                                      ");
                this.yokaiCbox.Items.Add((object)"Lie-in Heart                                  ");
                this.yokaiCbox.Items.Add((object)"Wazzat                                        ");
                this.yokaiCbox.Items.Add((object)"Nekidspeed                                    ");
                this.yokaiCbox.Items.Add((object)"Count Zapaway                                 ");
                this.yokaiCbox.Items.Add((object)"B3-NK1                                        ");
                this.yokaiCbox.Items.Add((object)"Rocky Badboya                                 ");
                this.yokaiCbox.Items.Add((object)"Smogmella                                     ");
                this.yokaiCbox.Items.Add((object)"Drizzelda                                     ");
                this.yokaiCbox.Items.Add((object)"Poofessor                                     ");
                this.yokaiCbox.Items.Add((object)"Ray O'Light                                   ");
                this.yokaiCbox.Items.Add((object)"Legsit                                        ");
                this.yokaiCbox.Items.Add((object)"Snottle                                       ");
                this.yokaiCbox.Items.Add((object)"Jibanyan B                                    ");
                this.yokaiCbox.Items.Add((object)"Komasan B                                     ");
                this.yokaiCbox.Items.Add((object)"Usapyon B                                     ");
                this.yokaiCbox.Items.Add((object)"Kukuri-hime                                   ");
                this.yokaiCbox.Items.Add((object)"Azukiarai                                     ");
                this.yokaiCbox.Items.Add((object)"Shien                                         ");
                this.yokaiCbox.Items.Add((object)"Yamamba (Boss)                                ");
                this.yokaiCbox.Items.Add((object)"Tamamo (Boss)                                 ");
                this.yokaiCbox.Items.Add((object)"Fukurou                                       ");
                this.yokaiCbox.Items.Add((object)"Shuka                                         ");
                this.yokaiCbox.Items.Add((object)"Gentou                                        ");
                this.yokaiCbox.Items.Add((object)"Hakushu                                       ");
                this.yokaiCbox.Items.Add((object)"Kuuten                                        ");
                this.yokaiCbox.Items.Add((object)"Yasha Enma                                    ");
                this.yokaiCbox.Items.Add((object)"Kenshin Amaterasu                             ");
                this.yokaiCbox.Items.Add((object)"Gesshin Tsukuyomi                             ");
                this.yokaiCbox.Items.Add((object)"Touma Fudou Myouou-kai                        ");
                this.yokaiCbox.Items.Add((object)"Himoji (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Himoji (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Pakkun (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Pakkun (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Kyunshii (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Kyunshii (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Hare-onna (Lightside)                         ");
                this.yokaiCbox.Items.Add((object)"Hare-onna (Shadowside)                        ");
                this.yokaiCbox.Items.Add((object)"Choky (Lightside)                             ");
                this.yokaiCbox.Items.Add((object)"Choky C(Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Fubuki-hime (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Fubuki-hime (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Merameraion (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Merameraion (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Orochi (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Orochi (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Honmaguro-taishou (Lightside)                 ");
                this.yokaiCbox.Items.Add((object)"Honmaguro-taishou (Shadowside)                ");
                this.yokaiCbox.Items.Add((object)"Semicolon (Lightside)                         ");
                this.yokaiCbox.Items.Add((object)"Semicolon (Shadowside)                        ");
                this.yokaiCbox.Items.Add((object)"Komasan (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Komasan (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Komajiro (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Komajiro (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Banchou (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Banchou (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Seiryuu (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Seiryuu (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Fuu-kun (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Fuu-kun (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Rai-chan (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Rai-chan (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Hamham (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Hamham (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Jibanyan (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Jibanyan (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Uribou (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Uribou (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Kyubi (Lightside)                             ");
                this.yokaiCbox.Items.Add((object)"Kyubi (Shadowside)                            ");
                this.yokaiCbox.Items.Add((object)"Charlie (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Charlie (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Zundoumaru (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Zundoumaru (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Ungaikyo (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Ungaikyo (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Jinta (Lightside)                             ");
                this.yokaiCbox.Items.Add((object)"Jinta (Shadowside)                            ");
                this.yokaiCbox.Items.Add((object)"Kantaro (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Kantaro (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Kiborikkuma (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Kiborikkuma (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Junior (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Junior (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Micchy (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Micchy (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Hyper Micchy (Lightside)                      ");
                this.yokaiCbox.Items.Add((object)"Hyper Micchy (Shadowside)                     ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Hungramps                                     ");
                this.yokaiCbox.Items.Add((object)"Dimmy                                         ");
                this.yokaiCbox.Items.Add((object)"Tattletell                                    ");
                this.yokaiCbox.Items.Add((object)"Dismarelda                                    ");
                this.yokaiCbox.Items.Add((object)"Hidabat                                       ");
                this.yokaiCbox.Items.Add((object)"Frostina                                      ");
                this.yokaiCbox.Items.Add((object)"Insomni                                       ");
                this.yokaiCbox.Items.Add((object)"Blizzaria                                     ");
                this.yokaiCbox.Items.Add((object)"Damona                                        ");
                this.yokaiCbox.Items.Add((object)"Little Charrmer                               ");
                this.yokaiCbox.Items.Add((object)"Roughraff                                     ");
                this.yokaiCbox.Items.Add((object)"Mochismo                                      ");
                this.yokaiCbox.Items.Add((object)"Blazion                                       ");
                this.yokaiCbox.Items.Add((object)"Sgt. Burly                                    ");
                this.yokaiCbox.Items.Add((object)"Venoct                                        ");
                this.yokaiCbox.Items.Add((object)"Illuminoct                                    ");
                this.yokaiCbox.Items.Add((object)"Shadow Venoct                                 ");
                this.yokaiCbox.Items.Add((object)"Shogunyan                                     ");
                this.yokaiCbox.Items.Add((object)"Snartle                                       ");
                this.yokaiCbox.Items.Add((object)"Arachnus                                      ");
                this.yokaiCbox.Items.Add((object)"Komashura                                     ");
                this.yokaiCbox.Items.Add((object)"Noko                                          ");
                this.yokaiCbox.Items.Add((object)"Komasan                                       ");
                this.yokaiCbox.Items.Add((object)"Komajiro                                      ");
                this.yokaiCbox.Items.Add((object)"Happierre                                     ");
                this.yokaiCbox.Items.Add((object)"Hovernyan                                     ");
                this.yokaiCbox.Items.Add((object)"Reuknight                                     ");
                this.yokaiCbox.Items.Add((object)"Corptain                                      ");
                this.yokaiCbox.Items.Add((object)"Toadal Dude                                   ");
                this.yokaiCbox.Items.Add((object)"Silver Lining                                 ");
                this.yokaiCbox.Items.Add((object)"Manjimutt                                     ");
                this.yokaiCbox.Items.Add((object)"Jibanyan                                      ");
                this.yokaiCbox.Items.Add((object)"Krystal Fox                                   ");
                this.yokaiCbox.Items.Add((object)"Baku                                          ");
                this.yokaiCbox.Items.Add((object)"Kyubi                                         ");
                this.yokaiCbox.Items.Add((object)"Darkyubi                                      ");
                this.yokaiCbox.Items.Add((object)"Master Nyada                                  ");
                this.yokaiCbox.Items.Add((object)"Noway                                         ");
                this.yokaiCbox.Items.Add((object)"Sandmeh                                       ");
                this.yokaiCbox.Items.Add((object)"Mimikin                                       ");
                this.yokaiCbox.Items.Add((object)"Mirapo                                        ");
                this.yokaiCbox.Items.Add((object)"Robonyan                                      ");
                this.yokaiCbox.Items.Add((object)"Goldenyan                                     ");
                this.yokaiCbox.Items.Add((object)"Wiglin                                        ");
                this.yokaiCbox.Items.Add((object)"Steppa                                        ");
                this.yokaiCbox.Items.Add((object)"Rhyth                                         ");
                this.yokaiCbox.Items.Add((object)"Walkappa                                      ");
                this.yokaiCbox.Items.Add((object)"Nosirs                                        ");
                this.yokaiCbox.Items.Add((object)"Cornfused                                     ");
                this.yokaiCbox.Items.Add((object)"Whisper                                       ");
                this.yokaiCbox.Items.Add((object)"Swelton                                       ");
                this.yokaiCbox.Items.Add((object)"Usapyon                                       ");
                this.yokaiCbox.Items.Add((object)"Spoilerina                                    ");
                this.yokaiCbox.Items.Add((object)"Sighborg Y                                    ");
                this.yokaiCbox.Items.Add((object)"Wobblewok                                     ");
                this.yokaiCbox.Items.Add((object)"Deadcool                                      ");
                this.yokaiCbox.Items.Add((object)"Gargaros                                      ");
                this.yokaiCbox.Items.Add((object)"Ogralus                                       ");
                this.yokaiCbox.Items.Add((object)"Orcanos                                       ");
                this.yokaiCbox.Items.Add((object)"Gilgaros                                      ");
                this.yokaiCbox.Items.Add((object)"Shirokuma                                     ");
                this.yokaiCbox.Items.Add((object)"Punkupine                                     ");
                this.yokaiCbox.Items.Add((object)"Sorrypus                                      ");
                this.yokaiCbox.Items.Add((object)"Jabow                                         ");
                this.yokaiCbox.Items.Add((object)"Beetall                                       ");
                this.yokaiCbox.Items.Add((object)"Cruncha                                       ");
                this.yokaiCbox.Items.Add((object)"Rhinormous                                    ");
                this.yokaiCbox.Items.Add((object)"Hornaplenty                                   ");
                this.yokaiCbox.Items.Add((object)"Mad Mountain                                  ");
                this.yokaiCbox.Items.Add((object)"Lava Lord                                     ");
                this.yokaiCbox.Items.Add((object)"Faux Kappa                                    ");
                this.yokaiCbox.Items.Add((object)"Suu-san                                       ");
                this.yokaiCbox.Items.Add((object)"Yamanba                                       ");
                this.yokaiCbox.Items.Add((object)"Tamamo                                        ");
                this.yokaiCbox.Items.Add((object)"Gyuuki                                        ");
                this.yokaiCbox.Items.Add((object)"Narigama                                      ");
                this.yokaiCbox.Items.Add((object)"Blobgoblin                                    ");
                this.yokaiCbox.Items.Add((object)"Nekomata/Gusto Neko'ou Bastet                 ");
                this.yokaiCbox.Items.Add((object)"Kappa Kappa'ou Sagojou                        ");
                this.yokaiCbox.Items.Add((object)"Zashiki-warashi Tengu'ou Kurama               ");
                this.yokaiCbox.Items.Add((object)"Kawauso                                       ");
                this.yokaiCbox.Items.Add((object)"Enma                                          ");
                this.yokaiCbox.Items.Add((object)"Lord Ananta                                   ");
                this.yokaiCbox.Items.Add((object)"Douketsu                                      ");
                this.yokaiCbox.Items.Add((object)"Shutendoji                                    ");
                this.yokaiCbox.Items.Add((object)"Ogu Togu Mogu                                 ");
                this.yokaiCbox.Items.Add((object)"Nurarihyon                                    ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou Boy                              ");
                this.yokaiCbox.Items.Add((object)"Whisper                                       ");
                this.yokaiCbox.Items.Add((object)"Enma Awakened                                 ");
                this.yokaiCbox.Items.Add((object)"Yami Enma                                     ");
                this.yokaiCbox.Items.Add((object)"Nekomata/Gusto Neko'ou Bastet                 ");
                this.yokaiCbox.Items.Add((object)"Kappa Kappa'ou Sagojou                        ");
                this.yokaiCbox.Items.Add((object)"Zashiki-warashi Tengu'ou Kurama               ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou Ten                              ");
                this.yokaiCbox.Items.Add((object)"Suzaku (Sword Bearer)                         ");
                this.yokaiCbox.Items.Add((object)"Genbu (Sword Bearer)                          ");
                this.yokaiCbox.Items.Add((object)"Byakko (Sword Bearer)                         ");
                this.yokaiCbox.Items.Add((object)"Ashura (Sword Bearer)                         ");
                this.yokaiCbox.Items.Add((object)"Kakurenbou (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Kakurenbou (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Hyakki-hime (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Hyakki-hime (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Daniel (Lightside)                            ");
                this.yokaiCbox.Items.Add((object)"Daniel (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Itashikatanshi (Lightside)                    ");
                this.yokaiCbox.Items.Add((object)"Itashikatanshi (Shadowside)                   ");
                this.yokaiCbox.Items.Add((object)"Saya (Lightside)                              ");
                this.yokaiCbox.Items.Add((object)"Saya (Shadowside)                             ");
                this.yokaiCbox.Items.Add((object)"Rai Oton (Lightside)                          ");
                this.yokaiCbox.Items.Add((object)"Rai Oton (Shadowside)                         ");
                this.yokaiCbox.Items.Add((object)"Kage Orochi (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Kage Orochi (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Bushinyan (Lightside)                         ");
                this.yokaiCbox.Items.Add((object)"Bushinyan (Shadowside)                        ");
                this.yokaiCbox.Items.Add((object)"Shurakoma (Lightside)                         ");
                this.yokaiCbox.Items.Add((object)"Shurakoma (Shadowside)                        ");
                this.yokaiCbox.Items.Add((object)"Tsuchigumo (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Tsuchigumo (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Tsuchinoko (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Tsuchinoko (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Ogama (Lightside)                             ");
                this.yokaiCbox.Items.Add((object)"Ogama (Shadowside)                            ");
                this.yokaiCbox.Items.Add((object)"Doyapon (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Doyapon (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Inugami (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Inugami (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Kezurin (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Kezurin (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Robonyan 00 (Lightside)                       ");
                this.yokaiCbox.Items.Add((object)"Robonyan 00 (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Becchan (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Becchan (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Dameboy (Lightside)                           ");
                this.yokaiCbox.Items.Add((object)"Dameboy (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Awevil                                        ");
                this.yokaiCbox.Items.Add((object)"Demuncher                                     ");
                this.yokaiCbox.Items.Add((object)"Slicenrice                                    ");
                this.yokaiCbox.Items.Add((object)"Signiton                                      ");
                this.yokaiCbox.Items.Add((object)"Molar Petite                                  ");
                this.yokaiCbox.Items.Add((object)"Shmoopie                                      ");
                this.yokaiCbox.Items.Add((object)"Lie-in Heart                                  ");
                this.yokaiCbox.Items.Add((object)"Wazzat                                        ");
                this.yokaiCbox.Items.Add((object)"Nekidspeed                                    ");
                this.yokaiCbox.Items.Add((object)"Count Zapaway                                 ");
                this.yokaiCbox.Items.Add((object)"B3-NK1                                        ");
                this.yokaiCbox.Items.Add((object)"Rocky Badboya                                 ");
                this.yokaiCbox.Items.Add((object)"Smogmella                                     ");
                this.yokaiCbox.Items.Add((object)"Drizzelda                                     ");
                this.yokaiCbox.Items.Add((object)"Poofessor                                     ");
                this.yokaiCbox.Items.Add((object)"Ray O'Light                                   ");
                this.yokaiCbox.Items.Add((object)"Legsit                                        ");
                this.yokaiCbox.Items.Add((object)"Snottle                                       ");
                this.yokaiCbox.Items.Add((object)"Kukuri-hime                                   ");
                this.yokaiCbox.Items.Add((object)"Azukiarai                                     ");
                this.yokaiCbox.Items.Add((object)"Fukurou                                       ");
                this.yokaiCbox.Items.Add((object)"Kenshin Amaterasu                             ");
                this.yokaiCbox.Items.Add((object)"Gesshin Tsukuyomi                             ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Hoggles                                       ");
                this.yokaiCbox.Items.Add((object)"Hoggles                                       ");
                this.yokaiCbox.Items.Add((object)"Hoggles                                       ");
                this.yokaiCbox.Items.Add((object)"Hoggles                                       ");
                this.yokaiCbox.Items.Add((object)"Hoggles                                       ");
                this.yokaiCbox.Items.Add((object)"Hoggles                                       ");
                this.yokaiCbox.Items.Add((object)"Hoggles                                       ");
                this.yokaiCbox.Items.Add((object)"Hoggles                                       ");
                this.yokaiCbox.Items.Add((object)"Raidenryu                                     ");
                this.yokaiCbox.Items.Add((object)"Raidenryu                                     ");
                this.yokaiCbox.Items.Add((object)"Raidenryu                                     ");
                this.yokaiCbox.Items.Add((object)"Wobblewok                                     ");
                this.yokaiCbox.Items.Add((object)"Wobblewok                                     ");
                this.yokaiCbox.Items.Add((object)"Wobblewok                                     ");
                this.yokaiCbox.Items.Add((object)"Wobblewok                                     ");
                this.yokaiCbox.Items.Add((object)"Wobblewok                                     ");
                this.yokaiCbox.Items.Add((object)"Wobblewok                                     ");
                this.yokaiCbox.Items.Add((object)"Gargaros                                      ");
                this.yokaiCbox.Items.Add((object)"Gargaros                                      ");
                this.yokaiCbox.Items.Add((object)"Gargaros                                      ");
                this.yokaiCbox.Items.Add((object)"Gargaros                                      ");
                this.yokaiCbox.Items.Add((object)"Gargaros                                      ");
                this.yokaiCbox.Items.Add((object)"Gargaros                                      ");
                this.yokaiCbox.Items.Add((object)"Ogralus                                       ");
                this.yokaiCbox.Items.Add((object)"Ogralus                                       ");
                this.yokaiCbox.Items.Add((object)"Ogralus                                       ");
                this.yokaiCbox.Items.Add((object)"Ogralus                                       ");
                this.yokaiCbox.Items.Add((object)"Ogralus                                       ");
                this.yokaiCbox.Items.Add((object)"Ogralus                                       ");
                this.yokaiCbox.Items.Add((object)"Orcanos                                       ");
                this.yokaiCbox.Items.Add((object)"Orcanos                                       ");
                this.yokaiCbox.Items.Add((object)"Orcanos                                       ");
                this.yokaiCbox.Items.Add((object)"Orcanos                                       ");
                this.yokaiCbox.Items.Add((object)"Orcanos                                       ");
                this.yokaiCbox.Items.Add((object)"Orcanos                                       ");
                this.yokaiCbox.Items.Add((object)"McKraken                                      ");
                this.yokaiCbox.Items.Add((object)"McKraken                                      ");
                this.yokaiCbox.Items.Add((object)"McKraken                                      ");
                this.yokaiCbox.Items.Add((object)"McKraken                                      ");
                this.yokaiCbox.Items.Add((object)"McKraken                                      ");
                this.yokaiCbox.Items.Add((object)"McKraken                                      ");
                this.yokaiCbox.Items.Add((object)"Demuncher                                     ");
                this.yokaiCbox.Items.Add((object)"Demuncher                                     ");
                this.yokaiCbox.Items.Add((object)"Demuncher                                     ");
                this.yokaiCbox.Items.Add((object)"Demuncher                                     ");
                this.yokaiCbox.Items.Add((object)"Demuncher                                     ");
                this.yokaiCbox.Items.Add((object)"Demuncher                                     ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin Shadow                             ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin Shadow                             ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin Shadow                             ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin Shadow                             ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin Shadow                             ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin Shadow                             ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou 1                                ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou 2                                ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou 3                                ");
                this.yokaiCbox.Items.Add((object)"Suzaku (Sword Bearer)                         ");
                this.yokaiCbox.Items.Add((object)"Suzaku (Celestial)                            ");
                this.yokaiCbox.Items.Add((object)"Genbu (Sword Bearer)                          ");
                this.yokaiCbox.Items.Add((object)"Genbu (Celestial)                             ");
                this.yokaiCbox.Items.Add((object)"Byakko (Sword Bearer)                         ");
                this.yokaiCbox.Items.Add((object)"Byakko (Celestial)                            ");
                this.yokaiCbox.Items.Add((object)"Asura (Sword Bearer)                          ");
                this.yokaiCbox.Items.Add((object)"Yamamba                                       ");
                this.yokaiCbox.Items.Add((object)"Yamamba                                       ");
                this.yokaiCbox.Items.Add((object)"Yamamba                                       ");
                this.yokaiCbox.Items.Add((object)"Yamamba                                       ");
                this.yokaiCbox.Items.Add((object)"Yamamba                                       ");
                this.yokaiCbox.Items.Add((object)"Yamamba                                       ");
                this.yokaiCbox.Items.Add((object)"Tamamo no Mae                                 ");
                this.yokaiCbox.Items.Add((object)"Tamamo no Mae                                 ");
                this.yokaiCbox.Items.Add((object)"Tamamo no Mae                                 ");
                this.yokaiCbox.Items.Add((object)"Tamamo no Mae                                 ");
                this.yokaiCbox.Items.Add((object)"Tamamo no Mae                                 ");
                this.yokaiCbox.Items.Add((object)"Tamamo no Mae                                 ");
                this.yokaiCbox.Items.Add((object)"Shien                                         ");
                this.yokaiCbox.Items.Add((object)"Rocky Badboya                                 ");
                this.yokaiCbox.Items.Add((object)"Snartle                                       ");
                this.yokaiCbox.Items.Add((object)"Damona (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Jinta (Shadowside)                            ");
                this.yokaiCbox.Items.Add((object)"Dameboy (Shadowside)                          ");
                this.yokaiCbox.Items.Add((object)"Bushinyan (Shadowside)                        ");
                this.yokaiCbox.Items.Add((object)"Lie-in Heart                                  ");
                this.yokaiCbox.Items.Add((object)"Signiton                                      ");
                this.yokaiCbox.Items.Add((object)"Robonyan                                      ");
                this.yokaiCbox.Items.Add((object)"Goldenyan                                     ");
                this.yokaiCbox.Items.Add((object)"Sighborg Y                                    ");
                this.yokaiCbox.Items.Add((object)"Robonyan00                                    ");
                this.yokaiCbox.Items.Add((object)"Jibanyan B                                    ");
                this.yokaiCbox.Items.Add((object)"Komasan B                                     ");
                this.yokaiCbox.Items.Add((object)"Usapyon B                                     ");
                this.yokaiCbox.Items.Add((object)"Hovernyan                                     ");
                this.yokaiCbox.Items.Add((object)"Sgt. Burly                                    ");
                this.yokaiCbox.Items.Add((object)"Slimamander (Shadowside) (Hyper)              ");
                this.yokaiCbox.Items.Add((object)"Kenshin Amaterasu                             ");
                this.yokaiCbox.Items.Add((object)"Gesshin Tsukuyomi                             ");
                this.yokaiCbox.Items.Add((object)"Neko'ou Bastet                                ");
                this.yokaiCbox.Items.Add((object)"Kappa'ou Sagojou                              ");
                this.yokaiCbox.Items.Add((object)"Tengu'ou Kurama                               ");
                this.yokaiCbox.Items.Add((object)"Tamamo                                        ");
                this.yokaiCbox.Items.Add((object)"Hamham (Shadowside)                           ");
                this.yokaiCbox.Items.Add((object)"Wiglin                                        ");
                this.yokaiCbox.Items.Add((object)"Roughraff                                     ");
                this.yokaiCbox.Items.Add((object)"Kakurenbou (Shadowside)                       ");
                this.yokaiCbox.Items.Add((object)"Sproink                                       ");
                this.yokaiCbox.Items.Add((object)"Legsit                                        ");
                this.yokaiCbox.Items.Add((object)"Doyapon                                       ");
                this.yokaiCbox.Items.Add((object)"Jibanyan B                                    ");
                this.yokaiCbox.Items.Add((object)"Komasan B                                     ");
                this.yokaiCbox.Items.Add((object)"Usapyon B                                     ");
                this.yokaiCbox.Items.Add((object)"Fubuki-hime (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Hyakki-hime (Shadowside)                      ");
                this.yokaiCbox.Items.Add((object)"Touma                                         ");
                this.yokaiCbox.Items.Add((object)"Summer                                        ");
                this.yokaiCbox.Items.Add((object)"Akinori                                       ");
                this.yokaiCbox.Items.Add((object)"Jack                                          ");
                this.yokaiCbox.Items.Add((object)"Nate                                          ");
                this.yokaiCbox.Items.Add((object)"Katie                                         ");
                this.yokaiCbox.Items.Add((object)"Hailey Anne                                   ");
                this.yokaiCbox.Items.Add((object)"Blonde Guy (Alt) (NPC)                        ");
                this.yokaiCbox.Items.Add((object)"Formal Guy (Alt) (NPC)                        ");
                this.yokaiCbox.Items.Add((object)"Blonde Guy (Alt) (NPC)                        ");
                this.yokaiCbox.Items.Add((object)"Formal Guy (Alt) (NPC)                        ");
                this.yokaiCbox.Items.Add((object)"Monk Guy                                      ");
                this.yokaiCbox.Items.Add((object)"CowBoy Guy                                    ");
                this.yokaiCbox.Items.Add((object)"Smart Monkey                                  ");
                this.yokaiCbox.Items.Add((object)"Jinpei Jiba                                   ");
                this.yokaiCbox.Items.Add((object)"Shiba Dog                                     ");
                this.yokaiCbox.Items.Add((object)"Black Shiba Dog                               ");
                this.yokaiCbox.Items.Add((object)"Yellow Shiba Dog                              ");
                this.yokaiCbox.Items.Add((object)"Mitsue                                        ");
                this.yokaiCbox.Items.Add((object)"Alien                                         ");
                this.yokaiCbox.Items.Add((object)"Honmaguro-taishou (Shadowside) (No clouds)    ");
                this.yokaiCbox.Items.Add((object)"Touma (Horse)                                 ");
                this.yokaiCbox.Items.Add((object)"Touma (Horse) (Alt)                           ");
                this.yokaiCbox.Items.Add((object)"Touma (Horse) (Alt)                           ");
                this.yokaiCbox.Items.Add((object)"Katie (Horse)                                 ");
                this.yokaiCbox.Items.Add((object)"Old Guy                                       ");
                this.yokaiCbox.Items.Add((object)"Yamakasa Demon                                ");
                this.yokaiCbox.Items.Add((object)"Yamakasa Demon                                ");
                this.yokaiCbox.Items.Add((object)"Tsuchinoko (Normal)                           ");
                this.yokaiCbox.Items.Add((object)"Tsuchinoko (Lightside)                        ");
                this.yokaiCbox.Items.Add((object)"Tsuchinoko (Shadowside)                       ");
                foreach (ListViewItem selectedItem in this.yokaiListView.SelectedItems)
                    this.yokaiCbox.SelectedIndex = new GetYokai().pickYokaiIDNumber(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Signature ?? "");
            }
            else
            {
                this.yokaiCbox.Items.Clear();
                this.yokaiCbox.Items.Add((object)"");
                this.yokaiCbox.Items.Add((object)"Arachnus                          ");
                this.yokaiCbox.Items.Add((object)"Arachnus (Lightside)              ");
                this.yokaiCbox.Items.Add((object)"Ashura                            ");
                this.yokaiCbox.Items.Add((object)"Ashura big                        ");
                this.yokaiCbox.Items.Add((object)"Awevil                            ");
                this.yokaiCbox.Items.Add((object)"Azukiarai                         ");
                this.yokaiCbox.Items.Add((object)"B3-NK1                            ");
                this.yokaiCbox.Items.Add((object)"Baku                              ");
                this.yokaiCbox.Items.Add((object)"Banchou (Lightside)               ");
                this.yokaiCbox.Items.Add((object)"Becchan (Lightside)               ");
                this.yokaiCbox.Items.Add((object)"Beetall                           ");
                this.yokaiCbox.Items.Add((object)"Benkei                            ");
                this.yokaiCbox.Items.Add((object)"Blazion                           ");
                this.yokaiCbox.Items.Add((object)"Blizzaria                         ");
                this.yokaiCbox.Items.Add((object)"Blobgoblin                        ");
                this.yokaiCbox.Items.Add((object)"Bushinyan (Lightside)             ");
                this.yokaiCbox.Items.Add((object)"Byakko                            ");
                this.yokaiCbox.Items.Add((object)"Byakko                            ");
                this.yokaiCbox.Items.Add((object)"Charlie (Lightside)               ");
                this.yokaiCbox.Items.Add((object)"Choky (Lightside)                 ");
                this.yokaiCbox.Items.Add((object)"Cornfused                         ");
                this.yokaiCbox.Items.Add((object)"Corptain                          ");
                this.yokaiCbox.Items.Add((object)"Count Zapaway                     ");
                this.yokaiCbox.Items.Add((object)"Cruncha                           ");
                this.yokaiCbox.Items.Add((object)"Dameboy (Lightside)               ");
                this.yokaiCbox.Items.Add((object)"Damona                            ");
                this.yokaiCbox.Items.Add((object)"Daniel (Lightside)                ");
                this.yokaiCbox.Items.Add((object)"Darkyubi                          ");
                this.yokaiCbox.Items.Add((object)"Deadcool                          ");
                this.yokaiCbox.Items.Add((object)"Demuncher                         ");
                this.yokaiCbox.Items.Add((object)"Dimmy                             ");
                this.yokaiCbox.Items.Add((object)"Dismarelda                        ");
                this.yokaiCbox.Items.Add((object)"Douketsu                          ");
                this.yokaiCbox.Items.Add((object)"Doyapon (Lightside)               ");
                this.yokaiCbox.Items.Add((object)"Drizzelda                         ");
                this.yokaiCbox.Items.Add((object)"Enma                              ");
                this.yokaiCbox.Items.Add((object)"Enma Awoken                       ");
                this.yokaiCbox.Items.Add((object)"Faux Kappa                        ");
                this.yokaiCbox.Items.Add((object)"Frostina                          ");
                this.yokaiCbox.Items.Add((object)"Fubuki-hime (Lightside)           ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou                      ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou Boy                  ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou Ten                  ");
                this.yokaiCbox.Items.Add((object)"Fudou Myouou-kai                  ");
                this.yokaiCbox.Items.Add((object)"Fukurou                           ");
                this.yokaiCbox.Items.Add((object)"Fuu-kun (Lightside)               ");
                this.yokaiCbox.Items.Add((object)"Gargaros                          ");
                this.yokaiCbox.Items.Add((object)"Genbu                             ");
                this.yokaiCbox.Items.Add((object)"Genbu 2                           ");
                this.yokaiCbox.Items.Add((object)"Gentou                            ");
                this.yokaiCbox.Items.Add((object)"Gesshin Tsukuyomi                 ");
                this.yokaiCbox.Items.Add((object)"Gilgaros                          ");
                this.yokaiCbox.Items.Add((object)"Goemon                            ");
                this.yokaiCbox.Items.Add((object)"Goldenyan                         ");
                this.yokaiCbox.Items.Add((object)"Gunshin Susanoo                   ");
                this.yokaiCbox.Items.Add((object)"Gyuuki                            ");
                this.yokaiCbox.Items.Add((object)"Hakushu                           ");
                this.yokaiCbox.Items.Add((object)"Hamham (Lightside)                ");
                this.yokaiCbox.Items.Add((object)"Happierre                         ");
                this.yokaiCbox.Items.Add((object)"Hare-onna (Lightside)             ");
                this.yokaiCbox.Items.Add((object)"Hi no Shin (Lightside)            ");
                this.yokaiCbox.Items.Add((object)"Hidabat                           ");
                this.yokaiCbox.Items.Add((object)"Himoji (Lightside)                ");
                this.yokaiCbox.Items.Add((object)"Honmaguro-taishou (Lightside)     ");
                this.yokaiCbox.Items.Add((object)"Hornaplenty                       ");
                this.yokaiCbox.Items.Add((object)"Hovernyan                         ");
                this.yokaiCbox.Items.Add((object)"Hungramps                         ");
                this.yokaiCbox.Items.Add((object)"Hyakki-hime (Lightside)           ");
                this.yokaiCbox.Items.Add((object)"Illuminoct                        ");
                this.yokaiCbox.Items.Add((object)"Insomni                           ");
                this.yokaiCbox.Items.Add((object)"Inugami (Lightside)               ");
                this.yokaiCbox.Items.Add((object)"Itashikatanshi (Lightside)        ");
                this.yokaiCbox.Items.Add((object)"Jabow                             ");
                this.yokaiCbox.Items.Add((object)"Jibanyan  (Lightside)             ");
                this.yokaiCbox.Items.Add((object)"Jibanyan                          ");
                this.yokaiCbox.Items.Add((object)"Jibanyan B                        ");
                this.yokaiCbox.Items.Add((object)"Jinta (Lightside)                 ");
                this.yokaiCbox.Items.Add((object)"Junior (Lightside)                ");
                this.yokaiCbox.Items.Add((object)"Kage Orochi (Lightside)           ");
                this.yokaiCbox.Items.Add((object)"Kaibyou Kamaitachi                ");
                this.yokaiCbox.Items.Add((object)"Kakurenbou (Lightside)            ");
                this.yokaiCbox.Items.Add((object)"Kantaro (Lightside)               ");
                this.yokaiCbox.Items.Add((object)"Kappa                             ");
                this.yokaiCbox.Items.Add((object)"Kappa'ou Sagojou                  ");
                this.yokaiCbox.Items.Add((object)"Kawauso                           ");
                this.yokaiCbox.Items.Add((object)"Kenshin Amaterasu                 ");
                this.yokaiCbox.Items.Add((object)"Kezurin (Lightside)               ");
                this.yokaiCbox.Items.Add((object)"Kiborikkuma (Lightside)           ");
                this.yokaiCbox.Items.Add((object)"Kirin                             ");
                this.yokaiCbox.Items.Add((object)"Komajiro (Lightside)              ");
                this.yokaiCbox.Items.Add((object)"Komajiro                          ");
                this.yokaiCbox.Items.Add((object)"Komasan  (Lightside)              ");
                this.yokaiCbox.Items.Add((object)"Komasan                           ");
                this.yokaiCbox.Items.Add((object)"Komasan B                         ");
                this.yokaiCbox.Items.Add((object)"Komashura                         ");
                this.yokaiCbox.Items.Add((object)"Krystal Fox                       ");
                this.yokaiCbox.Items.Add((object)"Kukuri-hime                       ");
                this.yokaiCbox.Items.Add((object)"Kuuten                            ");
                this.yokaiCbox.Items.Add((object)"Kyubi  (Lightside)                ");
                this.yokaiCbox.Items.Add((object)"Kyubi                             ");
                this.yokaiCbox.Items.Add((object)"Kyunshii (Lightside)              ");
                this.yokaiCbox.Items.Add((object)"Lava Lord                         ");
                this.yokaiCbox.Items.Add((object)"Legsit                            ");
                this.yokaiCbox.Items.Add((object)"Lie-in Heart                      ");
                this.yokaiCbox.Items.Add((object)"Little Charrmer                   ");
                this.yokaiCbox.Items.Add((object)"Lord Ananta                       ");
                this.yokaiCbox.Items.Add((object)"Mad Mountain                      ");
                this.yokaiCbox.Items.Add((object)"Manjimutt                         ");
                this.yokaiCbox.Items.Add((object)"Master Nyada                      ");
                this.yokaiCbox.Items.Add((object)"McKraken                          ");
                this.yokaiCbox.Items.Add((object)"Merameraion (Lightside)           ");
                this.yokaiCbox.Items.Add((object)"Micchy (Lightside)                ");
                this.yokaiCbox.Items.Add((object)"Micchy Hyper (Lightside)          ");
                this.yokaiCbox.Items.Add((object)"Mimikin                           ");
                this.yokaiCbox.Items.Add((object)"Mirapo                            ");
                this.yokaiCbox.Items.Add((object)"Mochismo                          ");
                this.yokaiCbox.Items.Add((object)"Molar Petite                      ");
                this.yokaiCbox.Items.Add((object)"Narigama                          ");
                this.yokaiCbox.Items.Add((object)"Nekidspeed                        ");
                this.yokaiCbox.Items.Add((object)"Neko'ou Bastet                    ");
                this.yokaiCbox.Items.Add((object)"Nekomata                          ");
                this.yokaiCbox.Items.Add((object)"Noko                              ");
                this.yokaiCbox.Items.Add((object)"Nosirs                            ");
                this.yokaiCbox.Items.Add((object)"Noway                             ");
                this.yokaiCbox.Items.Add((object)"Nurarihyon                        ");
                this.yokaiCbox.Items.Add((object)"Ogama (Lightside)                 ");
                this.yokaiCbox.Items.Add((object)"Ogralus                           ");
                this.yokaiCbox.Items.Add((object)"Ogu Togu Mogu                     ");
                this.yokaiCbox.Items.Add((object)"Omatsu                            ");
                this.yokaiCbox.Items.Add((object)"Orcanos                           ");
                this.yokaiCbox.Items.Add((object)"Orochi (Lightside)                ");
                this.yokaiCbox.Items.Add((object)"Pakkun (Lightside)                ");
                this.yokaiCbox.Items.Add((object)"Poofessor                         ");
                this.yokaiCbox.Items.Add((object)"Punkupine                         ");
                this.yokaiCbox.Items.Add((object)"Rai Oton (Lightside)              ");
                this.yokaiCbox.Items.Add((object)"Rai-chan (Lightside)              ");
                this.yokaiCbox.Items.Add((object)"Raidenryu                         ");
                this.yokaiCbox.Items.Add((object)"Ray O'Light                       ");
                this.yokaiCbox.Items.Add((object)"Reuknight                         ");
                this.yokaiCbox.Items.Add((object)"Rhinormous                        ");
                this.yokaiCbox.Items.Add((object)"Robonyan                          ");
                this.yokaiCbox.Items.Add((object)"Robonyan 00 (Lightside)           ");
                this.yokaiCbox.Items.Add((object)"Rocky Badboya                     ");
                this.yokaiCbox.Items.Add((object)"Roughraff                         ");
                this.yokaiCbox.Items.Add((object)"Sandmeh                           ");
                this.yokaiCbox.Items.Add((object)"Saya (Lightside)                  ");
                this.yokaiCbox.Items.Add((object)"Seiryuu (Lightside)               ");
                this.yokaiCbox.Items.Add((object)"Semicolon (Lightside)             ");
                this.yokaiCbox.Items.Add((object)"Sgt. Burly                        ");
                this.yokaiCbox.Items.Add((object)"Shadow Venoct                     ");
                this.yokaiCbox.Items.Add((object)"Shien                             ");
                this.yokaiCbox.Items.Add((object)"Shirokuma                         ");
                this.yokaiCbox.Items.Add((object)"Shmoopie                          ");
                this.yokaiCbox.Items.Add((object)"Shogunyan                         ");
                this.yokaiCbox.Items.Add((object)"Shuka                             ");
                this.yokaiCbox.Items.Add((object)"Shuka Natsume                     ");
                this.yokaiCbox.Items.Add((object)"Shurakoma (Lightside)             ");
                this.yokaiCbox.Items.Add((object)"Shutendoji                        ");
                this.yokaiCbox.Items.Add((object)"Sighborg Y                        ");
                this.yokaiCbox.Items.Add((object)"Signiton                          ");
                this.yokaiCbox.Items.Add((object)"Silver Lining                     ");
                this.yokaiCbox.Items.Add((object)"Slicenrice                        ");
                this.yokaiCbox.Items.Add((object)"Smogmella                         ");
                this.yokaiCbox.Items.Add((object)"Snartle                           ");
                this.yokaiCbox.Items.Add((object)"Snottle                           ");
                this.yokaiCbox.Items.Add((object)"Sorrypus                          ");
                this.yokaiCbox.Items.Add((object)"Souryuu                           ");
                this.yokaiCbox.Items.Add((object)"Spoilerina                        ");
                this.yokaiCbox.Items.Add((object)"Steppa                            ");
                this.yokaiCbox.Items.Add((object)"Suu-san                           ");
                this.yokaiCbox.Items.Add((object)"Suzaku                            ");
                this.yokaiCbox.Items.Add((object)"Suzaku  2                         ");
                this.yokaiCbox.Items.Add((object)"Swelton                           ");
                this.yokaiCbox.Items.Add((object)"Tamamo                            ");
                this.yokaiCbox.Items.Add((object)"Tattletell                        ");
                this.yokaiCbox.Items.Add((object)"Tengu'ou Kurama                   ");
                this.yokaiCbox.Items.Add((object)"Toadal Dude                       ");
                this.yokaiCbox.Items.Add((object)"Tsuchigumo (Lightside)            ");
                this.yokaiCbox.Items.Add((object)"Tsuchinoko (Lightside)            ");
                this.yokaiCbox.Items.Add((object)"Ungaikyo (Lightside)              ");
                this.yokaiCbox.Items.Add((object)"Uribou (Lightside)                ");
                this.yokaiCbox.Items.Add((object)"Usapyon                           ");
                this.yokaiCbox.Items.Add((object)"Usapyon (2)                       ");
                this.yokaiCbox.Items.Add((object)"Usapyon B                         ");
                this.yokaiCbox.Items.Add((object)"Venoct                            ");
                this.yokaiCbox.Items.Add((object)"Walkappa                          ");
                this.yokaiCbox.Items.Add((object)"Wazzat                            ");
                this.yokaiCbox.Items.Add((object)"Whisper                           ");
                this.yokaiCbox.Items.Add((object)"Whisper (Future)                  ");
                this.yokaiCbox.Items.Add((object)"Wiglin                            ");
                this.yokaiCbox.Items.Add((object)"Wobblewok                         ");
                this.yokaiCbox.Items.Add((object)"Yamanba                           ");
                this.yokaiCbox.Items.Add((object)"Yami Enma                         ");
                this.yokaiCbox.Items.Add((object)"Yasha Enma                        ");
                this.yokaiCbox.Items.Add((object)"Yoshitsune                        ");
                this.yokaiCbox.Items.Add((object)"Zashiki-warashi                   ");
                this.yokaiCbox.Items.Add((object)"Zundoumaru (Lightside)            ");
                foreach (ListViewItem selectedItem in this.yokaiListView.SelectedItems)
                    this.yokaiCbox.SelectedIndex = new GetYokai().pickYokaiHealthyIndex(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Signature ?? "");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.yokaiListView.SelectedItems)
            {
                if (this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Signature != new SetYokai().pickYokaiBytesFromIdIndex((int)Convert.ToInt16(this.yokaiIdNbox.Value)))
                    this.yokaiUnknown12Nbox.Value = 1M;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Signature = new SetYokai().pickYokaiBytesFromIdIndex((int)Convert.ToInt16(this.yokaiIdNbox.Value));
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Level = Convert.ToInt32(this.yokaiLevelNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_YP = Convert.ToInt32(this.yokaiYpNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_HP = Convert.ToInt32(this.yokaiHpNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_XP = Convert.ToInt32(this.yokaiExpNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_PG = Convert.ToInt32(this.yokaiPgNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Name = this.yokaiTbox.Text;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_HPplus = Convert.ToInt32(this.yokaiHpPlusNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_YPplus = Convert.ToInt32(this.yokaiYpPlusNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_PAplus = Convert.ToInt32(this.yokaiPdPlusNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_SAplus = Convert.ToInt32(this.yokaiSdPlusNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_STplus = Convert.ToInt32(this.yokaiStPlusNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_SPplus = Convert.ToInt32(this.yokaiSpPlusNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill1 = new SetSkill().pickSkillBytes(this.yokaiBAtkCbox.SelectedIndex);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill2 = new SetSkill().pickSkillBytes(this.yokaiSpSklCbox.SelectedIndex);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill3 = new SetSkill().pickSkillBytes(this.yokaiExSklNbox.SelectedIndex);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill4 = new SetSkill().pickSkillBytes(this.yokaiExSkl2Nbox.SelectedIndex);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill5 = new SetSkill().pickSkillBytes(this.yokaiExSkl3Nbox.SelectedIndex);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill6 = new SetSkill().pickSkillBytes(this.yokaiExSkl4Nbox.SelectedIndex);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].ID1 = Convert.ToInt32(this.yokaiId1Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].ID2 = Convert.ToInt32(this.yokaiId2Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Order = Convert.ToInt32(this.yokaiOrderNbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown1 = Convert.ToInt32(this.yokaiUnknown1Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown2 = Convert.ToInt32(this.yokaiUnknown2Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown3 = Convert.ToInt32(this.yokaiUnknown3Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown4 = Convert.ToInt32(this.yokaiUnknown4Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown5 = Convert.ToInt32(this.yokaiUnknown5Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown6 = Convert.ToInt32(this.yokaiUnknown6Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown7 = Convert.ToInt32(this.yokaiUnknown7Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown8 = Convert.ToInt32(this.yokaiUnknown8Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown9 = Convert.ToInt32(this.yokaiUnknown9Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown10 = Convert.ToInt32(this.yokaiUnknown10Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown11 = Convert.ToInt32(this.yokaiUnknown11Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown12 = Convert.ToInt32(this.yokaiUnknown12Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown13 = Convert.ToInt32(this.yokaiUnknown13Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown14 = Convert.ToInt32(this.yokaiUnknown14Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown15 = Convert.ToInt32(this.yokaiUnknown15Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown16 = Convert.ToInt32(this.yokaiUnknown16Nbox.Value);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown17 = Convert.ToInt32(this.yokaiUnknown17Nbox.Value);
                if (this.yokaiUnknown12Nbox.Value == 0M)
                    this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown12 = 1;
                if (this.yokaiUnknown13Nbox.Value == 0M)
                    this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown13 = 1;
                if (this.yokaiUnknown15Nbox.Value == 0M)
                    this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown15 = 1;
                selectedItem.Text = new GetYokai().pickYokaiName(this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Signature ?? "Invalid");
                if (this.yokaiId1Nbox.Value == 0M)
                {
                    bool flag = false;
                    this.saveFileParams.UserYoKaiList[selectedItem.Index].ID1 = 4096 + selectedItem.Index;
                    for (int index = 1; index < 1000; ++index)
                    {
                        foreach (ListViewItem listViewItem1 in this.yokaiListView.Items)
                        {
                            if (index == this.saveFileParams.UserYoKaiList[listViewItem1.Index].ID2)
                            {
                                foreach (ListViewItem listViewItem2 in this.mainCharacterViewList.Items)
                                {
                                    if (index == this.saveFileParams.MainCharacterList[listViewItem2.Index].ID2)
                                        flag = true;
                                }
                            }
                        }
                        if (!flag)
                        {
                            this.saveFileParams.UserYoKaiList[selectedItem.Index].ID2 = index;
                            this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Order = index;
                            selectedItem.Selected = false;
                            selectedItem.Selected = true;
                            return;
                        }
                        flag = false;
                    }
                }
                selectedItem.Selected = false;
                selectedItem.Selected = true;
            }
        }

        private void gatchaDaily_ValueChanged(object sender, EventArgs e) => this.saveFileParams.misc.Gatcha.gatchaTries = (int)Convert.ToInt16(this.gatchaDaily.Value);

        private void gatchaMax_ValueChanged(object sender, EventArgs e) => this.saveFileParams.misc.Gatcha.gatchaMaxTries = (int)Convert.ToInt16(this.gatchaMax.Value);

        private void positionXNbox_ValueChanged(object sender, EventArgs e) => this.saveFileParams.misc.LocalParams.PositionX = Convert.ToSingle(this.positionXNbox.Value);

        private void positionYNbox_ValueChanged(object sender, EventArgs e) => this.saveFileParams.misc.LocalParams.PositionY = Convert.ToSingle(this.positionYNbox.Value);

        private void positionZNbox_ValueChanged(object sender, EventArgs e) => this.saveFileParams.misc.LocalParams.PositionZ = Convert.ToSingle(this.positionZNbox.Value);

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.yokaiListView.SelectedItems)
            {
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Signature = new SetYokai().pickYokaiBytesFromIdIndex(0);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Level = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_YP = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_HP = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_XP = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_PG = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Name = "";
                this.saveFileParams.UserYoKaiList[selectedItem.Index].ID1 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].ID2 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Order = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_HPplus = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_YPplus = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_PAplus = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_SAplus = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_STplus = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_SPplus = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill1 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill2 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill3 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill4 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill5 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Skill6 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown1 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown2 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown3 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown4 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown5 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown6 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown7 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown8 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown9 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown10 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown11 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown12 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown13 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown14 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown15 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown16 = 0;
                this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Unknown17 = 0;
                selectedItem.Text = "Empty";
            }
        }

        private void toumaNameTbox_TextChanged(object sender, EventArgs e)
        {
            if (((IEnumerable<byte>)Encoding.UTF8.GetBytes(this.toumaNameTbox.Text)).Count<byte>() < 24)
                this.saveFileParams.misc.ToumaName = this.toumaNameTbox.Text;
            else
                this.toumaNameTbox.Text = this.saveFileParams.misc.ToumaName;
        }

        private void summerNameTbox_TextChanged(object sender, EventArgs e)
        {
            if (((IEnumerable<byte>)Encoding.UTF8.GetBytes(this.summerNameTbox.Text)).Count<byte>() < 24)
                this.saveFileParams.misc.SummerName = this.summerNameTbox.Text;
            else
                this.summerNameTbox.Text = this.saveFileParams.misc.SummerName;
        }

        private void akinoriNameTbox_TextChanged(object sender, EventArgs e)
        {
            if (((IEnumerable<byte>)Encoding.UTF8.GetBytes(this.akinoriNameTbox.Text)).Count<byte>() < 24)
                this.saveFileParams.misc.AkinoriName = this.akinoriNameTbox.Text;
            else
                this.akinoriNameTbox.Text = this.saveFileParams.misc.AkinoriName;
        }

        private void jackNameTbox_TextChanged(object sender, EventArgs e)
        {
            if (((IEnumerable<byte>)Encoding.UTF8.GetBytes(this.jackNameTbox.Text)).Count<byte>() < 24)
                this.saveFileParams.misc.JackName = this.jackNameTbox.Text;
            else
                this.jackNameTbox.Text = this.saveFileParams.misc.JackName;
        }

        private void nateNameTbox_TextChanged(object sender, EventArgs e)
        {
            if (((IEnumerable<byte>)Encoding.UTF8.GetBytes(this.nateNameTbox.Text)).Count<byte>() < 24)
                this.saveFileParams.misc.NateName = this.nateNameTbox.Text;
            else
                this.nateNameTbox.Text = this.saveFileParams.misc.NateName;
        }

        private void katieNameTbox_TextChanged(object sender, EventArgs e)
        {
            if (((IEnumerable<byte>)Encoding.UTF8.GetBytes(this.katieNameTbox.Text)).Count<byte>() < 24)
                this.saveFileParams.misc.KatieName = this.katieNameTbox.Text;
            else
                this.katieNameTbox.Text = this.saveFileParams.misc.KatieName;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            try
            {
                this.workFile = this.saveFileParams.injectParams(this.workFile);
                File.WriteAllBytes(this.saveFileDialog1.FileName, this.workFile.ToArray());
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Error message: " + ex.Message + "\n\nDetails:\n\n" + ex.StackTrace);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void yokaiCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.isAdvancedList.Checked)
                this.yokaiIdNbox.Value = (Decimal)new GetYokai().pickYokaiIDNumber(new SetYokai().pickYokaiBytesFromIdIndex(this.yokaiCbox.SelectedIndex));
            else
                this.yokaiIdNbox.Value = (Decimal)new GetYokai().pickYokaiIDNumber(new SetYokai().pickBytesFromHealthyIndex(this.yokaiCbox.SelectedIndex));
        }

        private void yokaiTbox_TextChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.yokaiListView.SelectedItems)
            {
                if (((IEnumerable<byte>)Encoding.UTF8.GetBytes(this.yokaiTbox.Text)).Count<byte>() < 24)
                    this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Name = this.yokaiTbox.Text;
                else
                    this.yokaiTbox.Text = this.saveFileParams.UserYoKaiList[selectedItem.Index].YoKai_Name;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] strArray = new SetSkill().pickYokaiSkillsByYokaiId(Convert.ToInt32(this.yokaiIdNbox.Value));
            if (new SetSkill().pickYokaiSkillsByYokaiId(Convert.ToInt32(this.yokaiIdNbox.Value)).Length <= 1)
                return;
            this.yokaiBAtkCbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[0]);
            this.yokaiSpSklCbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[1]);
            this.yokaiExSklNbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[2]);
            this.yokaiExSkl2Nbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[3]);
            this.yokaiExSkl3Nbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[4]);
            this.yokaiExSkl4Nbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[5]);
        }

        private void label27_Click(object sender, EventArgs e)
        {
        }

        private void foodItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.foodItemList.SelectedItems)
            {
                this.foodCbox.SelectedIndex = new GetConsumable().pickConsumableIndex(this.saveFileParams.ConsumableList[selectedItem.Index].ItemSignature ?? "");
                this.foodQtdNbox.Value = (Decimal)this.saveFileParams.ConsumableList[selectedItem.Index].Quantity;
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void foodReplace_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.foodItemList.SelectedItems)
            {
                this.saveFileParams.ConsumableList[selectedItem.Index].ItemSignature = new SetConsumable().pickBytesFromIndex(this.foodCbox.SelectedIndex);
                this.saveFileParams.ConsumableList[selectedItem.Index].Quantity = Convert.ToInt32(this.foodQtdNbox.Value);
                if (this.saveFileParams.ConsumableList[selectedItem.Index].ID2 == 0)
                {
                    this.saveFileParams.ConsumableList[selectedItem.Index].ID1 = selectedItem.Index;
                    for (int index = 1; index < 500; ++index)
                    {
                        bool flag = false;
                        foreach (Consumable consumable in this.saveFileParams.ConsumableList)
                        {
                            if (index == consumable.ID2)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            this.saveFileParams.ConsumableList[selectedItem.Index].ID2 = index;
                            this.saveFileParams.ConsumableList[selectedItem.Index].Order = index;
                            break;
                        }
                    }
                }
                selectedItem.SubItems.Clear();
                selectedItem.SubItems.AddRange(new string[4]
                {
          this.saveFileParams.ConsumableList[selectedItem.Index].ID2.ToString(),
          this.saveFileParams.ConsumableList[selectedItem.Index].Order.ToString(),
          new GetConsumable().pickConsumableName(this.saveFileParams.ConsumableList[selectedItem.Index].ItemSignature ?? "Invalid"),
          this.saveFileParams.ConsumableList[selectedItem.Index].Quantity.ToString()
                });
                selectedItem.Text = this.saveFileParams.ConsumableList[selectedItem.Index].ID1.ToString();
            }
        }

        private void foodRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.foodItemList.SelectedItems)
            {
                this.saveFileParams.ConsumableList[selectedItem.Index].ID1 = 0;
                this.saveFileParams.ConsumableList[selectedItem.Index].ID2 = 0;
                this.saveFileParams.ConsumableList[selectedItem.Index].Order = 0;
                this.saveFileParams.ConsumableList[selectedItem.Index].ItemSignature = "00-00-00-00";
                this.saveFileParams.ConsumableList[selectedItem.Index].Quantity = 0;
                selectedItem.SubItems.Clear();
                ListViewItem.ListViewSubItemCollection subItems = selectedItem.SubItems;
                string[] items = new string[4];
                int num = this.saveFileParams.ConsumableList[selectedItem.Index].ID2;
                items[0] = num.ToString();
                num = this.saveFileParams.ConsumableList[selectedItem.Index].Order;
                items[1] = num.ToString();
                items[2] = new GetConsumable().pickConsumableName(this.saveFileParams.ConsumableList[selectedItem.Index].ItemSignature ?? "Invalid");
                num = this.saveFileParams.ConsumableList[selectedItem.Index].Quantity;
                items[3] = num.ToString();
                subItems.AddRange(items);
                ListViewItem listViewItem = selectedItem;
                num = this.saveFileParams.ConsumableList[selectedItem.Index].ID1;
                string str = num.ToString();
                listViewItem.Text = str;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void yokaiIdNbox_ValueChanged(object sender, EventArgs e)
        {
            if (this.isAdvancedList.Checked)
                this.yokaiCbox.SelectedIndex = Convert.ToInt32(this.yokaiIdNbox.Value);
            else
                this.yokaiCbox.SelectedIndex = new GetYokai().pickYokaiHealthyIndex(new SetYokai().pickYokaiBytesFromIdIndex((int)this.yokaiIdNbox.Value));
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e) => this.characterIdNbox.Value = (Decimal)new GetYokai().pickYokaiIDNumber(new SetYokai().pickYokaiBytesFromIdIndex(this.mainCharacterCbox.SelectedIndex));

        private void mainCharacterViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.mainCharacterViewList.SelectedItems)
            {
                this.characterIdNbox.Value = (Decimal)new GetYokai().pickYokaiIDNumber(this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Signature ?? "");
                this.mainCharacterCbox.SelectedIndex = Convert.ToInt32(this.characterIdNbox.Value);
                this.characterLevelNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Level;
                this.characterYpNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_YP;
                this.characterHpNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_HP;
                this.characterExpNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_XP;
                this.characterPGNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_PG;
                this.characterId1Nbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].ID1;
                this.characterId2Nbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].ID2;
                this.characterOrderIdNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Order;
                this.characterHpPlusNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_HPplus;
                this.characterYpPlusNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_YPplus;
                this.characterPdNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_PAplus;
                this.characterSdNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_SAplus;
                this.characterStNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_STplus;
                this.characterSpNbox.Value = (Decimal)this.saveFileParams.MainCharacterList[selectedItem.Index].Character_SPplus;
                this.characterBAtkCbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill1 ?? "");
                this.characterSpSklCbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill2 ?? "");
                this.characterExSklCbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill3 ?? "");
                this.characterExSkl2Cbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill4 ?? "");
                this.characterExSkl3Cbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill5 ?? "");
                this.characterExSkl4Cbox.SelectedIndex = new GetSkill().pickYokaiSkill(this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill6 ?? "");
            }
        }

        private void characterIdNbox_ValueChanged(object sender, EventArgs e) => this.mainCharacterCbox.SelectedIndex = Convert.ToInt32(this.characterIdNbox.Value);

        private void yokaiLevelNbox_ValueChanged(object sender, EventArgs e)
        {
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void yokaiBAtkCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void saveMainCharacterChanges_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.mainCharacterViewList.SelectedItems)
            {
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Signature = new SetYokai().pickYokaiBytesFromIdIndex((int)Convert.ToInt16(this.characterIdNbox.Value));
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Level = Convert.ToInt32(this.characterLevelNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_YP = Convert.ToInt32(this.characterYpNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_HP = Convert.ToInt32(this.characterHpNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_XP = Convert.ToInt32(this.characterExpNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_PG = Convert.ToInt32(this.characterPGNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_HPplus = Convert.ToInt32(this.characterHpPlusNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_YPplus = Convert.ToInt32(this.characterYpPlusNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_PAplus = Convert.ToInt32(this.characterPdNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_SAplus = Convert.ToInt32(this.characterSdNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_STplus = Convert.ToInt32(this.characterStNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_SPplus = Convert.ToInt32(this.characterSpNbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill1 = new SetSkill().pickSkillBytes(this.characterBAtkCbox.SelectedIndex);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill2 = new SetSkill().pickSkillBytes(this.characterSpSklCbox.SelectedIndex);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill3 = new SetSkill().pickSkillBytes(this.characterExSklCbox.SelectedIndex);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill4 = new SetSkill().pickSkillBytes(this.characterExSkl2Cbox.SelectedIndex);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill5 = new SetSkill().pickSkillBytes(this.characterExSkl3Cbox.SelectedIndex);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill6 = new SetSkill().pickSkillBytes(this.characterExSkl4Cbox.SelectedIndex);
                this.saveFileParams.MainCharacterList[selectedItem.Index].ID1 = Convert.ToInt32(this.characterId1Nbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].ID2 = Convert.ToInt32(this.characterId2Nbox.Value);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Order = Convert.ToInt32(this.characterOrderIdNbox.Value);
                selectedItem.Text = new GetYokai().pickYokaiName(this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Signature ?? "Invalid");
                if (this.characterId1Nbox.Value == 0M && this.characterId2Nbox.Value == 0M)
                {
                    bool flag = false;
                    this.saveFileParams.MainCharacterList[selectedItem.Index].ID1 = selectedItem.Index;
                    for (int index = 1; index < 1000; ++index)
                    {
                        foreach (ListViewItem listViewItem1 in this.yokaiListView.Items)
                        {
                            if (index == this.saveFileParams.UserYoKaiList[listViewItem1.Index].ID2)
                            {
                                foreach (ListViewItem listViewItem2 in this.mainCharacterViewList.Items)
                                {
                                    if (index == this.saveFileParams.MainCharacterList[listViewItem2.Index].ID2)
                                        flag = true;
                                }
                            }
                        }
                        if (!flag)
                        {
                            this.saveFileParams.MainCharacterList[selectedItem.Index].ID2 = index;
                            this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Order = index;
                            selectedItem.Selected = false;
                            selectedItem.Selected = true;
                            return;
                        }
                        flag = false;
                    }
                }
            }
        }

        private void removeMainCharacter_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.mainCharacterViewList.SelectedItems)
            {
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Signature = new SetYokai().pickYokaiBytesFromIdIndex(0);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Level = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_YP = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_HP = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_XP = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_PG = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].ID1 = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].ID2 = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Order = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_HPplus = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_YPplus = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_PAplus = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_SAplus = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_STplus = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_SPplus = 0;
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill1 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill2 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill3 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill4 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill5 = new SetSkill().pickSkillBytes(0);
                this.saveFileParams.MainCharacterList[selectedItem.Index].Character_Skill6 = new SetSkill().pickSkillBytes(0);
                selectedItem.Text = "Empty";
            }
        }

        private void characterSkillLoaderBtn_Click(object sender, EventArgs e)
        {
            string[] strArray = new SetSkill().pickYokaiSkillsByYokaiId(Convert.ToInt32(this.characterIdNbox.Value));
            if (strArray.Length <= 1)
                return;
            this.characterBAtkCbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[0]);
            this.characterSpSklCbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[1]);
            this.characterExSklCbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[2]);
            this.characterExSkl2Cbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[3]);
            this.characterExSkl3Cbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[4]);
            this.characterExSkl4Cbox.SelectedIndex = new GetSkill().pickYokaiSkill(strArray[5]);
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(new ProcessStartInfo("https://www.buymeacoffee.com/bqsantana")
        {
            UseShellExecute = true
        });

        private void equipCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void replaceEquipBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.equipListView.SelectedItems)
            {
                this.saveFileParams.EquipmentList[selectedItem.Index].ItemSignature = new SetEquipment().pickBytesFromIndex(this.equipCbox.SelectedIndex);
                this.saveFileParams.EquipmentList[selectedItem.Index].Quantity = Convert.ToInt32(this.equipQtNbox.Value);
                if (this.saveFileParams.EquipmentList[selectedItem.Index].ID2 == 0)
                {
                    this.saveFileParams.EquipmentList[selectedItem.Index].ID1 = selectedItem.Index + 4096;
                    for (int index = 1; index < 500; ++index)
                    {
                        bool flag = false;
                        foreach (Equipment equipment in this.saveFileParams.EquipmentList)
                        {
                            if (index == equipment.ID2)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            this.saveFileParams.EquipmentList[selectedItem.Index].ID2 = index;
                            this.saveFileParams.EquipmentList[selectedItem.Index].Order = index;
                            break;
                        }
                    }
                }
                selectedItem.SubItems.Clear();
                selectedItem.SubItems.AddRange(new string[4]
                {
          this.saveFileParams.EquipmentList[selectedItem.Index].ID2.ToString(),
          this.saveFileParams.EquipmentList[selectedItem.Index].Order.ToString(),
          new GetEquipment().pickEquipmentName(this.saveFileParams.EquipmentList[selectedItem.Index].ItemSignature ?? "Invalid"),
          this.saveFileParams.EquipmentList[selectedItem.Index].Quantity.ToString()
                });
                selectedItem.Text = this.saveFileParams.EquipmentList[selectedItem.Index].ID1.ToString();
            }
        }

        private void removeEquipBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.equipListView.SelectedItems)
            {
                this.saveFileParams.EquipmentList[selectedItem.Index].ID1 = 0;
                this.saveFileParams.EquipmentList[selectedItem.Index].ID2 = 0;
                this.saveFileParams.EquipmentList[selectedItem.Index].Order = 0;
                this.saveFileParams.EquipmentList[selectedItem.Index].ItemSignature = "00-00-00-00";
                this.saveFileParams.EquipmentList[selectedItem.Index].Quantity = 0;
                selectedItem.SubItems.Clear();
                ListViewItem.ListViewSubItemCollection subItems = selectedItem.SubItems;
                string[] items = new string[4];
                int num = this.saveFileParams.EquipmentList[selectedItem.Index].ID2;
                items[0] = num.ToString();
                num = this.saveFileParams.EquipmentList[selectedItem.Index].Order;
                items[1] = num.ToString();
                items[2] = new GetEquipment().pickEquipmentName(this.saveFileParams.EquipmentList[selectedItem.Index].ItemSignature ?? "Invalid");
                num = this.saveFileParams.EquipmentList[selectedItem.Index].Quantity;
                items[3] = num.ToString();
                subItems.AddRange(items);
                ListViewItem listViewItem = selectedItem;
                num = this.saveFileParams.EquipmentList[selectedItem.Index].ID1;
                string str = num.ToString();
                listViewItem.Text = str;
            }
        }

        private void equipListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in this.equipListView.SelectedItems)
            {
                this.equipCbox.SelectedIndex = new GetEquipment().pickEquipmentIndex(this.saveFileParams.EquipmentList[selectedItem.Index].ItemSignature ?? "");
                this.equipQtNbox.Value = (Decimal)this.saveFileParams.EquipmentList[selectedItem.Index].Quantity;
            }
        }

        private void CloseAllForms(object sender, EventArgs e) => Application.OpenForms[0].Close();

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Application.Exit();
        }
    }
}
