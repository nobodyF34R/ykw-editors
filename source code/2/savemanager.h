#pragma execution_character_set("utf-8")

#ifndef SAVEMANAGER_H
#define SAVEMANAGER_H

#include <QtCore>
#include <QTreeWidget>
#include "gameconfig.h"
#include "crc32.h"
#include "ywcipher.h"
#include "ccmcipher.h"
#include "error.h"
#include "section.h"

class SaveManager
{
public:
    SaveManager();
    ~SaveManager();
    bool loaded() const;
    bool modified();
    QByteArray getSectionData(quint8 sectionId, bool withHeaderFooter=false);
    void setSectionData(const QByteArray& in,quint8 sectionId);
    Error::ErrorCode loadKeyFromHeadFile(QString path);
    Error::ErrorCode loadFile(QString path);
    Error::ErrorCode loadDecryptedFile(QString path);
    Error::ErrorCode writeFile(QString path);
    Error::ErrorCode writeDecryptedFile(QString path);
    template <class V> void writeSection(V val, int offset, quint8 sectionId);
    template <class V> V readSection(int offset, quint8 sectionId);
    QString readString(int offset, int lenInBytes, quint8 sectionId);
    void writeString(QString in, int offset, int lenInBytes, quint8 sectionId);
    QVector<bool> readBoolVector(int offset, int count, quint8 sectionId);
    void writeBoolVector(const QVector<bool> &v, int offset, quint8 sectionId);
    QString getFilepath() const;
    QTreeWidget *getTw() const;
    Section *getSectionById(quint8 id);
    void setAeskey(const QByteArray &value);
    QByteArray getAeskey() const;
    quint32 getFlags() const;
    void setFlags(const quint32 &value);
    void updateFlags();

private:
    bool isLoaded;
    bool isModified;
    QString filepath;
    QByteArray bodyData;
    QByteArray ywcipherKey;
    QByteArray nonce;
    QByteArray aeskey;
    QTreeWidget *tw;
    Error::ErrorCode parseSavedata(const QByteArray &bs);
    void writeout(QBuffer &f);
    void writeoutRec(QBuffer &f, Section *s);
    void reorderF3();
    static QByteArray *processYW(QByteArray &in, bool isEncrypt);
    static quint32 readUint32(const QByteArray* in, int pos);
    static quint32 sub(const QByteArray* in, int i);
    static const quint8 defaultOrder[];
    quint32 flags;
};

#endif // SAVEMANAGER_H
