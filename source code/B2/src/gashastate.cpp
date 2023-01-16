#include "gashastate.h"

GashaState::GashaState()
    : state()
{
}

void GashaState::setState(QByteArray in)
{
    int states = in.length() / 16;
    QVector<quint32> s;
    QDataStream ds(in);
    ds.setByteOrder(QDataStream::LittleEndian);

    this->state = QVector<Xorshift>();
    for (int i = 0; i < states; ++i) {
        quint32 t, u, v, w;
        ds >> t >> u >> v >> w;
        s.append(t);
        s.append(u);
        s.append(v);
        s.append(w);
        this->state.append(Xorshift(s));
        s.clear();
    }
}

quint32 GashaState::currect(int rngId, int divisor)
{
    if (this->state.length() <= rngId) {
        return 0;
    }
    Xorshift rng = this->state.at(rngId);
    return rng.current(divisor);
}

void GashaState::advance(int rngId)
{
    if (this->state.length() <= rngId) {
        return;
    }
    Xorshift rng = this->state.at(rngId);
    rng.next();
    rng.next();
    this->state[rngId] = rng;
}

QByteArray GashaState::stateData() const
{
    QByteArray out;
    QDataStream ds(&out, QIODevice::WriteOnly);
    ds.setByteOrder(QDataStream::LittleEndian);
    foreach (const Xorshift& x, this->state) {
        QVector<quint32> s = x.getState();
        ds << s.at(0);
        ds << s.at(1);
        ds << s.at(2);
        ds << s.at(3);
    }
    return out;
}

Xorshift GashaState::getRNG(int rngId)
{
    if (this->state.length() <= rngId) {
        return Xorshift();
    }
    return this->state.at(rngId);
}
