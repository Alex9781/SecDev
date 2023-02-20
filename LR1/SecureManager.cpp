#include "SecureManager.h"

SecureManager::SecureManager(QString password) {
    _password = password;
    OpenFile();
    _json = DecryptJSONDocumentFromFile();
}

SecureManager::~SecureManager() {
    CloseFile();
}

void SecureManager::OpenFile() {
    _file.setFileName("./accounts.data");
    _file.open(QIODevice::ReadWrite);
}

void SecureManager::CloseFile() {
    _file.close();
}

bool SecureManager::FileEmpty() {
    return _file.size() == 0 ? true : false;
}

bool SecureManager::PasswordValid() {
    return !_json.isEmpty();
}

QJsonDocument SecureManager::DecryptJSONDocumentFromFile() {
    _file.seek(0);
    QByteArray bytes = _file.readAll();
    QString dataAsString(bytes);
    dataAsString = SecureManager::DecryptString(dataAsString, _password);
    QJsonDocument json = QJsonDocument::fromJson(dataAsString.toUtf8());
    return json;
}

void SecureManager::EncryptJSONDocumentToFile(QJsonDocument json) {
    _file.seek(0);
    QByteArray jsonBytes(json.toJson());
    QString jsonString(jsonBytes);
    jsonString = SecureManager::EncryptString(jsonString, _password);
    _file.write(jsonString.toUtf8());
    _file.flush();
}

QString SecureManager::HashString(QString string) {
    return QCA::Hash("sha256").hashToString(string.toUtf8());
}

QString SecureManager::EncryptString(QString string, QString password) {
    return SecureManager::EncryptOrDecryptString(string, password, QCA::Encode);
}

QString SecureManager::DecryptString(QString string, QString password) {
    return SecureManager::EncryptOrDecryptString(string, password, QCA::Decode);
}

QString SecureManager::EncryptOrDecryptString(QString string, QString password, QCA::Direction mode) {
    QCA::SecureArray data;

    if (mode == QCA::Decode) data = QCA::hexToArray(string.toUtf8());
    else data = string.toUtf8();

    QCA::SymmetricKey key(password.toUtf8());
    QCA::InitializationVector iv(password.toUtf8());

    QCA::Cipher cipher(QStringLiteral("aes256"), QCA::Cipher::CBC, QCA::Cipher::DefaultPadding, mode, key, iv);
    QCA::SecureArray result = cipher.process(data);

    if (mode == QCA::Decode) return QString(result.toByteArray());
    else return QCA::arrayToHex(result.toByteArray());
}
