#ifndef GAMECONFIG
#define GAMECONFIG

#include <QtCore>

class GameConfig {
public:
    static const int SECTIONS_CNT = 0x13;
    static const quint8 defaultOrder[SECTIONS_CNT];
    static const quint8 sectionF2magic = 0x02;
    static const int YoukaiCountMax = 766;
    static const int ItemCountMax = 1008;
    static const int BattleItemCountMax = 9;
    static const int EquipmentCountMax = 4;
    static const int ImportantCountMax = 240;

    // The following values are determined for the sake of convenience.
    // They aren't based on the size of the section, unlike others.
    // The sum of them should be less than or equal to ItemCountMax.
    static const int Section36EntrySize = 0x14;
    static const int HackslashBattleCountMax = 66;
    static const int HackslashEquipmentCountMax = 402; // confirmed
    static const int HackslashConsumeCountMax = 308;
    static const int HackslashImportantCountMax = 102; //confirmed

    // num1Offset >> 12
    static const quint16 HackslashBattleFlag = 0;
    static const quint16 HackslashEquipmentFlag = 1;
    static const quint16 HackslashConsumeFlag = 2;
    static const quint16 HackslashImportantFlag = 3;
};

#endif // GAMECONFIG
