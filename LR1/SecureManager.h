#ifndef SECUREMANAGER_H
#define SECUREMANAGER_H

#include <QObject>
#include <QFile>
#include <QJsonObject>
#include <QJsonDocument>
#include <QJsonArray>
#include <Qca-qt5/QtCrypto/qca.h>

class SecureManager {
public:
    SecureManager(QString password);
    ~SecureManager();

    bool FileEmpty();
    bool PasswordValid();

    QJsonDocument DecryptJSONDocumentFromFile();
    void EncryptJSONDocumentToFile(QJsonDocument json);

    static QString HashString(QString string);
    static QString EncryptString(QString string, QString password);
    static QString DecryptString(QString string, QString password);
private:
    QString _password;
    QFile _file;
    QJsonDocument _json;

    void OpenFile();
    void CloseFile();

    static QString EncryptOrDecryptString(QString string, QString password, QCA::Direction mode);
};

#endif // SECUREMANAGER_H
