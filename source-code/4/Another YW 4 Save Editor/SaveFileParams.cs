using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another_YW_4_Save_Editor
{
    internal class SaveFileParams
    {
        public Misc misc { get; set; } = new Misc();

        public List<Consumable> ConsumableList { get; set; } = new List<Consumable>();

        public List<Consumable> GenericSoulList { get; set; } = new List<Consumable>();

        public List<Equipment> EquipmentList { get; set; } = new List<Equipment>();

        public List<YoKaiSoul> YoKaiSoulList { get; set; } = new List<YoKaiSoul>();

        public List<YoKai> UserYoKaiList { get; set; } = new List<YoKai>();

        public List<YoKai> SellingYoKaiList { get; set; } = new List<YoKai>();

        public List<MainCharacter> MainCharacterList { get; set; } = new List<MainCharacter>();

        public int TotalItemQuantity1 { get; set; }

        public List<int> characterID2List { get; set; }

        public void mapParams(Stream str)
        {
            GetByteValue getByteValue = new GetByteValue();
            this.misc.LocalParams.PositionX = getByteValue.ExtractByteToFloat(str, 131);
            this.misc.LocalParams.PositionY = getByteValue.ExtractByteToFloat(str, 135);
            this.misc.LocalParams.PositionZ = getByteValue.ExtractByteToFloat(str, 139);
            this.misc.LocalParams.Map = getByteValue.ExtractByteArrayToString(str, 167, 4);
            this.misc.Money = getByteValue.ExtractByteToInt(str, 203, 4);
            this.misc.NateName = getByteValue.ExtractByteToString(str, 282, 24);
            this.misc.KatieName = getByteValue.ExtractByteToString(str, 318, 24);
            this.misc.SummerName = getByteValue.ExtractByteToString(str, 354, 24);
            this.misc.ToumaName = getByteValue.ExtractByteToString(str, 390, 24);
            this.misc.AkinoriName = getByteValue.ExtractByteToString(str, 426, 24);
            this.misc.JackName = getByteValue.ExtractByteToString(str, 462, 24);
            this.misc.MoneySpent = getByteValue.ExtractByteToInt(str, 1040, 4);
            this.misc.Gatcha.gatchaTries = getByteValue.ExtractByteToInt(str, 2082, 1);
            this.misc.Gatcha.gatchaMaxTries = getByteValue.ExtractByteToInt(str, 2083, 1);
            int initialOffset1 = 76579;
            for (int index = 0; index < 500; ++index)
            {
                this.ConsumableList.Add(new Consumable()
                {
                    ID1 = getByteValue.ExtractByteToInt(str, initialOffset1, 2),
                    ID2 = getByteValue.ExtractByteToInt(str, initialOffset1 + 2, 2),
                    ItemSignature = getByteValue.ExtractByteArrayToString(str, initialOffset1 + 12, 4),
                    Order = getByteValue.ExtractByteToInt(str, initialOffset1 + 24, 4),
                    Quantity = getByteValue.ExtractByteToInt(str, initialOffset1 + 36, 2)
                });
                initialOffset1 += 54;
            }
            int initialOffset2 = 103587;
            for (int index = 0; index < 1000; ++index)
            {
                this.EquipmentList.Add(new Equipment()
                {
                    ID1 = getByteValue.ExtractByteToInt(str, initialOffset2, 2),
                    ID2 = getByteValue.ExtractByteToInt(str, initialOffset2 + 2, 2),
                    ItemSignature = getByteValue.ExtractByteArrayToString(str, initialOffset2 + 12, 4),
                    Order = getByteValue.ExtractByteToInt(str, initialOffset2 + 24, 4),
                    Quantity = getByteValue.ExtractByteToInt(str, initialOffset2 + 36, 2),
                    Equipped = getByteValue.ExtractByteToInt(str, initialOffset2 + 46, 1)
                });
                initialOffset2 += 63;
            }
            int initialOffset3 = 958227;
            for (int index = 0; index < 100; ++index)
            {
                this.GenericSoulList.Add(new Consumable()
                {
                    ID1 = getByteValue.ExtractByteToInt(str, initialOffset3, 2),
                    ID2 = getByteValue.ExtractByteToInt(str, initialOffset3 + 2, 2),
                    ItemSignature = getByteValue.ExtractByteArrayToString(str, initialOffset3 + 12, 4),
                    Order = getByteValue.ExtractByteToInt(str, initialOffset3 + 24, 4),
                    Quantity = getByteValue.ExtractByteToInt(str, initialOffset3 + 36, 2)
                });
                initialOffset3 += 54;
            }
            int initialOffset4 = 963635;
            for (int index = 0; index < 500; ++index)
            {
                this.YoKaiSoulList.Add(new YoKaiSoul()
                {
                    ID1 = getByteValue.ExtractByteToInt(str, initialOffset4, 2),
                    ID2 = getByteValue.ExtractByteToInt(str, initialOffset4 + 2, 2),
                    ItemSignature = getByteValue.ExtractByteArrayToString(str, initialOffset4 + 12, 4),
                    Order = getByteValue.ExtractByteToInt(str, initialOffset4 + 24, 4),
                    WhiteQuantity = getByteValue.ExtractByteToInt(str, initialOffset4 + 36, 2),
                    RedQuantity = getByteValue.ExtractByteToInt(str, initialOffset4 + 38, 2),
                    GoldQuantity = getByteValue.ExtractByteToInt(str, initialOffset4 + 40, 2),
                    ItemFlag1 = getByteValue.ExtractByteToInt(str, initialOffset4 + 50, 1),
                    ItemFlag2 = getByteValue.ExtractByteToInt(str, initialOffset4 + 51, 1),
                    ItemFlag3 = getByteValue.ExtractByteToInt(str, initialOffset4 + 52, 1),
                    ItemFlag4 = getByteValue.ExtractByteToInt(str, initialOffset4 + 61, 1),
                    ItemFlag5 = getByteValue.ExtractByteToInt(str, initialOffset4 + 62, 1),
                    ItemFlag6 = getByteValue.ExtractByteToInt(str, initialOffset4 + 63, 1)
                });
                initialOffset4 += 80;
            }
            int initialOffset5 = 166627;
            for (int index = 0; index < 6; ++index)
            {
                this.MainCharacterList.Add(new MainCharacter()
                {
                    ID1 = getByteValue.ExtractByteToInt(str, initialOffset5, 2),
                    ID2 = getByteValue.ExtractByteToInt(str, initialOffset5 + 2, 2),
                    Character_Name = getByteValue.ExtractByteToString(str, initialOffset5 + 28, 24),
                    Character_Signature = getByteValue.ExtractByteArrayToString(str, initialOffset5 + 72, 4),
                    Character_Skill1 = getByteValue.ExtractByteArrayToString(str, initialOffset5 + 84, 4),
                    Character_Skill2 = getByteValue.ExtractByteArrayToString(str, initialOffset5 + 88, 4),
                    Character_Skill3 = getByteValue.ExtractByteArrayToString(str, initialOffset5 + 92, 4),
                    Character_Skill4 = getByteValue.ExtractByteArrayToString(str, initialOffset5 + 96, 4),
                    Character_Skill5 = getByteValue.ExtractByteArrayToString(str, initialOffset5 + 100, 4),
                    Character_Skill6 = getByteValue.ExtractByteArrayToString(str, initialOffset5 + 104, 4),
                    Character_XP = getByteValue.ExtractByteToInt(str, initialOffset5 + 132, 4),
                    Character_HP = getByteValue.ExtractByteToInt(str, initialOffset5 + 144, 4),
                    Character_YP = getByteValue.ExtractByteToInt(str, initialOffset5 + 156, 4),
                    Character_PG = getByteValue.ExtractByteToInt(str, initialOffset5 + 168, 4),
                    Character_Level = getByteValue.ExtractByteToInt(str, initialOffset5 + 180, 4),
                    Character_Flag1 = getByteValue.ExtractByteToInt(str, initialOffset5 + 204, 2),
                    Character_HPplus = getByteValue.ExtractByteToInt(str, initialOffset5 + 214, 2),
                    Character_YPplus = getByteValue.ExtractByteToInt(str, initialOffset5 + 216, 2),
                    Character_STplus = getByteValue.ExtractByteToInt(str, initialOffset5 + 218, 2),
                    Character_SPplus = getByteValue.ExtractByteToInt(str, initialOffset5 + 220, 2),
                    Character_PAplus = getByteValue.ExtractByteToInt(str, initialOffset5 + 222, 2),
                    Character_SAplus = getByteValue.ExtractByteToInt(str, initialOffset5 + 224, 2),
                    Character_Unknown1 = getByteValue.ExtractByteToInt(str, initialOffset5 + 254, 1),
                    Character_Unknown2 = getByteValue.ExtractByteToInt(str, initialOffset5 + 255, 1),
                    Character_Unknown3 = getByteValue.ExtractByteToInt(str, initialOffset5 + 256, 1),
                    Character_Unknown4 = getByteValue.ExtractByteToInt(str, initialOffset5 + 257, 1),
                    Character_Unknown5 = getByteValue.ExtractByteToInt(str, initialOffset5 + 258, 1),
                    Character_Unknown6 = getByteValue.ExtractByteToInt(str, initialOffset5 + 259, 1),
                    Character_Unknown7 = getByteValue.ExtractByteToInt(str, initialOffset5 + 268, 4),
                    Character_Unknown8 = getByteValue.ExtractByteToInt(str, initialOffset5 + 292, 4),
                    Character_Unknown9 = getByteValue.ExtractByteToInt(str, initialOffset5 + 317, 2),
                    Character_Unknown10 = getByteValue.ExtractByteToInt(str, initialOffset5 + 330, 2),
                    Character_Order = getByteValue.ExtractByteToInt(str, initialOffset5 + 344, 4),
                    Character_Unknown11 = getByteValue.ExtractByteToInt(str, initialOffset5 + 356, 4),
                    Character_Unknown12 = getByteValue.ExtractByteToInt(str, initialOffset5 + 380, 4),
                    Character_Unknown13 = getByteValue.ExtractByteToInt(str, initialOffset5 + 389, 1),
                    Character_Unknown14 = getByteValue.ExtractByteToInt(str, initialOffset5 + 398, 1),
                    Character_Unknown15 = getByteValue.ExtractByteToInt(str, initialOffset5 + 416, 1),
                    Character_Unknown16 = getByteValue.ExtractByteToInt(str, initialOffset5 + 425, 1),
                    Character_Unknown17 = getByteValue.ExtractByteToInt(str, initialOffset5 + 452, 1)
                });
                initialOffset5 += 469;
            }
            int initialOffset6 = 169449;
            for (int index = 0; index < 400; ++index)
            {
                this.UserYoKaiList.Add(new YoKai()
                {
                    ID1 = getByteValue.ExtractByteToInt(str, initialOffset6, 2),
                    ID2 = getByteValue.ExtractByteToInt(str, initialOffset6 + 2, 2),
                    YoKai_Name = getByteValue.ExtractByteToString(str, initialOffset6 + 28, 24),
                    YoKai_Signature = getByteValue.ExtractByteArrayToString(str, initialOffset6 + 72, 4),
                    YoKai_Skill1 = getByteValue.ExtractByteArrayToString(str, initialOffset6 + 84, 4),
                    YoKai_Skill2 = getByteValue.ExtractByteArrayToString(str, initialOffset6 + 88, 4),
                    YoKai_Skill3 = getByteValue.ExtractByteArrayToString(str, initialOffset6 + 92, 4),
                    YoKai_Skill4 = getByteValue.ExtractByteArrayToString(str, initialOffset6 + 96, 4),
                    YoKai_Skill5 = getByteValue.ExtractByteArrayToString(str, initialOffset6 + 100, 4),
                    YoKai_Skill6 = getByteValue.ExtractByteArrayToString(str, initialOffset6 + 104, 4),
                    YoKai_XP = getByteValue.ExtractByteToInt(str, initialOffset6 + 132, 4),
                    YoKai_HP = getByteValue.ExtractByteToInt(str, initialOffset6 + 144, 4),
                    YoKai_YP = getByteValue.ExtractByteToInt(str, initialOffset6 + 156, 4),
                    YoKai_PG = getByteValue.ExtractByteToInt(str, initialOffset6 + 168, 4),
                    YoKai_Level = getByteValue.ExtractByteToInt(str, initialOffset6 + 180, 4),
                    YoKai_Flag1 = getByteValue.ExtractByteToInt(str, initialOffset6 + 204, 2),
                    YoKai_HPplus = getByteValue.ExtractByteToInt(str, initialOffset6 + 214, 2),
                    YoKai_YPplus = getByteValue.ExtractByteToInt(str, initialOffset6 + 216, 2),
                    YoKai_STplus = getByteValue.ExtractByteToInt(str, initialOffset6 + 218, 2),
                    YoKai_SPplus = getByteValue.ExtractByteToInt(str, initialOffset6 + 220, 2),
                    YoKai_PAplus = getByteValue.ExtractByteToInt(str, initialOffset6 + 222, 2),
                    YoKai_SAplus = getByteValue.ExtractByteToInt(str, initialOffset6 + 224, 2),
                    YoKai_Unknown1 = getByteValue.ExtractByteToInt(str, initialOffset6 + 254, 1),
                    YoKai_Unknown2 = getByteValue.ExtractByteToInt(str, initialOffset6 + 255, 1),
                    YoKai_Unknown3 = getByteValue.ExtractByteToInt(str, initialOffset6 + 256, 1),
                    YoKai_Unknown4 = getByteValue.ExtractByteToInt(str, initialOffset6 + 257, 1),
                    YoKai_Unknown5 = getByteValue.ExtractByteToInt(str, initialOffset6 + 258, 1),
                    YoKai_Unknown6 = getByteValue.ExtractByteToInt(str, initialOffset6 + 259, 1),
                    YoKai_Unknown7 = getByteValue.ExtractByteToInt(str, initialOffset6 + 268, 4),
                    YoKai_Unknown8 = getByteValue.ExtractByteToInt(str, initialOffset6 + 292, 4),
                    YoKai_Unknown9 = getByteValue.ExtractByteToInt(str, initialOffset6 + 317, 2),
                    YoKai_Unknown10 = getByteValue.ExtractByteToInt(str, initialOffset6 + 330, 2),
                    YoKai_Order = getByteValue.ExtractByteToInt(str, initialOffset6 + 344, 4),
                    YoKai_Unknown11 = getByteValue.ExtractByteToInt(str, initialOffset6 + 356, 4),
                    YoKai_Unknown12 = getByteValue.ExtractByteToInt(str, initialOffset6 + 380, 1),
                    YoKai_Unknown13 = getByteValue.ExtractByteToInt(str, initialOffset6 + 389, 1),
                    YoKai_Unknown14 = getByteValue.ExtractByteToInt(str, initialOffset6 + 398, 1),
                    YoKai_Unknown15 = getByteValue.ExtractByteToInt(str, initialOffset6 + 416, 1),
                    YoKai_Unknown16 = getByteValue.ExtractByteToInt(str, initialOffset6 + 425, 1),
                    YoKai_Unknown17 = getByteValue.ExtractByteToInt(str, initialOffset6 + 452, 1)
                });
                initialOffset6 += 469;
            }
            this.characterID2List = new List<int>();
            foreach (MainCharacter mainCharacter in this.MainCharacterList)
            {
                if (mainCharacter.ID2 > 0)
                    this.characterID2List.Add(mainCharacter.ID2);
            }
            foreach (YoKai userYoKai in this.UserYoKaiList)
            {
                if (userYoKai.ID2 > 0)
                    this.characterID2List.Add(userYoKai.ID2);
            }
            this.characterID2List.Sort();
        }

        public MemoryStream injectParams(MemoryStream str)
        {
            SetByteValue setByteValue = new SetByteValue();
            setByteValue.InjectByteFromFloat(str, this.misc.LocalParams.PositionX, 131);
            setByteValue.InjectByteFromFloat(str, this.misc.LocalParams.PositionY, 135);
            setByteValue.InjectByteFromFloat(str, this.misc.LocalParams.PositionZ, 139);
            setByteValue.InjectByteFromByteString(str, this.misc.LocalParams.Map, 167);
            setByteValue.InjectByteFromInt(str, this.misc.Money, 203, 4);
            setByteValue.InjectByteFromString(str, this.misc.NateName ?? "", 282, 24);
            setByteValue.InjectByteFromString(str, this.misc.KatieName ?? "", 318, 24);
            setByteValue.InjectByteFromString(str, this.misc.SummerName ?? "", 354, 24);
            setByteValue.InjectByteFromString(str, this.misc.ToumaName ?? "", 390, 24);
            setByteValue.InjectByteFromString(str, this.misc.AkinoriName ?? "", 426, 24);
            setByteValue.InjectByteFromString(str, this.misc.JackName ?? "", 462, 24);
            setByteValue.InjectByteFromInt(str, this.misc.Gatcha.gatchaTries, 2082, 1);
            setByteValue.InjectByteFromInt(str, this.misc.Gatcha.gatchaMaxTries, 2083, 1);
            int initialOffset1 = 76579;
            foreach (Consumable consumable in this.ConsumableList)
            {
                setByteValue.InjectByteFromInt(str, consumable.ID1, initialOffset1, 2);
                setByteValue.InjectByteFromInt(str, consumable.ID2, initialOffset1 + 2, 2);
                setByteValue.InjectByteFromByteString(str, consumable.ItemSignature ?? "00-00-00-00", initialOffset1 + 12);
                setByteValue.InjectByteFromInt(str, consumable.Order, initialOffset1 + 24, 4);
                setByteValue.InjectByteFromInt(str, consumable.Quantity, initialOffset1 + 36, 2);
                initialOffset1 += 54;
            }
            setByteValue.InjectByteFromInt(str, this.ConsumableList.Where<Consumable>((Func<Consumable, bool>)(food => food.ID2 > 0)).Count<Consumable>(), 166587, 2);
            int initialOffset2 = 169449;
            foreach (YoKai userYoKai in this.UserYoKaiList)
            {
                setByteValue.InjectByteFromInt(str, userYoKai.ID1, initialOffset2, 2);
                setByteValue.InjectByteFromInt(str, userYoKai.ID2, initialOffset2 + 2, 2);
                setByteValue.InjectByteFromString(str, userYoKai.YoKai_Name, initialOffset2 + 28, 24);
                setByteValue.InjectByteFromByteString(str, userYoKai.YoKai_Signature, initialOffset2 + 72);
                setByteValue.InjectByteFromByteString(str, userYoKai.YoKai_Skill1, initialOffset2 + 84);
                setByteValue.InjectByteFromByteString(str, userYoKai.YoKai_Skill2, initialOffset2 + 88);
                setByteValue.InjectByteFromByteString(str, userYoKai.YoKai_Skill3, initialOffset2 + 92);
                setByteValue.InjectByteFromByteString(str, userYoKai.YoKai_Skill4, initialOffset2 + 96);
                setByteValue.InjectByteFromByteString(str, userYoKai.YoKai_Skill5, initialOffset2 + 100);
                setByteValue.InjectByteFromByteString(str, userYoKai.YoKai_Skill6, initialOffset2 + 104);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_XP, initialOffset2 + 132, 4);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_HP, initialOffset2 + 144, 4);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_YP, initialOffset2 + 156, 4);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_PG, initialOffset2 + 168, 4);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Level, initialOffset2 + 180, 4);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Flag1, initialOffset2 + 204, 2);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_HPplus, initialOffset2 + 214, 2);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_YPplus, initialOffset2 + 216, 2);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_STplus, initialOffset2 + 218, 2);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_SPplus, initialOffset2 + 220, 2);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_PAplus, initialOffset2 + 222, 2);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_SAplus, initialOffset2 + 224, 2);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown1, initialOffset2 + 254, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown2, initialOffset2 + 255, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown3, initialOffset2 + 256, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown4, initialOffset2 + 257, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown5, initialOffset2 + 258, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown6, initialOffset2 + 259, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown7, initialOffset2 + 268, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown8, initialOffset2 + 292, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown9, initialOffset2 + 317, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown10, initialOffset2 + 330, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Order, initialOffset2 + 330, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown11, initialOffset2 + 356, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown12, initialOffset2 + 380, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown13, initialOffset2 + 389, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown14, initialOffset2 + 398, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown15, initialOffset2 + 416, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown16, initialOffset2 + 425, 1);
                setByteValue.InjectByteFromInt(str, userYoKai.YoKai_Unknown17, initialOffset2 + 452, 1);
                initialOffset2 += 469;
            }
            int initialOffset3 = 944897;
            foreach (YoKai userYoKai in this.UserYoKaiList)
            {
                setByteValue.InjectByteFromInt(str, userYoKai.ID1, initialOffset3, 2);
                setByteValue.InjectByteFromInt(str, userYoKai.ID2, initialOffset3 + 2, 2);
                initialOffset3 += 4;
            }
            setByteValue.InjectByteFromInt(str, this.UserYoKaiList.Where<YoKai>((Func<YoKai, bool>)(yokai => yokai.ID2 > 0)).Count<YoKai>(), 946497, 4);
            int initialOffset4 = 166627;
            foreach (MainCharacter mainCharacter in this.MainCharacterList)
            {
                setByteValue.InjectByteFromInt(str, mainCharacter.ID1, initialOffset4, 2);
                setByteValue.InjectByteFromInt(str, mainCharacter.ID2, initialOffset4 + 2, 2);
                setByteValue.InjectByteFromString(str, mainCharacter.Character_Name, initialOffset4 + 28, 24);
                setByteValue.InjectByteFromByteString(str, mainCharacter.Character_Signature, initialOffset4 + 72);
                setByteValue.InjectByteFromByteString(str, mainCharacter.Character_Skill1, initialOffset4 + 84);
                setByteValue.InjectByteFromByteString(str, mainCharacter.Character_Skill2, initialOffset4 + 88);
                setByteValue.InjectByteFromByteString(str, mainCharacter.Character_Skill3, initialOffset4 + 92);
                setByteValue.InjectByteFromByteString(str, mainCharacter.Character_Skill4, initialOffset4 + 96);
                setByteValue.InjectByteFromByteString(str, mainCharacter.Character_Skill5, initialOffset4 + 100);
                setByteValue.InjectByteFromByteString(str, mainCharacter.Character_Skill6, initialOffset4 + 104);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_XP, initialOffset4 + 132, 4);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_HP, initialOffset4 + 144, 4);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_YP, initialOffset4 + 156, 4);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_PG, initialOffset4 + 168, 4);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Level, initialOffset4 + 180, 4);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Flag1, initialOffset4 + 204, 2);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_HPplus, initialOffset4 + 214, 2);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_YPplus, initialOffset4 + 216, 2);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_STplus, initialOffset4 + 218, 2);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_SPplus, initialOffset4 + 220, 2);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_PAplus, initialOffset4 + 222, 2);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_SAplus, initialOffset4 + 224, 2);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown1, initialOffset4 + 254, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown2, initialOffset4 + 255, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown3, initialOffset4 + 256, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown4, initialOffset4 + 257, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown5, initialOffset4 + 258, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown6, initialOffset4 + 259, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown7, initialOffset4 + 268, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown8, initialOffset4 + 292, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown9, initialOffset4 + 317, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown10, initialOffset4 + 330, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Order, initialOffset4 + 330, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown11, initialOffset4 + 356, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown12, initialOffset4 + 380, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown13, initialOffset4 + 389, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown14, initialOffset4 + 398, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown15, initialOffset4 + 416, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown16, initialOffset4 + 425, 1);
                setByteValue.InjectByteFromInt(str, mainCharacter.Character_Unknown17, initialOffset4 + 452, 1);
                initialOffset4 += 469;
            }
            int initialOffset5 = 946513;
            foreach (MainCharacter mainCharacter in this.MainCharacterList)
            {
                setByteValue.InjectByteFromInt(str, mainCharacter.ID1, initialOffset5, 2);
                setByteValue.InjectByteFromInt(str, mainCharacter.ID2, initialOffset5 + 2, 2);
                initialOffset5 += 4;
            }
            setByteValue.InjectByteFromInt(str, this.MainCharacterList.Where<MainCharacter>((Func<MainCharacter, bool>)(character => character.ID2 > 0)).Count<MainCharacter>(), 946537, 4);
            return str;
        }
    }
}
