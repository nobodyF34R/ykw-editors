#ifndef ERROR_H
#define ERROR_H

#include <QtCore>

class Error {
public:
    Error();
    static QString humanReadableString(int code);
    enum ErrorCode {
        SUCCESS = 0,
        IO_ERROR = 100,
        FILE_CANNOT_OPEN,
        FILE_CANNOT_OPEN_TO_WRITE,
        HEAD_FILE_CANNOT_OPEN,
        DECRYPTION_ERROR = 200,
        DECRYPTION_CCM_FAILED,
        DECRYPTION_YW_FAILED,
        DECRYPTION_HEAD_FAILED,
        ENCRYPTION_ERROR = 300,
        ENCRYPTION_CCM_FAILED,
        ENCRYPTION_YW_FAILED,
        PARSE_ERROR = 400,
        PARSE_MAGIC_NOT_FOUND,
        PARSE_INVALID_SIZE,
        PARSE_INVALID_SECTION_TYPE
    };
};

#endif // ERROR_H
