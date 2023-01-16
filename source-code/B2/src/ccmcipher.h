#ifndef CCMCIPHER_H
#define CCMCIPHER_H

#include <QtCore>
#include <string>

#include <cryptopp/aes.h>
#include <cryptopp/ccm.h>
#include <cryptopp/cryptlib.h>
#include <cryptopp/filters.h>

class CCMCipher {
public:
    CCMCipher(const QByteArray& key, const QByteArray& nonce);
    QByteArray* encrypt(const QByteArray& in);
    QByteArray* decrypt(const QByteArray& in);

private:
    QByteArray key;
    QByteArray nonce;
};

#endif // CCMCIPHER_H
