﻿#pragma execution_character_set("utf-8")

#ifndef GAMEDATA_H
#define GAMEDATA_H

#include <QtCore>

typedef QPair<quint32, QHash<QString, QString> > dataentry_t;

class GameData
{
private:
    GameData();
    GameData(const GameData&);
    GameData& operator=(const GameData&);
    ~GameData();
public:
    static GameData& getInstance() {
        static GameData instance;
        return instance;
    }
    const QList<dataentry_t> &getData(const QString& s);

private:
    QHash<QString, QList<dataentry_t> > data;
    QStringList availableData;
};

#endif // GAMEDATA_H
