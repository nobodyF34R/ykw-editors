#pragma execution_character_set("utf-8")

#include "gamedata.h"

#include <QtCore>

GameData::GameData()
{
    this->availableData << "consume" << "equipment" << "important" << "youkai" << "creature";
    foreach (QString s, this->availableData) {
        QFile f(QString(":/data/data/%1.xml").arg(s));
        QFile g(QString(":/data/data/%1_%2.xml").arg(s).arg(QLocale().name()));
        QFile *file = &g;
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
                        this->data[s].append(
                                    qMakePair(
                                        r.attributes().value("id").toUInt(),
                                        r.attributes().value("name").toString())
                                    );
                    }
                }
            }
            f.close();
        }
    }
}

GameData::~GameData()
{

}

const QList<QPair<quint32, QString> > &GameData::getData(const QString& s)
{
    return this->data[s];
}
