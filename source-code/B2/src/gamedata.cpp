#include "gamedata.h"

#include <QtCore>

GameData::GameData()
{
    this->availableData << "consume"
                        << "equipment_skill"
                        << "hackslash_battle"
                        << "hackslash_baura"
                        << "hackslash_consume"
                        << "hackslash_equipment"
                        << "hackslash_important"
                        << "hackslash_ogreball"
                        << "hackslash_technic"
                        << "hackslash_treasure_jewel"
                        << "hidden_treasure"
                        << "youkai"
                        << "youkaiNum";
    foreach (QString s, this->availableData) {
        QFile f(QString(":/data/data/%1.xml").arg(s));
        QFile g(QString(":/data/data/%1_%2.xml").arg(s).arg(QLocale().name()));
        QFile* file = &g;
        if (!g.exists()) {
            file = &f;
        }
        if (file->open(QIODevice::ReadOnly)) {
            QXmlStreamReader r;
            r.setDevice(&*file);
            while (!r.atEnd()) {
                r.readNext();
                if (r.isStartElement()) {
                    if (r.name().toString() == "item") {
                        QHash<QString, QString> item;
                        foreach (QXmlStreamAttribute attr, r.attributes()) {
                            if (attr.name() == "id") {
                                continue;
                            }
                            item[attr.name().toString()] = attr.value().toString();
                        }
                        this->data[s].append(qMakePair(r.attributes().value("id").toUInt(), item));
                    }
                }
            }
            f.close();
        }
    }

    this->availableJsonArrayData << "gashaData"
                                 << "trophy";
    foreach (QString s, this->availableJsonArrayData) {
        QFile f(QString(":/data/data/%1.json").arg(s));
        if (f.open(QIODevice::ReadOnly)) {
            QByteArray data = f.readAll();
            QJsonDocument doc = QJsonDocument::fromJson(data);
            this->jsonArrayData[s] = doc.array();
        }
    }
    this->availableJsonObjectData << "technic";
    foreach (QString s, this->availableJsonObjectData) {
        QFile f(QString(":/data/data/%1.json").arg(s));
        if (f.open(QIODevice::ReadOnly)) {
            QByteArray data = f.readAll();
            QJsonDocument doc = QJsonDocument::fromJson(data);
            this->jsonObjectData[s] = doc.object();
        }
    }
}

GameData::~GameData()
{
}

const QList<dataentry_t>& GameData::getData(const QString& s)
{
    return this->data[s];
}

const QJsonArray& GameData::getJSONArrayData(const QString& s)
{
    return this->jsonArrayData[s];
}

const QJsonObject& GameData::getJSONObjectData(const QString& s)
{
    return this->jsonObjectData[s];
}
