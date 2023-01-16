#pragma execution_character_set("utf-8")

#include "gamedata.h"

#include <QtCore>

GameData::GameData()
{
    this->availableData << "ai" << "creature" << "consume" << "equipment"
                        << "important" << "soul" << "youkai" << "youkaiNum";
    foreach (QString s, this->availableData) {
        QFile file(QString(":/data/data/%1.xml").arg(s));
        if (file.open(QIODevice::ReadOnly)) {
            QXmlStreamReader r;
            r.setDevice(&file);
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
            file.close();
        }
    }
}

GameData::~GameData()
{

}

const QList<dataentry_t> &GameData::getData(const QString& s)
{
    return this->data[s];
}
