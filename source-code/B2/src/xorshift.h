#ifndef XORSHIFT_H
#define XORSHIFT_H

#include <QtCore>

class Xorshift {
public:
    Xorshift();
    Xorshift(quint32 seed);
    Xorshift(const QVector<quint32>& state);
    void initialize(quint32 seed);
    quint32 next(int divisor = 0);
    quint32 current(int divisor = 0);
    QVector<quint32> getState() const;
    void setState(const QVector<quint32>& value);

private:
    QVector<quint32> state;
};

#endif // XORSHIFT_H
