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
    const QJsonObject &getJSONData(const QString& s);
private:
    QHash<QString, QList<dataentry_t> > data;
    QHash<QString, QJsonObject> jsonData;
    QStringList availableData;
    QStringList availableJsonData;
};

#endif // GAMEDATA_H
