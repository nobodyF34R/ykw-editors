#ifndef SAVEMANAGER_H
#define SAVEMANAGER_H

#include "ccmcipher.h"
#include "crc32.h"
#include "error.h"
#include "gameconfig.h"
#include "section.h"
#include "ywcipher.h"
#include <QTreeWidget>
#include <QtCore>

class SaveManager {
public:
    enum class GameLocale : char {
        JP,
        NONJP /* this includes EU, KR, and US versions */
    };
    SaveManager();
    ~SaveManager();
    bool loaded() const;
    bool modified();
    QByteArray getSectionData(quint8 sectionId, bool withHeaderFooter = false);
    void setSectionData(const QByteArray& in, quint8 sectionId);
    Error::ErrorCode loadFile(QString path);
    Error::ErrorCode loadDecryptedFile(QString path);
    Error::ErrorCode writeFile(QString path);
    Error::ErrorCode writeDecryptedFile(QString path);
    template <class V>
    void writeSection(V val, int offset, quint8 sectionId);
    template <class V>
    V readSection(int offset, quint8 sectionId);
    QString readString(int offset, int lenInBytes, quint8 sectionId);
    void writeString(QString in, int offset, int lenInBytes, quint8 sectionId);
    QVector<bool> readBoolVector(int offset, int count, quint32 sectionId);
    void writeBoolVector(const QVector<bool>& v, int offset, quint32 sectionId);
    QString getFilepath() const;
    QTreeWidget* getTw() const;
    Section* getSectionById(quint8 id);
    void setLocale(GameLocale locale);
    QString getLocaleName();
    GameLocale getCurrentLocale() const;

private:
    bool isLoaded;
    bool isModified;
    QString filepath;
    QByteArray bodyData;
    QByteArray ywcipherKey;
    QByteArray nonce;
    QByteArray aeskey;
    QTreeWidget* tw;
    Error::ErrorCode parseSavedata(const QByteArray& bs);
    void writeout(QBuffer& f);
    void writeoutRec(QBuffer& f, Section* s);
    void reorderF3();
    static QByteArray* processYW(QByteArray& in, bool isEncrypt);
    static quint32 readUint32(const QByteArray* in, int pos);
    quint32 sub(const QByteArray* in, int i, int index);
    static const quint8 defaultOrder[];
    QByteArray genKey(QByteArray* decryptedHead, int index = 0);
    GameLocale currentLocale;
    int ignLength; /* length of ign in head.yw */
    int userLength;
    QTextCodec* codec;

    static const int ignLength_JP = 0x18;
    static const int ignLength_NONJP = 0x1C;
    static const int userLength_JP = 0x78;
    static const int userLength_NONJP = 0x80;
};

#endif // SAVEMANAGER_H
