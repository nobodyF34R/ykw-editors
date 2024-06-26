﻿#pragma execution_character_set("utf-8")

#include <stdint.h>
#include "xorshift.h"

Xorshift::Xorshift(quint32 seed)
{
    this->initialize(seed);
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
