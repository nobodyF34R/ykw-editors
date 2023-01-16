#ifndef TAB_H
#define TAB_H

#include <QWidget>
#include <QtCore>

#include "savemanager.h"

class Tab : public QWidget {
    Q_OBJECT

public:
    Tab(SaveManager* mgr, QWidget* parent = 0, int sectionId = -1);
    int getSectionId() const;
    void setSectionId(int value);
    virtual void update() = 0;
    SaveManager* getMgr() const;
    void setMgr(SaveManager* value);
    template <class V>
    void write(V val, int offset);
    template <class V>
    V read(int offset);
    QString readString(int offset, int lenInBytes);
    void writeString(QString in, int offset, int lenInBytes);
    QByteArray getSectionData();
    void setSectionData(QByteArray in);

protected:
    int sectionId;

private:
    SaveManager* mgr;
};

#endif // TAB_H
