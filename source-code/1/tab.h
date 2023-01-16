#pragma execution_character_set("utf-8")

#ifndef TAB_H
#define TAB_H

#include <QtCore>
#include <QWidget>

#include "savemanager.h"

class Tab : public QWidget
{
    Q_OBJECT

public:
    Tab(SaveManager *mgr, QWidget *parent=0, int sectionId=-1);
    int getSectionId() const;
    void setSectionId(int value);
    virtual void update() = 0;
    SaveManager *getMgr() const;
    void setMgr(SaveManager *value);

protected:
    int sectionId;
    template <class V> void write(V val, int offset);
    template <class V> V read(int offset);
    QString readString(int offset, int lenInBytes);
    void writeString(QString in, int offset, int lenInBytes);
    QVector<bool> readBoolVector(int offset, int count);
    void writeBoolVector(const QVector<bool> &v, int offset);

private:
    SaveManager *mgr;
};


#endif // TAB_H
