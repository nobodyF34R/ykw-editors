#ifndef CRC32_H
#define CRC32_H

#include <QtCore>

class CRC32 {
public:
    CRC32();
    static quint32 calcCRC32(const QByteArray& in);

private:
    static const quint32 crc32_tab[];
};

#endif // CRC32_H
