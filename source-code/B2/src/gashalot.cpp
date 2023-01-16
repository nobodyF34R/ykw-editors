#include "gashalot.h"
#include "gamedata.h"

#include <algorithm>

GashaLot::GashaLot(QJsonObject data, GashaState* st)
    : data(data)
    , st(st)
    , rng(0)
    , rng_menu(0x3A)
{
    if (!this->data.contains("seed")) {
        return;
    }
    this->rng = this->data["seed"].toInt();
}

GashaLot::~GashaLot()
{
}

QString GashaLot::lotName(bool isUSA)
{
    QJsonObject obj;
    if (isUSA) {
        if (!this->data.contains("usa")) {
            return QString("");
        }
        obj = this->data["usa"].toObject();
    } else {
        if (!this->data.contains("japan")) {
            return QString("");
        }
        obj = this->data["japan"].toObject();
    }

    Xorshift rng_tmp = this->st->getRNG(rng);
    Xorshift rng_menu_tmp = this->st->getRNG(rng_menu);
    QVector<int> lot1;
    QVector<int> lot2;
    QVector<int> lot3;
    QVector<int> lot4;

    foreach (QJsonValue v, obj["lot1"].toArray()) {
        lot1.append(v.toArray()[0].toInt());
    }
    foreach (QJsonValue v, obj["lot2"].toArray()) {
        lot2.append(v.toArray()[0].toInt());
    }
    foreach (QJsonValue v, obj["lot3"].toArray()) {
        lot3.append(v.toArray()[0].toInt());
    }
    foreach (QJsonValue v, obj["lot4"].toArray()) {
        lot4.append(v.toArray()[0].toInt());
    }

    if (obj["type"].toInt() == 1) {
        int sn;
        int index;
        QJsonArray lot1Rewards;
        QJsonArray lot2Rewards;
        QJsonArray lot3Rewards;
        QJsonArray lot4Rewards;
        QJsonArray lot1tmp = obj["lot1"].toArray();
        QJsonArray lot2tmp = obj["lot2"].toArray();
        QJsonArray lot3tmp = obj["lot3"].toArray();
        QJsonArray lot4tmp = obj["lot4"].toArray();

        if (this->data["id"].toVariant().toUInt() == 0) {
            // Terror time
            rng_menu_tmp.setState(rng_tmp.getState());
            for (int i = 0; i < this->getSeedIndex(); i++) {
                rng_menu_tmp.current();
            }
            // lot4
            for (int i = 0; i < 3; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot4.constBegin(), lot4.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot4);
                lot4Rewards.append(lot4tmp[index].toArray());
                lot4.remove(index);
                lot4tmp.removeAt(index);
            }
            // lot3
            for (int i = 0; i < 5; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot3.constBegin(), lot3.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot3);
                lot3Rewards.append(lot3tmp[index].toArray());
                lot3.remove(index);
                lot3tmp.removeAt(index);
            }
            // lot2
            for (int i = 0; i < 5; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot2.constBegin(), lot2.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot2);
                lot2Rewards.append(lot2tmp[index].toArray());
                lot2.remove(index);
                lot2tmp.removeAt(index);
            }
            // lot1
            for (int i = 0; i < 5; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot1.constBegin(), lot1.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot1);
                lot1Rewards.append(lot1tmp[index].toArray());
                lot1.remove(index);
                lot1tmp.removeAt(index);
            }

            int rn = rng_tmp.current(99);
            QString lotType;
            QJsonArray reward;
            if (rn < 15) {
                lotType = tr("LOT1");
                reward = lot1Rewards.at(rng_tmp.current(lot1Rewards.size())).toArray();
            } else if (rn < 50) {
                lotType = tr("LOT2");
                reward = lot2Rewards.at(rng_tmp.current(lot2Rewards.size())).toArray();
            } else if (rn < 90) {
                lotType = tr("LOT3");
                reward = lot3Rewards.at(rng_tmp.current(lot3Rewards.size())).toArray();
            } else {
                lotType = tr("LOT4");
                reward = lot4Rewards.at(rng_tmp.current(lot4Rewards.size())).toArray();
            }
            return QString("%1 (%2)").arg(this->idToName(reward[2].toVariant().toUInt(), reward[1].toBool())).arg(lotType);
        } else if (this->data["id"].toVariant().toUInt() == 675617994) {
            // Oni-gasha coin
            for (int i = 0; i < this->getSeedIndex(); i++) {
                rng_menu_tmp.current();
            }
            // lot4
            for (int i = 0; i < 1; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot4.constBegin(), lot4.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot4);
                lot4Rewards.append(lot4tmp[index].toArray());
                lot4.remove(index);
                lot4tmp.removeAt(index);
            }
            // lot3
            for (int i = 0; i < 5; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot3.constBegin(), lot3.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot3);
                lot3Rewards.append(lot3tmp[index].toArray());
                lot3.remove(index);
                lot3tmp.removeAt(index);
            }
            // lot2
            for (int i = 0; i < 5; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot2.constBegin(), lot2.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot2);
                lot2Rewards.append(lot2tmp[index].toArray());
                lot2.remove(index);
                lot2tmp.removeAt(index);
            }

            int rn = rng_tmp.current(100);
            QString lotType;
            QJsonArray reward;
            if (rn < 25) {
                lotType = tr("LOT2");
                reward = lot2Rewards.at(rng_tmp.current(lot2Rewards.size())).toArray();
            } else if (rn < 60) {
                lotType = tr("LOT3");
                reward = lot3Rewards.at(rng_tmp.current(lot3Rewards.size())).toArray();
            } else {
                lotType = tr("LOT4");
                reward = lot4Rewards.at(rng_tmp.current(lot4Rewards.size())).toArray();
            }
            return QString("%1 (%2)").arg(this->idToName(reward[2].toVariant().toUInt(), reward[1].toBool())).arg(lotType);
        } else {
            // normal coins
            for (int i = 0; i < this->getSeedIndex(); i++) {
                rng_menu_tmp.current();
            }
            // lot4
            for (int i = 0; i < 1; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot4.constBegin(), lot4.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot4);
                lot4Rewards.append(lot4tmp[index].toArray());
                lot4.remove(index);
                lot4tmp.removeAt(index);
            }
            // lot3
            for (int i = 0; i < 5; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot3.constBegin(), lot3.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot3);
                lot3Rewards.append(lot3tmp[index].toArray());
                lot3.remove(index);
                lot3tmp.removeAt(index);
            }
            // lot2
            for (int i = 0; i < 5; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot2.constBegin(), lot2.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot2);
                lot2Rewards.append(lot2tmp[index].toArray());
                lot2.remove(index);
                lot2tmp.removeAt(index);
            }
            // lot1
            for (int i = 0; i < 5; i++) {
                sn = rng_menu_tmp.current(std::accumulate(lot1.constBegin(), lot1.constEnd(), 0));
                index = GashaLot::findMatch(sn, lot1);
                lot1Rewards.append(lot1tmp[index].toArray());
                lot1.remove(index);
                lot1tmp.removeAt(index);
            }

            int rn = rng_tmp.current(100);
            QString lotType;
            QJsonArray reward;
            if (rn < 36) {
                lotType = tr("LOT1");
                reward = lot1Rewards.at(rng_tmp.current(lot1Rewards.size())).toArray();
            } else if (rn < 72) {
                lotType = tr("LOT2");
                reward = lot2Rewards.at(rng_tmp.current(lot2Rewards.size())).toArray();
            } else if (rn < 96) {
                lotType = tr("LOT3");
                reward = lot3Rewards.at(rng_tmp.current(lot3Rewards.size())).toArray();
            } else {
                lotType = tr("LOT4");
                reward = lot4Rewards.at(rng_tmp.current(lot4Rewards.size())).toArray();
            }
            return QString("%1 (%2)").arg(this->idToName(reward[2].toVariant().toUInt(), reward[1].toBool())).arg(lotType);
        }
    } else if (obj["type"].toInt() == 2) {
        QVector<int> lotsRate;
        lotsRate.append(std::accumulate(lot1.constBegin(), lot1.constEnd(), 0));
        lotsRate.append(std::accumulate(lot2.constBegin(), lot2.constEnd(), 0));
        lotsRate.append(std::accumulate(lot3.constBegin(), lot3.constEnd(), 0));
        lotsRate.append(std::accumulate(lot4.constBegin(), lot4.constEnd(), 0));

        int rn = rng_tmp.current(std::accumulate(lotsRate.constBegin(), lotsRate.constEnd(), 0));
        int rm;
        QString lotType;
        QJsonArray reward;
        if (rn < lotsRate.at(0)) {
            lotType = tr("LOT1");
            rm = rng_tmp.current(lotsRate.at(0));
            reward = obj["lot1"].toArray()[GashaLot::findMatch(rm, lot1)].toArray();
        } else if (rn < lotsRate.at(0) + lotsRate.at(1)) {
            lotType = tr("LOT2");
            rm = rng_tmp.current(lotsRate.at(1));
            reward = obj["lot2"].toArray()[GashaLot::findMatch(rm, lot2)].toArray();
        } else if (rn < lotsRate.at(0) + lotsRate.at(1) + lotsRate.at(2)) {
            lotType = tr("LOT3");
            rm = rng_tmp.current(lotsRate.at(2));
            reward = obj["lot3"].toArray()[GashaLot::findMatch(rm, lot3)].toArray();
        } else {
            lotType = tr("LOT4");
            rm = rng_tmp.current(lotsRate.at(3));
            reward = obj["lot4"].toArray()[GashaLot::findMatch(rm, lot4)].toArray();
        }
        return QString("%1 (%2)").arg(this->idToName(reward[2].toVariant().toUInt(), reward[1].toBool())).arg(lotType);
    }
    return QString("%1-%2").arg(rng_tmp.current(100)).arg(rng_tmp.current(25));
}

void GashaLot::advance()
{
    st->advance(this->rng);
}

int GashaLot::getSeedIndex()
{
    return this->data["seed"].toInt();
}

QString GashaLot::idToName(quint32 id, bool is_item)
{
    QList<dataentry_t>::const_iterator it;
    if (is_item) {
        const QList<dataentry_t> d2 = GameData::getInstance().getData("consume");
        const QList<dataentry_t> d3 = GameData::getInstance().getData("equipment");
        it = std::find_if(d2.constBegin(), d2.constEnd(), [=](const dataentry_t& d) { return d.first == id; });
        if (it != d2.constEnd()) {
            return (*it).second.value("name");
        }
        it = std::find_if(d3.constBegin(), d3.constEnd(), [=](const dataentry_t& d) { return d.first == id; });
        if (it != d3.constEnd()) {
            return (*it).second.value("name");
        }
    } else {
        const QList<dataentry_t> d1 = GameData::getInstance().getData("youkai");
        it = std::find_if(d1.constBegin(), d1.constEnd(), [=](const dataentry_t& d) { return d.first == id; });
        if (it != d1.constEnd()) {
            return (*it).second.value("name");
        }
    }
    return QString("%1").arg(id);
}

int GashaLot::findMatch(int num, const QVector<int>& array)
{
    int sum = 0;
    int i = 0;
    foreach (int n, array) {
        sum += n;
        if (num < sum) {
            return i;
        }
        i++;
    }
    return -1;
}
