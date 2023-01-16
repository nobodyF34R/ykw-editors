#include "gamedata.h"

#include <QtCore>

GameData::GameData()
{
    this->availableData << "battle" << "consume" << "element" << "equipment"
                        << "important" << "soul" << "technic" << "youkai"
                        << "aura";
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

    this->availableJsonData << "technic";
    foreach (QString s, this->availableJsonData) {
        QFile f(QString(":/data/data/%1.json").arg(s));
        if (f.open(QIODevice::ReadOnly)) {
            QByteArray data = f.readAll();
            QJsonDocument doc = QJsonDocument::fromJson(data);
            this->jsonData[s] = doc.object();
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

const QJsonObject &GameData::getJSONData(const QString &s)
{
    return this->jsonData[s];
}
