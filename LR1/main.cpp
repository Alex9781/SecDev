#include <QGuiApplication>
#include <QQmlApplicationEngine>
#include <QQmlContext>
#include <Qca-qt5/QtCrypto/qca.h>

#include "AuthManager.h"
#include "AccountsModel.h"

int main(int argc, char *argv[])
{
    QCA::Initializer init;

#if QT_VERSION < QT_VERSION_CHECK(6, 0, 0)
    QCoreApplication::setAttribute(Qt::AA_EnableHighDpiScaling);
#endif
    QGuiApplication app(argc, argv);

    QQmlApplicationEngine engine;
    QQmlContext *context = engine.rootContext();

    AuthManager authManager;
    context->setContextProperty("authManager", &authManager);

    AccountsModel accountModel;
    context->setContextProperty("accountModel", &accountModel);

    const QUrl url(QStringLiteral("qrc:/main.qml"));
    QObject::connect(&engine, &QQmlApplicationEngine::objectCreated,
                     &app, [url](QObject *obj, const QUrl &objUrl) {
        if (!obj && url == objUrl)
            QCoreApplication::exit(-1);
    }, Qt::QueuedConnection);
    engine.load(url);

    return app.exec();
}
