#ifndef SAVEMANAGER_H
#define SAVEMANAGER_H

#include "ccmcipher.h"
#include "crc32.h"
#include "error.h"
#include "section.h"
#include "ywcipher.h"
#include <QTreeWidget>
#include <QtCore>

class SaveManager {
public:
    SaveManager();
    ~SaveManager();
    bool loaded() const;
    QByteArray getSectionData(quint32 sectionId, bool withHeaderFooter = false);
    void setSectionData(const QByteArray& in, quint32 sectionId);
    Error::ErrorCode loadKeyFromHeadFile(QString path);
    Error::ErrorCode loadFile(QString path);
    Error::ErrorCode loadDecryptedFile(QString path);
    Error::ErrorCode writeFile(QString path);
    Error::ErrorCode writeDecryptedFile(QString path);
    template <class V>
    void writeSection(V val, int offset, quint32 sectionId);
    template <class V>
    V readSection(int offset, quint32 sectionId);
    template <class V>
    void writeRaw(V val, int offset);
    template <class V>
    V readRaw(int offset);
    QString readString(int offset, int lenInBytes, quint32 sectionId);
    void writeString(QString in, int offset, int lenInBytes, quint32 sectionId);
    QVector<bool> readBoolVector(int offset, int count, quint32 sectionId);
    void writeBoolVector(const QVector<bool>& v, int offset, quint32 sectionId);
    QString getFilepath() const;
    QTreeWidget* getTw() const;
    Section* getSectionById(quint32 id);
    int indexOfRaw(const QByteArray& ba, int from = 0) const;
    bool isVirtualSection(quint32 sectionId);

private:
    bool isLoaded;
    bool isModified;
    QString filepath;
    QByteArray bodyData;
    QByteArray ywcipherKey;
    QByteArray nonce;
    QByteArray aeskey;
    QByteArray crcvalue;
    QTreeWidget* tw;
    Error::ErrorCode parseSavedata(const QByteArray& bs);
    void writeout(QBuffer& f, bool legitSort = true);
    void writeoutRec(QBuffer& f, Section* s);
    void reorderF3();
    static QByteArray* processYW(QByteArray& in, bool isEncrypt);
    static quint32 readUint32(const QByteArray* in, int pos);
    static quint32 sub(const QByteArray* in, int index);
    static quint32 sub2(const QByteArray* in, int index);
    QByteArray genKey(QByteArray* head, int index);
    static const quint8 defaultOrder[];
    void separateSection36();
    void mergeSection36();
};

#endif // SAVEMANAGER_H
