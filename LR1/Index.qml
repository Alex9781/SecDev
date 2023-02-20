import QtQuick 2.15
import QtQuick.Controls 2.15
import QtQuick.Layouts 1.15

Item {
    TableView {
        anchors.fill: parent
        columnSpacing: 1
        rowSpacing: 1
        clip: true

        model: accountModel

        delegate: Rectangle {
            implicitWidth: 100
            implicitHeight: 50

            id: delegateRect
            RowLayout {
                Label {
                    id: site
                    text: model.site
                    font.pixelSize: 16
                    verticalAlignment: Text.AlignVCenter

                    Layout.fillHeight: true
                    Layout.fillWidth: true
                }
                Label {
                    id: login
                    text: qsTr("•").repeat(model.login.length)
                    font.pixelSize: 26

                    verticalAlignment: Text.AlignVCenter
                    Layout.fillHeight: true
                    Layout.preferredWidth: parent.width * 0.3
                }
                Label {
                    id: password
                    text: qsTr("•").repeat(model.password.length)
                    font.pixelSize: 26

                    verticalAlignment: Text.AlignVCenter
                    Layout.fillHeight: true
                    Layout.preferredWidth: parent.width * 0.3
                }
            }
        }
    }
}
