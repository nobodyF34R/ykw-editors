#pragma execution_character_set("utf-8")

#ifndef GAMECONFIG
#define GAMECONFIG

#include <QtCore>

class GameConfig {
public:
    static const int SECTIONS_CNT = 0x16;
    static const quint8 defaultOrder[SECTIONS_CNT];
    static const quint8 sectionF2magic = 0x02;
    static const int YoukaiCountMax = 656;
    static const int ItemCountMax = 618;
    static const int EquipmentCountMax = 110;
    static const int ImportantCountMax = 240;
    static const int SoulCountMax = 100;
    static const int HackSlashCountMax = 48; // item box
    static const int BustersEquipmentCountMax = 4;
    static const int BustersItemBoxCountMax = 48;
    static const int BustersItemPouchCountMax = 9;
    static const int BustersHiddenTreasureCountMax = 16;
};

#endif // GAMECONFIG
