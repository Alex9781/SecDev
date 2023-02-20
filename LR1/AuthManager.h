#ifndef AUTHMANAGER_H
#define AUTHMANAGER_H

#include <QObject>

#include "SecureManager.h"
#include "AccountsModel.h"

class AuthManager : public QObject
{
    Q_OBJECT
public:
    explicit AuthManager(QObject *parent = 0);

public slots:
    void authBtnClicked(QString password);

signals:
    void pwdChecked(bool ok);

private:

};

#endif // AUTHMANAGER_H
