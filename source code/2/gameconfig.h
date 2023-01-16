#pragma execution_character_set("utf-8")

#ifndef GAMECONFIG
#define GAMECONFIG

#include<QtCore>

class GameConfig {
public:
    static const int SECTIONS_CNT = 0x10;
    static const quint8 defaultOrder[SECTIONS_CNT];
    static const quint8 sectionF2magic = 0x02;
    static const int YoukaiCountMax = 406;
    static const int ItemCountMax = 430;
    static const int EquipmentCountMax = 90;
    static const int ImportantCountMax = 180;
    static const int SoulCountMax = 100;
    enum GameTypeFlags {
        PREFFER_SJIS = 1 << 0,
        IS_SHINNUCHI = 1 << 1
    };
};

#endif // GAMECONFIG
