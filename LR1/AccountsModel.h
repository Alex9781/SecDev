#ifndef ACCOUNTSMODEL_H
#define ACCOUNTSMODEL_H

#include <QAbstractTableModel>
#include <QJsonDocument>
#include <QJsonObject>
#include <QJsonArray>

#include "SecureManager.h"

class AccountsModel : public QAbstractTableModel
{
    Q_OBJECT
public:
    enum {
        site,
        login,
        password
    };

    explicit AccountsModel(QObject *parent = nullptr);
    explicit AccountsModel(SecureManager &sm, QObject *parent = nullptr);

    int rowCount(const QModelIndex &parent = QModelIndex()) const;
    int columnCount(const QModelIndex &parent = QModelIndex()) const;
    QVariant data(const QModelIndex &index, int role = Qt::DisplayRole) const;
//    QVariant headerData(int section, Qt::Orientation orientation, int role = Qt::DisplayRole) const;
//    bool setData(const QModelIndex &index, const QVariant &value, int role = Qt::EditRole);
//    Qt::ItemFlags flags(const QModelIndex &index) const;

    static QJsonDocument CreateModel(QString password);
    QJsonDocument _json;
private:
};

#endif // ACCOUNTSMODEL_H
