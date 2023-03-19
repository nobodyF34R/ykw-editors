#pragma execution_character_set("utf-8")

#include "gamedata.h"

#include <QtCore>

GameData::GameData()
{
    this->availableData << "creature"
                        << "consume"
                        << "equipment"
                        << "important"
                        << "soul"
                        << "youkai"
                        << "ai"
                        << "youkaiNum"
                        << "flags"
                        << "map"
                        << "hackslash"
                        << "busters_equipment"
                        << "busters_hidden_treasure";
    foreach (QString s, this->availableData) {
        QFile f(QString(":/data/data/%1.xml").arg(s));
        if (f.open(QIODevice::ReadOnly)) {
            QXmlStreamReader r;
            r.setDevice(&f);
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

    this->availableJsonData << "gashaData"
                            << "trophy";
    foreach (QString s, this->availableJsonData) {
        QFile f(QString(":/data/data/%1.json").arg(s));
        if (f.open(QIODevice::ReadOnly)) {
            QByteArray data = f.readAll();
            QJsonDocument doc = QJsonDocument::fromJson(data);
            this->jsonData[s] = doc.array();
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

const QJsonArray& GameData::getJSONData(const QString& s)
{
    return this->jsonData[s];
}
