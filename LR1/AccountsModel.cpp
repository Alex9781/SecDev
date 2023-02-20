#include "AccountsModel.h"

AccountsModel::AccountsModel(QObject *parent) : QAbstractTableModel(parent) {}

AccountsModel::AccountsModel(SecureManager &sm, QObject *parent) : QAbstractTableModel(parent) {
    _json = sm.DecryptJSONDocumentFromFile();
}

int AccountsModel::rowCount(const QModelIndex &parent) const {
    return 3;
}

int AccountsModel::columnCount(const QModelIndex &parent) const {
    return 3;
}

QVariant AccountsModel::data(const QModelIndex &index, int role) const {
    if (!index.isValid())
        return QVariant();

    switch (role) {
    case site:
        return QVariant(_json.array()[index.row()].toObject()["site"]);
    case login:
        return QVariant(_json[index.row()]["login"]);
    case password:
        return QVariant(_json[index.row()]["password"]);
    }

    return QVariant();
}

QJsonDocument AccountsModel::CreateModel(QString password) {
    QJsonObject site1;
    QJsonObject site2;
    QJsonObject site3;

    site1.insert("site", "https://site1.qwe");
    site1.insert("login", "login1");
    site1.insert("password", SecureManager::EncryptString("qwerty", password));

    site2.insert("site", "https://site2.qwe");
    site2.insert("login", "login2");
    site2.insert("password", SecureManager::EncryptString("zxczxc", password));

    site3.insert("site", "https://site3.qwe");
    site3.insert("login", "login3");
    site3.insert("password", SecureManager::EncryptString("asdasd", password));

    QJsonArray sites;
    sites.append(site1);
    sites.append(site2);
    sites.append(site3);

    QJsonDocument json(sites);

    return json;
}
