#include "AuthManager.h"

AuthManager::AuthManager(QObject *parent) : QObject(parent){}

void AuthManager::authBtnClicked(QString password){
    SecureManager sm(password);

    if (sm.FileEmpty()) {
        QJsonDocument json = AccountsModel::CreateModel(password);
        sm.EncryptJSONDocumentToFile(json);
        AccountsModel am(sm);
        emit pwdChecked(true);
    } else {
        if (sm.PasswordValid()){
            emit pwdChecked(true);
        } else {
            emit pwdChecked(false);
        }
    }
}

