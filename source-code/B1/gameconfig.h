#ifndef GAMECONFIG
#define GAMECONFIG

#include <QtCore>

class GameConfig {
public:
    static const int SECTIONS_CNT = 8;
    static const quint8 defaultOrder[SECTIONS_CNT];
    static const quint8 sectionF2magic = 0x02;
};

#endif // GAMECONFIG
