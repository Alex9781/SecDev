import QtQuick 2.15
import QtQuick.Window 2.15
import QtQuick.Controls 2.15
import QtQuick.Layouts 1.15

ApplicationWindow {
    id: root

    width: 640
    height: 480
    minimumWidth: 640 / 2
    minimumHeight: 480 / 2

    visible: true
    title: qsTr("Password Manager")

    property alias windowsStack: windowsStack

    Auth {
        id: authWindow
    }

    Index {
        id: indexWindow
        visible: false
    }

    StackView {
        id: windowsStack
        initialItem: authWindow
        anchors.fill: parent
    }

    Connections {
        target: authWindow
        function onSuccessLogIn() {
            windowsStack.push(indexWindow)
        }
    }
}
