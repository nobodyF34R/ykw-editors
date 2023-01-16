#ifndef GASHASTATE_H
#define GASHASTATE_H

#include "savemanager.h"
#include "xorshift.h"

class GashaState {
public:
    GashaState();
    void setState(QByteArray in);
    quint32 currect(int rngId, int divisor);
    void advance(int rngId);
    QByteArray stateData() const;
    Xorshift getRNG(int rngId);

private:
    QVector<Xorshift> state;
};

#endif // GASHASTATE_H
