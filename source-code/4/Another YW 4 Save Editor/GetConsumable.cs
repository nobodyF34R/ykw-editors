using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_YW_4_Save_Editor
{
    internal class GetConsumable
    {
        public string pickConsumableName(string bytes)
        {
            switch (bytes)
            {
                case "00-00-00-00":
                    return "Empty";
                case "02-7D-A5-F9":
                    return "Royal Gelato                         ";
                case "03-56-DF-E0":
                    return "Sproink Bath Tub                     ";
                case "03-7E-D8-B1":
                    return "Illuminoct Light                     ";
                case "06-70-C3-A4":
                    return "Oni Egg M                            ";
                case "08-EF-21-2A":
                    return "Salad Chicken                        ";
                case "09-0C-51-0A":
                    return "Everything Ramen                     ";
                case "09-CA-DB-D6":
                    return "Yo-lixir Fusilaren                   ";
                case "0A-F9-FC-D4":
                    return "Giant Cracker                        ";
                case "0B-DC-06-28":
                    return "Tongman Rope                         ";
                case "0C-2A-4D-4E":
                    return "Chateaubriand                        ";
                case "0D-0F-B7-B2":
                    return "Yo-lixir Yamihaler                   ";
                case "0D-C9-3D-6E":
                    return "Pork Ramen                           ";
                case "0E-32-10-55":
                    return "Sakura Softcream                     ";
                case "0E-3B-18-FA":
                    return "Red Bean Jelly                       ";
                case "0E-FA-1A-6C":
                    return "Yo-Gourt                             ";
                case "0F-19-6A-4C":
                    return "Ogralus Horn                         ";
                case "0F-DF-E0-90":
                    return "Fishy Noodles                        ";
                case "10-42-BD-11":
                    return "Insomni Eye Drops                    ";
                case "16-4A-E8-79":
                    return "Lord Ananta Perfume                  ";
                case "16-B4-D5-91":
                    return "Soy Milk Kinako Donut                ";
                case "17-87-99-0F":
                    return "High-End Sushi                       ";
                case "18-33-01-98":
                    return "Meat Noodles                         ";
                case "18-FB-0B-A1":
                    return "Acala Devil Keystone                 ";
                case "19-16-FB-64":
                    return "Black Doll                           ";
                case "19-22-E2-4F":
                    return "God King Keystone (S)                ";
                case "1A-25-DC-66":
                    return "Fruit Milk                           ";
                case "1B-C8-2C-A3":
                    return "Fin Sushi                            ";
                case "1B-F1-85-AA":
                    return "Burly Wristband                      ";
                case "1C-3E-67-C5":
                    return "Suzaku Devil Keystone                ";
                case "1D-D3-97-00":
                    return "Bronze Doll                          ";
                case "1E-26-3A-DE":
                    return "Nasty Medicine                       ";
                case "1E-9C-FB-BE":
                    return "Demuncher Bead                       ";
                case "1F-03-C0-22":
                    return "Grilled Ayu                          ";
                case "20-3A-EF-FA":
                    return "Squid Tempura                        ";
                case "24-FF-83-9E":
                    return "Eggplant Tempura                     ";
                case "26-44-34-C4":
                    return "Chankonabe                           ";
                case "26-FF-E8-02":
                    return "Five-star Keystone                   ";
                case "28-6E-8A-69":
                    return "Aristocrat Tea                       ";
                case "29-83-7A-AC":
                    return "Giant Strawberry                     ";
                case "29-8D-FA-49":
                    return "Lamb Curry                           ";
                case "29-F6-39-BF":
                    return "Noko Shedded Skin                    ";
                case "2A-78-57-97":
                    return "Lettuce Taro                         ";
                case "2A-B0-5D-AE":
                    return "Sealed Tsukumono Keystone            ";
                case "2B-5D-AD-6B":
                    return "Large Exporb                         ";
                case "2B-9B-27-B7":
                    return "Shrimp Rice Ball                     ";
                case "2C-9B-47-AB":
                    return "Blazion Flame                        ";
                case "2C-AB-E6-0D":
                    return "Soul Tea                             ";
                case "2D-05-E1-1A":
                    return "Blizzaria Hair Fastener              ";
                case "2D-46-16-C8":
                    return "Grapes                               ";
                case "2D-48-96-2D":
                    return "Megaton Cutlet Curry                 ";
                case "2E-BD-3B-F3":
                    return "Spicy Chips                          ";
                case "2F-5E-4B-D3":
                    return "Plum Rice Ball                       ";
                case "31-27-10-21":
                    return "Crank-a-coin                         ";
                case "37-D6-0E-F2":
                    return "Chicken Sukiyaki                     ";
                case "38-73-A8-4D":
                    return "Wobblewok Feather Kettle             ";
                case "38-74-20-07":
                    return "Rusted Coin                          ";
                case "38-B2-AA-DB":
                    return "Baguette                             ";
                case "39-51-DA-FB":
                    return "Soul Soughnut                        ";
                case "3A-A4-77-25":
                    return "Carrot                               ";
                case "3B-47-07-05":
                    return "Nom Burger                           ";
                case "3C-77-C6-BF":
                    return "Custard Bread                        ";
                case "3C-B6-C4-29":
                    return "Demuncher Teeth                      ";
                case "3D-94-B6-9F":
                    return "Siberia                              ";
                case "3E-61-1B-41":
                    return "Ripe Tomatoes                        ";
                case "3F-82-6B-61":
                    return "Hamburger                            ";
                case "42-67-C4-F9":
                    return "Orcanos Super Horn                   ";
                case "47-41-D8-BD":
                    return "Oni Egg S                            ";
                case "48-3D-4A-13":
                    return "Noodle King                          ";
                case "49-DE-3A-33":
                    return "Ground Meat Cutlet                   ";
                case "4A-2B-97-ED":
                    return "Soba Saemon                          ";
                case "4B-07-76-DE":
                    return "Guribobo Fang                        ";
                case "4B-0E-6D-11":
                    return "Super Orb                            ";
                case "4B-C6-67-28":
                    return "Gorigori                             ";
                case "4B-C8-E7-CD":
                    return "Opulent Caramel                      ";
                case "4B-F0-14-FC":
                    return "The Inevitable Belt                  ";
                case "4C-3E-AC-AB":
                    return "Yo-lixir Numericole                  ";
                case "4C-66-E7-25":
                    return "Smogmella Smoke                      ";
                case "4C-F8-26-77":
                    return "Instant Ramen                        ";
                case "4D-1B-56-57":
                    return "Sirloin Steak                        ";
                case "4E-28-71-55":
                    return "Gargaros Super Horn                  ";
                case "4E-6A-08-CA":
                    return "Zazel Brush                          ";
                case "4E-EE-FB-89":
                    return "Duck Noodles                         ";
                case "4F-03-0B-4C":
                    return "King of Monaka                       ";
                case "4F-0A-03-E3":
                    return "Luxury Castella                      ";
                case "4F-0D-8B-A9":
                    return "Humdrum Gum                          ";
                case "53-40-A2-EC":
                    return "Cosmic Doughnut                      ";
                case "57-6F-6B-F8":
                    return "Sushi Set                            ";
                case "57-85-CE-88":
                    return "Choco. Doughnut                      ";
                case "59-02-1A-81":
                    return "Maruten Noodles                      ";
                case "59-CA-10-B8":
                    return "Nightshade Enma Keystone             ";
                case "5A-F7-B7-5F":
                    return "Dried Mackerel                       ";
                case "5A-F9-37-BA":
                    return "Salmon Roe Sushi                     ";
                case "5B-14-C7-7F":
                    return "Amazing Milk                         ";
                case "5B-D2-4D-A3":
                    return "Miracle Medicine                     ";
                case "5C-E2-8C-19":
                    return "Silver Doll                          ";
                case "5D-0F-7C-DC":
                    return "Xuanwu Devil Keystone                ";
                case "5E-32-DB-3B":
                    return "Kind Salmon                          ";
                case "5E-3C-5B-DE":
                    return "Cucumber Roll                        ";
                case "5F-D1-AB-1B":
                    return "Milk                                 ";
                case "61-0B-F4-E3":
                    return "Fish Tempura                         ";
                case "63-B0-43-B9":
                    return "Chocodrug                            ";
                case "63-C3-95-46":
                    return "Snow-Pea Snack                       ";
                case "67-CE-F3-1B":
                    return "One-chance Keystone                  ";
                case "68-B2-61-B5":
                    return "Melon Queen                          ";
                case "68-BC-E1-50":
                    return "Green Curry                          ";
                case "69-5F-91-70":
                    return "Big Boss Coffee                      ";
                case "6A-6C-B6-72":
                    return "Mega Exporb                          ";
                case "6A-AA-3C-AE":
                    return "Roe Rice Ball                        ";
                case "6B-81-46-B7":
                    return "Sealed Uwanosora Keystone            ";
                case "6C-77-0D-D1":
                    return "Mandarin Orange                      ";
                case "6D-44-41-4F":
                    return "Deluxe Tempura                       ";
                case "6D-9A-FD-14":
                    return "Ramune                               ";
                case "6E-A9-DA-16":
                    return "Mini Exporb                          ";
                case "6F-44-2A-D3":
                    return "Sealed Goriki Keystone               ";
                case "6F-8C-20-EA":
                    return "Tasty Nibbles                        ";
                case "72-B3-F2-70":
                    return "Hinizall Proposal                    ";
                case "75-0D-06-F8":
                    return "Hinozall Senior Servants             ";
                case "76-E7-15-EB":
                    return "Beef Sukiyaki                        ";
                case "78-60-C1-E2":
                    return "Big Imagawayaki                      ";
                case "78-A1-C3-74":
                    return "Oni Egg L                            ";
                case "79-00-CA-CB":
                    return "Fudo Myoo Hair Decoration            ";
                case "79-42-B3-54":
                    return "McKraken Special Smear               ";
                case "79-45-3B-1E":
                    return "Special Coin                         ";
                case "79-83-B1-C2":
                    return "Blehgel                              ";
                case "7A-76-1C-1C":
                    return "Double Burger                        ";
                case "7A-92-83-95":
                    return "Robonyan Oil                         ";
                case "7C-A5-AD-86":
                    return "Shortcake                            ";
                case "7D-46-DD-A6":
                    return "Anko                                 ";
                case "7D-87-DF-30":
                    return "Sproink Gilded Tub                   ";
                case "7E-75-FA-A4":
                    return "Getaway Plush                        ";
                case "7F-50-00-58":
                    return "Bamboo Shoot                         ";
                case "82-9B-4F-11":
                    return "Darkyubi Comb                        ";
                case "88-5D-40-3A":
                    return "Super Orb B                          ";
                case "88-95-4A-03":
                    return "Ice Cream                            ";
                case "88-9B-CA-E6":
                    return "Fruit Drops                          ";
                case "89-78-BA-C6":
                    return "Soba Noodles                         ";
                case "89-B9-B8-50":
                    return "Y Coin                               ";
                case "89-BE-30-1A":
                    return "Gargaros Horn                        ";
                case "8A-8D-17-18":
                    return "Chicken Thigh                        ";
                case "8B-6E-67-38":
                    return "Ajitsuke Tamago Ramen                ";
                case "8B-A8-ED-E4":
                    return "Yo-lixir Dimininar                   ";
                case "8C-50-26-67":
                    return "Black Everest                        ";
                case "8C-59-2E-C8":
                    return "Strawberry Princess Parfait          ";
                case "8C-5E-A6-82":
                    return "Inazuma Black                        ";
                case "8D-7B-5C-7E":
                    return "Orcanos Horn                         ";
                case "8E-48-7B-7C":
                    return "Marbled Beef                         ";
                case "8F-AB-0B-5C":
                    return "Ramen Cup                            ";
                case "90-13-8F-C7":
                    return "Angel Ring                           ";
                case "90-39-8C-00":
                    return "Baku Pillow                          ";
                case "94-D6-E3-A3":
                    return "Doughnut                             ";
                case "96-D6-88-3F":
                    return "God King Keystone                    ";
                case "97-0F-61-D1":
                    return "Ming Dynasty Devil Keystone          ";
                case "97-58-1D-FB":
                    return "Hareonna Cloud                       ";
                case "99-A4-9A-74":
                    return "Yellowtail                           ";
                case "99-AA-1A-91":
                    return "Fatty Tuna Sushi                     ";
                case "9A-51-37-AA":
                    return "Yukisuke Noodles                     ";
                case "9A-99-3D-93":
                    return "White Tiger Devil Keystone           ";
                case "9B-74-CD-56":
                    return "Golden Doll                          ";
                case "9B-8A-B4-BB":
                    return "GHz Orb                              ";
                case "9B-D3-B6-6D":
                    return "Whisper Diary                        ";
                case "9C-44-0C-EC":
                    return "Mighty Medicine                      ";
                case "9C-82-86-30":
                    return "Coffee Milk                          ";
                case "9D-2C-81-27":
                    return "Zashiki-warashi Mirror               ";
                case "9D-61-F6-10":
                    return "Choice Tuna                          ";
                case "9D-6F-76-F5":
                    return "Shrimp Sushi                         ";
                case "9E-94-5B-CE":
                    return "Tempura Noodles                      ";
                case "A2-58-D9-C8":
                    return "Jumbo Shri.Temp                      ";
                case "A4-26-02-F6":
                    return "Yoki Drop                            ";
                case "A5-5F-A1-EE":
                    return "Jarboe Ore                           ";
                case "A6-43-09-F7":
                    return "VoltXtreme                           ";
                case "A6-9D-B5-AC":
                    return "Chicken Tempura                      ";
                case "A6-CD-E8-B0":
                    return "Reunight Flag                        ";
                case "A8-1A-61-A5":
                    return "Potato Chips                         ";
                case "A8-D2-6B-9C":
                    return "Sealed Omamori Keystone              ";
                case "A9-3F-9B-59":
                    return "Holy Exporb                          ";
                case "AA-0C-BC-5B":
                    return "Oshiruko Soup                        ";
                case "AA-E8-23-D2":
                    return "Mirapo Fragments                     ";
                case "AB-E1-4C-9E":
                    return "Apple                                ";
                case "AC-17-07-F8":
                    return "Sealed Onnen Keystone                ";
                case "AC-DF-0D-C1":
                    return "Melty Pizza Chips                    ";
                case "AD-3C-7D-E1":
                    return "Burger Rice Ball                     ";
                case "AD-FA-F7-3D":
                    return "Small Exporb                         ";
                case "AE-1B-FB-77":
                    return "Dameboy Gloves                       ";
                case "AF-2A-A0-1F":
                    return "Seafood Curry                        ";
                case "B1-71-54-A4":
                    return "Double Sukiyaki                      ";
                case "B3-B9-35-01":
                    return "Sakura Mochi On Leaf                 ";
                case "B6-59-A3-99":
                    return "Oni Coin Super                       ";
                case "B6-9F-29-45":
                    return "Drill Croissant                      ";
                case "B8-C6-41-17":
                    return "Avocado                              ";
                case "B9-25-31-37":
                    return "MogMog Giant                         ";
                case "BA-11-9E-7F":
                    return "Hinozall Servants                    ";
                case "BA-16-16-35":
                    return "Five-star Coin                       ";
                case "BA-D0-9C-E9":
                    return "Curry Bread                          ";
                case "BD-E0-5D-53":
                    return "Teriyaki Chicken Burger              ";
                case "BE-D4-F2-1B":
                    return "McKraken Smear                       ";
                case "BF-F6-80-AD":
                    return "Cheesecake                           ";
                case "C2-6D-F0-6F":
                    return "Whisper Hair Gel                     ";
                case "C5-0C-61-94":
                    return "Ushioni Eye                          ";
                case "C5-A2-01-60":
                    return "Junior Rare Cards                    ";
                case "C6-10-C9-8D":
                    return "Saburo Hell Ramen                    ";
                case "C8-49-A1-DF":
                    return "Noodles in Broth                     ";
                case "C8-88-A3-49":
                    return "Oni Coin Ultra                       ";
                case "C8-8F-2B-03":
                    return "Tongman Super Rope                   ";
                case "C9-6C-5B-23":
                    return "Ultra Orb                            ";
                case "C9-87-CA-02":
                    return "Shmoopie Heart                       ";
                case "C9-A4-51-1A":
                    return "Macha Softcream                      ";
                case "C9-AA-D1-FF":
                    return "Candy Apple                          ";
                case "CA-5F-7C-21":
                    return "Miso Corn Ramen                      ";
                case "CA-99-F6-FD":
                    return "Yo-lixir Nerawarer                   ";
                case "CB-7C-47-CF":
                    return "Hora Kiyoshi Griding Wheels          ";
                case "CB-8B-25-ED":
                    return "Ogg-Tog-Mog Toys                     ";
                case "CC-1D-D6-34":
                    return "Punkupine Needle                     ";
                case "CC-4A-47-67":
                    return "Ogralus Super Horn                   ";
                case "CD-61-3D-7E":
                    return "Special Sundae                       ";
                case "CD-68-35-D1":
                    return "Shirayuki Daifuku                    ";
                case "CD-6F-BD-9B":
                    return "Gooey Candy                          ";
                case "CD-A9-37-47":
                    return "Music Card                           ";
                case "CE-5C-9A-99":
                    return "Yo-lixir Shakkirin                   ";
                case "CE-E6-5B-F9":
                    return "Cuny Hair Clip                       ";
                case "CF-79-60-65":
                    return "Beef Tongue                          ";
                case "D1-22-94-DE":
                    return "Mochirin roll                        ";
                case "D6-3E-7A-C8":
                    return "Nightshade Enma Keystone (S)         ";
                case "D8-95-81-6D":
                    return "Grilled Squid                        ";
                case "D8-9B-01-88":
                    return "Sea Urchin Sushi                     ";
                case "DA-45-D6-4F":
                    return "Platinum Doll                        ";
                case "DB-A8-26-8A":
                    return "Ashura Devil Keystone                ";
                case "DC-50-ED-09":
                    return "Supreme Urchin Bowl                  ";
                case "DC-5E-6D-EC":
                    return "Egg Sushi                            ";
                case "DD-75-17-F5":
                    return "Bitter Medicine                      ";
                case "DD-B3-9D-29":
                    return "Strawberry Milk                      ";
                case "DE-80-BA-2B":
                    return "Iron Doll                            ";
                case "DF-A5-40-D7":
                    return "Curry Noodles                        ";
                case "E3-69-C2-D1":
                    return "Eel Tempura                          ";
                case "E5-17-19-EF":
                    return "Yakuzen Cookies                      ";
                case "E7-AC-AE-B5":
                    return "Pumpkin Tempura                      ";
                case "E7-FC-F3-A9":
                    return "Corptain Flag                        ";
                case "E8-C8-0A-9C":
                    return "Big Bomb Sushi                       ";
                case "E9-2B-7A-BC":
                    return "Lucky Bean                           ";
                case "E9-E3-70-85":
                    return "Rainbow Keystone                     ";
                case "EA-D0-57-87":
                    return "Pineapple                            ";
                case "EA-DE-D7-62":
                    return "Chicken Curry                        ";
                case "EB-3D-A7-42":
                    return "Doctor Rapper                        ";
                case "EC-0D-66-F8":
                    return "Salmon Rice Ball                     ";
                case "EC-CB-EC-24":
                    return "Medium Exporb                        ";
                case "ED-26-1C-E1":
                    return "Sealed Mononoke Keystone             ";
                case "ED-EE-16-D8":
                    return "Cheesy Chips                         ";
                case "EE-15-3B-E3":
                    return "Banana                               ";
                case "EE-1B-BB-06":
                    return "Keema Curry                          ";
                case "EF-F8-CB-26":
                    return "Y-Cola                               ";
                case "F0-40-4F-BD":
                    return "Spec. Marbled Suki.                  ";
                case "F2-88-2E-18":
                    return "Royal Pancakes                       ";
                case "F4-85-23-D9":
                    return "Sukiyaki Lunchbox                    ";
                case "F7-68-B8-80":
                    return "Oni Coin                             ";
                case "F8-14-2A-2E":
                    return "Extreme Star Burg.                   ";
                case "F9-F7-5A-0E":
                    return "Cucumber                             ";
                case "FA-02-F7-D0":
                    return "Spirit Doughnut                      ";
                case "FB-20-85-66":
                    return "Wobblewok Pure Gold Feather Kettle   ";
                case "FB-27-0D-2C":
                    return "One-star Coin                        ";
                case "FB-77-14-35":
                    return "Shirokuma Honey Bottle               ";
                case "FB-E1-87-F0":
                    return "Soba Sandwich                        ";
                case "FB-EF-07-15":
                    return "Chocobar                             ";
                case "FC-16-85-CE":
                    return "Thurston Sakazaki                    ";
                case "FC-D1-46-4A":
                    return "Cheeseburger                         ";
                case "FD-32-36-6A":
                    return "Matsutake                            ";
                case "FE-C7-9B-B4":
                    return "Tiramisu                             ";
                case "FF-24-EB-94":
                    return "Sandwich                             ";
                case "FF-E5-E9-02":
                    return "Demuncher Wisdom Teeth               ";
                default:
                    return "Unknown";
            }
        }

        public int pickConsumableIndex(string bytes)
        {
            switch (bytes)
            {
                case "02-7D-A5-F9":
                    return 131;
                case "03-56-DF-E0":
                    return 258;
                case "03-7E-D8-B1":
                    return 233;
                case "06-70-C3-A4":
                    return 181;
                case "08-EF-21-2A":
                    return 74;
                case "09-0C-51-0A":
                    return 48;
                case "09-CA-DB-D6":
                    return 164;
                case "0A-F9-FC-D4":
                    return 18;
                case "0B-DC-06-28":
                    return 250;
                case "0C-2A-4D-4E":
                    return 78;
                case "0D-0F-B7-B2":
                    return 160;
                case "0D-C9-3D-6E":
                    return 44;
                case "0E-32-10-55":
                    return (int)sbyte.MaxValue;
                case "0E-3B-18-FA":
                    return 103;
                case "0E-FA-1A-6C":
                    return 178;
                case "0F-19-6A-4C":
                    return 254;
                case "0F-DF-E0-90":
                    return 108;
                case "10-42-BD-11":
                    return 229;
                case "16-4A-E8-79":
                    return 224;
                case "16-B4-D5-91":
                    return 134;
                case "17-87-99-0F":
                    return 58;
                case "18-33-01-98":
                    return 112;
                case "18-FB-0B-A1":
                    return 208;
                case "19-16-FB-64":
                    return 177;
                case "19-22-E2-4F":
                    return 213;
                case "1A-25-DC-66":
                    return 25;
                case "1B-C8-2C-A3":
                    return 53;
                case "1B-F1-85-AA":
                    return 232;
                case "1C-3E-67-C5":
                    return 204;
                case "1D-D3-97-00":
                    return 173;
                case "1E-26-3A-DE":
                    return 155;
                case "1E-9C-FB-BE":
                    return 246;
                case "1F-03-C0-22":
                    return 82;
                case "20-3A-EF-FA":
                    return 142;
                case "24-FF-83-9E":
                    return 138;
                case "26-44-34-C4":
                    return 151;
                case "26-FF-E8-02":
                    return 202;
                case "28-6E-8A-69":
                    return 32;
                case "29-83-7A-AC":
                    return 64;
                case "29-8D-FA-49":
                    return 87;
                case "29-F6-39-BF":
                    return 234;
                case "2A-78-57-97":
                    return 115;
                case "2A-B0-5D-AE":
                    return 198;
                case "2B-5D-AD-6B":
                    return 169;
                case "2B-9B-27-B7":
                    return 5;
                case "2C-9B-47-AB":
                    return 231;
                case "2C-AB-E6-0D":
                    return 28;
                case "2D-05-E1-1A":
                    return 230;
                case "2D-46-16-C8":
                    return 60;
                case "2D-48-96-2D":
                    return 91;
                case "2E-BD-3B-F3":
                    return 119;
                case "2F-5E-4B-D3":
                    return 1;
                case "31-27-10-21":
                    return 186;
                case "37-D6-0E-F2":
                    return 147;
                case "38-73-A8-4D":
                    return 264;
                case "38-74-20-07":
                    return 190;
                case "38-B2-AA-DB":
                    return 12;
                case "39-51-DA-FB":
                    return 93;
                case "3A-A4-77-25":
                    return 66;
                case "3B-47-07-05":
                    return 39;
                case "3C-77-C6-BF":
                    return 8;
                case "3C-B6-C4-29":
                    return 260;
                case "3D-94-B6-9F":
                    return 97;
                case "3E-61-1B-41":
                    return 70;
                case "3F-82-6B-61":
                    return 35;
                case "42-67-C4-F9":
                    return 257;
                case "47-41-D8-BD":
                    return 180;
                case "48-3D-4A-13":
                    return 47;
                case "49-DE-3A-33":
                    return 73;
                case "4A-2B-97-ED":
                    return 105;
                case "4B-07-76-DE":
                    return 220;
                case "4B-0E-6D-11":
                    return 183;
                case "4B-C6-67-28":
                    return 124;
                case "4B-C8-E7-CD":
                    return 19;
                case "4B-F0-14-FC":
                    return 244;
                case "4C-3E-AC-AB":
                    return 161;
                case "4C-66-E7-25":
                    return 249;
                case "4C-F8-26-77":
                    return 43;
                case "4D-1B-56-57":
                    return 77;
                case "4E-28-71-55":
                    return 253;
                case "4E-6A-08-CA":
                    return 227;
                case "4E-EE-FB-89":
                    return 109;
                case "4F-03-0B-4C":
                    return 128;
                case "4F-0A-03-E3":
                    return 104;
                case "4F-0D-8B-A9":
                    return 15;
                case "53-40-A2-EC":
                    return 137;
                case "57-6F-6B-F8":
                    return 57;
                case "57-85-CE-88":
                    return 133;
                case "59-02-1A-81":
                    return 111;
                case "59-CA-10-B8":
                    return 210;
                case "5A-F7-B7-5F":
                    return 79;
                case "5A-F9-37-BA":
                    return 54;
                case "5B-14-C7-7F":
                    return 26;
                case "5B-D2-4D-A3":
                    return 158;
                case "5C-E2-8C-19":
                    return 174;
                case "5D-0F-7C-DC":
                    return 205;
                case "5E-32-DB-3B":
                    return 83;
                case "5E-3C-5B-DE":
                    return 50;
                case "5F-D1-AB-1B":
                    return 22;
                case "61-0B-F4-E3":
                    return 141;
                case "63-B0-43-B9":
                    return 154;
                case "63-C3-95-46":
                    return 122;
                case "67-CE-F3-1B":
                    return 203;
                case "68-B2-61-B5":
                    return 65;
                case "68-BC-E1-50":
                    return 88;
                case "69-5F-91-70":
                    return 33;
                case "6A-6C-B6-72":
                    return 170;
                case "6A-AA-3C-AE":
                    return 4;
                case "6B-81-46-B7":
                    return 199;
                case "6C-77-0D-D1":
                    return 61;
                case "6D-44-41-4F":
                    return 145;
                case "6D-9A-FD-14":
                    return 29;
                case "6E-A9-DA-16":
                    return 166;
                case "6F-44-2A-D3":
                    return 195;
                case "6F-8C-20-EA":
                    return 118;
                case "72-B3-F2-70":
                    return 223;
                case "75-0D-06-F8":
                    return 267;
                case "76-E7-15-EB":
                    return 148;
                case "78-60-C1-E2":
                    return 94;
                case "78-A1-C3-74":
                    return 182;
                case "79-00-CA-CB":
                    return 228;
                case "79-42-B3-54":
                    return 263;
                case "79-45-3B-1E":
                    return 189;
                case "79-83-B1-C2":
                    return 13;
                case "7A-76-1C-1C":
                    return 38;
                case "7A-92-83-95":
                    return 239;
                case "7C-A5-AD-86":
                    return 98;
                case "7D-46-DD-A6":
                    return 9;
                case "7D-87-DF-30":
                    return 259;
                case "7E-75-FA-A4":
                    return 165;
                case "7F-50-00-58":
                    return 69;
                case "82-9B-4F-11":
                    return 238;
                case "88-5D-40-3A":
                    return 185;
                case "88-95-4A-03":
                    return 125;
                case "88-9B-CA-E6":
                    return 20;
                case "89-78-BA-C6":
                    return 106;
                case "89-B9-B8-50":
                    return 194;
                case "89-BE-30-1A":
                    return 252;
                case "8A-8D-17-18":
                    return 72;
                case "8B-6E-67-38":
                    return 46;
                case "8B-A8-ED-E4":
                    return 162;
                case "8C-50-26-67":
                    return 129;
                case "8C-59-2E-C8":
                    return 101;
                case "8C-5E-A6-82":
                    return 16;
                case "8D-7B-5C-7E":
                    return 256;
                case "8E-48-7B-7C":
                    return 76;
                case "8F-AB-0B-5C":
                    return 42;
                case "90-13-8F-C7":
                    return 136;
                case "90-39-8C-00":
                    return 237;
                case "94-D6-E3-A3":
                    return 132;
                case "96-D6-88-3F":
                    return 212;
                case "97-0F-61-D1":
                    return 209;
                case "97-58-1D-FB":
                    return 219;
                case "99-A4-9A-74":
                    return 80;
                case "99-AA-1A-91":
                    return 55;
                case "9A-51-37-AA":
                    return 110;
                case "9A-99-3D-93":
                    return 206;
                case "9B-74-CD-56":
                    return 175;
                case "9B-8A-B4-BB":
                    return 247;
                case "9B-D3-B6-6D":
                    return 215;
                case "9C-44-0C-EC":
                    return 157;
                case "9C-82-86-30":
                    return 23;
                case "9D-2C-81-27":
                    return 242;
                case "9D-61-F6-10":
                    return 84;
                case "9D-6F-76-F5":
                    return 51;
                case "9E-94-5B-CE":
                    return 114;
                case "A2-58-D9-C8":
                    return 144;
                case "A4-26-02-F6":
                    return 153;
                case "A5-5F-A1-EE":
                    return 217;
                case "A6-43-09-F7":
                    return 34;
                case "A6-9D-B5-AC":
                    return 140;
                case "A6-CD-E8-B0":
                    return 235;
                case "A8-1A-61-A5":
                    return 117;
                case "A8-D2-6B-9C":
                    return 200;
                case "A9-3F-9B-59":
                    return 171;
                case "AA-0C-BC-5B":
                    return 30;
                case "AA-E8-23-D2":
                    return 221;
                case "AB-E1-4C-9E":
                    return 62;
                case "AC-17-07-F8":
                    return 196;
                case "AC-DF-0D-C1":
                    return 121;
                case "AD-3C-7D-E1":
                    return 3;
                case "AD-FA-F7-3D":
                    return 167;
                case "AE-1B-FB-77":
                    return 245;
                case "AF-2A-A0-1F":
                    return 89;
                case "B1-71-54-A4":
                    return 149;
                case "B3-B9-35-01":
                    return 99;
                case "B6-59-A3-99":
                    return 192;
                case "B6-9F-29-45":
                    return 14;
                case "B8-C6-41-17":
                    return 68;
                case "B9-25-31-37":
                    return 41;
                case "BA-11-9E-7F":
                    return 266;
                case "BA-16-16-35":
                    return 188;
                case "BA-D0-9C-E9":
                    return 10;
                case "BD-E0-5D-53":
                    return 37;
                case "BE-D4-F2-1B":
                    return 262;
                case "BF-F6-80-AD":
                    return 95;
                case "C2-6D-F0-6F":
                    return 214;
                case "C5-0C-61-94":
                    return 243;
                case "C5-A2-01-60":
                    return 222;
                case "C6-10-C9-8D":
                    return 49;
                case "C8-49-A1-DF":
                    return 107;
                case "C8-88-A3-49":
                    return 193;
                case "C8-8F-2B-03":
                    return 251;
                case "C9-6C-5B-23":
                    return 184;
                case "C9-87-CA-02":
                    return 248;
                case "C9-A4-51-1A":
                    return 126;
                case "C9-AA-D1-FF":
                    return 21;
                case "CA-5F-7C-21":
                    return 45;
                case "CA-99-F6-FD":
                    return 163;
                case "CB-7C-47-CF":
                    return 226;
                case "CB-8B-25-ED":
                    return 216;
                case "CC-1D-D6-34":
                    return 241;
                case "CC-4A-47-67":
                    return (int)byte.MaxValue;
                case "CD-61-3D-7E":
                    return 130;
                case "CD-68-35-D1":
                    return 102;
                case "CD-6F-BD-9B":
                    return 17;
                case "CD-A9-37-47":
                    return 179;
                case "CE-5C-9A-99":
                    return 159;
                case "CE-E6-5B-F9":
                    return 218;
                case "CF-79-60-65":
                    return 75;
                case "D1-22-94-DE":
                    return 135;
                case "D6-3E-7A-C8":
                    return 211;
                case "D8-95-81-6D":
                    return 81;
                case "D8-9B-01-88":
                    return 56;
                case "DA-45-D6-4F":
                    return 176;
                case "DB-A8-26-8A":
                    return 207;
                case "DC-50-ED-09":
                    return 85;
                case "DC-5E-6D-EC":
                    return 52;
                case "DD-75-17-F5":
                    return 156;
                case "DD-B3-9D-29":
                    return 24;
                case "DE-80-BA-2B":
                    return 172;
                case "DF-A5-40-D7":
                    return 113;
                case "E3-69-C2-D1":
                    return 143;
                case "E5-17-19-EF":
                    return 152;
                case "E7-AC-AE-B5":
                    return 139;
                case "E7-FC-F3-A9":
                    return 236;
                case "E8-C8-0A-9C":
                    return 6;
                case "E9-2B-7A-BC":
                    return 116;
                case "E9-E3-70-85":
                    return 201;
                case "EA-D0-57-87":
                    return 63;
                case "EA-DE-D7-62":
                    return 86;
                case "EB-3D-A7-42":
                    return 31;
                case "EC-0D-66-F8":
                    return 2;
                case "EC-CB-EC-24":
                    return 168;
                case "ED-26-1C-E1":
                    return 197;
                case "ED-EE-16-D8":
                    return 120;
                case "EE-15-3B-E3":
                    return 59;
                case "EE-1B-BB-06":
                    return 90;
                case "EF-F8-CB-26":
                    return 27;
                case "F0-40-4F-BD":
                    return 150;
                case "F2-88-2E-18":
                    return 100;
                case "F4-85-23-D9":
                    return 146;
                case "F7-68-B8-80":
                    return 191;
                case "F8-14-2A-2E":
                    return 40;
                case "F9-F7-5A-0E":
                    return 67;
                case "FA-02-F7-D0":
                    return 92;
                case "FB-20-85-66":
                    return 265;
                case "FB-27-0D-2C":
                    return 187;
                case "FB-77-14-35":
                    return 240;
                case "FB-E1-87-F0":
                    return 11;
                case "FB-EF-07-15":
                    return 123;
                case "FC-16-85-CE":
                    return 225;
                case "FC-D1-46-4A":
                    return 36;
                case "FD-32-36-6A":
                    return 71;
                case "FE-C7-9B-B4":
                    return 96;
                case "FF-24-EB-94":
                    return 7;
                case "FF-E5-E9-02":
                    return 261;
                default:
                    return 0;
            }
        }
    }
}
