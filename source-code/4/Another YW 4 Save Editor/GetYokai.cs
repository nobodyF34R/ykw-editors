using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_YW_4_Save_Editor
{
    internal class GetYokai
    {
        public string pickYokaiName(string bytes)
        {
            switch (bytes)
            {
                case "00-00-00-00":
                    return "Empty";
                case "00-13-AF-C2":
                    return "Genbu (Celestial)";
                case "00-51-35-63":
                    return "McKraken";
                case "00-60-8A-EC":
                    return "Touma (Horse) (Alt)";
                case "00-E8-F9-E8":
                    return "Manjimutt";
                case "01-06-68-75":
                    return "Monk Guy";
                case "01-6A-1D-0F":
                    return "Smogmella";
                case "01-99-3D-FB":
                    return "Shuka Natsume (Summer)";
                case "02-71-B8-A4":
                    return "Nekomata Neko'ou Bastet";
                case "02-90-45-4D":
                    return "Gesshin Tsukuyomi";
                case "02-D2-B0-62":
                    return "Dismarelda";
                case "03-3F-40-A7":
                    return "Blizzaria";
                case "03-DB-BD-07":
                    return "Touma (Horse)";
                case "04-21-A7-90":
                    return "Zundoumaru Shadow Boss";
                case "04-4C-01-4B":
                    return "Mimikin";
                case "04-6D-58-0F":
                    return "Fubuki-hime (Shadowside)";
                case "05-25-AC-64":
                    return "Kappa Kappa'ou Sagojou";
                case "05-D9-CC-99":
                    return "McKraken";
                case "06-9E-9B-8F":
                    return "Gyuuki";
                case "07-1D-57-3C":
                    return "Yamanba";
                case "07-5A-E5-E2":
                    return "Overseer";
                case "07-DA-E5-69":
                    return "Lord Ananta";
                case "07-F4-AC-26":
                    return "Roughraff";
                case "08-9E-88-EA":
                    return "Reuknight";
                case "08-B9-D2-6D":
                    return "Hovernyan";
                case "08-DC-7D-C5":
                    return "Touma Benkei";
                case "08-DD-04-CD":
                    return "Orochi Shadow Boss";
                case "09-31-8D-00":
                    return "Touma Ashura";
                case "09-73-78-2F":
                    return "Slicenrice";
                case "09-8F-76-9C":
                    return "Tamamo no Mae";
                case "09-BB-E6-54":
                    return "Honmaguro-taishou Shadow Boss";
                case "0A-23-9E-42":
                    return "Tsuchinoko (Shadowside)";
                case "0A-C0-1C-64":
                    return "Dameboy (Shadowside)";
                case "0A-C4-20-DE":
                    return "Touma Fudou Myouou-kai";
                case "0A-CB-D5-42":
                    return "Rhinormous";
                case "0B-26-25-87":
                    return "Drizzelda";
                case "0B-7D-5E-E8":
                    return "Sighborg Y";
                case "0B-B7-9F-CF":
                    return "Hyakki-hime (Shadowside)";
                case "0C-17-91-44":
                    return "Kirin ";
                case "0C-55-64-6B":
                    return "Jibanyan";
                case "0D-1E-4B-21":
                    return "Neko'ou Bastet";
                case "0E-64-A0-48":
                    return "Nekomata/Gusto Neko'ou Bastet";
                case "0F-03-23-F4":
                    return "Usapyon B";
                case "0F-60-BA-2C":
                    return "Akinori";
                case "0F-EB-77-81":
                    return "Fudou Myouou 3";
                case "0F-ED-C9-06":
                    return "Wiglin";
                case "10-C9-E2-F6":
                    return "Little Charrmer";
                case "11-86-30-A3":
                    return "Fuu-kun (Lightside)";
                case "11-AF-00-6F":
                    return "Demuncher";
                case "11-B6-3D-BD":
                    return "Swelton";
                case "12-0E-90-D0":
                    return "Tattletell";
                case "12-14-37-84":
                    return "Komajiro";
                case "12-2E-15-32":
                    return "Goldenyan";
                case "12-4C-65-FF":
                    return "Zashiki-warashi Tengu'ou Kurama";
                case "12-A8-E4-7F":
                    return "Toadal Dude Boss";
                case "12-E7-6B-CA":
                    return "Narigama";
                case "13-0A-9B-0F":
                    return "Kappa Kappa'ou Sagojou";
                case "13-72-D5-1D":
                    return "Mochismo";
                case "14-36-CB-7A":
                    return "Shinmagunjin Fukurou";
                case "14-5B-AB-92":
                    return "Himoji (Lightside)";
                case "14-73-49-13":
                    return "Mad Mountain";
                case "14-90-21-F9":
                    return "Mirapo";
                case "14-D2-C5-51":
                    return "Fudou Myouou";
                case "15-15-AB-8A":
                    return "Count Zapaway";
                case "15-30-E6-91":
                    return "Pakkun Shadow Boss";
                case "15-3D-49-0B":
                    return "Choky (Lightside)";
                case "15-7D-D1-3C":
                    return "Robonyan";
                case "15-97-E3-B0":
                    return "Tamamo no Mae";
                case "15-E3-87-F4":
                    return "Ungaikyo (Shadowside)";
                case "16-46-A6-9F":
                    return "Douketsu";
                case "16-AE-9C-61":
                    return "Nekidspeed";
                case "16-C5-7C-51":
                    return "Arachnus";
                case "16-EB-1E-08":
                    return "Maten Soranaki";
                case "16-FC-5E-93":
                    return "Damona";
                case "17-28-8C-94":
                    return "Sgt. Burly";
                case "17-87-D1-6A":
                    return "Illuminoct";
                case "17-8D-FC-91":
                    return "Jorogumo";
                case "17-B0-2E-F6":
                    return "Yamamba";
                case "17-C8-7E-F8":
                    return "Rhinormous";
                case "18-16-80-C7":
                    return "Tsuchinoko (Shadowside)";
                case "19-52-11-A9":
                    return "Micchy Eye Ball";
                case "19-68-57-F4":
                    return "Yami Enma";
                case "19-70-62-5E":
                    return "Merameraion (Shadowside)";
                case "19-73-33-79":
                    return "Bushinyan (Shadowside)";
                case "19-AE-AC-A1":
                    return "Becchan (Lightside)";
                case "19-AF-58-9D":
                    return "Komajiro";
                case "19-ED-AD-B2":
                    return "Touma Suzaku";
                case "1A-15-9B-4A":
                    return "Hyper Micchy (Lightside)";
                case "1A-17-F5-F0":
                    return "Komashura";
                case "1A-3D-79-CB":
                    return "Awevil";
                case "1A-71-21-06":
                    return "Byakko big";
                case "1A-B1-25-1C":
                    return "Enma";
                case "1A-CB-55-B5":
                    return "Seiryuu (Shadowside)";
                case "1B-5B-9B-52":
                    return "Master Nyada";
                case "1B-AD-B7-2C":
                    return "Fuu-kun (Shadowside)";
                case "1C-72-E5-DD":
                    return "Tsuchigumo (Lightside)";
                case "1C-89-44-D9":
                    return "Baku";
                case "1C-8E-45-0F":
                    return "Raidenryu";
                case "1C-AC-2B-22":
                    return "Kiborikkuma (Shadowside)";
                case "1C-CB-B1-F6":
                    return "Gentou";
                case "1D-14-07-44":
                    return "Komasan (Lightside)";
                case "1D-26-41-33":
                    return "Yami Enma";
                case "1D-64-B4-1C":
                    return "Master Nyada";
                case "1E-25-BF-92":
                    return "Blizzaria";
                case "1E-71-FE-50":
                    return "Dameboy (Shadowside)";
                case "1E-87-7E-6F":
                    return "Blonde Guy (Alt) (NPC)";
                case "1E-AF-30-AF":
                    return "Jibanyan (Lightside)";
                case "1E-DC-19-71":
                    return "Sorrypus";
                case "1F-31-E9-B4":
                    return "Steppa";
                case "1F-50-BD-C2":
                    return "Jinpei Jiba";
                case "1F-C9-D2-36":
                    return "Bushinyan (Lightside)";
                case "1F-DF-03-46":
                    return "Poofessor";
                case "1F-E0-E2-FA":
                    return "Kyubi (Shadowside)";
                case "20-42-C9-FE":
                    return "Suzaku (Celestial)";
                case "20-EC-BC-80":
                    return "Formal Guy (Alt) (NPC)";
                case "21-21-71-76":
                    return "Yamamba";
                case "21-66-EC-67":
                    return "Honmaguro-taishou (Lightside)";
                case "21-74-8C-E1":
                    return "Itashikatanshi (Shadowside)";
                case "21-8B-20-15":
                    return "Kyubi (Lightside)";
                case "21-A2-10-D9":
                    return "Orochi (Lightside)";
                case "22-19-27-32":
                    return "Honmaguro-taishou (Lightside)";
                case "22-A5-F4-C9":
                    return "Snartle (Boss)";
                case "22-C7-E9-CD":
                    return "Kantaro (Shadowside)";
                case "23-7F-C5-AB":
                    return "Micchy (Lightside)";
                case "24-40-F0-23":
                    return "Daniel (Lightside)";
                case "24-52-90-A5":
                    return "Bushinyan (Shadowside)";
                case "24-56-BB-24":
                    return "Blizzaria";
                case "24-A0-97-5A":
                    return "Kyubi (Shadowside)";
                case "24-E7-36-51":
                    return "Mitsue";
                case "25-18-BB-3C":
                    return "Junior (Lightside)";
                case "25-30-59-BD":
                    return "Kyubi";
                case "25-9A-22-08":
                    return "Yamamba";
                case "25-AD-00-E6":
                    return "Saya (Lightside)";
                case "25-C6-75-C3":
                    return "Ogama (Shadowside)";
                case "26-34-05-84":
                    return "Sproink";
                case "26-7D-42-28":
                    return "Komajiro (Shadowside)";
                case "26-A3-8C-D7":
                    return "Shurakoma (Lightside)";
                case "27-1B-A0-B1":
                    return "Fubuki-hime (Shadowside)";
                case "27-C5-6E-4E":
                    return "Hi no Shin (Lightside)";
                case "28-C5-5E-8E":
                    return "Mirapo";
                case "29-6D-E9-C1":
                    return "Junior (Shadowside)";
                case "29-7F-89-47":
                    return "Doyapon (Lightside)";
                case "29-A3-BC-17":
                    return "Beetall";
                case "2A-18-8B-FC":
                    return "Faux Kappa";
                case "2A-51-64-17":
                    return "Black Shiba Dog";
                case "2A-8F-AD-27":
                    return "Hi no Shin Shadow";
                case "2A-AF-40-5C":
                    return "Gargaros";
                case "2A-C7-24-2A":
                    return "Semicolon (Lightside)";
                case "2A-D5-44-AC":
                    return "Seiryuu (Shadowside)";
                case "2B-3B-EB-0C":
                    return "Overseer";
                case "2B-56-8B-E4":
                    return "Saya (Lightside)";
                case "2B-7E-69-65":
                    return "B3-NK1";
                case "2C-11-61-D1":
                    return "Shuka";
                case "2C-7F-F5-6B":
                    return "Komasan";
                case "2C-89-F7-06":
                    return "Manjimutt";
                case "2D-19-17-F2":
                    return "Roughraff";
                case "2E-0C-C8-AB":
                    return "Rai Oton (Lightside)";
                case "2E-55-FA-71":
                    return "Orcanos";
                case "2E-CE-E5-1D":
                    return "Blizzaria";
                case "2E-DF-8D-57":
                    return "Usapyon B";
                case "2F-C4-C2-80":
                    return "Noko";
                case "2F-E1-38-6E":
                    return "Fubuki-hime (Lightside)";
                case "2F-ED-F2-4C":
                    return "Fuu-kun (Shadowside)";
                case "2F-F3-58-E8":
                    return "Banchou (Shadowside)";
                case "30-0F-62-A7":
                    return "Kappa Kappa'ou Sagojou";
                case "30-57-3C-10":
                    return "Rai-chan (Lightside)";
                case "30-8A-A7-8E":
                    return "Snartle";
                case "30-E5-65-3E":
                    return "Sproink";
                case "30-EF-4B-E1":
                    return "Raidenryu";
                case "31-0B-78-C3":
                    return "Summer";
                case "31-49-2B-BD":
                    return "Micchy Shadow (boss)";
                case "31-A8-AC-53":
                    return "Kyunshii (Shadowside)";
                case "31-BA-CC-D5":
                    return "Tsuchinoko (Lightside)";
                case "32-02-61-B8":
                    return "Hi no Shin (Lightside)";
                case "32-B0-4F-28":
                    return "Touma";
                case "33-66-F2-89":
                    return "Jinta Shadow (boss)";
                case "33-B4-55-4C":
                    return "Zashiki-warashi Tengu'ou Kurama";
                case "33-EF-91-7D":
                    return "Lord Ananta";
                case "34-8E-B0-17":
                    return "Ogama (Shadowside)";
                case "34-96-5D-E6":
                    return "Ashura";
                case "34-9C-D0-91":
                    return "Kakurenbou (Lightside)";
                case "35-33-1F-47":
                    return "Micchy Eye Ball";
                case "35-67-F6-B6":
                    return "Gargaros";
                case "36-07-86-A7":
                    return "Sgt. Burly";
                case "36-D0-2B-F2":
                    return "Enma";
                case "37-24-7D-FC":
                    return "Kuuten";
                case "37-36-1D-7A":
                    return "Micchy Hyper (Shadowside)";
                case "38-05-82-5E":
                    return "Manjimutt Boss";
                case "38-57-C5-94":
                    return "Shinmagunjin Fukurou";
                case "39-A3-A9-F5":
                    return "Charlie (Lightside)";
                case "3A-05-64-CF":
                    return "Suzaku (Sword Bearer)";
                case "3A-1B-04-98":
                    return "Pakkun (Lightside)";
                case "3A-8A-10-E6":
                    return "Maten Soranaki";
                case "3A-9D-50-7D":
                    return "Damona";
                case "3B-2E-70-ED":
                    return "Tamamo no Mae";
                case "3B-4E-6E-8B":
                    return "Kawauso";
                case "3B-EC-F2-7F":
                    return "Jorogumo";
                case "3B-F6-F4-5D":
                    return "Himoji (Lightside)";
                case "3C-85-B5-B1":
                    return "Kantaro (Lightside)";
                case "3C-97-D5-37":
                    return "Zundoumaru (Shadowside)";
                case "3C-BC-20-D7":
                    return "Hi no Shin Shadow";
                case "3C-D6-9D-71":
                    return "CowBoy Guy";
                case "3C-F2-A1-3D":
                    return "Orcanos";
                case "3D-8A-CA-82":
                    return "Jinta (Shadowside)";
                case "3D-C3-5A-C6":
                    return "Fudou Myouou";
                case "3E-0B-48-03":
                    return "Touma (Horse) (Alt)";
                case "3E-78-6D-2D":
                    return "Suzaku (Celestial)";
                case "3F-3D-18-DC":
                    return "Komasan (Lightside)";
                case "3F-6D-AA-9A":
                    return "Old Guy";
                case "40-04-97-BE":
                    return "Mitsumata Nozuchi";
                case "40-74-C1-F2":
                    return "Shogunyan";
                case "40-C8-02-88":
                    return "Rocky Badboya";
                case "40-CA-BC-5E":
                    return "Saya (Shadowside)";
                case "41-27-4C-9B":
                    return "Daniel (Shadowside)";
                case "41-35-2C-1D":
                    return "Bushinyan (Lightside)";
                case "41-65-C3-B3":
                    return "Kappa Kappa'ou Sagojou";
                case "41-EE-85-82":
                    return "Nekomata/Gusto Neko'ou Bastet";
                case "42-0E-5B-BE":
                    return "Damona";
                case "42-49-A4-5E":
                    return "Usapyon B";
                case "42-55-B2-69":
                    return "Tamamo";
                case "43-BF-A0-55":
                    return "Jinta Shadow";
                case "44-01-50-DF":
                    return "Honmaguro-taishou (Shadowside)";
                case "44-13-30-59":
                    return "Itashikatanshi (Lightside)";
                case "44-72-34-15":
                    return "Hi no Shin Shadow";
                case "44-76-AC-B3":
                    return "Blizzaria";
                case "44-EB-32-3C":
                    return "Sproink";
                case "45-30-1A-E1":
                    return "Shadow Venoct";
                case "45-D8-00-21":
                    return "Wobblewok";
                case "46-25-50-59":
                    return "Robonyan00";
                case "46-5F-B7-A0":
                    return "Arachnus";
                case "47-10-94-E1":
                    return "Katie (Horse)";
                case "47-63-B1-CF":
                    return "Ashura";
                case "47-79-23-18":
                    return "Hyakki-hime (Shadowside)";
                case "47-AB-9D-34":
                    return "Nurarihyon";
                case "48-10-A4-21":
                    return "Nate";
                case "48-13-3F-BF":
                    return "McKraken";
                case "48-72-5C-DC":
                    return "Enma Awakened";
                case "48-89-C5-47":
                    return "Douketsu";
                case "49-AF-93-F3":
                    return "Corptain";
                case "4A-71-53-BC":
                    return "Komajiro Shadow Boss";
                case "4A-86-84-D6":
                    return "Fubuki-hime (Shadowside)";
                case "4A-94-E4-50":
                    return "Banchou (Lightside)";
                case "4A-AF-89-AE":
                    return "Gesshin Tsukuyomi";
                case "4B-1A-1E-BF":
                    return "Zashiki-warashi Tengu'ou Kurama";
                case "4B-6B-74-13":
                    return "Rai Oton (Shadowside)";
                case "4B-F5-3B-C7":
                    return "Touma Fudou Myouou Ten";
                case "4B-FA-CE-5B":
                    return "Hornaplenty";
                case "4C-0A-55-79":
                    return "Junior (Lightside)";
                case "4C-18-35-FF":
                    return "Doyapon (Shadowside)";
                case "4C-4E-0E-FF":
                    return "Jorogumo (boss)";
                case "4C-FF-0C-96":
                    return "Fudou Myouou 2";
                case "4D-3C-C7-77":
                    return "Rai-chan Shadow Boss";
                case "4D-44-5F-7A":
                    return "Shien";
                case "4D-68-EC-0E":
                    return "Sgt. Burly";
                case "4D-6E-BD-76":
                    return "Shien";
                case "4D-91-90-CD":
                    return "Yamamba";
                case "4E-88-F2-4B":
                    return "Gilgaros";
                case "4E-C7-85-8E":
                    return "Fukurou";
                case "4F-0E-6C-65":
                    return "Genbu (Celestial)";
                case "4F-35-0B-44":
                    return "Diamond ";
                case "4F-A0-98-92":
                    return "Semicolon (Shadowside)";
                case "4F-B2-F8-14":
                    return "Seiryuu (Lightside)";
                case "4F-BD-B7-11":
                    return "Hoggles";
                case "4F-CE-26-10":
                    return "Ogralus";
                case "50-B8-60-F5":
                    return "Sighborg Y";
                case "50-BF-A1-10":
                    return "Wobblewok";
                case "51-5E-96-2A":
                    return "Illuminoct";
                case "51-C4-7D-66":
                    return "Suzaku big";
                case "51-DE-82-6C":
                    return "Mimikin";
                case "51-E4-A0-DA":
                    return "Corptain";
                case "51-E9-0C-AF":
                    return "Ogama (Lightside)";
                case "51-FB-6C-29":
                    return "Kakurenbou (Shadowside)";
                case "52-51-A1-C2":
                    return "Micchy Hyper (Lightside)";
                case "52-65-B5-87":
                    return "Noway";
                case "53-03-57-1E":
                    return "Ogralus";
                case "53-E5-D3-4B":
                    return "McKraken";
                case "54-02-CB-10":
                    return "Sgt. Burly";
                case "54-4C-CA-25":
                    return "Goldenyan";
                case "54-CF-10-EB":
                    return "Kyunshii (Lightside)";
                case "54-DD-70-6D":
                    return "Tsuchinoko (Shadowside)";
                case "55-30-80-A8":
                    return "Rai-chan (Shadowside)";
                case "55-49-C1-54":
                    return "Genbu (Sword Bearer)";
                case "55-64-29-89":
                    return "Happierre";
                case "56-22-BE-A1":
                    return "Overseer 2";
                case "56-29-32-1C":
                    return "Choky C(Shadowside)";
                case "56-3C-CE-4E":
                    return "Overseer giant";
                case "56-DF-1E-62":
                    return "Hovernyan";
                case "56-F7-FC-E3":
                    return "Ungaikyo (Lightside)";
                case "57-06-2B-05":
                    return "Enma";
                case "57-4F-D0-85":
                    return "Himoji (Shadowside)";
                case "57-65-DD-00":
                    return "Hi no Shin (Shadowside)";
                case "57-77-BD-86":
                    return "Douketsu";
                case "57-9C-B1-E0":
                    return "Banchou Shadow Boss";
                case "57-B9-FC-FB":
                    return "Venoct";
                case "58-76-32-1B":
                    return "Hoggles";
                case "58-B9-CC-3B":
                    return "Fuu-kun (Lightside)";
                case "59-01-E0-5D":
                    return "Hyper Micchy (Shadowside)";
                case "59-DF-2E-A2":
                    return "Seiryuu (Lightside)";
                case "59-E2-09-09":
                    return "Kantaro (Shadowside)";
                case "59-F0-69-8F":
                    return "Zundoumaru (Lightside)";
                case "59-F7-CC-23":
                    return "Gargaros";
                case "5A-48-C4-E2":
                    return "Fukurou";
                case "5A-4C-57-89":
                    return "Formal Guy (Alt) (NPC)";
                case "5A-5A-A4-64":
                    return "Komasan (Shadowside)";
                case "5A-64-19-49":
                    return "Merameraion (Lightside)";
                case "5A-BA-D7-B6":
                    return "Becchan (Shadowside)";
                case "5B-02-FB-D0":
                    return "Tsuchinoko (Lightside)";
                case "5B-4C-CF-3D":
                    return "Whisper";
                case "5C-C4-15-4D":
                    return "Charlie (Shadowside)";
                case "5C-DD-A9-21":
                    return "Bushinyan (Shadowside)";
                case "5D-4C-B5-8B":
                    return "Micchy (Shadowside)";
                case "5D-65-85-47":
                    return "Dameboy (Lightside)";
                case "5D-BB-4B-B8":
                    return "Jibanyan (Shadowside)";
                case "5E-00-7C-53":
                    return "Komasan (Shadowside)";
                case "5E-0C-63-F5":
                    return "Overseer giant";
                case "5E-91-48-E5":
                    return "Himoji (Shadowside)";
                case "5F-66-9E-CA":
                    return "Tsuchigumo (Shadowside)";
                case "5F-6A-41-0B":
                    return "Raidenryu";
                case "5F-7C-B8-20":
                    return "Pakkun (Shadowside)";
                case "5F-B8-50-35":
                    return "Kiborikkuma (Lightside)";
                case "60-6B-BE-BC":
                    return "Micchy (Shadowside)";
                case "60-BA-91-69":
                    return "Hoggles";
                case "61-09-E2-E0":
                    return "Sgt. Burly";
                case "61-0D-5C-25":
                    return "Honmaguro-taishou (Shadowside)";
                case "61-0F-B3-98":
                    return "Shien";
                case "61-39-DD-75":
                    return "Spoilerina";
                case "61-D3-92-DA":
                    return "Kantaro (Lightside)";
                case "62-48-D7-0B":
                    return "Tamamo no Mae";
                case "62-6E-8E-75":
                    return "Jinta (boss)";
                case "62-81-70-18":
                    return "Frostina";
                case "62-B6-6B-CE":
                    return "Orochi (Shadowside)";
                case "62-E9-FC-A5":
                    return "Gilgaros";
                case "63-27-77-64":
                    return "Micchy (Lightside)";
                case "63-54-05-AA":
                    return "Diamond ";
                case "63-85-7B-C7":
                    return "Nekomata Neko'ou Bastet";
                case "64-0E-47-27":
                    return "Orcanos";
                case "64-0F-DB-A6":
                    return "Fubuki-hime (Lightside)";
                case "64-1F-C1-31":
                    return "Wazzat";
                case "64-27-95-66":
                    return "Blonde Guy (Alt) (NPC)";
                case "64-A2-3E-8D":
                    return "Shinma Kaira";
                case "64-D1-15-59":
                    return "Hi no Shin (Shadowside)";
                case "64-FE-81-43":
                    return "Summer ";
                case "65-50-06-6D":
                    return "Shinma Kaira";
                case "65-69-39-3F":
                    return "Komajiro (Lightside)";
                case "65-B7-F7-C0":
                    return "Shurakoma (Shadowside)";
                case "66-0C-C0-2B":
                    return "Junior (Shadowside)";
                case "66-A3-67-83":
                    return "Suu-san";
                case "66-D2-0E-D4":
                    return "Ogama (Lightside)";
                case "66-FA-EC-55":
                    return "Deadcool";
                case "67-91-A1-56":
                    return "Kyunshii Shadow Boss";
                case "67-9C-0E-CC":
                    return "Sorrypus";
                case "67-A7-6C-5C":
                    return "Little Charrmer";
                case "67-B4-EC-4D":
                    return "Kyubi (Lightside)";
                case "67-F5-77-F6":
                    return "Signiton";
                case "68-17-A2-5D":
                    return "Blizzaria";
                case "68-42-F0-F3":
                    return "Saya (Shadowside)";
                case "68-5A-F2-D3":
                    return "Gargaros";
                case "68-8A-3C-D2":
                    return "Sproink";
                case "68-B4-DC-8D":
                    return "Signiton";
                case "69-20-B8-55":
                    return "Hovernyan";
                case "69-62-4D-7A":
                    return "Touma Yoshitsune";
                case "69-D2-3E-14":
                    return "Shogunyan";
                case "6A-50-B0-46":
                    return "Manjimutt";
                case "6A-69-09-FF":
                    return "Blazion";
                case "6A-98-15-38":
                    return "Faux Kappa";
                case "6B-0F-EB-66":
                    return "Slicenrice";
                case "6B-E4-5F-B5":
                    return "Souryuu";
                case "6C-06-A4-11":
                    return "Silver Lining";
                case "6C-0E-77-68":
                    return "Wazzat";
                case "6C-37-8B-97":
                    return "Wobblewok";
                case "6C-44-51-3E":
                    return "Genbu (Sword Bearer)";
                case "6C-65-99-50":
                    return "Mitsumata Nozuchi";
                case "6C-78-3B-D3":
                    return "Kakurenbou (Shadowside)";
                case "6C-90-2E-9B":
                    return "Suzaku (Celestial)";
                case "6D-68-95-F1":
                    return "Orcanos";
                case "6E-01-F5-DA":
                    return "Wiglin";
                case "6E-78-53-1D":
                    return "Ogralus";
                case "6E-BD-36-A0":
                    return "Fudou Myouou Boy";
                case "6E-D0-23-77":
                    return "Hyakki-hime (Lightside)";
                case "6E-D3-A2-1A":
                    return "Komashura";
                case "6F-50-E3-8E":
                    return "Jibanyan B";
                case "6F-A4-9D-50":
                    return "Shutendoji";
                case "6F-B5-40-83":
                    return "Sandmeh";
                case "6F-DE-AE-BB":
                    return "Jinta Shadow";
                case "70-1C-18-59":
                    return "Honmaguro-taishou (Shadowside) (No clouds)";
                case "70-79-D1-44":
                    return "Hovernyan";
                case "70-94-AA-7E":
                    return "Yamamba";
                case "70-D9-32-20":
                    return "Usapyon";
                case "71-69-1A-09":
                    return "Damona";
                case "71-B0-38-AF":
                    return "Tengu'ou Kurama";
                case "71-E3-95-34":
                    return "Whisper";
                case "71-E5-FD-C7":
                    return "Nosirs";
                case "72-1F-A5-85":
                    return "Neko'ou Bastet";
                case "72-58-A2-DF":
                    return "Whisper";
                case "72-5D-50-AA":
                    return "Hungramps";
                case "72-6D-6D-1B":
                    return "Overseer giant";
                case "74-17-3C-F5":
                    return "Hoggles";
                case "74-22-A1-F1":
                    return "Nate";
                case "74-C3-E1-83":
                    return "Count Zapaway";
                case "74-C4-4B-41":
                    return "Kenshin Amaterasu";
                case "75-71-DC-50":
                    return "Yamanba";
                case "75-FB-1A-67":
                    return "Hi no Shin Shadow";
                case "76-55-76-72":
                    return "Mimikin Boss";
                case "76-7B-66-CE":
                    return "Jack";
                case "77-7B-4C-EE":
                    return "Shogunyan";
                case "78-A5-0A-67":
                    return "Demuncher";
                case "79-08-73-20":
                    return "Byakko (Celestial)";
                case "79-1C-3D-61":
                    return "Yamakasa Demon";
                case "79-73-81-7D":
                    return "Demuncher";
                case "79-FC-98-E7":
                    return "Noko";
                case "7A-44-35-8A":
                    return "Ogralus";
                case "7A-5D-C0-A0":
                    return "Overseer giant";
                case "7A-7C-43-0A":
                    return "Merameraion Shadow Boss";
                case "7C-98-71-8C":
                    return "Enma Awakened";
                case "7C-C2-91-DF":
                    return "Tsuchinoko (Lightside)";
                case "7C-DA-84-A3":
                    return "Lie-in Heart";
                case "7D-3F-98-C4":
                    return "Illuminoct";
                case "7D-DE-8F-7C":
                    return "Blobgoblin";
                case "7E-6F-55-51":
                    return "Sproink";
                case "7E-A8-63-6C":
                    return "Shadow Venoct";
                case "7E-D9-EE-7F":
                    return "Yasha Enma";
                case "7E-E3-A5-F4":
                    return "Blobgoblin";
                case "7F-62-29-CE":
                    return "Shirokuma";
                case "7F-85-47-6D":
                    return "Kukuri-hime";
                case "7F-8C-C3-3C":
                    return "Snottle";
                case "7F-BF-0C-E6":
                    return "Gentou";
                case "80-7E-5C-2D":
                    return "Hamham (Lightside)";
                case "80-CC-59-E4":
                    return "Damona";
                case "80-DB-19-7F":
                    return "Maten Soranaki";
                case "81-62-A6-D8":
                    return "Kappa'ou Sagojou";
                case "81-7F-79-74":
                    return "Tamamo no Mae";
                case "81-93-AC-E8":
                    return "Komajiro (Lightside)";
                case "81-BD-FB-E6":
                    return "Jorogumo";
                case "82-06-CC-0D":
                    return "Shinmagunjin Fukurou";
                case "82-2B-01-85":
                    return "Becchan (Lightside)";
                case "83-86-05-CD":
                    return "Manjimutt";
                case "83-C6-D9-C0":
                    return "Sgt. Burly";
                case "83-C6-F1-40":
                    return "Enma";
                case "84-41-AA-06":
                    return "Smart Monkey";
                case "84-59-4E-8A":
                    return "Zashiki-warashi Tengu'ou Kurama";
                case "84-A7-D0-2A":
                    return "Fuu-kun (Shadowside)";
                case "84-B5-B0-AC":
                    return "Hare-onna (Lightside)";
                case "85-42-5C-1B":
                    return "Sproink";
                case "86-58-1E-E6":
                    return "Overseer";
                case "86-63-37-CA":
                    return "Illuminoct";
                case "86-A3-A8-A4":
                    return "Orcanos";
                case "86-ED-29-4E":
                    return "Hi no Shin Shadow";
                case "87-0D-1D-C1":
                    return "Shuka";
                case "88-67-39-0D":
                    return "Ungaikyo (Lightside)";
                case "88-A1-7D-33":
                    return "Goldenyan";
                case "8A-20-04-23":
                    return "Jibanyan (Shadowside)";
                case "8A-32-64-A5":
                    return "Ogu Togu Mogu";
                case "8A-B5-75-CC":
                    return "Jinta (boss)";
                case "8A-BE-42-78":
                    return "Raidenryu";
                case "8B-16-E5-F6":
                    return "Ashura (Sword Bearer)";
                case "8B-1D-A9-C1":
                    return "Insomni (Boss)";
                case "8B-36-6F-7A":
                    return "Whisper";
                case "8B-C5-90-7E":
                    return "Narigama";
                case "8B-C8-3F-E4":
                    return "Fuu-kun Shadow Boss";
                case "8C-81-22-6B":
                    return "Enma";
                case "8C-AC-D5-8C":
                    return "Kiborikkuma (Lightside)";
                case "8C-BE-B5-0A":
                    return "Kezurin (Shadowside)";
                case "8D-31-0E-F7":
                    return "Gilgaros";
                case "8F-14-78-E1":
                    return "Micchy (Lightside)";
                case "8F-62-16-DE":
                    return "Micchy Eye Ball";
                case "90-5D-CC-82":
                    return "Damona";
                case "90-67-EE-34":
                    return "Wiglin";
                case "90-AB-E0-FC":
                    return "Inugami (Shadowside)";
                case "90-DE-A4-BE":
                    return "Hi no Shin Shadow";
                case "90-FE-49-C5":
                    return "Gargaros";
                case "91-01-0C-AD":
                    return "Rocky Badboya";
                case "91-15-05-40":
                    return "Kenshin Amaterasu";
                case "91-3B-2E-1B":
                    return "Darkyubi";
                case "91-4F-8C-5A":
                    return "Tsuchigumo (Lightside)";
                case "91-6A-E2-95":
                    return "Overseer";
                case "92-93-0B-8A":
                    return "Orochi (Lightside)";
                case "92-BA-3B-46":
                    return "Nosirs";
                case "92-FD-F4-E8":
                    return "Yamakasa Demon";
                case "93-10-D7-17":
                    return "Hyakki-hime (Shadowside)";
                case "94-7B-F0-98":
                    return "Orochi (Shadowside)";
                case "94-DD-45-D1":
                    return "Hidabat";
                case "94-E3-65-04":
                    return "Orcanos";
                case "95-84-60-DB":
                    return "Choky (Lightside)";
                case "95-A9-67-7F":
                    return "Kage Orochi (Lightside)";
                case "95-BB-A7-48":
                    return "Baku";
                case "95-E0-01-4A":
                    return "Illuminoct";
                case "95-F7-AF-8D":
                    return "Ray O'Light";
                case "96-00-90-A3":
                    return "Shmoopie";
                case "96-25-DD-B8":
                    return "Semicolon Shadow Boss";
                case "96-4C-98-66":
                    return "Snottle";
                case "96-D8-FE-9F":
                    return "Manjimutt";
                case "96-F6-BC-DD":
                    return "Rai-chan (Shadowside)";
                case "97-43-3F-21":
                    return "Jinta Shadow Boss";
                case "97-4E-90-BB":
                    return "Enma";
                case "97-66-72-3A":
                    return "Frostina";
                case "97-90-5E-44":
                    return "Robonyan 00 (Shadowside)";
                case "97-C3-5D-F5":
                    return "Dameboy (Shadowside)";
                case "98-4E-A0-7B":
                    return "Walkappa";
                case "98-66-42-FA":
                    return "Itashikatanshi (Lightside)";
                case "98-B8-8C-05":
                    return "Zundoumaru (Shadowside)";
                case "99-00-A0-63":
                    return "Jabow";
                case "99-28-42-E2":
                    return "Drizzelda";
                case "99-56-E9-7A":
                    return "Uribou (Lightside)";
                case "99-DA-4F-A5":
                    return "Lord Ananta Shadow";
                case "9A-BB-97-88":
                    return "Pakkun (Lightside)";
                case "9A-FC-24-91":
                    return "Kyubi (Shadowside)";
                case "9B-70-78-EF":
                    return "Yamamba";
                case "9B-80-6E-1C":
                    return "Lava Lord";
                case "9C-70-F5-3E":
                    return "Shurakoma (Lightside)";
                case "9D-64-C5-79":
                    return "Banchou (Shadowside)";
                case "9D-81-AC-39":
                    return "Sgt. Burly";
                case "9D-A8-CB-B1":
                    return "Cruncha";
                case "9D-BA-0B-86":
                    return "Douketsu";
                case "9E-25-A8-96":
                    return "Robonyan 00 (Lightside)";
                case "9E-5A-13-B1":
                    return "Shiba Dog";
                case "9F-67-DE-F4":
                    return "Doyapon (Lightside)";
                case "9F-B9-10-0B":
                    return "Kakurenbou (Shadowside)";
                case "9F-C8-58-53":
                    return "Merameraion (Lightside)";
                case "9F-DA-38-D5":
                    return "Jinta (Shadowside)";
                case "A0-78-3E-B5":
                    return "Lava Lord";
                case "A0-B4-30-7D":
                    return "Semicolon (Shadowside)";
                case "A0-E0-2C-85":
                    return "Enma";
                case "A1-0C-1C-1B":
                    return "Uribou (Lightside)";
                case "A1-47-D3-CD":
                    return "Fudou Myouou-kai";
                case "A1-9F-5D-80":
                    return "Rocky Badboya";
                case "A1-D2-D2-E4":
                    return "Hare-onna (Shadowside)";
                case "A2-27-F0-ED":
                    return "Dimmy";
                case "A2-65-05-C2":
                    return "Gunshin Susanoo";
                case "A2-69-E5-0F":
                    return "Kyunshii (Shadowside)";
                case "A2-CE-0B-F7":
                    return "Azukiarai";
                case "A2-FC-E4-26":
                    return "Fudou Myouou";
                case "A3-03-18-30":
                    return "Micchy Eye Ball";
                case "A3-0F-07-96":
                    return "Jinta (Shadowside)";
                case "A3-23-FB-32":
                    return "Kawauso";
                case "A3-C3-09-5E":
                    return "Hornaplenty";
                case "A3-D1-C9-69":
                    return "Shutendoji";
                case "A4-B9-41-C4":
                    return "Nekidspeed";
                case "A4-D0-55-67":
                    return "Ogu Togu Mogu";
                case "A5-54-B1-01":
                    return "Walkappa";
                case "A5-68-79-01":
                    return "Charlie (Shadowside)";
                case "A5-B6-B7-FE":
                    return "Daniel (Lightside)";
                case "A6-05-E7-76":
                    return "Yamamba (Boss)";
                case "A6-25-62-94":
                    return "Robonyan";
                case "A6-D3-4E-EA":
                    return "Kezurin (Shadowside)";
                case "A6-EC-1C-6C":
                    return "Snartle";
                case "A6-FD-5B-2B":
                    return "Roughraff (Boss)";
                case "A7-01-EC-A9":
                    return "Blazion";
                case "A7-6B-62-8C":
                    return "Fukurou";
                case "A8-27-5A-89":
                    return "Legsit";
                case "A8-6B-52-4C":
                    return "Lie-in Heart";
                case "A8-9D-7E-32":
                    return "Hamham (Shadowside)";
                case "A9-0D-B0-D5":
                    return "Insomni";
                case "A9-25-52-54":
                    return "Lord Ananta";
                case "A9-86-38-A0":
                    return "Komasan";
                case "A9-C4-CD-8F":
                    return "Touma Genbu 2";
                case "A9-FB-9C-AB":
                    return "Rai Oton (Shadowside)";
                case "AA-3E-95-CD":
                    return "Sighborg Y";
                case "AA-73-BA-7C":
                    return "Tamamo no Mae";
                case "AA-B6-87-3E":
                    return "Dismarelda";
                case "AB-2A-E5-91":
                    return "Enma Awoken";
                case "AB-8C-6C-AC":
                    return "Ogralus";
                case "AB-9C-6D-62":
                    return "Poofessor";
                case "AB-D0-65-A7":
                    return "Molar Petite";
                case "AC-53-C3-8C":
                    return "Jinta Shadow (boss)";
                case "AC-A0-24-E4":
                    return "Molar Petite";
                case "AC-AD-57-0A":
                    return "Damona";
                case "AC-BA-17-91":
                    return "Maten Soranaki";
                case "AC-D1-F9-A9":
                    return "Cornfused";
                case "AC-E2-D1-CB":
                    return "Hakushu";
                case "AC-F8-C9-65":
                    return "Orochi (Shadowside)";
                case "AD-0F-21-0E":
                    return "Kaibyou Kamaitachi";
                case "AD-4D-D4-21":
                    return "Kyubi";
                case "AD-DC-F5-08":
                    return "Jorogumo";
                case "AD-E1-27-6F":
                    return "Yamamba";
                case "AE-0C-2C-DB":
                    return "Gilgaros";
                case "AE-67-C2-E3":
                    return "Shinmagunjin Fukurou";
                case "AE-F5-79-4C":
                    return "Gargaros";
                case "AF-18-89-89":
                    return "Rhyth";
                case "AF-49-81-71":
                    return "Maten Soranaki";
                case "AF-6A-CE-42":
                    return "Swelton";
                case "AF-F6-63-7B":
                    return "Ray O'Light";
                case "B0-2D-57-39":
                    return "Kage Orochi (Lightside)";
                case "B0-AE-8D-F7":
                    return "Deadcool";
                case "B1-41-B6-BB":
                    return "Jibanyan B";
                case "B1-43-7D-32":
                    return "Usapyon";
                case "B1-4F-CB-3B":
                    return "Byakko (Celestial)";
                case "B1-B0-5D-C6":
                    return "Akinori (Fit)";
                case "B2-00-BC-92":
                    return "Gilgaros";
                case "B2-9B-3A-29":
                    return "Komasan B";
                case "B2-B9-25-70":
                    return "Kenshin Amaterasu";
                case "B2-FB-D0-5F":
                    return "Hidabat";
                case "B3-16-20-9A":
                    return "Awevil";
                case "B3-FF-DB-80":
                    return "Tamamo";
                case "B4-65-61-76":
                    return "Sandmeh";
                case "B4-84-21-04":
                    return "Touma";
                case "B5-7D-27-19":
                    return "Byakko (Sword Bearer)";
                case "B5-AE-52-91":
                    return "Azukiarai";
                case "B5-EC-FC-BB":
                    return "Asura (Sword Bearer)";
                case "B6-8D-29-D7":
                    return "Toadal Dude";
                case "B6-D9-C7-C4":
                    return "Tamamo (Boss)";
                case "B7-34-37-01":
                    return "Zashiki-warashi Tengu'ou Kurama";
                case "B7-DD-CC-1B":
                    return "Mochismo";
                case "B8-B7-E8-D7":
                    return "Toadal Dude";
                case "B8-F5-1D-F8":
                    return "Touma Goemon";
                case "B9-18-ED-3D":
                    return "Touma Byakko";
                case "B9-5A-18-12":
                    return "Happierre";
                case "B9-EE-1E-D3":
                    return "Roughraff";
                case "BA-00-3C-FA":
                    return "McKraken";
                case "BA-04-19-E4":
                    return "Shien";
                case "BA-A3-CD-CB":
                    return "Fubuki-hime Shadow Boss";
                case "BA-B9-F0-71":
                    return "Manjimutt";
                case "BA-E2-B5-7F":
                    return "Beetall";
                case "BB-0F-45-BA":
                    return "McKraken";
                case "BB-C5-2F-52":
                    return "Kyubi Shadow Boss";
                case "BC-3E-F1-79":
                    return "Byakko (Sword Bearer)";
                case "BC-7C-04-56":
                    return "Krystal Fox";
                case "BD-0B-EC-7B":
                    return "Overseer";
                case "BE-AA-83-30":
                    return "Inugami (Lightside)";
                case "BF-60-82-27":
                    return "Hakushu";
                case "BF-C4-A9-3B":
                    return "Gilgaros";
                case "BF-DC-F2-12":
                    return "Byakko (Celestial)";
                case "C0-0C-C9-39":
                    return "Overseer giant";
                case "C0-CC-21-03":
                    return "Ashura big";
                case "C1-CC-9D-FA":
                    return "Cornfused";
                case "C2-36-C5-B8":
                    return "Kappa Kappa'ou Sagojou";
                case "C2-F4-03-FE":
                    return "Demuncher";
                case "C3-22-88-E4":
                    return "Demuncher";
                case "C3-31-B4-0B":
                    return "Alien";
                case "C3-61-FA-DB":
                    return "Little Charrmer";
                case "C3-70-3B-48":
                    return "Gyuuki";
                case "C3-77-16-E8":
                    return "Suzaku big";
                case "C4-0B-C1-CC":
                    return "Jack";
                case "C4-3E-5C-C8":
                    return "Sproink";
                case "C4-73-47-02":
                    return "Hoggles";
                case "C4-EA-81-BE":
                    return "B3-NK1";
                case "C5-E6-31-09":
                    return "Katie";
                case "C6-15-1E-A4":
                    return "Damona";
                case "C6-41-15-4E":
                    return "Suu-san";
                case "C6-56-27-0C":
                    return "Shien";
                case "C6-5F-6F-F6":
                    return "McKraken";
                case "C6-E2-CF-28":
                    return "Demuncher";
                case "C7-52-2C-D3":
                    return "Venoct";
                case "C7-6E-91-5D":
                    return "Illuminoct";
                case "C8-3C-64-82":
                    return "Overseer giant";
                case "C9-97-0D-F5":
                    return "Touma Fudou Myouou";
                case "C9-D5-F8-DA":
                    return "Demuncher";
                case "CA-6D-55-B7":
                    return "Orcanos";
                case "CA-D7-FA-B8":
                    return "Fudou Myouou 1";
                case "CB-B5-06-24":
                    return "Robonyan";
                case "CC-66-FB-FB":
                    return "Genbu (Sword Bearer)";
                case "CC-A7-27-79":
                    return "Tengu'ou Kurama";
                case "CC-B1-11-B1":
                    return "Yasha Enma";
                case "CC-F3-E4-9E":
                    return "Shmoopie";
                case "CD-C1-C5-E0":
                    return "Kappa'ou Sagojou";
                case "CE-46-35-6C":
                    return "Hoggles";
                case "CF-0F-11-4E":
                    return "Tamamo";
                case "CF-4B-49-F3":
                    return "Punkupine";
                case "CF-A5-A3-01":
                    return "Legsit";
                case "D0-04-AC-00":
                    return "Hyakki-hime (Lightside)";
                case "D1-10-BD-48":
                    return "Wobblewok";
                case "D1-3D-D4-95":
                    return "Legsit";
                case "D1-54-E6-CE":
                    return "Shinmagunjin Fukurou (boss)";
                case "D1-70-8E-AE":
                    return "Silver Lining";
                case "D2-0B-FB-4A":
                    return "Gargaros";
                case "D2-46-AB-C4":
                    return "Blizzaria";
                case "D2-77-6A-BE":
                    return "Reuknight Boss";
                case "D2-A2-FC-9B":
                    return "Himoji Shadow Boss";
                case "D2-A8-10-25":
                    return "Insomni";
                case "D2-CB-B9-45":
                    return "Krystal Fox";
                case "D3-65-30-41":
                    return "[DONT_WORK]";
                case "D3-AC-1B-FA":
                    return "Kukuri-hime";
                case "D3-AD-5B-DC":
                    return "Tattletell";
                case "D3-BF-9B-EB":
                    return "Inugami (Lightside)";
                case "D4-1D-EB-BB":
                    return "Genbu big";
                case "D4-29-5A-84":
                    return "Ogralus";
                case "D4-36-A1-0C":
                    return "Noway";
                case "D4-84-25-53":
                    return "Robonyan 00 (Lightside)";
                case "D4-AC-C7-D2":
                    return "Shirokuma";
                case "D4-D7-E1-7E":
                    return "Akinori";
                case "D5-4A-EB-81":
                    return "Kage Orochi (Shadowside)";
                case "D5-8F-A7-22":
                    return "Jinta Shadow";
                case "D5-CA-25-4B":
                    return "Wobblewok";
                case "D5-E2-C7-CA":
                    return "Rai-chan (Lightside)";
                case "D6-34-90-C9":
                    return "Mitsumata Nozuchi";
                case "D6-66-82-0E":
                    return "Wobblewok";
                case "D6-71-12-A0":
                    return "Smogmella";
                case "D6-BD-1C-68":
                    return "Kage Orochi (Shadowside)";
                case "D7-17-F0-39":
                    return "Rhyth";
                case "D7-72-C8-30":
                    return "Rai-chan (Lightside)";
                case "D8-19-DE-92":
                    return "Tamamo no Mae";
                case "D8-A7-91-68":
                    return "Fudou Myouou Ten";
                case "D8-B8-F5-3C":
                    return "Gilgaros";
                case "D8-F8-94-A6":
                    return "Hi no Shin Shadow";
                case "D9-05-0C-33":
                    return "Diamond ";
                case "D9-09-D8-68":
                    return "Signiton";
                case "D9-4B-2D-47":
                    return "Touma Omatsu";
                case "D9-AF-EC-9F":
                    return "Pakkun (Shadowside)";
                case "DA-A0-59-20":
                    return "Byakko (Sword Bearer)";
                case "DA-B1-75-05":
                    return "Mad Mountain";
                case "DA-CA-15-8B":
                    return "Fudou Myouou Boy";
                case "DA-E2-F7-0A":
                    return "Arachnus";
                case "DA-EB-98-F0":
                    return "Hoggles";
                case "DB-58-EB-79":
                    return "Sgt. Burly";
                case "DB-5E-BA-01":
                    return "Shien";
                case "DB-72-39-ED":
                    return "Itashikatanshi (Shadowside)";
                case "DB-84-15-93":
                    return "Toadal Dude";
                case "DB-97-E7-ED":
                    return "Wobblewok";
                case "DB-AC-F7-12":
                    return "Zundoumaru (Lightside)";
                case "DB-CD-3F-88":
                    return "Inugami (Shadowside)";
                case "DC-2F-C4-2C":
                    return "Manjimutt";
                case "DC-6D-31-03":
                    return "Suzaku (Sword Bearer)";
                case "DC-73-A5-E3":
                    return "Doyapon (Shadowside)";
                case "DC-AD-6B-1C":
                    return "Kakurenbou (Lightside)";
                case "DD-31-F7-7A":
                    return "Doyapon";
                case "DD-D7-9F-B2":
                    return "Jibanyan B";
                case "DE-0D-13-20":
                    return "Komasan B";
                case "DE-5F-4E-BE":
                    return "Orcanos";
                case "DE-70-BE-6E":
                    return "Banchou (Lightside)";
                case "DF-3F-6C-3B":
                    return "Seiryuu Shadow";
                case "DF-79-83-B3":
                    return "Komasan B";
                case "DF-8F-33-03":
                    return "Hailey Anne";
                case "E0-1B-7C-81":
                    return "Jinta (Lightside)";
                case "E1-33-8B-FA":
                    return "Micchy Eye Ball (boss)";
                case "E1-7D-9E-18":
                    return "Kyunshii (Lightside)";
                case "E1-C0-6C-92":
                    return "Fuu-kun (Lightside)";
                case "E1-D2-0C-14":
                    return "Hare-onna (Shadowside)";
                case "E2-18-67-0C":
                    return "Uribou (Shadowside)";
                case "E2-2C-E1-2B":
                    return "Lie-in Heart";
                case "E2-7A-7A-08":
                    return "Arachnus (Boss)";
                case "E2-7D-AB-6C":
                    return "Komashura";
                case "E2-B6-E4-11":
                    return "Tsuchinoko (Normal)";
                case "E2-C6-A9-F3":
                    return "Hare-onna (Lightside)";
                case "E3-A0-4B-6A":
                    return "Semicolon (Lightside)";
                case "E3-B2-8B-5D":
                    return "Illuminoct";
                case "E4-5D-6A-6C":
                    return "Overseer giant";
                case "E4-89-35-E5":
                    return "Snartle";
                case "E4-A1-D7-64":
                    return "Nurarihyon";
                case "E4-F4-10-50":
                    return "Komajiro (Shadowside)";
                case "E5-19-E0-95":
                    return "Hamham (Shadowside)";
                case "E5-37-EE-C3":
                    return "Blazion (Boss)";
                case "E5-C4-28-19":
                    return "Douketsu";
                case "E5-C7-35-FD":
                    return "Kezurin (Lightside)";
                case "E5-EF-D7-7C":
                    return "Reuknight";
                case "E6-0B-DE-9C":
                    return "Overseer 3";
                case "E6-7C-02-16":
                    return "Charlie (Lightside)";
                case "E6-A2-CC-E9":
                    return "Daniel (Shadowside)";
                case "E7-05-3F-7F":
                    return "Hamham (Shadowside)";
                case "E7-41-CF-53":
                    return "Yellow Shiba Dog";
                case "E7-4C-BD-3D":
                    return "Becchan (Shadowside)";
                case "E7-5E-DD-BB":
                    return "Shutendoji";
                case "E8-1A-D0-4F":
                    return "Usapyon";
                case "E8-1C-EF-82":
                    return "Demuncher";
                case "E8-5F-52-26":
                    return "Sproink";
                case "E9-19-0A-DF":
                    return "Rai-chan (Shadowside)";
                case "E9-1E-DB-BB":
                    return "Kantaro Shadow Boss";
                case "E9-49-B8-46":
                    return "Genbu (Celestial)";
                case "E9-7C-32-D6":
                    return "Steppa";
                case "E9-B4-DA-D2":
                    return "McKraken";
                case "E9-CB-69-34":
                    return "Kiborikkuma (Shadowside)";
                case "E9-D9-09-B2":
                    return "Kezurin (Lightside)";
                case "EA-61-A4-DF":
                    return "Jabow";
                case "EA-63-50-D1":
                    return "Maten Soranaki";
                case "EA-65-21-8B":
                    return "Slimamander (Shadowside) (Hyper)";
                case "EA-73-C4-59":
                    return "Micchy (Shadowside)";
                case "EA-C7-05-3D":
                    return "Punkupine";
                case "EA-EF-E7-BC":
                    return "Rai Oton (Lightside)";
                case "EB-0F-9F-B3":
                    return "Illuminoct";
                case "EB-30-84-D0":
                    return "Damona (Shadowside)";
                case "EB-89-05-25":
                    return "Hamham (Lightside)";
                case "EB-A1-E7-A4":
                    return "Spoilerina";
                case "EC-31-21-A6":
                    return "Gilgaros";
                case "EC-6D-C7-D7":
                    return "Overseer giant";
                case "EC-7C-CF-38":
                    return "Darkyubi";
                case "EC-A0-7B-AA":
                    return "Jibanyan";
                case "EC-CE-EF-10":
                    return "Kuuten";
                case "ED-00-85-B5":
                    return "Ungaikyo (Shadowside)";
                case "ED-C6-99-33":
                    return "Dimmy";
                case "EE-2E-03-43":
                    return "Neko'ou Bastet";
                case "EE-7D-AE-D8":
                    return "Hungramps";
                case "EF-1B-4C-41":
                    return "Manjimutt";
                case "EF-47-B8-9B":
                    return "Jibanyan (Lightside)";
                case "EF-4C-FF-DF":
                    return "Gargaros";
                case "F0-E3-DC-63":
                    return "Choky (Shadowside)";
                case "F1-1C-4C-20":
                    return "Orochi (Lightside)";
                case "F2-0D-39-14":
                    return "Suzaku (Sword Bearer)";
                case "F2-A4-E1-4D":
                    return "Dameboy (Lightside)";
                case "F4-28-30-E2":
                    return "Tsuchigumo (Shadowside)";
                case "F4-D9-FB-D2":
                    return "Gilgaros";
                case "F5-64-02-DD":
                    return "Diamond ";
                case "F5-9F-2F-89":
                    return "Ogralus";
                case "F6-8A-96-1E":
                    return "Hoggles";
                case "F6-D7-FE-2E":
                    return "Diamond ";
                case "F7-23-09-EB":
                    return "Yami Enma";
                case "F7-39-E5-97":
                    return "Sgt. Burly";
                case "F7-3F-B4-EF":
                    return "Shien";
                case "F7-82-FD-09":
                    return "Fudou Myouou Boy";
                case "F8-9B-5A-D4":
                    return "Katie";
                case "F9-17-49-86":
                    return "Shurakoma (Shadowside)";
                case "F9-BB-3F-62":
                    return "Deadcool";
                case "F9-EE-A9-CC":
                    return "Jinta Shadow";
                case "FA-55-9E-27":
                    return "Mitsumata Nozuchi";
                case "FA-AF-E4-EB":
                    return "Merameraion (Shadowside)";
                case "FA-BD-84-6D":
                    return "Jinta (Lightside)";
                case "FB-42-14-2E":
                    return "Robonyan 00 (Shadowside)";
                case "FB-42-95-C2":
                    return "Yami Enma";
                case "FB-AF-C0-9F":
                    return "Ogralus";
                case "FB-D3-AE-66":
                    return "Cruncha";
                case "FC-31-55-C2":
                    return "Uribou (Shadowside)";
                case "FD-1C-D4-07":
                    return "Genbu big";
                case "FE-04-60-01":
                    return "Sproink";
                case "FE-23-3D-8C":
                    return "Hi no Shin Shadow";
                case "FE-27-A5-2A":
                    return "Blizzaria";
                case "FE-59-A0-DB":
                    return "Gesshin Tsukuyomi";
                case "FE-A7-E3-EC":
                    return "Byakko big";
                case "FE-BA-3B-A5":
                    return "Sproink";
                case "FF-89-09-B8":
                    return "Wobblewok";
                case "FF-94-D7-2C":
                    return "Sproink";
                case "FF-9B-98-29":
                    return "Kyubi (Lightside)";
                default:
                    return "Unknown";
            }
        }

        public int pickYokaiIDNumber(string bytes)
        {
            switch (bytes)
            {
                case "00-00-00-00":
                    return 0;
                case "00-13-AF-C2":
                    return 233;
                case "00-51-35-63":
                    return 713;
                case "00-60-8A-EC":
                    return 809;
                case "00-E8-F9-E8":
                    return 309;
                case "01-06-68-75":
                    return 798;
                case "01-6A-1D-0F":
                    return 424;
                case "01-99-3D-FB":
                    return 207;
                case "02-71-B8-A4":
                    return 336;
                case "02-90-45-4D":
                    return 445;
                case "02-D2-B0-62":
                    return 87;
                case "03-3F-40-A7":
                    return 92;
                case "03-DB-BD-07":
                    return 808;
                case "04-21-A7-90":
                    return 65;
                case "04-4C-01-4B":
                    return 131;
                case "04-6D-58-0F":
                    return 785;
                case "05-25-AC-64":
                    return 585;
                case "05-D9-CC-99":
                    return 710;
                case "06-9E-9B-8F":
                    return 581;
                case "07-1D-57-3C":
                    return 167;
                case "07-5A-E5-E2":
                    return 269;
                case "07-DA-E5-69":
                    return 343;
                case "07-F4-AC-26":
                    return 95;
                case "08-9E-88-EA":
                    return 115;
                case "08-B9-D2-6D":
                    return 766;
                case "08-DC-7D-C5":
                    return 194;
                case "08-DD-04-CD":
                    return 29;
                case "09-31-8D-00":
                    return 206;
                case "09-73-78-2F":
                    return 414;
                case "09-8F-76-9C":
                    return 243;
                case "09-BB-E6-54":
                    return 32;
                case "0A-23-9E-42":
                    return 817;
                case "0A-C0-1C-64":
                    return 755;
                case "0A-C4-20-DE":
                    return 446;
                case "0A-CB-D5-42":
                    return 160;
                case "0B-26-25-87":
                    return 425;
                case "0B-7D-5E-E8":
                    return 761;
                case "0B-B7-9F-CF":
                    return 379;
                case "0C-17-91-44":
                    return 198;
                case "0C-55-64-6B":
                    return 123;
                case "0D-1E-4B-21":
                    return 364;
                case "0E-64-A0-48":
                    return 598;
                case "0F-03-23-F4":
                    return 432;
                case "0F-60-BA-2C":
                    return 789;
                case "0F-EB-77-81":
                    return 730;
                case "0F-ED-C9-06":
                    return 136;
                case "10-C9-E2-F6":
                    return 516;
                case "11-86-30-A3":
                    return 344;
                case "11-AF-00-6F":
                    return 643;
                case "11-B6-3D-BD":
                    return 143;
                case "12-0E-90-D0":
                    return 86;
                case "12-14-37-84":
                    return 530;
                case "12-2E-15-32":
                    return 549;
                case "12-4C-65-FF":
                    return 190;
                case "12-A8-E4-7F":
                    return 119;
                case "12-E7-6B-CA":
                    return 170;
                case "13-0A-9B-0F":
                    return 173;
                case "13-72-D5-1D":
                    return 518;
                case "14-36-CB-7A":
                    return 263;
                case "14-5B-AB-92":
                    return 447;
                case "14-73-49-13":
                    return 575;
                case "14-90-21-F9":
                    return 133;
                case "14-D2-C5-51":
                    return 230;
                case "15-15-AB-8A":
                    return 651;
                case "15-30-E6-91":
                    return 13;
                case "15-3D-49-0B":
                    return 455;
                case "15-7D-D1-3C":
                    return 134;
                case "15-97-E3-B0":
                    return 745;
                case "15-E3-87-F4":
                    return 492;
                case "16-46-A6-9F":
                    return 179;
                case "16-AE-9C-61":
                    return 650;
                case "16-C5-7C-51":
                    return 107;
                case "16-EB-1E-08":
                    return 288;
                case "16-FC-5E-93":
                    return 314;
                case "17-28-8C-94":
                    return 100;
                case "17-87-D1-6A":
                    return 293;
                case "17-8D-FC-91":
                    return 259;
                case "17-B0-2E-F6":
                    return 741;
                case "17-C8-7E-F8":
                    return 573;
                case "18-16-80-C7":
                    return 627;
                case "19-52-11-A9":
                    return 257;
                case "19-68-57-F4":
                    return 335;
                case "19-70-62-5E":
                    return 460;
                case "19-73-33-79":
                    return 756;
                case "19-AE-AC-A1":
                    return 638;
                case "19-AF-58-9D":
                    return 112;
                case "19-ED-AD-B2":
                    return 203;
                case "1A-15-9B-4A":
                    return 503;
                case "1A-17-F5-F0":
                    return 109;
                case "1A-3D-79-CB":
                    return 642;
                case "1A-71-21-06":
                    return 333;
                case "1A-B1-25-1C":
                    return 282;
                case "1A-CB-55-B5":
                    return 474;
                case "1B-5B-9B-52":
                    return 543;
                case "1B-AD-B7-2C":
                    return 476;
                case "1C-72-E5-DD":
                    return 624;
                case "1C-89-44-D9":
                    return 125;
                case "1C-8E-45-0F":
                    return 683;
                case "1C-AC-2B-22":
                    return 498;
                case "1C-CB-B1-F6":
                    return 440;
                case "1D-14-07-44":
                    return 467;
                case "1D-26-41-33":
                    return 186;
                case "1D-64-B4-1C":
                    return 128;
                case "1E-25-BF-92":
                    return 223;
                case "1E-71-FE-50":
                    return 641;
                case "1E-87-7E-6F":
                    return 796;
                case "1E-AF-30-AF":
                    return 481;
                case "1E-DC-19-71":
                    return 156;
                case "1F-31-E9-B4":
                    return 137;
                case "1F-50-BD-C2":
                    return 801;
                case "1F-C9-D2-36":
                    return 620;
                case "1F-DF-03-46":
                    return 426;
                case "1F-E0-E2-FA":
                    return 353;
                case "20-42-C9-FE":
                    return 732;
                case "20-EC-BC-80":
                    return 797;
                case "21-21-71-76":
                    return 740;
                case "21-66-EC-67":
                    return 30;
                case "21-74-8C-E1":
                    return 383;
                case "21-8B-20-15":
                    return 352;
                case "21-A2-10-D9":
                    return 461;
                case "22-19-27-32":
                    return 463;
                case "22-A5-F4-C9":
                    return 106;
                case "22-C7-E9-CD":
                    return 496;
                case "23-7F-C5-AB":
                    return 501;
                case "24-40-F0-23":
                    return 380;
                case "24-52-90-A5":
                    return 391;
                case "24-56-BB-24":
                    return 514;
                case "24-A0-97-5A":
                    return 486;
                case "24-E7-36-51":
                    return 805;
                case "25-18-BB-3C":
                    return 499;
                case "25-30-59-BD":
                    return 541;
                case "25-9A-22-08":
                    return 738;
                case "25-AD-00-E6":
                    return 384;
                case "25-C6-75-C3":
                    return 629;
                case "26-34-05-84":
                    return 667;
                case "26-7D-42-28":
                    return 470;
                case "26-A3-8C-D7":
                    return 622;
                case "27-1B-A0-B1":
                    return 458;
                case "27-C5-6E-4E":
                    return 505;
                case "28-C5-5E-8E":
                    return 547;
                case "29-6D-E9-C1":
                    return 77;
                case "29-7F-89-47":
                    return 400;
                case "29-A3-BC-17":
                    return 571;
                case "2A-18-8B-FC":
                    return 577;
                case "2A-51-64-17":
                    return 803;
                case "2A-8F-AD-27":
                    return 727;
                case "2A-AF-40-5C":
                    return 696;
                case "2A-C7-24-2A":
                    return 33;
                case "2A-D5-44-AC":
                    return 45;
                case "2B-3B-EB-0C":
                    return 267;
                case "2B-56-8B-E4":
                    return 614;
                case "2B-7E-69-65":
                    return 652;
                case "2C-11-61-D1":
                    return 370;
                case "2C-7F-F5-6B":
                    return 529;
                case "2C-89-F7-06":
                    return 321;
                case "2D-19-17-F2":
                    return 517;
                case "2E-0C-C8-AB":
                    return 386;
                case "2E-55-FA-71":
                    return 705;
                case "2E-CE-E5-1D":
                    return 294;
                case "2E-DF-8D-57":
                    return 765;
                case "2F-C4-C2-80":
                    return 528;
                case "2F-E1-38-6E":
                    return 21;
                case "2F-ED-F2-4C":
                    return 345;
                case "2F-F3-58-E8":
                    return 42;
                case "30-0F-62-A7":
                    return 599;
                case "30-57-3C-10":
                    return 49;
                case "30-8A-A7-8E":
                    return 752;
                case "30-E5-65-3E":
                    return 668;
                case "30-EF-4B-E1":
                    return 685;
                case "31-0B-78-C3":
                    return 788;
                case "31-49-2B-BD":
                    return 210;
                case "31-A8-AC-53":
                    return 15;
                case "31-BA-CC-D5":
                    return 396;
                case "32-02-61-B8":
                    return 82;
                case "32-B0-4F-28":
                    return 787;
                case "33-66-F2-89":
                    return 341;
                case "33-B4-55-4C":
                    return 600;
                case "33-EF-91-7D":
                    return 177;
                case "34-8E-B0-17":
                    return 399;
                case "34-96-5D-E6":
                    return 334;
                case "34-9C-D0-91":
                    return 376;
                case "35-33-1F-47":
                    return 255;
                case "35-67-F6-B6":
                    return 693;
                case "36-07-86-A7":
                    return 767;
                case "36-D0-2B-F2":
                    return 274;
                case "37-24-7D-FC":
                    return 442;
                case "37-36-1D-7A":
                    return 81;
                case "38-05-82-5E":
                    return 122;
                case "38-57-C5-94":
                    return 265;
                case "39-A3-A9-F5":
                    return 61;
                case "3A-05-64-CF":
                    return 731;
                case "3A-1B-04-98":
                    return 11;
                case "3A-8A-10-E6":
                    return 290;
                case "3A-9D-50-7D":
                    return 302;
                case "3B-2E-70-ED":
                    return 746;
                case "3B-4E-6E-8B":
                    return 587;
                case "3B-EC-F2-7F":
                    return 261;
                case "3B-F6-F4-5D":
                    return 8;
                case "3C-85-B5-B1":
                    return 71;
                case "3C-97-D5-37":
                    return 64;
                case "3C-BC-20-D7":
                    return 726;
                case "3C-D6-9D-71":
                    return 799;
                case "3C-F2-A1-3D":
                    return 708;
                case "3D-8A-CA-82":
                    return 754;
                case "3D-C3-5A-C6":
                    return 229;
                case "3E-0B-48-03":
                    return 810;
                case "3E-78-6D-2D":
                    return 231;
                case "3F-3D-18-DC":
                    return 36;
                case "3F-6D-AA-9A":
                    return 812;
                case "40-04-97-BE":
                    return 252;
                case "40-74-C1-F2":
                    return 360;
                case "40-C8-02-88":
                    return 751;
                case "40-CA-BC-5E":
                    return 385;
                case "41-27-4C-9B":
                    return 381;
                case "41-35-2C-1D":
                    return 390;
                case "41-65-C3-B3":
                    return 337;
                case "41-EE-85-82":
                    return 584;
                case "42-0E-5B-BE":
                    return 93;
                case "42-49-A4-5E":
                    return 784;
                case "42-55-B2-69":
                    return 580;
                case "43-BF-A0-55":
                    return 248;
                case "44-01-50-DF":
                    return 31;
                case "44-13-30-59":
                    return 382;
                case "44-72-34-15":
                    return 363;
                case "44-76-AC-B3":
                    return 306;
                case "44-EB-32-3C":
                    return 674;
                case "45-30-1A-E1":
                    return 103;
                case "45-D8-00-21":
                    return 690;
                case "46-25-50-59":
                    return 762;
                case "46-5F-B7-A0":
                    return 348;
                case "47-10-94-E1":
                    return 811;
                case "47-63-B1-CF":
                    return 237;
                case "47-79-23-18":
                    return 786;
                case "47-AB-9D-34":
                    return 182;
                case "48-10-A4-21":
                    return 791;
                case "48-13-3F-BF":
                    return 339;
                case "48-72-5C-DC":
                    return 596;
                case "48-89-C5-47":
                    return 240;
                case "49-AF-93-F3":
                    return 117;
                case "4A-71-53-BC":
                    return 40;
                case "4A-86-84-D6":
                    return 22;
                case "4A-94-E4-50":
                    return 41;
                case "4A-AF-89-AE":
                    return 664;
                case "4B-1A-1E-BF":
                    return 586;
                case "4B-6B-74-13":
                    return 387;
                case "4B-F5-3B-C7":
                    return 202;
                case "4B-FA-CE-5B":
                    return 161;
                case "4C-0A-55-79":
                    return 76;
                case "4C-18-35-FF":
                    return 401;
                case "4C-4E-0E-FF":
                    return 212;
                case "4C-FF-0C-96":
                    return 729;
                case "4D-3C-C7-77":
                    return 51;
                case "4D-44-5F-7A":
                    return 244;
                case "4D-68-EC-0E":
                    return 313;
                case "4D-6E-BD-76":
                    return 322;
                case "4D-91-90-CD":
                    return 739;
                case "4E-88-F2-4B":
                    return 298;
                case "4E-C7-85-8E":
                    return 369;
                case "4F-0E-6C-65":
                    return 734;
                case "4F-35-0B-44":
                    return 273;
                case "4F-A0-98-92":
                    return 34;
                case "4F-B2-F8-14":
                    return 44;
                case "4F-BD-B7-11":
                    return 676;
                case "4F-CE-26-10":
                    return 701;
                case "50-B8-60-F5":
                    return 560;
                case "50-BF-A1-10":
                    return 686;
                case "51-5E-96-2A":
                    return 317;
                case "51-C4-7D-66":
                    return 329;
                case "51-DE-82-6C":
                    return 546;
                case "51-E4-A0-DA":
                    return 534;
                case "51-E9-0C-AF":
                    return 398;
                case "51-FB-6C-29":
                    return 377;
                case "52-51-A1-C2":
                    return 80;
                case "52-65-B5-87":
                    return 544;
                case "53-03-57-1E":
                    return 564;
                case "53-E5-D3-4B":
                    return 714;
                case "54-02-CB-10":
                    return 520;
                case "54-4C-CA-25":
                    return 135;
                case "54-CF-10-EB":
                    return 14;
                case "54-DD-70-6D":
                    return 397;
                case "55-30-80-A8":
                    return 50;
                case "55-49-C1-54":
                    return 733;
                case "55-64-29-89":
                    return 531;
                case "56-22-BE-A1":
                    return 215;
                case "56-29-32-1C":
                    return 456;
                case "56-3C-CE-4E":
                    return 272;
                case "56-DF-1E-62":
                    return 532;
                case "56-F7-FC-E3":
                    return 491;
                case "57-06-2B-05":
                    return 219;
                case "57-4F-D0-85":
                    return 448;
                case "57-65-DD-00":
                    return 83;
                case "57-77-BD-86":
                    return 178;
                case "57-9C-B1-E0":
                    return 43;
                case "57-B9-FC-FB":
                    return 521;
                case "58-76-32-1B":
                    return 677;
                case "58-B9-CC-3B":
                    return 475;
                case "59-01-E0-5D":
                    return 504;
                case "59-DF-2E-A2":
                    return 473;
                case "59-E2-09-09":
                    return 72;
                case "59-F0-69-8F":
                    return 63;
                case "59-F7-CC-23":
                    return 563;
                case "5A-48-C4-E2":
                    return 438;
                case "5A-4C-57-89":
                    return 795;
                case "5A-5A-A4-64":
                    return 37;
                case "5A-64-19-49":
                    return 459;
                case "5A-BA-D7-B6":
                    return 639;
                case "5B-02-FB-D0":
                    return 626;
                case "5B-4C-CF-3D":
                    return 184;
                case "5C-C4-15-4D":
                    return 62;
                case "5C-DD-A9-21":
                    return 621;
                case "5D-4C-B5-8B":
                    return 358;
                case "5D-65-85-47":
                    return 640;
                case "5D-BB-4B-B8":
                    return 482;
                case "5E-00-7C-53":
                    return 468;
                case "5E-0C-63-F5":
                    return 275;
                case "5E-91-48-E5":
                    return 9;
                case "5F-66-9E-CA":
                    return 625;
                case "5F-6A-41-0B":
                    return 228;
                case "5F-7C-B8-20":
                    return 12;
                case "5F-B8-50-35":
                    return 497;
                case "60-6B-BE-BC":
                    return 502;
                case "60-BA-91-69":
                    return 680;
                case "61-09-E2-E0":
                    return 301;
                case "61-0D-5C-25":
                    return 464;
                case "61-0F-B3-98":
                    return 324;
                case "61-39-DD-75":
                    return 146;
                case "61-D3-92-DA":
                    return 495;
                case "62-48-D7-0B":
                    return 747;
                case "62-6E-8E-75":
                    return 374;
                case "62-81-70-18":
                    return 89;
                case "62-B6-6B-CE":
                    return 462;
                case "62-E9-FC-A5":
                    return 310;
                case "63-27-77-64":
                    return 357;
                case "63-54-05-AA":
                    return 281;
                case "63-85-7B-C7":
                    return 172;
                case "64-0E-47-27":
                    return 709;
                case "64-0F-DB-A6":
                    return 457;
                case "64-1F-C1-31":
                    return 419;
                case "64-27-95-66":
                    return 794;
                case "64-A2-3E-8D":
                    return 246;
                case "64-D1-15-59":
                    return 506;
                case "64-FE-81-43":
                    return 2;
                case "65-50-06-6D":
                    return 245;
                case "65-69-39-3F":
                    return 469;
                case "65-B7-F7-C0":
                    return 623;
                case "66-0C-C0-2B":
                    return 500;
                case "66-A3-67-83":
                    return 166;
                case "66-D2-0E-D4":
                    return 628;
                case "66-FA-EC-55":
                    return 562;
                case "67-91-A1-56":
                    return 16;
                case "67-9C-0E-CC":
                    return 569;
                case "67-A7-6C-5C":
                    return 94;
                case "67-B4-EC-4D":
                    return 485;
                case "67-F5-77-F6":
                    return 758;
                case "68-17-A2-5D":
                    return 318;
                case "68-42-F0-F3":
                    return 615;
                case "68-5A-F2-D3":
                    return 697;
                case "68-8A-3C-D2":
                    return 670;
                case "68-B4-DC-8D":
                    return 645;
                case "69-20-B8-55":
                    return 114;
                case "69-62-4D-7A":
                    return 192;
                case "69-D2-3E-14":
                    return 524;
                case "6A-50-B0-46":
                    return 297;
                case "6A-69-09-FF":
                    return 519;
                case "6A-98-15-38":
                    return 164;
                case "6B-0F-EB-66":
                    return 644;
                case "6B-E4-5F-B5":
                    return 199;
                case "6C-06-A4-11":
                    return 120;
                case "6C-0E-77-68":
                    return 649;
                case "6C-37-8B-97":
                    return 689;
                case "6C-44-51-3E":
                    return 196;
                case "6C-65-99-50":
                    return 254;
                case "6C-78-3B-D3":
                    return 778;
                case "6C-90-2E-9B":
                    return 328;
                case "6D-68-95-F1":
                    return 565;
                case "6E-01-F5-DA":
                    return 776;
                case "6E-78-53-1D":
                    return 700;
                case "6E-BD-36-A0":
                    return 359;
                case "6E-D0-23-77":
                    return 378;
                case "6E-D3-A2-1A":
                    return 527;
                case "6F-50-E3-8E":
                    return 430;
                case "6F-A4-9D-50":
                    return 241;
                case "6F-B5-40-83":
                    return 545;
                case "6F-DE-AE-BB":
                    return 250;
                case "70-1C-18-59":
                    return 807;
                case "70-79-D1-44":
                    return 355;
                case "70-94-AA-7E":
                    return 242;
                case "70-D9-32-20":
                    return 145;
                case "71-69-1A-09":
                    return 225;
                case "71-B0-38-AF":
                    return 773;
                case "71-E3-95-34":
                    return 595;
                case "71-E5-FD-C7":
                    return 140;
                case "72-1F-A5-85":
                    return 188;
                case "72-58-A2-DF":
                    return 556;
                case "72-5D-50-AA":
                    return 84;
                case "72-6D-6D-1B":
                    return 283;
                case "74-17-3C-F5":
                    return 681;
                case "74-22-A1-F1":
                    return 6;
                case "74-C3-E1-83":
                    return 421;
                case "74-C4-4B-41":
                    return 663;
                case "75-71-DC-50":
                    return 579;
                case "75-FB-1A-67":
                    return 722;
                case "76-55-76-72":
                    return 132;
                case "76-7B-66-CE":
                    return 790;
                case "77-7B-4C-EE":
                    return 104;
                case "78-A5-0A-67":
                    return 718;
                case "79-08-73-20":
                    return 235;
                case "79-1C-3D-61":
                    return 814;
                case "79-73-81-7D":
                    return 721;
                case "79-FC-98-E7":
                    return 110;
                case "7A-44-35-8A":
                    return 151;
                case "7A-5D-C0-A0":
                    return 280;
                case "7A-7C-43-0A":
                    return 26;
                case "7C-98-71-8C":
                    return 185;
                case "7C-C2-91-DF":
                    return 816;
                case "7C-DA-84-A3":
                    return 418;
                case "7D-3F-98-C4":
                    return 305;
                case "7D-DE-8F-7C":
                    return 171;
                case "7E-6F-55-51":
                    return 671;
                case "7E-A8-63-6C":
                    return 523;
                case "7E-D9-EE-7F":
                    return 368;
                case "7E-E3-A5-F4":
                    return 583;
                case "7F-62-29-CE":
                    return 154;
                case "7F-85-47-6D":
                    return 660;
                case "7F-8C-C3-3C":
                    return 429;
                case "7F-BF-0C-E6":
                    return 371;
                case "80-7E-5C-2D":
                    return 52;
                case "80-CC-59-E4":
                    return 320;
                case "80-DB-19-7F":
                    return 289;
                case "81-62-A6-D8":
                    return 772;
                case "81-7F-79-74":
                    return 748;
                case "81-93-AC-E8":
                    return 38;
                case "81-BD-FB-E6":
                    return 260;
                case "82-06-CC-0D":
                    return 264;
                case "82-2B-01-85":
                    return 408;
                case "83-86-05-CD":
                    return 226;
                case "83-C6-D9-C0":
                    return 224;
                case "83-C6-F1-40":
                    return 176;
                case "84-41-AA-06":
                    return 800;
                case "84-59-4E-8A":
                    return 338;
                case "84-A7-D0-2A":
                    return 47;
                case "84-B5-B0-AC":
                    return 17;
                case "85-42-5C-1B":
                    return 665;
                case "86-58-1E-E6":
                    return 214;
                case "86-63-37-CA":
                    return 102;
                case "86-A3-A8-A4":
                    return 706;
                case "86-ED-29-4E":
                    return 724;
                case "87-0D-1D-C1":
                    return 439;
                case "88-67-39-0D":
                    return 66;
                case "88-A1-7D-33":
                    return 760;
                case "8A-20-04-23":
                    return 55;
                case "8A-32-64-A5":
                    return 181;
                case "8A-B5-75-CC":
                    return 375;
                case "8A-BE-42-78":
                    return 684;
                case "8B-16-E5-F6":
                    return 605;
                case "8B-1D-A9-C1":
                    return 91;
                case "8B-36-6F-7A":
                    return 142;
                case "8B-C5-90-7E":
                    return 582;
                case "8B-C8-3F-E4":
                    return 48;
                case "8C-81-22-6B":
                    return 286;
                case "8C-AC-D5-8C":
                    return 74;
                case "8C-BE-B5-0A":
                    return 405;
                case "8D-31-0E-F7":
                    return 362;
                case "8F-14-78-E1":
                    return 78;
                case "8F-62-16-DE":
                    return 258;
                case "90-5D-CC-82":
                    return 515;
                case "90-67-EE-34":
                    return 550;
                case "90-AB-E0-FC":
                    return 633;
                case "90-DE-A4-BE":
                    return 725;
                case "90-FE-49-C5":
                    return 694;
                case "91-01-0C-AD":
                    return 653;
                case "91-15-05-40":
                    return 769;
                case "91-3B-2E-1B":
                    return 542;
                case "91-4F-8C-5A":
                    return 394;
                case "91-6A-E2-95":
                    return 270;
                case "92-93-0B-8A":
                    return 350;
                case "92-BA-3B-46":
                    return 554;
                case "92-FD-F4-E8":
                    return 813;
                case "93-10-D7-17":
                    return 609;
                case "94-7B-F0-98":
                    return 28;
                case "94-DD-45-D1":
                    return 511;
                case "94-E3-65-04":
                    return 704;
                case "95-84-60-DB":
                    return 19;
                case "95-A9-67-7F":
                    return 618;
                case "95-BB-A7-48":
                    return 540;
                case "95-E0-01-4A":
                    return 222;
                case "95-F7-AF-8D":
                    return 657;
                case "96-00-90-A3":
                    return 647;
                case "96-25-DD-B8":
                    return 35;
                case "96-4C-98-66":
                    return 659;
                case "96-D8-FE-9F":
                    return 303;
                case "96-F6-BC-DD":
                    return 478;
                case "97-43-3F-21":
                    return 70;
                case "97-4E-90-BB":
                    return 588;
                case "97-66-72-3A":
                    return 512;
                case "97-90-5E-44":
                    return 637;
                case "97-C3-5D-F5":
                    return 411;
                case "98-4E-A0-7B":
                    return 553;
                case "98-66-42-FA":
                    return 612;
                case "98-B8-8C-05":
                    return 490;
                case "99-00-A0-63":
                    return 570;
                case "99-28-42-E2":
                    return 655;
                case "99-56-E9-7A":
                    return 56;
                case "99-DA-4F-A5":
                    return 367;
                case "9A-BB-97-88":
                    return 449;
                case "9A-FC-24-91":
                    return 59;
                case "9B-70-78-EF":
                    return 742;
                case "9B-80-6E-1C":
                    return 163;
                case "9C-70-F5-3E":
                    return 392;
                case "9D-64-C5-79":
                    return 472;
                case "9D-81-AC-39":
                    return 295;
                case "9D-A8-CB-B1":
                    return 572;
                case "9D-BA-0B-86":
                    return 590;
                case "9E-25-A8-96":
                    return 406;
                case "9E-5A-13-B1":
                    return 802;
                case "9F-67-DE-F4":
                    return 630;
                case "9F-B9-10-0B":
                    return 607;
                case "9F-C8-58-53":
                    return 24;
                case "9F-DA-38-D5":
                    return 69;
                case "A0-78-3E-B5":
                    return 576;
                case "A0-B4-30-7D":
                    return 466;
                case "A0-E0-2C-85":
                    return 278;
                case "A1-0C-1C-1B":
                    return 483;
                case "A1-47-D3-CD":
                    return 327;
                case "A1-9F-5D-80":
                    return 423;
                case "A1-D2-D2-E4":
                    return 454;
                case "A2-27-F0-ED":
                    return 85;
                case "A2-65-05-C2":
                    return 200;
                case "A2-69-E5-0F":
                    return 452;
                case "A2-CE-0B-F7":
                    return 434;
                case "A2-FC-E4-26":
                    return 326;
                case "A3-03-18-30":
                    return 256;
                case "A3-0F-07-96":
                    return 494;
                case "A3-23-FB-32":
                    return 175;
                case "A3-C3-09-5E":
                    return 574;
                case "A3-D1-C9-69":
                    return 591;
                case "A4-B9-41-C4":
                    return 420;
                case "A4-D0-55-67":
                    return 592;
                case "A5-54-B1-01":
                    return 139;
                case "A5-68-79-01":
                    return 488;
                case "A5-B6-B7-FE":
                    return 610;
                case "A6-05-E7-76":
                    return 436;
                case "A6-25-62-94":
                    return 548;
                case "A6-D3-4E-EA":
                    return 635;
                case "A6-EC-1C-6C":
                    return 105;
                case "A6-FD-5B-2B":
                    return 96;
                case "A7-01-EC-A9":
                    return 98;
                case "A7-6B-62-8C":
                    return 662;
                case "A8-27-5A-89":
                    return 658;
                case "A8-6B-52-4C":
                    return 648;
                case "A8-9D-7E-32":
                    return 480;
                case "A9-0D-B0-D5":
                    return 513;
                case "A9-25-52-54":
                    return 589;
                case "A9-86-38-A0":
                    return 111;
                case "A9-C4-CD-8F":
                    return 204;
                case "A9-FB-9C-AB":
                    return 617;
                case "AA-3E-95-CD":
                    return 147;
                case "AA-73-BA-7C":
                    return 744;
                case "AA-B6-87-3E":
                    return 510;
                case "AB-2A-E5-91":
                    return 227;
                case "AB-8C-6C-AC":
                    return 699;
                case "AB-9C-6D-62":
                    return 656;
                case "AB-D0-65-A7":
                    return 646;
                case "AC-53-C3-8C":
                    return 209;
                case "AC-A0-24-E4":
                    return 416;
                case "AC-AD-57-0A":
                    return 308;
                case "AC-BA-17-91":
                    return 291;
                case "AC-D1-F9-A9":
                    return 555;
                case "AC-E2-D1-CB":
                    return 441;
                case "AC-F8-C9-65":
                    return 351;
                case "AD-0F-21-0E":
                    return 187;
                case "AD-4D-D4-21":
                    return 126;
                case "AD-DC-F5-08":
                    return 262;
                case "AD-E1-27-6F":
                    return 743;
                case "AE-0C-2C-DB":
                    return 566;
                case "AE-67-C2-E3":
                    return 266;
                case "AE-F5-79-4C":
                    return 150;
                case "AF-18-89-89":
                    return 138;
                case "AF-49-81-71":
                    return 220;
                case "AF-6A-CE-42":
                    return 557;
                case "AF-F6-63-7B":
                    return 427;
                case "B0-2D-57-39":
                    return 388;
                case "B0-AE-8D-F7":
                    return 149;
                case "B1-41-B6-BB":
                    return 763;
                case "B1-43-7D-32":
                    return 144;
                case "B1-4F-CB-3B":
                    return 332;
                case "B1-B0-5D-C6":
                    return 4;
                case "B2-00-BC-92":
                    return 292;
                case "B2-9B-3A-29":
                    return 783;
                case "B2-B9-25-70":
                    return 444;
                case "B2-FB-D0-5F":
                    return 88;
                case "B3-16-20-9A":
                    return 412;
                case "B3-FF-DB-80":
                    return 168;
                case "B4-65-61-76":
                    return 130;
                case "B4-84-21-04":
                    return 1;
                case "B5-7D-27-19":
                    return 604;
                case "B5-AE-52-91":
                    return 661;
                case "B5-EC-FC-BB":
                    return 737;
                case "B6-8D-29-D7":
                    return 349;
                case "B6-D9-C7-C4":
                    return 437;
                case "B7-34-37-01":
                    return 174;
                case "B7-DD-CC-1B":
                    return 97;
                case "B8-B7-E8-D7":
                    return 118;
                case "B8-F5-1D-F8":
                    return 193;
                case "B9-18-ED-3D":
                    return 205;
                case "B9-5A-18-12":
                    return 113;
                case "B9-EE-1E-D3":
                    return 777;
                case "BA-00-3C-FA":
                    return 715;
                case "BA-04-19-E4":
                    return 750;
                case "BA-A3-CD-CB":
                    return 23;
                case "BA-B9-F0-71":
                    return 315;
                case "BA-E2-B5-7F":
                    return 158;
                case "BB-0F-45-BA":
                    return 165;
                case "BB-C5-2F-52":
                    return 60;
                case "BC-3E-F1-79":
                    return 197;
                case "BC-7C-04-56":
                    return 124;
                case "BD-0B-EC-7B":
                    return 268;
                case "BE-AA-83-30":
                    return 402;
                case "BF-60-82-27":
                    return 372;
                case "BF-C4-A9-3B":
                    return 153;
                case "BF-DC-F2-12":
                    return 736;
                case "C0-0C-C9-39":
                    return 276;
                case "C0-CC-21-03":
                    return 238;
                case "C1-CC-9D-FA":
                    return 141;
                case "C2-36-C5-B8":
                    return 189;
                case "C2-F4-03-FE":
                    return 720;
                case "C3-22-88-E4":
                    return 719;
                case "C3-31-B4-0B":
                    return 806;
                case "C3-61-FA-DB":
                    return 356;
                case "C3-70-3B-48":
                    return 169;
                case "C3-77-16-E8":
                    return 232;
                case "C4-0B-C1-CC":
                    return 5;
                case "C4-3E-5C-C8":
                    return 673;
                case "C4-73-47-02":
                    return 675;
                case "C4-EA-81-BE":
                    return 422;
                case "C5-E6-31-09":
                    return 7;
                case "C6-15-1E-A4":
                    return 296;
                case "C6-41-15-4E":
                    return 578;
                case "C6-56-27-0C":
                    return 435;
                case "C6-5F-6F-F6":
                    return 711;
                case "C6-E2-CF-28":
                    return 717;
                case "C7-52-2C-D3":
                    return 101;
                case "C7-6E-91-5D":
                    return 311;
                case "C8-3C-64-82":
                    return 271;
                case "C9-97-0D-F5":
                    return 201;
                case "C9-D5-F8-DA":
                    return 413;
                case "CA-6D-55-B7":
                    return 152;
                case "CA-D7-FA-B8":
                    return 728;
                case "CB-B5-06-24":
                    return 759;
                case "CC-66-FB-FB":
                    return 603;
                case "CC-A7-27-79":
                    return 366;
                case "CC-B1-11-B1":
                    return 443;
                case "CC-F3-E4-9E":
                    return 417;
                case "CD-C1-C5-E0":
                    return 365;
                case "CE-46-35-6C":
                    return 679;
                case "CF-0F-11-4E":
                    return 774;
                case "CF-4B-49-F3":
                    return 155;
                case "CF-A5-A3-01":
                    return 428;
                case "D0-04-AC-00":
                    return 608;
                case "D1-10-BD-48":
                    return 148;
                case "D1-3D-D4-95":
                    return 780;
                case "D1-54-E6-CE":
                    return 213;
                case "D1-70-8E-AE":
                    return 536;
                case "D2-0B-FB-4A":
                    return 695;
                case "D2-46-AB-C4":
                    return 300;
                case "D2-77-6A-BE":
                    return 116;
                case "D2-A2-FC-9B":
                    return 10;
                case "D2-A8-10-25":
                    return 90;
                case "D2-CB-B9-45":
                    return 539;
                case "D3-65-30-41":
                    return 208;
                case "D3-AC-1B-FA":
                    return 433;
                case "D3-AD-5B-DC":
                    return 509;
                case "D3-BF-9B-EB":
                    return 632;
                case "D4-1D-EB-BB":
                    return 331;
                case "D4-29-5A-84":
                    return 702;
                case "D4-36-A1-0C":
                    return 129;
                case "D4-84-25-53":
                    return 636;
                case "D4-AC-C7-D2":
                    return 567;
                case "D4-D7-E1-7E":
                    return 3;
                case "D5-4A-EB-81":
                    return 389;
                case "D5-8F-A7-22":
                    return 247;
                case "D5-CA-25-4B":
                    return 561;
                case "D5-E2-C7-CA":
                    return 477;
                case "D6-34-90-C9":
                    return 251;
                case "D6-66-82-0E":
                    return 691;
                case "D6-71-12-A0":
                    return 654;
                case "D6-BD-1C-68":
                    return 619;
                case "D7-17-F0-39":
                    return 552;
                case "D7-72-C8-30":
                    return 346;
                case "D8-19-DE-92":
                    return 749;
                case "D8-A7-91-68":
                    return 601;
                case "D8-B8-F5-3C":
                    return 304;
                case "D8-F8-94-A6":
                    return 723;
                case "D9-05-0C-33":
                    return 277;
                case "D9-09-D8-68":
                    return 415;
                case "D9-4B-2D-47":
                    return 191;
                case "D9-AF-EC-9F":
                    return 450;
                case "DA-A0-59-20":
                    return 735;
                case "DA-B1-75-05":
                    return 162;
                case "DA-CA-15-8B":
                    return 594;
                case "DA-E2-F7-0A":
                    return 526;
                case "DA-EB-98-F0":
                    return 682;
                case "DB-58-EB-79":
                    return 319;
                case "DB-5E-BA-01":
                    return 323;
                case "DB-72-39-ED":
                    return 613;
                case "DB-84-15-93":
                    return 535;
                case "DB-97-E7-ED":
                    return 687;
                case "DB-AC-F7-12":
                    return 489;
                case "DB-CD-3F-88":
                    return 403;
                case "DC-2F-C4-2C":
                    return 121;
                case "DC-6D-31-03":
                    return 195;
                case "DC-73-A5-E3":
                    return 631;
                case "DC-AD-6B-1C":
                    return 606;
                case "DD-31-F7-7A":
                    return 781;
                case "DD-D7-9F-B2":
                    return 782;
                case "DE-0D-13-20":
                    return 764;
                case "DE-5F-4E-BE":
                    return 707;
                case "DE-70-BE-6E":
                    return 471;
                case "DF-3F-6C-3B":
                    return 340;
                case "DF-79-83-B3":
                    return 431;
                case "DF-8F-33-03":
                    return 793;
                case "E0-1B-7C-81":
                    return 493;
                case "E1-33-8B-FA":
                    return 211;
                case "E1-7D-9E-18":
                    return 451;
                case "E1-C0-6C-92":
                    return 46;
                case "E1-D2-0C-14":
                    return 18;
                case "E2-18-67-0C":
                    return 484;
                case "E2-2C-E1-2B":
                    return 757;
                case "E2-7A-7A-08":
                    return 108;
                case "E2-7D-AB-6C":
                    return 361;
                case "E2-B6-E4-11":
                    return 815;
                case "E2-C6-A9-F3":
                    return 453;
                case "E3-A0-4B-6A":
                    return 465;
                case "E3-B2-8B-5D":
                    return 522;
                case "E4-5D-6A-6C":
                    return 279;
                case "E4-89-35-E5":
                    return 525;
                case "E4-A1-D7-64":
                    return 593;
                case "E4-F4-10-50":
                    return 39;
                case "E5-19-E0-95":
                    return 53;
                case "E5-37-EE-C3":
                    return 99;
                case "E5-C4-28-19":
                    return 239;
                case "E5-C7-35-FD":
                    return 634;
                case "E5-EF-D7-7C":
                    return 533;
                case "E6-0B-DE-9C":
                    return 216;
                case "E6-7C-02-16":
                    return 487;
                case "E6-A2-CC-E9":
                    return 611;
                case "E7-05-3F-7F":
                    return 775;
                case "E7-41-CF-53":
                    return 804;
                case "E7-4C-BD-3D":
                    return 409;
                case "E7-5E-DD-BB":
                    return 180;
                case "E8-1A-D0-4F":
                    return 558;
                case "E8-1C-EF-82":
                    return 716;
                case "E8-5F-52-26":
                    return 669;
                case "E9-19-0A-DF":
                    return 347;
                case "E9-1E-DB-BB":
                    return 73;
                case "E9-49-B8-46":
                    return 330;
                case "E9-7C-32-D6":
                    return 551;
                case "E9-B4-DA-D2":
                    return 712;
                case "E9-CB-69-34":
                    return 75;
                case "E9-D9-09-B2":
                    return 404;
                case "EA-61-A4-DF":
                    return 157;
                case "EA-63-50-D1":
                    return 287;
                case "EA-65-21-8B":
                    return 768;
                case "EA-73-C4-59":
                    return 79;
                case "EA-C7-05-3D":
                    return 568;
                case "EA-EF-E7-BC":
                    return 616;
                case "EB-0F-9F-B3":
                    return 299;
                case "EB-30-84-D0":
                    return 753;
                case "EB-89-05-25":
                    return 479;
                case "EB-A1-E7-A4":
                    return 559;
                case "EC-31-21-A6":
                    return 221;
                case "EC-6D-C7-D7":
                    return 284;
                case "EC-7C-CF-38":
                    return 127;
                case "EC-A0-7B-AA":
                    return 538;
                case "EC-CE-EF-10":
                    return 373;
                case "ED-00-85-B5":
                    return 67;
                case "ED-C6-99-33":
                    return 508;
                case "EE-2E-03-43":
                    return 771;
                case "EE-7D-AE-D8":
                    return 507;
                case "EF-1B-4C-41":
                    return 537;
                case "EF-47-B8-9B":
                    return 54;
                case "EF-4C-FF-DF":
                    return 692;
                case "F0-E3-DC-63":
                    return 20;
                case "F1-1C-4C-20":
                    return 27;
                case "F2-0D-39-14":
                    return 602;
                case "F2-A4-E1-4D":
                    return 410;
                case "F4-28-30-E2":
                    return 395;
                case "F4-D9-FB-D2":
                    return 316;
                case "F5-64-02-DD":
                    return 285;
                case "F5-9F-2F-89":
                    return 703;
                case "F6-8A-96-1E":
                    return 678;
                case "F6-D7-FE-2E":
                    return 217;
                case "F7-23-09-EB":
                    return 218;
                case "F7-39-E5-97":
                    return 307;
                case "F7-3F-B4-EF":
                    return 325;
                case "F7-82-FD-09":
                    return 183;
                case "F8-9B-5A-D4":
                    return 792;
                case "F9-17-49-86":
                    return 393;
                case "F9-BB-3F-62":
                    return 354;
                case "F9-EE-A9-CC":
                    return 249;
                case "FA-55-9E-27":
                    return 253;
                case "FA-AF-E4-EB":
                    return 25;
                case "FA-BD-84-6D":
                    return 68;
                case "FB-42-14-2E":
                    return 407;
                case "FB-42-95-C2":
                    return 597;
                case "FB-AF-C0-9F":
                    return 698;
                case "FB-D3-AE-66":
                    return 159;
                case "FC-31-55-C2":
                    return 57;
                case "FD-1C-D4-07":
                    return 234;
                case "FE-04-60-01":
                    return 779;
                case "FE-23-3D-8C":
                    return 342;
                case "FE-27-A5-2A":
                    return 312;
                case "FE-59-A0-DB":
                    return 770;
                case "FE-A7-E3-EC":
                    return 236;
                case "FE-BA-3B-A5":
                    return 672;
                case "FF-89-09-B8":
                    return 688;
                case "FF-94-D7-2C":
                    return 666;
                case "FF-9B-98-29":
                    return 58;
                default:
                    return 0;
            }
        }

        public int pickYokaiHealthyIndex(string bytes)
        {
            switch (bytes)
            {
                case "00-00-00-00":
                    return 0;
                case "01-6A-1D-0F":
                    return 163;
                case "01-99-3D-FB":
                    return 156;
                case "02-90-45-4D":
                    return 51;
                case "02-D2-B0-62":
                    return 32;
                case "03-3F-40-A7":
                    return 14;
                case "04-4C-01-4B":
                    return 114;
                case "07-1D-57-3C":
                    return 192;
                case "07-F4-AC-26":
                    return 144;
                case "08-9E-88-EA":
                    return 139;
                case "08-DC-7D-C5":
                    return 12;
                case "09-31-8D-00":
                    return 3;
                case "09-73-78-2F":
                    return 162;
                case "0A-CB-D5-42":
                    return 140;
                case "0B-26-25-87":
                    return 35;
                case "0C-17-91-44":
                    return 89;
                case "0C-55-64-6B":
                    return 75;
                case "0F-03-23-F4":
                    return 184;
                case "0F-ED-C9-06":
                    return 190;
                case "11-B6-3D-BD":
                    return 173;
                case "12-0E-90-D0":
                    return 175;
                case "12-4C-65-FF":
                    return 176;
                case "12-E7-6B-CA":
                    return 118;
                case "13-0A-9B-0F":
                    return 83;
                case "14-90-21-F9":
                    return 115;
                case "15-7D-D1-3C":
                    return 141;
                case "16-C5-7C-51":
                    return 1;
                case "17-28-8C-94":
                    return 149;
                case "19-AF-58-9D":
                    return 91;
                case "19-ED-AD-B2":
                    return 172;
                case "1A-17-F5-F0":
                    return 95;
                case "1C-89-44-D9":
                    return 8;
                case "1C-CB-B1-F6":
                    return 50;
                case "1D-26-41-33":
                    return 193;
                case "1D-64-B4-1C":
                    return 109;
                case "1E-DC-19-71":
                    return 166;
                case "1F-31-E9-B4":
                    return 169;
                case "1F-DF-03-46":
                    return 133;
                case "21-66-EC-67":
                    return 64;
                case "24-40-F0-23":
                    return 27;
                case "25-18-BB-3C":
                    return 78;
                case "25-AD-00-E6":
                    return 146;
                case "29-7F-89-47":
                    return 34;
                case "2A-C7-24-2A":
                    return 148;
                case "2E-0C-C8-AB":
                    return 135;
                case "2F-E1-38-6E":
                    return 40;
                case "30-57-3C-10":
                    return 136;
                case "31-BA-CC-D5":
                    return 179;
                case "32-02-61-B8":
                    return 61;
                case "33-EF-91-7D":
                    return 106;
                case "34-9C-D0-91":
                    return 81;
                case "37-24-7D-FC":
                    return 98;
                case "39-A3-A9-F5":
                    return 19;
                case "3A-1B-04-98":
                    return 132;
                case "3B-F6-F4-5D":
                    return 63;
                case "3C-85-B5-B1":
                    return 82;
                case "3F-3D-18-DC":
                    return 92;
                case "41-35-2C-1D":
                    return 16;
                case "42-0E-5B-BE":
                    return 26;
                case "44-13-30-59":
                    return 72;
                case "45-30-1A-E1":
                    return 150;
                case "46-5F-B7-A0":
                    return 2;
                case "47-AB-9D-34":
                    return 125;
                case "49-AF-93-F3":
                    return 22;
                case "4A-94-E4-50":
                    return 9;
                case "4B-F5-3B-C7":
                    return 43;
                case "4B-FA-CE-5B":
                    return 65;
                case "4F-B2-F8-14":
                    return 147;
                case "51-E9-0C-AF":
                    return 126;
                case "52-51-A1-C2":
                    return 113;
                case "54-4C-CA-25":
                    return 54;
                case "54-CF-10-EB":
                    return 101;
                case "57-77-BD-86":
                    return 33;
                case "59-F0-69-8F":
                    return 197;
                case "5A-48-C4-E2":
                    return 45;
                case "5B-4C-CF-3D":
                    return 189;
                case "5F-6A-41-0B":
                    return 137;
                case "61-39-DD-75":
                    return 168;
                case "62-81-70-18":
                    return 39;
                case "63-85-7B-C7":
                    return 121;
                case "64-1F-C1-31":
                    return 187;
                case "66-A3-67-83":
                    return 170;
                case "67-A7-6C-5C":
                    return 105;
                case "69-20-B8-55":
                    return 66;
                case "69-62-4D-7A":
                    return 195;
                case "6A-98-15-38":
                    return 38;
                case "6B-E4-5F-B5":
                    return 167;
                case "6C-06-A4-11":
                    return 161;
                case "6C-44-51-3E":
                    return 48;
                case "6E-D0-23-77":
                    return 68;
                case "6F-50-E3-8E":
                    return 76;
                case "70-D9-32-20":
                    return 183;
                case "71-E5-FD-C7":
                    return 123;
                case "72-1F-A5-85":
                    return 120;
                case "72-5D-50-AA":
                    return 67;
                case "74-C3-E1-83":
                    return 23;
                case "77-7B-4C-EE":
                    return 154;
                case "79-FC-98-E7":
                    return 122;
                case "7A-44-35-8A":
                    return 127;
                case "7C-98-71-8C":
                    return 37;
                case "7C-DA-84-A3":
                    return 104;
                case "7D-DE-8F-7C":
                    return 15;
                case "7E-D9-EE-7F":
                    return 194;
                case "7F-62-29-CE":
                    return 152;
                case "7F-8C-C3-3C":
                    return 165;
                case "80-7E-5C-2D":
                    return 58;
                case "81-93-AC-E8":
                    return 90;
                case "82-2B-01-85":
                    return 10;
                case "83-C6-F1-40":
                    return 36;
                case "84-B5-B0-AC":
                    return 60;
                case "86-63-37-CA":
                    return 69;
                case "87-0D-1D-C1":
                    return 155;
                case "88-67-39-0D":
                    return 180;
                case "8A-32-64-A5":
                    return 128;
                case "8B-36-6F-7A":
                    return 188;
                case "8C-AC-D5-8C":
                    return 88;
                case "8F-14-78-E1":
                    return 112;
                case "91-4F-8C-5A":
                    return 178;
                case "95-84-60-DB":
                    return 20;
                case "99-56-E9-7A":
                    return 181;
                case "9B-80-6E-1C":
                    return 102;
                case "9C-70-F5-3E":
                    return 157;
                case "9E-25-A8-96":
                    return 142;
                case "9F-C8-58-53":
                    return 111;
                case "A1-47-D3-CD":
                    return 44;
                case "A1-9F-5D-80":
                    return 143;
                case "A2-27-F0-ED":
                    return 31;
                case "A2-65-05-C2":
                    return 55;
                case "A2-CE-0B-F7":
                    return 6;
                case "A3-23-FB-32":
                    return 85;
                case "A4-B9-41-C4":
                    return 119;
                case "A5-54-B1-01":
                    return 186;
                case "A6-EC-1C-6C":
                    return 164;
                case "A7-01-EC-A9":
                    return 13;
                case "A9-86-38-A0":
                    return 93;
                case "A9-C4-CD-8F":
                    return 49;
                case "AA-3E-95-CD":
                    return 159;
                case "AC-A0-24-E4":
                    return 117;
                case "AC-E2-D1-CB":
                    return 57;
                case "AD-0F-21-0E":
                    return 80;
                case "AD-4D-D4-21":
                    return 100;
                case "AE-F5-79-4C":
                    return 47;
                case "AF-F6-63-7B":
                    return 138;
                case "B0-2D-57-39":
                    return 79;
                case "B0-AE-8D-F7":
                    return 29;
                case "B1-43-7D-32":
                    return 182;
                case "B2-B9-25-70":
                    return 86;
                case "B2-FB-D0-5F":
                    return 62;
                case "B3-16-20-9A":
                    return 5;
                case "B3-FF-DB-80":
                    return 174;
                case "B4-65-61-76":
                    return 145;
                case "B7-34-37-01":
                    return 196;
                case "B7-DD-CC-1B":
                    return 116;
                case "B8-B7-E8-D7":
                    return 177;
                case "B8-F5-1D-F8":
                    return 53;
                case "B9-18-ED-3D":
                    return 18;
                case "B9-5A-18-12":
                    return 59;
                case "BA-E2-B5-7F":
                    return 11;
                case "BB-0F-45-BA":
                    return 110;
                case "BC-3E-F1-79":
                    return 17;
                case "BC-7C-04-56":
                    return 96;
                case "BE-AA-83-30":
                    return 71;
                case "BF-C4-A9-3B":
                    return 52;
                case "C0-CC-21-03":
                    return 4;
                case "C1-CC-9D-FA":
                    return 21;
                case "C2-36-C5-B8":
                    return 84;
                case "C3-70-3B-48":
                    return 56;
                case "C4-EA-81-BE":
                    return 7;
                case "C6-56-27-0C":
                    return 151;
                case "C7-52-2C-D3":
                    return 185;
                case "C9-97-0D-F5":
                    return 41;
                case "C9-D5-F8-DA":
                    return 30;
                case "CA-6D-55-B7":
                    return 130;
                case "CC-F3-E4-9E":
                    return 153;
                case "CF-4B-49-F3":
                    return 134;
                case "CF-A5-A3-01":
                    return 103;
                case "D1-10-BD-48":
                    return 191;
                case "D2-A8-10-25":
                    return 70;
                case "D3-AC-1B-FA":
                    return 97;
                case "D4-36-A1-0C":
                    return 124;
                case "D9-09-D8-68":
                    return 160;
                case "D9-4B-2D-47":
                    return 129;
                case "DA-B1-75-05":
                    return 107;
                case "DC-2F-C4-2C":
                    return 108;
                case "DC-6D-31-03":
                    return 171;
                case "DF-79-83-B3":
                    return 94;
                case "E1-C0-6C-92":
                    return 46;
                case "E7-5E-DD-BB":
                    return 158;
                case "E9-D9-09-B2":
                    return 87;
                case "EA-61-A4-DF":
                    return 73;
                case "EC-7C-CF-38":
                    return 28;
                case "EF-47-B8-9B":
                    return 74;
                case "F1-1C-4C-20":
                    return 131;
                case "F2-A4-E1-4D":
                    return 25;
                case "F7-82-FD-09":
                    return 42;
                case "FA-BD-84-6D":
                    return 77;
                case "FB-D3-AE-66":
                    return 24;
                case "FF-9B-98-29":
                    return 99;
                default:
                    return 0;
            }
        }
    }
}
