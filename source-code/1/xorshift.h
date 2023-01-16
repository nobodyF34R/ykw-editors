#pragma execution_character_set("utf-8")

#ifndef XORSHIFT_H
#define XORSHIFT_H

#include <QtCore>

class Xorshift
{
public:
    Xorshift(quint32 seed);
    void initialize(quint32 seed);
    quint32 next(int divisor = 0);
private:
    quint32 state[4];
};

#endif // XORSHIFT_H
