import QtQuick 2.12
import QtQuick.Controls 2.12
import QtQuick.Controls.Material 2.12
import QtQuick.Layouts 1.12

import "../Behaviors"

Dialog {
    id: root

    property int todoItemId: -1
    property string todoItemTitle: ""
    property string todoItemDescription: ""

    modal: true
    focus: true
    title: todoItemTitle
    x: (window.width - width) / 2
    y: 10
    width: Math.min(window.width, window.height) / 3 * 2
    height: Math.min(window.width, window.height) / 2

	ColumnLayout {
        Layout.fillWidth: true
        Layout.fillHeight: true
        anchors.fill: parent

        Label {
            text: root.todoItemDescription
            wrapMode: Text.WordWrap
            font.pixelSize: 14
            Layout.alignment: Qt.AlignLeft | Qt.AlignTop
            Layout.fillWidth: true
            color: '#777777'
        }

        Button {
            text: "Delete"
            highlighted: true
            Layout.alignment: Qt.AlignRight | Qt.AlignBottom
            Material.background: Material.Red

            PointingHandCursorOnHover { 
                onClicked: {
                    if (root.todoItemId !== -1) {
                        ctrl.deleteTodoItem(todoItemId)
                        root.close()
                    }
                }
            }
        }
    }
}
