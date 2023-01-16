#ifndef GASHALOT_H
#define GASHALOT_H

#include <QtCore>

#include "gashastate.h"
#include "xorshift.h"

class GashaLot : public QObject {
    Q_OBJECT

public:
    GashaLot(QJsonObject data, GashaState* st);
    ~GashaLot();
    QString lotName(bool isUSA = false);
    void advance();
    QVector<quint32> getState();
    void setState(QVector<quint32> s);
    void setMenuState(QVector<quint32> s);
    int getSeedIndex();

private:
    QJsonObject data;
    GashaState* st;
    QString idToName(quint32 id, bool is_item);
    static int findMatch(int num, const QVector<int>& array);
    int rng;
    int rng_menu;
};

#endif // GASHALOT_H
