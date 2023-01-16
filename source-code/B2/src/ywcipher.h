#ifndef YWCIPHER_H
#define YWCIPHER_H

#include "xorshift.h"
#include <QtCore>

class YWCipher : public Xorshift {
public:
    YWCipher(quint32 seed, int count);
    QByteArray* encrypt(const QByteArray& in);
    QByteArray* decrypt(const QByteArray& in);

private:
    QList<quint8> table;
    static const qint32 oddPrimes[];
};

#endif // YWCIPHER_H
