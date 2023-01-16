#include "ccmcipher.h"

static const int TAG_SIZE = 16;

CCMCipher::CCMCipher(const QByteArray& key, const QByteArray& nonce)
    : key(key)
    , nonce(nonce)
{
}

QByteArray* CCMCipher::encrypt(const QByteArray& in)
{
    /*
     * in  : { plaintext (x byte) }
     * out : { MAC (16 byte), ciphertext (x byte) }
     */
    std::string plaintext(in.data(), in.size());
    std::string out;
    try {
        CryptoPP::CCM<CryptoPP::AES, TAG_SIZE>::Encryption e;
        e.SetKeyWithIV((unsigned char*)this->key.data(), this->key.size(),
            (unsigned char*)this->nonce.data(), this->nonce.size());
        e.SpecifyDataLengths(0, plaintext.size(), 0);

        /*
         *  StringSource destroys AuthenticatedEncryptionFilter and StringSink
         *  when it is destroyed. so no need to delete them.
         */
        CryptoPP::StringSource(plaintext, true,
            new CryptoPP::AuthenticatedEncryptionFilter(
                                   e, new CryptoPP::StringSink(out)));
    } catch (CryptoPP::Exception&) {
        return 0;
    }
    QByteArray* result = new QByteArray(out.c_str(), in.size());
    result->prepend(out.c_str() + in.size(), TAG_SIZE);
    return result;
}

QByteArray* CCMCipher::decrypt(const QByteArray& in)
{
    /*
     * in  : { MAC (16 byte), ciphertext (x byte) }
     * out : { plaintext (x byte) }
     */

    if (in.isEmpty()) {
        return 0;
    }
    // { MAC, ciphertext } -> { ciphertext, MAC}
    std::string ciphertext(in.data() + TAG_SIZE, in.size() - TAG_SIZE);
    ciphertext.append(in.data(), TAG_SIZE);

    std::string out;
    try {
        CryptoPP::CCM<CryptoPP::AES, TAG_SIZE>::Decryption d;
        d.SetKeyWithIV((unsigned char*)this->key.data(), this->key.size(),
            (unsigned char*)this->nonce.data(), this->nonce.size());
        d.SpecifyDataLengths(0, ciphertext.size() - TAG_SIZE, 0);

        CryptoPP::AuthenticatedDecryptionFilter df(
            d, new CryptoPP::StringSink(out));
        CryptoPP::StringSource(ciphertext, true, new CryptoPP::Redirector(df));
    } catch (CryptoPP::Exception&) {
        return 0;
    }
    QByteArray* result = new QByteArray(out.c_str(), in.size() - TAG_SIZE);
    return result;
}
