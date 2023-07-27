using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_YW_4_Save_Editor
{
    internal class GetEquipment
    {
        public string pickEquipmentName(string bytes)
        {
            switch (bytes)
            {
                case "00-00-00-00":
                    return "Empty";
                case "01-67-14-68":
                    return "Sword of Destruction                    ";
                case "02-31-C3-87":
                    return "Cat King's Mirror                       ";
                case "02-60-93-C6":
                    return "Demon Jade Treasure Sword               ";
                case "02-F5-CA-8A":
                    return "Night Sky Amulet                        ";
                case "03-5B-BA-19":
                    return "Commander Armour                        ";
                case "05-A2-78-0C":
                    return "Wild Sword                              ";
                case "06-57-D5-D2":
                    return "A Thousand-Handed Spider Claw           ";
                case "06-F4-AF-E3":
                    return "Flamenca                                ";
                case "07-54-EF-04":
                    return "Onihime Halberd                         ";
                case "08-4D-0D-CC":
                    return "Race Soul Hammer - Good Luck            ";
                case "08-D0-91-AB":
                    return "Death of a Strange Sword                ";
                case "08-DA-F3-4E":
                    return "B Shiroinu Launcher                     ";
                case "09-D3-AB-7D":
                    return "Shakugo No Yoki Fan                     ";
                case "0B-25-3C-75":
                    return "Demon Axe                               ";
                case "0B-62-F3-A1":
                    return "Quick Clawed Weasel                     ";
                case "0C-1B-CD-BB":
                    return "Amaterasu The Divine Wand               ";
                case "0D-BB-8D-5C":
                    return "Yo-Gun                                  ";
                case "0E-27-63-CA":
                    return "Good Luck Charm                         ";
                case "0E-7E-76-2B":
                    return "Demon's Jaw Of Darkness                 ";
                case "10-0C-AC-83":
                    return "Onniwa Cudgel                           ";
                case "10-46-B3-C6":
                    return "Giant Choccie                           ";
                case "10-A2-CC-77":
                    return "Sunny Stick                             ";
                case "10-FC-B6-81":
                    return "Fudo Kaimei Ken                         ";
                case "11-3C-6A-C6":
                    return "Unknown Cane                            ";
                case "11-D2-AF-82":
                    return "Nightmare Slingshot                     ";
                case "11-D8-15-77":
                    return "Extreme Charm                           ";
                case "12-AE-23-98":
                    return "Fudou Thunderbolt Sword Boy             ";
                case "13-E0-E9-97":
                    return "Crr Wand                                ";
                case "14-39-DA-E5":
                    return "Lion King Knuckle                       ";
                case "14-A6-76-F0":
                    return "Spider Sword                            ";
                case "14-B7-5B-11":
                    return "Black Iron Shield                       ";
                case "15-19-2B-82":
                    return "Courage Charm                           ";
                case "15-7E-58-BE":
                    return "Divine Spear Red Cross                  ";
                case "16-28-8F-51":
                    return "Demon's Staff                           ";
                case "16-4E-E6-AE":
                    return "Concealment Cloak                       ";
                case "16-8B-F5-60":
                    return "Mega Manbo Crash                        ";
                case "17-06-4E-42":
                    return "Sproink Scorching Tub                   ";
                case "17-25-85-F3":
                    return "Wand Of The Marquis                     ";
                case "17-2B-B5-87":
                    return "Yosha Hyo Flame Dance                   ";
                case "17-34-3F-AE":
                    return "Zuto Shinya                             ";
                case "17-C3-5D-8C":
                    return "Chain Whip                              ";
                case "1B-11-F4-CC":
                    return "An No Jolt Blow                         ";
                case "1B-E6-96-EE":
                    return "Hovernyan Knuckle                       ";
                case "1B-F9-1C-C7":
                    return "Practice Glove                          ";
                case "1C-87-07-15":
                    return "Wind Cloud Drum                         ";
                case "1D-0A-BC-37":
                    return "Silver Lining Cloak                     ";
                case "1D-19-A1-A4":
                    return "Shadow Snake Fang                       ";
                case "1D-67-AD-EE":
                    return "Fancy Fan                               ";
                case "1D-9B-B7-EA":
                    return "Kibitsu Sword                           ";
                case "1E-7C-8A-D8":
                    return "Maul Attachment                         ";
                case "1E-8B-E8-FA":
                    return "Illuminoct Blade                        ";
                case "1F-82-B0-C9":
                    return "Petit Petit King Wand                   ";
                case "20-6C-8C-43":
                    return "Divine Shield                           ";
                case "20-A9-9F-8D":
                    return "Giraffe Pencil                          ";
                case "20-CF-F6-72":
                    return "Mitchy Life-Size Panel                  ";
                case "21-CC-CC-A4":
                    return "Clean Cloak                             ";
                case "22-52-12-40":
                    return "Frostina Fan                            ";
                case "22-9A-1B-4B":
                    return "Momoiro Bow                             ";
                case "23-28-CB-40":
                    return "Betsukari Charm                         ";
                case "23-53-18-E4":
                    return "Enma Yasha Sealed Prison Blade          ";
                case "23-99-21-9D":
                    return "Genbu Gauntlets                         ";
                case "23-CC-B4-F1":
                    return "Komasan Wand                            ";
                case "25-07-90-B4":
                    return "Quick Charm                             ";
                case "25-33-83-BB":
                    return "Three Kendama Brothers                  ";
                case "25-C4-E1-99":
                    return "Hundred Flowers Fan                     ";
                case "26-36-34-67":
                    return "New Style Magic Bullet Rifle            ";
                case "26-56-A8-C7":
                    return "Golden Particle Cannon                  ";
                case "26-B8-6D-83":
                    return "Poop Stick                              ";
                case "26-EB-D5-A0":
                    return "Kukurihime Braid                        ";
                case "27-35-0E-B1":
                    return "Demon God Kuzanagi Sword                ";
                case "27-66-6E-82":
                    return "Hungry Wand                             ";
                case "27-C8-0E-76":
                    return "Oni Crush                               ";
                case "28-B1-70-1E":
                    return "Crimson Halberd                         ";
                case "29-16-48-D9":
                    return "Vise Scissors                           ";
                case "29-29-23-F0":
                    return "Handmade Scarf                          ";
                case "29-B4-BF-97":
                    return "White Tiger Gauntlets                   ";
                case "29-D5-39-F4":
                    return "Flower Charm                            ";
                case "29-E1-2A-FB":
                    return "Snartle Blade                           ";
                case "2A-00-28-C2":
                    return "Triple Nyan Claw                        ";
                case "2A-41-12-49":
                    return "Black Tong Lava Tub                     ";
                case "2A-60-7E-36":
                    return "Prison Handcuffs                        ";
                case "2B-B4-C7-C2":
                    return "Bewitching Lipstick                     ";
                case "2C-1B-AA-6D":
                    return "Ultimate Crushing Hammer                ";
                case "2C-8C-54-EF":
                    return "Komajiro Punch                          ";
                case "2C-BE-25-03":
                    return "General Armour                          ";
                case "2D-10-55-90":
                    return "Twilight Charm                          ";
                case "2D-85-0C-DC":
                    return "Zanma King's Great Spirit Sword         ";
                case "2E-77-D9-22":
                    return "Enma Blade                              ";
                case "2E-80-BB-00":
                    return "Magic Flame Fist                        ";
                case "2E-82-8B-72":
                    return "Warrior God Sword                       ";
                case "2E-C5-44-A6":
                    return "Akaneko Kouren-maru                     ";
                case "2F-0D-00-22":
                    return "Dismarelda Headband                     ";
                case "2F-1C-AD-48":
                    return "Shiroinu Silver Sword - Blue Flame      ";
                case "2F-2A-0E-BE":
                    return "Healing Charm                           ";
                case "2F-2C-FB-E1":
                    return "Golden Rose                             ";
                case "30-67-2F-D3":
                    return "Discipline Fan 2                        ";
                case "30-F0-D1-51":
                    return "Nail Bat                                ";
                case "31-10-EC-16":
                    return "Ronin Hakama                            ";
                case "33-45-01-2F":
                    return "Carbide Ticking Mail                    ";
                case "37-4C-A1-6D":
                    return "Custom Demon Skater                     ";
                case "38-C0-1A-E9":
                    return "Ghost Wand                              ";
                case "39-68-9F-25":
                    return "Indigo Dragon Armour                    ";
                case "39-6E-6A-7A":
                    return "Death Black Hammer                      ";
                case "3A-FC-B4-98":
                    return "Passion Pendant                         ";
                case "3B-52-C4-0B":
                    return "Glory Shield                            ";
                case "3C-62-05-B1":
                    return "Suzaku Great Gauntlets                  ";
                case "3C-C1-7F-80":
                    return "Myo Robe                                ";
                case "3F-97-A8-6F":
                    return "Iron Shield                             ";
                case "40-56-0F-71":
                    return "Demon King Sword                        ";
                case "42-4B-CD-7F":
                    return "Specially Selected Meat Loincloth       ";
                case "42-6A-A1-00":
                    return "Bannerman Armour                        ";
                case "43-51-88-DF":
                    return "Demon Jade Secret Sword                 ";
                case "43-C4-D1-93":
                    return "Galaxy Amulet                           ";
                case "44-36-EC-7B":
                    return "Hyper Dress                             ";
                case "44-43-98-17":
                    return "Spoilerina Toe Shoes                    ";
                case "45-39-41-17":
                    return "Masakuni Doudanuki                      ";
                case "46-65-F4-1D":
                    return "Love Mitchy Fan                         ";
                case "46-AB-08-49":
                    return "Demon Cutter                            ";
                case "46-B8-15-DA":
                    return "Cool Hat                                ";
                case "47-01-BD-F7":
                    return "Simple Amulet                           ";
                case "47-35-AE-F8":
                    return "Venoct Blade                            ";
                case "47-C2-CC-DA":
                    return "Komashura Fist                          ";
                case "48-4F-FA-21":
                    return "Yo-Magnum                               ";
                case "48-91-31-57":
                    return "Cloak From A Can                        ";
                case "48-E2-B0-64":
                    return "Shakugo No Genjyo Fan                   ";
                case "49-7C-16-D5":
                    return "Race Soul Hammer - Great Luck           ";
                case "49-EB-E8-57":
                    return "Mie Mie Stick                           ";
                case "4A-8E-C3-2B":
                    return "True Lord Ananta's Sword                ";
                case "4B-D3-14-B7":
                    return "Tsugihagi Charm                         ";
                case "4C-86-96-43":
                    return "Blizzaria Fan                           ";
                case "4D-0B-2D-61":
                    return "Komadog Charm                           ";
                case "4D-2A-D6-A2":
                    return "Amaterasu The Goddess Wand              ";
                case "4D-4D-A5-9E":
                    return "Asura Gauntlets                         ";
                case "4E-1B-72-71":
                    return "Hyper Suit                              ";
                case "4E-D3-7B-7A":
                    return "Shura No Ou Fang                        ";
                case "4F-07-C2-8E":
                    return "Noko Charm                              ";
                case "4F-14-DF-1D":
                    return "Mountain God Fang                       ";
                case "4F-18-48-A7":
                    return "Bat Cloak                               ";
                case "4F-4F-6D-32":
                    return "Enma Awoken Flute                       ";
                case "4F-F0-A0-AC":
                    return "Fast Sneakers                           ";
                case "51-43-2C-6C":
                    return "Round Shield                            ";
                case "51-CD-AD-98":
                    return "Cat Fist Jiva Jiva Nyakuru              ";
                case "52-B6-81-B2":
                    return "Fudo Myoo Great Gauntlets               ";
                case "54-28-30-9B":
                    return "Pulsating Charm                         ";
                case "55-08-C1-FC":
                    return "Whis Hammer                             ";
                case "55-86-40-08":
                    return "Scarlet Sky Shield                      ";
                case "56-14-9E-EA":
                    return "Brr Wand                                ";
                case "5D-91-85-2C":
                    return "Holy Armour                             ";
                case "5E-0D-6B-BA":
                    return "Volcano Upper                           ";
                case "5E-B3-AB-D0":
                    return "Petit Petit Wise Wand                   ";
                case "5F-BA-F3-E3":
                    return "Shadow Venoct Blade                     ";
                case "61-5D-97-5A":
                    return "Holy & Divine Shield                    ";
                case "62-62-03-FD":
                    return "Enma Karma Violent Double Blade         ";
                case "62-CF-49-B8":
                    return "True Magic Owl-Kai Wand                 ";
                case "63-6F-09-5F":
                    return "Sniper Shot                             ";
                case "64-38-BB-D9":
                    return "Hero Cloak                              ";
                case "66-04-15-A8":
                    return "Holy Blade                              ";
                case "66-A7-6F-99":
                    return "Demon Blade                             ";
                case "66-F9-15-6F":
                    return "Heroes Bamboo Sword                     ";
                case "67-07-2F-7E":
                    return "High Pressure Migic Bullet Rifle        ";
                case "67-67-B3-DE":
                    return "Bottomles Bottle                        ";
                case "68-83-51-D1":
                    return "Brutal Claw                             ";
                case "69-80-6B-07":
                    return "Demon's Claw Type-3                     ";
                case "6B-31-33-DB":
                    return "Enma Yasha Sealed Sword                 ";
                case "6B-76-FC-0F":
                    return "Beginner Sword                          ";
                case "6C-21-4E-89":
                    return "Dawn cHARM                              ";
                case "6C-B4-17-C5":
                    return "Zanma's Spirit Sword                    ";
                case "6D-2A-B1-74":
                    return "Super Crushing Hammer                   ";
                case "6D-BD-4F-F6":
                    return "B Rabbit Launcher                       ";
                case "6E-1D-E0-F8":
                    return "Blue Ballade                            ";
                case "6E-2D-B6-51":
                    return "Get Golden Gun Universe                 ";
                case "6F-B3-90-6B":
                    return "Bloodstained Sword                      ";
                case "6F-F4-5F-BF":
                    return "Shiroinu Silver Sword                   ";
                case "70-5F-6C-F9":
                    return "Burly Dumbbell                          ";
                case "70-A8-0E-DB":
                    return "Earth Demon Crusher                     ";
                case "70-AF-76-FB":
                    return "Immovable Kutani Sword                  ";
                case "71-56-34-CA":
                    return "Secret Fan                              ";
                case "71-C1-CA-48":
                    return "Damona Fan                              ";
                case "71-D2-D7-DB":
                    return "Bankara Jacket                          ";
                case "72-0A-81-C0":
                    return "Kichizuchi Nari Gama                    ";
                case "72-53-83-16":
                    return "Thunder Cloud Drum                      ";
                case "72-59-39-E3":
                    return "Emergency Disaster Bag                  ";
                case "73-29-5A-16":
                    return "Tokoyami Lid                            ";
                case "73-4F-33-E9":
                    return "Spear Of Annihilation                   ";
                case "73-D2-AF-8E":
                    return "Lord Ananta Wind-Thunder Sword          ";
                case "74-E4-9B-6B":
                    return "High King Robe                          ";
                case "76-44-24-02":
                    return "Wiglin Happi                            ";
                case "76-7B-4F-2B":
                    return "Whis Hammer II                          ";
                case "76-7D-BA-74":
                    return "Super Demon Skater                      ";
                case "78-5F-71-63":
                    return "Very Dangerous Hammer                   ";
                case "78-6D-00-8F":
                    return "Monk Robe                               ";
                case "78-9A-62-AD":
                    return "Transfiguration Shield                  ";
                case "78-FC-0B-52":
                    return "Musou Knuckle                           ";
                case "79-04-C4-1C":
                    return "Evil Cloak                              ";
                case "79-E0-BB-AD":
                    return "Lost Sword                              ";
                case "79-F1-01-F0":
                    return "Evil Wand                               ";
                case "79-FF-31-84":
                    return "Enma Hellfire Sword                     ";
                case "7A-63-DF-12":
                    return "Evil Shield                             ";
                case "7B-1B-36-60":
                    return "Demon Rattle                            ";
                case "7B-AA-DC-BD":
                    return "Spear of the Great Tree                 ";
                case "7B-CD-AF-81":
                    return "Fighting Spirit Pedant                  ";
                case "7B-EC-54-42":
                    return "Insomnia Wand                           ";
                case "7D-34-6D-94":
                    return "Twisted Wand                            ";
                case "7D-E4-01-2A":
                    return "Lord Ananta's Sword                     ";
                case "7E-81-2A-56":
                    return "Kyubi Fan                               ";
                case "7F-06-2B-81":
                    return "B Akaneko Launcher                      ";
                case "7F-FB-F3-56":
                    return "Onikuma Make-Up                         ";
                case "80-53-F5-B5":
                    return "Tengu King's Mirror                     ";
                case "80-97-FC-B8":
                    return "Starlight Amulet                        ";
                case "81-39-8C-2B":
                    return "Ashigaru Armour                         ";
                case "84-52-90-DC":
                    return "Clean Amulet                            ";
                case "84-96-99-D1":
                    return "Clawed Weasel                           ";
                case "87-65-C1-50":
                    return "Super Hyper Dress                       ";
                case "87-C0-4E-3E":
                    return "Demon Sword                             ";
                case "88-80-39-9C":
                    return "Good Smell Charm                        ";
                case "89-47-0A-47":
                    return "Axe of the Evil God                     ";
                case "8C-4B-65-8C":
                    return "Vampire Cloak                           ";
                case "8D-48-5F-5A":
                    return "Super Hyper Suit                        ";
                case "8D-EB-25-6B":
                    return "Warty Shield                            ";
                case "8E-1E-88-B5":
                    return "Asura Great Gauntlets                   ";
                case "8F-D9-BB-6E":
                    return "Yo-Gun 2.0                              ";
                case "90-2E-9F-44":
                    return "Hidabat Shuriken                        ";
                case "90-D9-FD-66":
                    return "Fire Demon Crusher                      ";
                case "91-82-DF-A5":
                    return "Bzz Wand                                ";
                case "91-E5-AC-99":
                    return "Fudo Myoo Gauntlets                     ";
                case "92-10-01-47":
                    return "Study Shield                            ";
                case "92-22-70-AB":
                    return "The Weather Scissors                    ";
                case "92-9E-80-B3":
                    return "Basterds Hell Launcher                  ";
                case "92-B3-7B-76":
                    return "Mitchy Love Diary                       ";
                case "93-58-A9-AB":
                    return "Wazzhat                                 ";
                case "93-AF-CB-89":
                    return "Happierre Beard                         ";
                case "94-4A-B9-63":
                    return "Demolition Wand                         ";
                case "94-CE-5A-72":
                    return "Sushi Chief Soul                        ";
                case "96-C2-B5-9D":
                    return "Little Charrmer's Robe                  ";
                case "96-D5-6D-23":
                    return "Blue Sea Shield                         ";
                case "97-4F-0E-BF":
                    return "Giant Snake Pickaxe                     ";
                case "97-7B-1D-B0":
                    return "Cheerful Charm                          ";
                case "97-AB-71-0E":
                    return "So-Sorry Earpiece                       ";
                case "97-B8-6C-9D":
                    return "Chairman's Staff                        ";
                case "99-66-2A-32":
                    return "Judgement Wand                          ";
                case "99-91-48-10":
                    return "Shin Toad's Great Spear                 ";
                case "99-9B-2A-F5":
                    return "Burning Knuckles                        ";
                case "9A-10-1C-DD":
                    return "Green Amulet                            ";
                case "9A-F4-63-6C":
                    return "Water Demon Crusher                     ";
                case "9B-8E-BA-6C":
                    return "Double 0 Armour                         ";
                case "9C-E9-DE-C8":
                    return "Moonlight Pills                         ";
                case "9C-FC-36-04":
                    return "Seminaire                               ";
                case "9D-E0-86-FB":
                    return "Petit Petit Wand                        ";
                case "9E-A9-DB-3D":
                    return "Whis Pointing Stick                     ";
                case "9E-C2-A8-07":
                    return "Divine Armour                           ";
                case "9E-F0-D9-EB":
                    return "Den Punch                               ";
                case "9F-05-9B-DC":
                    return "Yo-Kai's War Coat                       ";
                case "9F-6E-7F-5A":
                    return "Darkyubi Fan                            ";
                case "9F-F9-81-D8":
                    return "Kibitsu Sword - Fuma                    ";
                case "A0-3C-24-74":
                    return "Sniper Shokai                           ";
                case "A0-D2-AE-9C":
                    return "Flame Demon Sword                       ";
                case "A0-E8-C7-38":
                    return "Get Golden Gun                          ";
                case "A0-F8-2D-79":
                    return "Pretty Bow                              ";
                case "A1-31-2E-D6":
                    return "Enma Naraku Cutting Knife               ";
                case "A1-5F-15-BE":
                    return "Horned Helmet                           ";
                case "A1-9C-64-93":
                    return "True Magic Owl Wand                     ";
                case "A2-29-23-51":
                    return "Karakuri Zambara                        ";
                case "A2-DE-41-73":
                    return "Shiname Kiseru                          ";
                case "A3-AE-FA-96":
                    return "Dark Night Cloak                        ";
                case "A3-FD-9A-A5":
                    return "Cow Devil's Charm                       ";
                case "A4-32-6B-AA":
                    return "Noway Tile                              ";
                case "A4-54-02-55":
                    return "Magic Bullet Rifle                      ";
                case "A4-8F-16-CD":
                    return "Kappa's Gourd                           ";
                case "A5-57-38-83":
                    return "Kusanagi                                ";
                case "A5-BF-D0-88":
                    return "Buroron Stick                           ";
                case "A5-F4-42-B2":
                    return "Black Claw Nekomata                     ";
                case "A7-44-5D-45":
                    return "Tattletell Microphone                   ";
                case "A7-B3-3F-67":
                    return "Machibari Stick                         ";
                case "A8-04-BD-5B":
                    return "Nyan Style Super Gravuty Gun            ";
                case "A8-25-D1-24":
                    return "Great Skills Sword                      ";
                case "A8-86-AB-15":
                    return "Whis Pointer                            ";
                case "A9-D0-04-AF":
                    return "Red Bean Colander                       ";
                case "AA-D3-46-2C":
                    return "Demon's Claw Type-2                     ";
                case "AB-4B-15-C2":
                    return "Handmade Love Scarf                     ";
                case "AB-96-F4-05":
                    return "Blue Dragon Wand                        ";
                case "AB-B7-0F-C6":
                    return "Mirage Charm                            ";
                case "AB-D0-7C-FA":
                    return "Sharp Claws                             ";
                case "AC-00-07-DC":
                    return "Baikiki Scissors                        ";
                case "AC-A7-72-94":
                    return "Enma Karma Double Blade                 ";
                case "AC-E0-BD-40":
                    return "Sage Sword                              ";
                case "AC-E4-78-6D":
                    return "Purr Armor                              ";
                case "AD-4E-CD-D3":
                    return "Wonderful Wand                          ";
                case "AE-79-9C-5F":
                    return "Crushing Hammer                         ";
                case "AF-76-31-33":
                    return "Kyunkyun Karoshi Hat                    ";
                case "AF-81-53-11":
                    return "Jituri Loincloth                        ";
                case "AF-E7-3A-EE":
                    return "Zanma Sword                             ";
                case "B0-1C-1E-C2":
                    return "The Great Spear Of Annihilation         ";
                case "B3-19-A9-1E":
                    return "Chu Chu Tick Claw                       ";
                case "B3-72-DA-24":
                    return "Master Hakama                           ";
                case "B5-28-62-00":
                    return "Whis Hammer III                         ";
                case "B6-74-D7-0A":
                    return "Mangetsu Maru                           ";
                case "B7-DE-F5-08":
                    return "Fang Of The Great Demon Serpent         ";
                case "B9-D0-48-A5":
                    return "Sakuraji Belt                           ";
                case "BA-81-E7-6A":
                    return "Flashy Shield                           ";
                case "BA-A2-2C-DB":
                    return "Radiant Wand                            ";
                case "BB-0C-5C-48":
                    return "Dangerous Hammer                        ";
                case "BB-38-D8-FB":
                    return "Ebisu Great Spear                       ";
                case "BB-AF-26-79":
                    return "Tenka Musou Knuckle                     ";
                case "BD-F5-9E-5D":
                    return "Stripes Shield                          ";
                case "BE-67-40-BF":
                    return "Yo-kai Wand                             ";
                case "C0-2F-0E-12":
                    return "Spider Cutlass                          ";
                case "C0-76-0C-C4":
                    return "Amateru Staff Hiizuru                   ";
                case "C0-D8-6C-30":
                    return "Staff Of Liberation                     ";
                case "C1-33-BE-ED":
                    return "Demon Jade Sword                        ";
                case "C1-55-D7-12":
                    return "Nosirs Glasses                          ";
                case "C1-62-EE-AC":
                    return "Kappa King's Mirror                     ";
                case "C1-A2-B5-30":
                    return "First Class Lady Pouch                  ";
                case "C1-E8-AA-75":
                    return "Cane of Stregth                         ";
                case "C2-23-E1-FD":
                    return "Blazion Punch                           ";
                case "C4-07-C2-2F":
                    return "Demon Blade Halberd                     ";
                case "C4-38-A9-06":
                    return "Rhyth Happi                             ";
                case "C4-CD-FB-56":
                    return "Feudal Lord Armour                      ";
                case "C4-DC-D6-B7":
                    return "Cuddly Bills                            ";
                case "C5-04-F8-F9":
                    return "Thousand-Armed Spider Claw              ";
                case "C5-42-70-06":
                    return "Ice Flower Fan                          ";
                case "C5-63-8B-C5":
                    return "Dark Amulet                             ";
                case "C5-65-7E-9A":
                    return "Reincarnation Wand                      ";
                case "C5-A6-0F-B7":
                    return "Red Cassock                             ";
                case "C5-A7-82-C8":
                    return "Fudo Kenjaku                            ";
                case "C6-52-2F-16":
                    return "Mitsumata Fork                          ";
                case "C6-C3-24-CB":
                    return "Hide and Seek Charm                     ";
                case "C6-F1-55-27":
                    return "Great Thief Sword                       ";
                case "C7-17-9D-3F":
                    return "Red Slash                               ";
                case "C7-4E-9F-E9":
                    return "Secret Sword                            ";
                case "C8-44-60-B2":
                    return "Nukeboshi Hatchet                       ";
                case "C8-76-11-5E":
                    return "Axe of the Demon God                    ";
                case "C8-F9-1D-D5":
                    return "Wicked Staff - Yamiaro                  ";
                case "C9-B1-22-85":
                    return "Lucky Charm                             ";
                case "CA-80-86-56":
                    return "Fan Of Shakugo                          ";
                case "CA-E6-EF-A9":
                    return "Sandmeh's Charm                         ";
                case "CB-1E-20-E7":
                    return "Race Soul Hammer                        ";
                case "CB-83-BC-80":
                    return "Strange Sword                           ";
                case "CB-9C-36-A9":
                    return "Giant Snake Dagger                      ";
                case "CC-0A-C5-70":
                    return "Bunny Blaster                           ";
                case "CC-19-D8-E3":
                    return "Time And Space Shield                   ";
                case "CD-29-1E-A6":
                    return "Borororin Braided Hat                   ";
                case "CD-63-01-E3":
                    return "Magic Claw Akaneko                      ";
                case "CE-06-2A-9F":
                    return "Demon Weeping Sword                     ";
                case "CE-E8-A0-77":
                    return "Premium Yo-Gun                          ";
                case "CE-F1-48-BD":
                    return "Oni Sakura Fan                          ";
                case "CF-48-E0-90":
                    return "Amaterasu Wand                          ";
                case "CF-7C-F3-9F":
                    return "Mochiri Guard                           ";
                case "D0-92-3F-7F":
                    return "Frostail Coat                           ";
                case "D0-B3-C4-BC":
                    return "Zzz Wand                                ";
                case "D1-13-84-5B":
                    return "Torrent Gun Splash T                    ";
                case "D2-8F-6A-CD":
                    return "Fiend Charm                             ";
                case "D3-21-1A-5E":
                    return "Alloy Shield                            ";
                case "D3-AF-9B-AA":
                    return "Spirit Sword                            ";
                case "D4-55-63-69":
                    return "Sproink Tub                             ";
                case "D4-78-98-AC":
                    return "High-Blade Yasha Ice Flame Dance        ";
                case "D5-7B-A2-7A":
                    return "Demolition Wand                         ";
                case "D5-D8-D8-4B":
                    return "Mega Manbo Smash                        ";
                case "D8-AA-31-EC":
                    return "Fire Punch                              ";
                case "D9-0A-71-0B":
                    return "Black Iron Vajra Ball                   ";
                case "DC-BE-C4-5C":
                    return "Yo-Kai Blade                            ";
                case "DE-34-80-C5":
                    return "Spectral Fan                            ";
                case "DE-5F-64-43":
                    return "Masternyada Hose                        ";
                case "DE-C8-9A-C1":
                    return "Kibitsu Sword - Shiver                  ";
                case "E0-00-35-CF":
                    return "Akaneko Kouren-maru - Flame             ";
                case "E0-6E-0E-A7":
                    return "Giant Horned Helmet                     ";
                case "E0-CA-0C-B6":
                    return "Genbu Great Gauntlets                   ";
                case "E1-0D-3F-6D":
                    return "Demon Rifle                             ";
                case "E1-C9-36-60":
                    return "Cute Bow                                ";
                case "E1-D9-DC-21":
                    return "Phantom Beast Holy Spear                ";
                case "E2-9F-E1-8F":
                    return "Elite Cloak                             ";
                case "E3-3F-A1-68":
                    return "Holy Shield                             ";
                case "E4-C5-59-AB":
                    return "Triple Nyanyan Claw                     ";
                case "E6-54-BD-9F":
                    return "Speedy Charm                            ";
                case "E8-BA-BA-AE":
                    return "Rainbow Rose Walking Stick              ";
                case "E9-12-3F-62":
                    return "Black Tong Tub                          ";
                case "E9-14-CA-3D":
                    return "Swordsman Sword                         ";
                case "E9-53-05-E9":
                    return "Super Demon Blade                       ";
                case "EA-7A-0E-DB":
                    return "Handmade Sincerity Scarf                ";
                case "EA-86-14-DF":
                    return "Aurora Charm                            ";
                case "EA-E7-92-BC":
                    return "White Tiger Great Gauntlets             ";
                case "ED-31-1C-C5":
                    return "Squisker Tentacles                      ";
                case "ED-96-69-8D":
                    return "Enma Naraku Knife                       ";
                case "EF-ED-08-28":
                    return "Samurai Armour                          ";
                case "F0-24-5D-E8":
                    return "Reuknight Spear                         ";
                case "F1-2D-05-DB":
                    return "Roaring Spear Of Annihilation           ";
                case "F1-5E-84-E8":
                    return "Sacred Kettle                           ";
                case "F2-28-B2-07":
                    return "Great Fox Fan                           ";
                case "F2-43-C1-3D":
                    return "Swordsman Hakama                        ";
                case "F2-DF-D0-25":
                    return "Magic Tube - Mimizuku                   ";
                case "F3-34-02-F8":
                    return "Discipline Fan                          ";
                case "F3-52-6B-07":
                    return "Steppa Happi                            ";
                case "F3-FC-0B-F3":
                    return "Moon Poet Hair Ornament                 ";
                case "F4-19-79-19":
                    return "Demon's Claw                            ";
                case "F4-1F-8C-46":
                    return "Demon Skater                            ";
                case "F6-82-68-74":
                    return "Nekomata Claws                          ";
                case "F6-C8-77-31":
                    return "Sleeping Charm                          ";
                case "F7-45-CC-13":
                    return "Mon Puke Fist                           ";
                case "F8-E1-53-BC":
                    return "Fujiya Belt                             ";
                case "F9-6C-E8-9E":
                    return "Demon's Sword                           ";
                case "F9-9B-8A-BC":
                    return "Old Demon Wand                          ";
                case "F9-AF-99-B3":
                    return "Fever Pendant                           ";
                case "FA-09-C3-E2":
                    return "Yomi Hirasaka Magic Spear               ";
                case "FA-43-DC-A7":
                    return "Faux Kappa Bag                          ";
                case "FA-9E-3D-60":
                    return "Tenjo Tenka Musou Knuckle               ";
                case "FB-10-F1-1B":
                    return "High King Fire Robe                     ";
                case "FC-01-96-8A":
                    return "Pika Pika Stick                         ";
                case "FC-67-FF-75":
                    return "Mitchy Meat Bag                         ";
                case "FC-AF-F6-7E":
                    return "Fan of Wind                             ";
                case "FC-C4-85-44":
                    return "Silver Shield                           ";
                case "FD-8C-2D-A8":
                    return "Special Loincloth                       ";
                case "FE-A3-19-91":
                    return "B Kamunagi                              ";
                case "FE-F8-2B-35":
                    return "Rocket Hammer                           ";
                case "FE-FA-1B-47":
                    return "Dimmy Ninjitsu                          ";
                case "FF-31-28-9A":
                    return "Suzaku Gauntlets                        ";
                case "FF-56-5B-A6":
                    return "Wonders Wand                            ";
                default:
                    return "Unknown";
            }
        }

        public int pickEquipmentIndex(string bytes)
        {
            switch (bytes)
            {
                case "01-67-14-68":
                    return 11;
                case "02-31-C3-87":
                    return 81;
                case "02-60-93-C6":
                    return 255;
                case "02-F5-CA-8A":
                    return 320;
                case "03-5B-BA-19":
                    return 288;
                case "05-A2-78-0C":
                    return 7;
                case "06-57-D5-D2":
                    return 30;
                case "06-F4-AF-E3":
                    return 74;
                case "07-54-EF-04":
                    return 115;
                case "08-4D-0D-CC":
                    return 258;
                case "08-D0-91-AB":
                    return 34;
                case "08-DA-F3-4E":
                    return 217;
                case "09-D3-AB-7D":
                    return 237;
                case "0B-25-3C-75":
                    return 20;
                case "0B-62-F3-A1":
                    return 80;
                case "0C-1B-CD-BB":
                    return 56;
                case "0D-BB-8D-5C":
                    return 66;
                case "0E-27-63-CA":
                    return 338;
                case "0E-7E-76-2B":
                    return 76;
                case "10-0C-AC-83":
                    return 161;
                case "10-46-B3-C6":
                    return 367;
                case "10-A2-CC-77":
                    return 213;
                case "10-FC-B6-81":
                    return 102;
                case "11-3C-6A-C6":
                    return 193;
                case "11-D2-AF-82":
                    return 215;
                case "11-D8-15-77":
                    return 374;
                case "12-AE-23-98":
                    return 145;
                case "13-E0-E9-97":
                    return 48;
                case "14-39-DA-E5":
                    return 106;
                case "14-A6-76-F0":
                    return 178;
                case "14-B7-5B-11":
                    return 269;
                case "15-19-2B-82":
                    return 330;
                case "15-7E-58-BE":
                    return 32;
                case "16-28-8F-51":
                    return 230;
                case "16-4E-E6-AE":
                    return 406;
                case "16-8B-F5-60":
                    return 19;
                case "17-06-4E-42":
                    return 283;
                case "17-25-85-F3":
                    return 52;
                case "17-2B-B5-87":
                    return 38;
                case "17-34-3F-AE":
                    return 149;
                case "17-C3-5D-8C":
                    return 136;
                case "1B-11-F4-CC":
                    return 211;
                case "1B-E6-96-EE":
                    return 181;
                case "1B-F9-1C-C7":
                    return 23;
                case "1C-87-07-15":
                    return 133;
                case "1D-0A-BC-37":
                    return 379;
                case "1D-19-A1-A4":
                    return 150;
                case "1D-67-AD-EE":
                    return 63;
                case "1D-9B-B7-EA":
                    return 248;
                case "1E-7C-8A-D8":
                    return 202;
                case "1E-8B-E8-FA":
                    return 174;
                case "1F-82-B0-C9":
                    return 262;
                case "20-6C-8C-43":
                    return 280;
                case "20-A9-9F-8D":
                    return 155;
                case "20-CF-F6-72":
                    return 354;
                case "21-CC-CC-A4":
                    return 301;
                case "22-52-12-40":
                    return 166;
                case "22-9A-1B-4B":
                    return 343;
                case "23-28-CB-40":
                    return 375;
                case "23-53-18-E4":
                    return 90;
                case "23-99-21-9D":
                    return 309;
                case "23-CC-B4-F1":
                    return 179;
                case "25-07-90-B4":
                    return 339;
                case "25-33-83-BB":
                    return 126;
                case "25-C4-E1-99":
                    return 146;
                case "26-36-34-67":
                    return 241;
                case "26-56-A8-C7":
                    return 191;
                case "26-B8-6D-83":
                    return 214;
                case "26-EB-D5-A0":
                    return 413;
                case "27-35-0E-B1":
                    return 37;
                case "27-66-6E-82":
                    return 162;
                case "27-C8-0E-76":
                    return 195;
                case "28-B1-70-1E":
                    return 113;
                case "29-16-48-D9":
                    return 203;
                case "29-29-23-F0":
                    return 349;
                case "29-B4-BF-97":
                    return 311;
                case "29-D5-39-F4":
                    return 323;
                case "29-E1-2A-FB":
                    return 177;
                case "2A-00-28-C2":
                    return 87;
                case "2A-41-12-49":
                    return 285;
                case "2A-60-7E-36":
                    return 380;
                case "2B-B4-C7-C2":
                    return 223;
                case "2C-1B-AA-6D":
                    return 244;
                case "2C-8C-54-EF":
                    return 180;
                case "2C-BE-25-03":
                    return 291;
                case "2D-10-55-90":
                    return 327;
                case "2D-85-0C-DC":
                    return 253;
                case "2E-77-D9-22":
                    return 139;
                case "2E-80-BB-00":
                    return 121;
                case "2E-82-8B-72":
                    return 4;
                case "2E-C5-44-A6":
                    return 95;
                case "2F-0D-00-22":
                    return 392;
                case "2F-1C-AD-48":
                    return 98;
                case "2F-2A-0E-BE":
                    return 341;
                case "2F-2C-FB-E1":
                    return 61;
                case "30-67-2F-D3":
                    return 264;
                case "30-F0-D1-51":
                    return 170;
                case "31-10-EC-16":
                    return 296;
                case "33-45-01-2F":
                    return 294;
                case "37-4C-A1-6D":
                    return 347;
                case "38-C0-1A-E9":
                    return 45;
                case "39-68-9F-25":
                    return 295;
                case "39-6E-6A-7A":
                    return 16;
                case "3A-FC-B4-98":
                    return 333;
                case "3B-52-C4-0B":
                    return 276;
                case "3C-62-05-B1":
                    return 308;
                case "3C-C1-7F-80":
                    return 342;
                case "3F-97-A8-6F":
                    return 272;
                case "40-56-0F-71":
                    return 10;
                case "42-4B-CD-7F":
                    return 368;
                case "42-6A-A1-00":
                    return 287;
                case "43-51-88-DF":
                    return 256;
                case "43-C4-D1-93":
                    return 321;
                case "44-36-EC-7B":
                    return 357;
                case "44-43-98-17":
                    return 396;
                case "45-39-41-17":
                    return 154;
                case "46-65-F4-1D":
                    return 116;
                case "46-AB-08-49":
                    return 207;
                case "46-B8-15-DA":
                    return 360;
                case "47-01-BD-F7":
                    return 317;
                case "47-35-AE-F8":
                    return 173;
                case "47-C2-CC-DA":
                    return 201;
                case "48-4F-FA-21":
                    return 69;
                case "48-91-31-57":
                    return 366;
                case "48-E2-B0-64":
                    return 238;
                case "49-7C-16-D5":
                    return 259;
                case "49-EB-E8-57":
                    return 186;
                case "4A-8E-C3-2B":
                    return 141;
                case "4B-D3-14-B7":
                    return 335;
                case "4C-86-96-43":
                    return 168;
                case "4D-0B-2D-61":
                    return 359;
                case "4D-2A-D6-A2":
                    return 57;
                case "4D-4D-A5-9E":
                    return 313;
                case "4E-1B-72-71":
                    return 355;
                case "4E-D3-7B-7A":
                    return 228;
                case "4F-07-C2-8E":
                    return 378;
                case "4F-14-DF-1D":
                    return 135;
                case "4F-18-48-A7":
                    return 305;
                case "4F-4F-6D-32":
                    return 75;
                case "4F-F0-A0-AC":
                    return 405;
                case "51-43-2C-6C":
                    return 266;
                case "51-CD-AD-98":
                    return 103;
                case "52-B6-81-B2":
                    return 316;
                case "54-28-30-9B":
                    return 329;
                case "55-08-C1-FC":
                    return 107;
                case "55-86-40-08":
                    return 270;
                case "56-14-9E-EA":
                    return 51;
                case "5D-91-85-2C":
                    return 292;
                case "5E-0D-6B-BA":
                    return 26;
                case "5E-B3-AB-D0":
                    return 261;
                case "5F-BA-F3-E3":
                    return 175;
                case "61-5D-97-5A":
                    return 281;
                case "62-62-03-FD":
                    return 92;
                case "62-CF-49-B8":
                    return 54;
                case "63-6F-09-5F":
                    return 70;
                case "64-38-BB-D9":
                    return 304;
                case "66-04-15-A8":
                    return 36;
                case "66-A7-6F-99":
                    return 84;
                case "66-F9-15-6F":
                    return 219;
                case "67-07-2F-7E":
                    return 240;
                case "67-67-B3-DE":
                    return 192;
                case "68-83-51-D1":
                    return 28;
                case "69-80-6B-07":
                    return 112;
                case "6B-31-33-DB":
                    return 89;
                case "6B-76-FC-0F":
                    return 1;
                case "6C-21-4E-89":
                    return 326;
                case "6C-B4-17-C5":
                    return 252;
                case "6D-2A-B1-74":
                    return 243;
                case "6D-BD-4F-F6":
                    return 218;
                case "6E-1D-E0-F8":
                    return 60;
                case "6E-2D-B6-51":
                    return 100;
                case "6F-B3-90-6B":
                    return 5;
                case "6F-F4-5F-BF":
                    return 97;
                case "70-5F-6C-F9":
                    return 172;
                case "70-A8-0E-DB":
                    return 200;
                case "70-AF-76-FB":
                    return 78;
                case "71-56-34-CA":
                    return 265;
                case "71-C1-CA-48":
                    return 169;
                case "71-D2-D7-DB":
                    return 361;
                case "72-0A-81-C0":
                    return 224;
                case "72-53-83-16":
                    return 134;
                case "72-59-39-E3":
                    return 408;
                case "73-29-5A-16":
                    return 386;
                case "73-4F-33-E9":
                    return 245;
                case "73-D2-AF-8E":
                    return 41;
                case "74-E4-9B-6B":
                    return 299;
                case "76-44-24-02":
                    return 388;
                case "76-7B-4F-2B":
                    return 108;
                case "76-7D-BA-74":
                    return 348;
                case "78-5F-71-63":
                    return 15;
                case "78-6D-00-8F":
                    return 401;
                case "78-9A-62-AD":
                    return 385;
                case "78-FC-0B-52":
                    return 233;
                case "79-04-C4-1C":
                    return 387;
                case "79-E0-BB-AD":
                    return 148;
                case "79-F1-01-F0":
                    return 46;
                case "79-FF-31-84":
                    return 40;
                case "7A-63-DF-12":
                    return 275;
                case "7B-1B-36-60":
                    return 196;
                case "7B-AA-DC-BD":
                    return 31;
                case "7B-CD-AF-81":
                    return 334;
                case "7B-EC-54-42":
                    return 167;
                case "7D-34-6D-94":
                    return 42;
                case "7D-E4-01-2A":
                    return 140;
                case "7E-81-2A-56":
                    return 187;
                case "7F-06-2B-81":
                    return 216;
                case "7F-FB-F3-56":
                    return 369;
                case "80-53-F5-B5":
                    return 83;
                case "80-97-FC-B8":
                    return 322;
                case "81-39-8C-2B":
                    return 286;
                case "84-52-90-DC":
                    return 318;
                case "84-96-99-D1":
                    return 79;
                case "87-65-C1-50":
                    return 358;
                case "87-C0-4E-3E":
                    return 9;
                case "88-80-39-9C":
                    return 336;
                case "89-47-0A-47":
                    return 22;
                case "8C-4B-65-8C":
                    return 306;
                case "8D-48-5F-5A":
                    return 356;
                case "8D-EB-25-6B":
                    return 277;
                case "8E-1E-88-B5":
                    return 314;
                case "8F-D9-BB-6E":
                    return 68;
                case "90-2E-9F-44":
                    return 165;
                case "90-D9-FD-66":
                    return 198;
                case "91-82-DF-A5":
                    return 50;
                case "91-E5-AC-99":
                    return 315;
                case "92-10-01-47":
                    return 267;
                case "92-22-70-AB":
                    return 130;
                case "92-9E-80-B3":
                    return 104;
                case "92-B3-7B-76":
                    return 353;
                case "93-58-A9-AB":
                    return 404;
                case "93-AF-CB-89":
                    return 393;
                case "94-4A-B9-63":
                    return 232;
                case "94-CE-5A-72":
                    return 363;
                case "96-C2-B5-9D":
                    return 376;
                case "96-D5-6D-23":
                    return 271;
                case "97-4F-0E-BF":
                    return 127;
                case "97-7B-1D-B0":
                    return 328;
                case "97-AB-71-0E":
                    return 391;
                case "97-B8-6C-9D":
                    return 144;
                case "99-66-2A-32":
                    return 138;
                case "99-91-48-10":
                    return 153;
                case "99-9B-2A-F5":
                    return 25;
                case "9A-10-1C-DD":
                    return 362;
                case "9A-F4-63-6C":
                    return 199;
                case "9B-8E-BA-6C":
                    return 371;
                case "9C-E9-DE-C8":
                    return 176;
                case "9C-FC-36-04":
                    return 125;
                case "9D-E0-86-FB":
                    return 260;
                case "9E-A9-DB-3D":
                    return 119;
                case "9E-C2-A8-07":
                    return 293;
                case "9E-F0-D9-EB":
                    return 208;
                case "9F-05-9B-DC":
                    return 65;
                case "9F-6E-7F-5A":
                    return 188;
                case "9F-F9-81-D8":
                    return 250;
                case "A0-3C-24-74":
                    return 71;
                case "A0-D2-AE-9C":
                    return 143;
                case "A0-E8-C7-38":
                    return 99;
                case "A0-F8-2D-79":
                    return 345;
                case "A1-31-2E-D6":
                    return 94;
                case "A1-5F-15-BE":
                    return 397;
                case "A1-9C-64-93":
                    return 53;
                case "A2-29-23-51":
                    return 210;
                case "A2-DE-41-73":
                    return 212;
                case "A3-AE-FA-96":
                    return 303;
                case "A3-FD-9A-A5":
                    return 410;
                case "A4-32-6B-AA":
                    return 382;
                case "A4-54-02-55":
                    return 239;
                case "A4-8F-16-CD":
                    return 225;
                case "A5-57-38-83":
                    return 35;
                case "A5-BF-D0-88":
                    return 137;
                case "A5-F4-42-B2":
                    return 86;
                case "A7-44-5D-45":
                    return 164;
                case "A7-B3-3F-67":
                    return 197;
                case "A8-04-BD-5B":
                    return 190;
                case "A8-25-D1-24":
                    return 2;
                case "A8-86-AB-15":
                    return 118;
                case "A9-D0-04-AF":
                    return 414;
                case "AA-D3-46-2C":
                    return 111;
                case "AB-4B-15-C2":
                    return 351;
                case "AB-96-F4-05":
                    return 124;
                case "AB-B7-0F-C6":
                    return 325;
                case "AB-D0-7C-FA":
                    return 27;
                case "AC-00-07-DC":
                    return 204;
                case "AC-A7-72-94":
                    return 91;
                case "AC-E0-BD-40":
                    return 6;
                case "AC-E4-78-6D":
                    return 372;
                case "AD-4E-CD-D3":
                    return 59;
                case "AE-79-9C-5F":
                    return 242;
                case "AF-76-31-33":
                    return 403;
                case "AF-81-53-11":
                    return 395;
                case "AF-E7-3A-EE":
                    return 251;
                case "B0-1C-1E-C2":
                    return 246;
                case "B3-19-A9-1E":
                    return 147;
                case "B3-72-DA-24":
                    return 298;
                case "B5-28-62-00":
                    return 109;
                case "B6-74-D7-0A":
                    return 151;
                case "B7-DE-F5-08":
                    return 12;
                case "B9-D0-48-A5":
                    return 400;
                case "BA-81-E7-6A":
                    return 278;
                case "BA-A2-2C-DB":
                    return 47;
                case "BB-0C-5C-48":
                    return 14;
                case "BB-38-D8-FB":
                    return 184;
                case "BB-AF-26-79":
                    return 234;
                case "BD-F5-9E-5D":
                    return 274;
                case "BE-67-40-BF":
                    return 43;
                case "C0-2F-0E-12":
                    return 152;
                case "C0-76-0C-C4":
                    return 226;
                case "C0-D8-6C-30":
                    return 229;
                case "C1-33-BE-ED":
                    return 254;
                case "C1-55-D7-12":
                    return 394;
                case "C1-62-EE-AC":
                    return 82;
                case "C1-A2-B5-30":
                    return 402;
                case "C1-E8-AA-75":
                    return 221;
                case "C2-23-E1-FD":
                    return 171;
                case "C4-07-C2-2F":
                    return 114;
                case "C4-38-A9-06":
                    return 390;
                case "C4-CD-FB-56":
                    return 289;
                case "C4-DC-D6-B7":
                    return 129;
                case "C5-04-F8-F9":
                    return 29;
                case "C5-42-70-06":
                    return 122;
                case "C5-63-8B-C5":
                    return 319;
                case "C5-65-7E-9A":
                    return 58;
                case "C5-A6-0F-B7":
                    return 407;
                case "C5-A7-82-C8":
                    return 77;
                case "C6-52-2F-16":
                    return 117;
                case "C6-C3-24-CB":
                    return 373;
                case "C6-F1-55-27":
                    return 8;
                case "C7-17-9D-3F":
                    return 120;
                case "C7-4E-9F-E9":
                    return 209;
                case "C8-44-60-B2":
                    return 411;
                case "C8-76-11-5E":
                    return 21;
                case "C8-F9-1D-D5":
                    return 206;
                case "C9-B1-22-85":
                    return 337;
                case "CA-80-86-56":
                    return 236;
                case "CA-E6-EF-A9":
                    return 383;
                case "CB-1E-20-E7":
                    return 257;
                case "CB-83-BC-80":
                    return 33;
                case "CB-9C-36-A9":
                    return 131;
                case "CC-0A-C5-70":
                    return 194;
                case "CC-19-D8-E3":
                    return 365;
                case "CD-29-1E-A6":
                    return 412;
                case "CD-63-01-E3":
                    return 185;
                case "CE-06-2A-9F":
                    return 159;
                case "CE-E8-A0-77":
                    return 67;
                case "CE-F1-48-BD":
                    return 158;
                case "CF-48-E0-90":
                    return 55;
                case "CF-7C-F3-9F":
                    return 377;
                case "D0-92-3F-7F":
                    return 370;
                case "D0-B3-C4-BC":
                    return 49;
                case "D1-13-84-5B":
                    return 73;
                case "D2-8F-6A-CD":
                    return 331;
                case "D3-21-1A-5E":
                    return 268;
                case "D3-AF-9B-AA":
                    return 105;
                case "D4-55-63-69":
                    return 282;
                case "D4-78-98-AC":
                    return 39;
                case "D5-7B-A2-7A":
                    return 231;
                case "D5-D8-D8-4B":
                    return 18;
                case "D8-AA-31-EC":
                    return 24;
                case "D9-0A-71-0B":
                    return 13;
                case "DC-BE-C4-5C":
                    return 142;
                case "DE-34-80-C5":
                    return 64;
                case "DE-5F-64-43":
                    return 189;
                case "DE-C8-9A-C1":
                    return 249;
                case "E0-00-35-CF":
                    return 96;
                case "E0-6E-0E-A7":
                    return 398;
                case "E0-CA-0C-B6":
                    return 310;
                case "E1-0D-3F-6D":
                    return 72;
                case "E1-C9-36-60":
                    return 344;
                case "E1-D9-DC-21":
                    return 101;
                case "E2-9F-E1-8F":
                    return 302;
                case "E3-3F-A1-68":
                    return 279;
                case "E4-C5-59-AB":
                    return 88;
                case "E6-54-BD-9F":
                    return 340;
                case "E8-BA-BA-AE":
                    return 62;
                case "E9-12-3F-62":
                    return 284;
                case "E9-14-CA-3D":
                    return 3;
                case "E9-53-05-E9":
                    return 85;
                case "EA-7A-0E-DB":
                    return 350;
                case "EA-86-14-DF":
                    return 324;
                case "EA-E7-92-BC":
                    return 312;
                case "ED-31-1C-C5":
                    return 205;
                case "ED-96-69-8D":
                    return 93;
                case "EF-ED-08-28":
                    return 290;
                case "F0-24-5D-E8":
                    return 182;
                case "F1-2D-05-DB":
                    return 247;
                case "F1-5E-84-E8":
                    return 364;
                case "F2-28-B2-07":
                    return 123;
                case "F2-43-C1-3D":
                    return 297;
                case "F2-DF-D0-25":
                    return 157;
                case "F3-34-02-F8":
                    return 263;
                case "F3-52-6B-07":
                    return 389;
                case "F3-FC-0B-F3":
                    return 415;
                case "F4-19-79-19":
                    return 110;
                case "F4-1F-8C-46":
                    return 346;
                case "F6-82-68-74":
                    return 222;
                case "F6-C8-77-31":
                    return 381;
                case "F7-45-CC-13":
                    return 132;
                case "F8-E1-53-BC":
                    return 399;
                case "F9-6C-E8-9E":
                    return 160;
                case "F9-9B-8A-BC":
                    return 128;
                case "F9-AF-99-B3":
                    return 332;
                case "FA-09-C3-E2":
                    return 183;
                case "FA-43-DC-A7":
                    return 409;
                case "FA-9E-3D-60":
                    return 235;
                case "FB-10-F1-1B":
                    return 300;
                case "FC-01-96-8A":
                    return 156;
                case "FC-67-FF-75":
                    return 352;
                case "FC-AF-F6-7E":
                    return 220;
                case "FC-C4-85-44":
                    return 273;
                case "FD-8C-2D-A8":
                    return 384;
                case "FE-A3-19-91":
                    return 227;
                case "FE-F8-2B-35":
                    return 17;
                case "FE-FA-1B-47":
                    return 163;
                case "FF-31-28-9A":
                    return 307;
                case "FF-56-5B-A6":
                    return 44;
                default:
                    return 0;
            }
        }
    }
}
