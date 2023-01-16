#include "savemanager.h"
#include <QFileInfo>

SaveManager::SaveManager()
    : isLoaded(false)
    , isModified(false)
    , tw(new QTreeWidget)
    , currentLocale(GameLocale::JP)
    , ignLength(ignLength_JP)
    , userLength(userLength_JP)
    , codec(QTextCodec::codecForName("Shift_JIS"))
{
    tw->setObjectName("savedataTree");
    tw->setHeaderLabel("section");
    tw->setColumnCount(1);
    tw->setSizePolicy(QSizePolicy::Fixed, QSizePolicy::Expanding);
    tw->setMaximumWidth(200);
}

SaveManager::~SaveManager()
{
    delete this->tw;
}

bool SaveManager::loaded() const
{
    return this->isLoaded;
}

QByteArray SaveManager::getSectionData(quint8 sectionId, bool withHeaderFooter)
{
    Section* s = this->getSectionById(sectionId);
    if (!s) {
        return QByteArray();
    }
    if (withHeaderFooter) {
        return this->bodyData.mid(s->getOffset() - 8, s->getSize() + 8 + 4);
    }
    return this->bodyData.mid(s->getOffset(), s->getSize());
}

void SaveManager::setSectionData(const QByteArray& in, quint8 sectionId)
{
    Section* s = this->getSectionById(sectionId);
    if (!s) {
        return;
    }
    this->bodyData.replace(s->getOffset(), s->getSize(), in);
}

quint32 SaveManager::readUint32(const QByteArray* in, int pos)
{
    QDataStream st(in->mid(pos, 4));
    st.setByteOrder(QDataStream::LittleEndian);
    quint32 r;
    st >> r;
    return r;
}

quint32 SaveManager::sub(const QByteArray* in, int i, int index)
{
    quint32 pos;
    if (index) {
        index -= 1;
    }
    if ((pos = index * this->userLength + 0x39C8)) {
        pos += this->ignLength + i * 4;
        return SaveManager::readUint32(in, pos);
    }
    return 0;
}

Error::ErrorCode SaveManager::loadDecryptedFile(QString path)
{
    QFile file(path);

    if (!file.open(QIODevice::ReadOnly)) {
        return Error::FILE_CANNOT_OPEN;
    }

    QByteArray bodydata = file.readAll();
    file.close();

    // set locale
    this->setLocale(static_cast<GameLocale>(bodydata.at(0xC)));

    QByteArray key;
    // decrypt first layer (AES CCM)
    nonce = bodydata.left(0x0C);
    key = bodydata.mid(0x10, 0x10);
    bodydata = bodydata.right(bodydata.size() - 0x20);

    // decrypt second layer (YWCipher)
    QByteArray ywkeyBytes = bodydata.right(4);

    // strip key
    bodydata.resize(bodydata.size() - 4);

    // split into sections
    Error::ErrorCode status = this->parseSavedata(bodydata);

    if (status != Error::SUCCESS) {
        return status;
    }

    // loaded successfully
    this->filepath = path;
    this->aeskey = key;
    this->nonce = nonce;
    this->ywcipherKey = ywkeyBytes;
    this->isLoaded = true;

    return Error::SUCCESS;
}

Error::ErrorCode SaveManager::loadFile(QString path)
{
    QFile file(path);

    QDir dir(QFileInfo(path).absolutePath());
    QFileInfo fileinfo(file);
    QFile head_yw(dir.filePath("head.yw"));
    QFile head_yw_g(dir.filePath("head.yw_g"));
    bool use_head_yw = false;

    if (!file.open(QIODevice::ReadOnly)) {
        return Error::FILE_CANNOT_OPEN;
    }

    bool head_yw_opened = head_yw.open(QIODevice::ReadOnly);
    bool head_yw_g_opened = head_yw_g.open(QIODevice::ReadOnly);

    if (!head_yw_opened && !head_yw_g_opened) {
        /* couldn't open both head candidates */
        file.close();
        return Error::HEAD_FILE_CANNOT_OPEN;
    } else if (!head_yw_opened) {
        /* couldn't open head.yw */
        use_head_yw = false;
    } else if (!head_yw_g_opened) {
        /* couldn't open head.yw_g */
        use_head_yw = true;
    } else {
        /*
         * if both files can be opened, in order of preference, use
         * 1. the one that has same extension to main file
         * 2. head.yw_g
         * 3. head.yw
         */
        if (fileinfo.suffix() == "yw") {
            use_head_yw = true;
            head_yw_g.close();
        } else {
            use_head_yw = false;
            head_yw.close();
        }
    }

    QByteArray bodydata = file.readAll();
    QByteArray headdata;
    if (use_head_yw) {
        headdata = head_yw.readAll();
        head_yw.close();
    } else {
        headdata = head_yw_g.readAll();
        head_yw_g.close();
    }
    file.close();

    QByteArray* decryptedHead = SaveManager::processYW(headdata, false);

    // set locale based on the size of head.yw
    if (headdata.length() >= 15180) {
        // US: 15180
        this->setLocale(GameLocale::NONJP);
    } else {
        // JP: 15156
        this->setLocale(GameLocale::JP);
    }
    // generate key
    QByteArray key1 = genKey(decryptedHead, 1);
    QByteArray key2 = genKey(decryptedHead, 2);
    QByteArray key3 = genKey(decryptedHead, 3);
    QByteArray& key = key1;

    delete decryptedHead;

    // decrypt first layer (AES CCM)
    QByteArray nonce = bodydata.left(0x0C);
    CCMCipher myCCM(key, nonce);
    QByteArray* decryptedFirst = myCCM.decrypt(bodydata.right(bodydata.size() - 0x10));
    if (!decryptedFirst) {
        key = key2;
        CCMCipher myCCM2(key, nonce);
        decryptedFirst = myCCM2.decrypt(bodydata.right(bodydata.size() - 0x10));
        if (!decryptedFirst) {
            key = key3;
            CCMCipher myCCM3(key, nonce);
            decryptedFirst = myCCM3.decrypt(bodydata.right(bodydata.size() - 0x10));
            if (!decryptedFirst) {
                return Error::DECRYPTION_CCM_FAILED;
            }
        }
    }

    // decrypt second layer (YWCipher)
    QByteArray ywkeyBytes = decryptedFirst->right(4);
    QByteArray* decryptedSecond = SaveManager::processYW(*decryptedFirst, false);
    delete decryptedFirst;
    if (!decryptedSecond) {
        return Error::DECRYPTION_YW_FAILED;
    }

    // strip CRC + key
    decryptedSecond->resize(decryptedSecond->size() - 8);

    // split into sections
    Error::ErrorCode status = this->parseSavedata(*decryptedSecond);

    delete decryptedSecond;
    if (status != Error::SUCCESS) {
        return status;
    }

    // loaded successfully
    this->filepath = path;
    this->aeskey = key;
    this->nonce = nonce;
    this->ywcipherKey = ywkeyBytes;
    this->isLoaded = true;

    return Error::SUCCESS;
}

QByteArray SaveManager::genKey(QByteArray* decryptedHead, int index)
{
    quint32 a;
    a = SaveManager::readUint32(decryptedHead, 0x0C);
    a ^= SaveManager::sub(decryptedHead, 0x0C, index);
    if (sub(decryptedHead, 0, index) & 0x4000) {
        a = ~a;
    }
    Xorshift myRNG(a);
    for (int i = sub(decryptedHead, 0x0A, index) & 0xFF; i > 0; --i) {
        myRNG.next();
    }
    QByteArray key;
    for (int i = 0; i < 0x10; i++) {
        key.append(myRNG.next(0x100));
    }
    return key;
}

SaveManager::GameLocale SaveManager::getCurrentLocale() const
{
    return currentLocale;
}

Error::ErrorCode SaveManager::writeDecryptedFile(QString path)
{
    QFile file(path);

    if (!file.open(QIODevice::WriteOnly)) {
        return Error::FILE_CANNOT_OPEN_TO_WRITE;
    }

    QByteArray bodydata;
    QBuffer buf;
    buf.open(QIODevice::WriteOnly);

    this->writeout(buf);
    bodydata.append(this->nonce);
    // store locale
    bodydata.append(static_cast<char>(this->currentLocale));
    bodydata.append(QByteArray(3, '\0'));
    bodydata.append(this->aeskey);
    bodydata.append(buf.data());
    bodydata.append(this->ywcipherKey);
    buf.close();

    // write
    file.write(bodydata);
    return Error::SUCCESS;
}

Error::ErrorCode SaveManager::writeFile(QString path)
{
    QFile file(path);

    if (!file.open(QIODevice::WriteOnly)) {
        return Error::FILE_CANNOT_OPEN_TO_WRITE;
    }

    QByteArray bodydata;
    QBuffer buf;
    buf.open(QIODevice::WriteOnly);

    this->writeout(buf);
    bodydata.append(buf.data());
    buf.close();
    bodydata.append(QByteArray(4, '\0'));
    bodydata.append(this->ywcipherKey);

    // encrypt second layer (YWCipher)
    QByteArray* encryptedSecond = SaveManager::processYW(bodydata, true);
    if (!encryptedSecond) {
        file.close();
        return Error::ENCRYPTION_YW_FAILED;
    }

    // encrypt first layer (AES CCM)
    CCMCipher myCCM(this->aeskey, this->nonce);
    QByteArray* encryptedFirst = myCCM.encrypt(*encryptedSecond);
    delete encryptedSecond;
    if (!encryptedFirst) {
        file.close();
        return Error::ENCRYPTION_CCM_FAILED;
    }

    // prepend nonce
    encryptedFirst->prepend(QByteArray(4, '\0'));
    encryptedFirst->prepend(this->nonce);

    // write
    file.write(*encryptedFirst);
    delete encryptedFirst;
    return Error::SUCCESS;
}

/*
 * Though the game uses cp932, which extends Shift_JIS,
 * I ignore the difference and treat as normal Shift_JIS.
 */
QString SaveManager::readString(int offset, int lenInBytes, quint8 sectionId)
{
    Section* s = this->getSectionById(sectionId);
    if (!s) {
        return QString("");
    }

    QByteArray str = this->bodyData.mid(s->getOffset() + offset, lenInBytes);
    { // null terminating
        int i = 0;
        for (; i < lenInBytes; ++i) {
            if (str.data()[i] == '\0') {
                break;
            }
        }
        lenInBytes = i;
    }
    if (!codec) {
        return QString("");
    }
    QString out = codec->toUnicode(str.data(), lenInBytes);
    return out;
}

void SaveManager::writeString(QString in, int offset, int lenInBytes, quint8 sectionId)
{
    Section* s = this->getSectionById(sectionId);
    if (!s) {
        return;
    }

    QByteArray str;
    if (!codec) {
        return;
    }
    for (int i = 1; i <= lenInBytes; ++i) {
        QByteArray newStr;
        newStr = codec->fromUnicode(in.left(i));
        if (newStr.size() <= lenInBytes) {
            str = newStr;
            continue;
        }
        break;
    }
    str.append('\0');
    this->bodyData.replace(s->getOffset() + offset, str.size(), str);
}

QVector<bool> SaveManager::readBoolVector(int offset, int count, quint32 sectionId)
{
    /*
     * The argument count is the minimum element count in the returned QVector<bool>
     */
    QVector<bool> out;
    int lenInBytes = (count + 8 - 1) / 8;
    for (int i = 0; i < lenInBytes; ++i) {
        quint8 d = this->readSection<quint8>(offset + i, sectionId);
        for (int j = 0; j < 8; ++j) {
            out.append(d & (1 << j));
        }
    }
    return out;
}

void SaveManager::writeBoolVector(const QVector<bool>& v, int offset, quint32 sectionId)
{
    /*
     * This function assumes v has 8*n elements, where n is a natural number.
     * If not, it regards left elements as false.
     * [1, 1, 1] -> [1, 1, 1, 0, 0, 0, 0, 0]
     */
    for (int i = 0; i < (v.count() + 8 - 1) / 8; ++i) {
        quint8 d = 0;
        for (int j = 0; j < 8; ++j) {
            if (v.value(i * 8 + j, false)) {
                d |= 1 << j;
            }
        }
        this->writeSection<quint8>(d, offset + i, sectionId);
    }
}

QString SaveManager::getFilepath() const
{
    if (this->loaded()) {
        return filepath;
    }
    return QDir::homePath();
}

QTreeWidget* SaveManager::getTw() const
{
    return tw;
}

Error::ErrorCode SaveManager::parseSavedata(const QByteArray& bs)
{
    QDataStream ds(bs);
    ds.setByteOrder(QDataStream::LittleEndian);

    QStack<Section*> lastParent;
    Section* root = 0;
    quint32 pos = 0;
    Error::ErrorCode error = Error::PARSE_ERROR;

    { // root node
        quint32 h1;
        ds >> h1;
        pos += 4;
        if (ds.atEnd()) {
            error = Error::PARSE_MAGIC_NOT_FOUND;
            goto err;
        }
        if ((h1 & 0xFFFF) == 0xFFFE) {
            quint32 h2, size;
            quint8 id;
            ds >> h2;
            pos += 4;
            id = h2 & 0xFF;
            size = h2 >> 8;
            root = new Section(0, id, size, pos);
            root->setExpanded(true);
            lastParent.push(root);
        } else {
            return Error::PARSE_MAGIC_NOT_FOUND;
        }
    }

    while (1) {
        quint32 h1, h2, size = 4, id;
        if (ds.atEnd()) {
            break;
        }
        ds >> h1;
        pos += 4;
        while ((h1 & 0xFFFF) == 0xFFFE) {
            ds >> h2;
            pos += 4;
            id = h2 & 0xFF;
            size = h2 >> 8;
            if (lastParent.isEmpty()) {
                error = Error::PARSE_ERROR;
                goto err;
            }
            if (pos + size <= (quint32)bs.size()) {
                Section* sec = new Section(0, id, size, pos);
                lastParent.top()->addChild(sec); // lastParent is not empty
                lastParent.push(sec);
            } else {
                error = Error::PARSE_INVALID_SIZE;
                goto err;
            }
            ds >> h1;
            pos += 4;
        }
        if ((h1 & 0xFFFF) == 0xFEFF) {
            lastParent.pop();
        }
        ds.skipRawData(size - 4);
        pos += size - 4;
    }

    if (lastParent.count()) { // no node should exist
        error = Error::PARSE_ERROR;
        goto err;
    }
    tw->clear();
    tw->addTopLevelItem(root);
    this->bodyData = bs;
    return Error::SUCCESS;
err:
    delete root;
    return error;
}

void SaveManager::writeout(QBuffer& f)
{
    QTreeWidgetItem* root_ = this->tw->topLevelItem(0);
    Section* root;
    if (root_ && root_->type() == Section::Type) {
        root = static_cast<Section*>(root_);
    } else {
        return;
    }
    this->reorderF3();
    this->writeoutRec(f, root);
}

void SaveManager::writeoutRec(QBuffer& f, Section* s)
{
    f.write(this->bodyData.mid(s->getOffset() - 8, 8)); // header
    if (s->childCount() == 0) {
        f.write(this->bodyData.mid(s->getOffset(), s->getSize() + 4)); // body + footer
    } else {
        for (int i = 0; i < s->childCount(); ++i) {
            this->writeoutRec(f, s->child(i));
        }
        f.write(this->bodyData.mid(s->getOffset() + s->getSize(), 4)); // footer
    }
}

void SaveManager::reorderF3()
{
    // re-ordering sections
    QList<quint8> order;
    Section* s;
    Xorshift rng_0x01(CRC32::calcCRC32(this->getSectionData(0x01, true)));
    Xorshift rng_0x03(CRC32::calcCRC32(this->getSectionData(0x03, true)));
    Xorshift rng_0x07(CRC32::calcCRC32(this->getSectionData(0x07, true)));
    for (int i = 0; i < GameConfig::SECTIONS_CNT; ++i) {
        order.append(GameConfig::defaultOrder[i]);
    }
    for (int i = 7; i > 0; --i) {
        int r = rng_0x01.next(i + 1);
        order.swap(r, i);
    }
    for (int i = 7; i > 0; --i) {
        int r = rng_0x03.next(i + 1);
        order.swap(r, i);
    }
    for (int i = 7; i > 0; --i) {
        int r = rng_0x07.next(i + 1);
        order.swap(r, i);
    }

    foreach (const quint8& sid, order) {
        if ((s = this->getSectionById(sid))) {
            QTreeWidgetItem* parent = s->parent();
            if (!parent) {
                continue;
            }
            parent->removeChild(s);
            parent->addChild(s);
        }
    }
}

Section* SaveManager::getSectionById(quint8 id)
{
    QString sid = QString::number(id, 10);
    QList<QTreeWidgetItem*> l = this->tw->findItems(sid, Qt::MatchExactly | Qt::MatchRecursive);
    if (l.size() > 0 && l.at(0)->type() == Section::Type) {
        return static_cast<Section*>(l.at(0));
    }
    return 0;
}

void SaveManager::setLocale(SaveManager::GameLocale locale)
{
    this->currentLocale = locale;
    switch (locale) {
    case GameLocale::JP:
        this->ignLength = ignLength_JP;
        this->userLength = userLength_JP;
        this->codec = QTextCodec::codecForName("Shift_JIS");
        break;
    case GameLocale::NONJP:
        this->ignLength = ignLength_NONJP;
        this->userLength = userLength_NONJP;
        this->codec = QTextCodec::codecForName("UTF-8");
        break;
    }
}

QString SaveManager::getLocaleName()
{
    switch (this->currentLocale) {
    case GameLocale::JP:
        return "JP";
    case GameLocale::NONJP:
        return "Non-JP";
    }
}

QByteArray* SaveManager::processYW(QByteArray& in, bool isEncrypt)
{
    /*
     * [decrypt (isEncyrpt = False)]  in: {ciphertext, crc value of ciphertext, key}
     *                               out: {plaintext, crc value of ciphertext, key}
     * [encrypt (isEncyrpt =  True)]  in: {plaintext, crc value of ciphertext, key}
     *                               out: {ciphertext, new crc value of ciphertext, key}
     * if isEncrypt = True, crc value will be recalculated.
     */
    QByteArray CRCandKey = in.right(8);
    quint32 crc32, key;
    crc32 = SaveManager::readUint32(&in, in.size() - 8);
    key = SaveManager::readUint32(&in, in.size() - 4);
    in.resize(in.size() - 8);

    if (!isEncrypt) {
        if (CRC32::calcCRC32(in) != crc32) {
            return NULL;
        }
    }

    YWCipher myCipher(key, 0x1000);
    // YWCipher exactly do the same thing in decryption and encryption
    QByteArray* decrypted = myCipher.decrypt(in);

    if (isEncrypt) {
        CRCandKey.clear();
        QDataStream ds(&CRCandKey, QIODevice::WriteOnly);
        ds.setByteOrder(QDataStream::LittleEndian);
        ds << CRC32::calcCRC32(*decrypted);
        ds << key;
    }
    decrypted->append(CRCandKey);
    return decrypted;
}

// explicit instantiations
template qint32 SaveManager::readSection(int offset, quint8 sectionId);
template quint32 SaveManager::readSection(int offset, quint8 sectionId);
template quint16 SaveManager::readSection(int offset, quint8 sectionId);
template quint8 SaveManager::readSection(int offset, quint8 sectionId);
template void SaveManager::writeSection(qint32 val, int offset, quint8 sectionId);
template void SaveManager::writeSection(quint32 val, int offset, quint8 sectionId);
template void SaveManager::writeSection(quint16 val, int offset, quint8 sectionId);
template void SaveManager::writeSection(quint8 val, int offset, quint8 sectionId);

template <class V>
V SaveManager::readSection(int offset, quint8 sectionId)
{
    Section* s = this->getSectionById(sectionId);
    if (!s) {
        return V(0);
    }
    QDataStream ds(&this->bodyData, QIODevice::ReadOnly);
    ds.setByteOrder(QDataStream::LittleEndian);
    ds.device()->seek(s->getOffset() + offset);
    V tmp;
    ds >> tmp;
    return tmp;
}

template <class V>
void SaveManager::writeSection(V val, int offset, quint8 sectionId)
{
    Section* s = this->getSectionById(sectionId);
    if (!s) {
        return;
    }
    QDataStream ds(&this->bodyData, QIODevice::WriteOnly);
    ds.setByteOrder(QDataStream::LittleEndian);
    ds.device()->seek(s->getOffset() + offset);
    ds << val;
}
