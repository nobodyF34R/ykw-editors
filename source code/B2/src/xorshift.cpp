#include "xorshift.h"
#include <stdint.h>

Xorshift::Xorshift()
    : state(4)
{
}

Xorshift::Xorshift(quint32 seed)
    : state(4)
{
    this->initialize(seed);
}

Xorshift::Xorshift(const QVector<quint32>& state)
    : state(4)
{
    this->state[0] = state.at(0);
    this->state[1] = state.at(1);
    this->state[2] = state.at(2);
    this->state[3] = state.at(3);
}

void Xorshift::initialize(quint32 seed)
{
    if (seed == 0) {
        return;
    }
    seed = seed ^ (seed >> 30);
    seed = seed * (0x6C078966 - 1);
    seed = seed + 1;
    this->state[0] = seed;
    seed = seed ^ (seed >> 30);
    seed = seed * (0x6C078966 - 1);
    seed = seed + 2;
    this->state[1] = seed;
    seed = seed ^ (seed >> 30);
    seed = seed * (0x6C078966 - 1);
    seed = seed + 3;
    this->state[2] = seed;
    this->state[3] = 0x03DF95B3;
}

quint32 Xorshift::next(int divisor)
{
    uint32_t t;

    t = this->state[0] ^ (this->state[0] << 11);
    this->state[0] = this->state[1];
    this->state[1] = this->state[2];
    this->state[2] = this->state[3];
    this->state[3] = (this->state[3] ^ (this->state[3] >> 19)) ^ (t ^ (t >> 8));
    if (divisor > 0) {
        return this->state[3] % divisor;
    }
    return this->state[3];
}

quint32 Xorshift::current(int divisor)
{
    uint32_t out;
    if (divisor > 0) {
        out = this->state[3] % divisor;
    } else {
        out = this->state[3];
    }
    this->next();
    return out;
}

QVector<quint32> Xorshift::getState() const
{
    return this->state;
}
void Xorshift::setState(const QVector<quint32>& value)
{
    state = value;
}
