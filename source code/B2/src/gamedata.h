#ifndef GAMEDATA_H
#define GAMEDATA_H

#include <QtCore>

typedef QPair<quint32, QHash<QString, QString> > dataentry_t;

class GameData {
private:
    GameData();
    GameData(const GameData&);
    GameData& operator=(const GameData&);
    ~GameData();

public:
    static GameData& getInstance()
    {
        static GameData instance;
        return instance;
    }
    const QList<dataentry_t>& getData(const QString& s);
    const QJsonArray& getJSONArrayData(const QString& s);
    const QJsonObject& getJSONObjectData(const QString& s);

private:
    QHash<QString, QList<dataentry_t> > data;
    QHash<QString, QJsonArray> jsonArrayData;
    QHash<QString, QJsonObject> jsonObjectData;
    QStringList availableData;
    QStringList availableJsonArrayData;
    QStringList availableJsonObjectData;
};

#endif // GAMEDATA_H
