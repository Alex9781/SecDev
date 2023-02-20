import QtQuick 2.15
import QtQuick.Controls 2.15
import QtQuick.Layouts 1.15

Item {
    id: authWindow
    signal successLogIn

    Popup {
        id: popup
        anchors.centerIn: Overlay.overlay
        width: 200
        height: 150
        modal: true
        focus: true

        ColumnLayout {
            anchors.fill: parent
            anchors.horizontalCenter: parent.horizontalCenter
            anchors.verticalCenter: parent.verticalCenter
            Label {
                Layout.alignment: Qt.AlignHCenter
                font.pixelSize: 18
                text: "Неверный пароль"
            }
            Button {
                id: okButton
                Layout.preferredWidth: 100
                Layout.preferredHeight: 40
                Layout.alignment: Qt.AlignHCenter
                text: "Ok"
                onClicked: popup.close()
            }
        }
    }

    ColumnLayout {
        anchors.horizontalCenter: parent.horizontalCenter
        anchors.verticalCenter: parent.verticalCenter

        TextField {
            id: authText

            anchors.horizontalCenter: parent.horizontalCenter
            anchors.bottom: authBtn.top
            anchors.bottomMargin: 5

            echoMode: TextInput.Password
        }

        Button {
            id: authBtn

            width: authText.width
            anchors.horizontalCenter: parent.horizontalCenter

            text: "Вход"

            onClicked: authManager.authBtnClicked(authText.text)
        }
    }

    Connections {
        target: authManager
        function onPwdChecked(ok) {
            if (ok) {
                authWindow.successLogIn()
            } else {
                popup.open()
            }
        }
    }
}
