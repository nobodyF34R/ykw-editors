#pragma execution_character_set("utf-8")

#ifndef GAMEDATA_H
#define GAMEDATA_H

#include <QtCore>

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
    const QList<QPair<quint32, QString> > &getData(const QString& s);

private:
    QHash<QString, QList<QPair<quint32, QString> > > data;
    QStringList availableData;
};

#endif // GAMEDATA_H
