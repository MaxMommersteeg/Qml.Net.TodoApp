import QtQuick 2.9
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3

import "../Common"

Dialog {
    id: root

    property int todoItemId: -1
    property string todoItemTitle: ""
    property string todoItemDescription: ""

    modal: true
    focus: true
    title: todoItemTitle
    x: (window.width - width) / 2
    y: 0
    width: Math.min(window.width, window.height) / 3 * 2
    height: 200

	ColumnLayout {
        Layout.fillWidth: true
        Layout.fillHeight: true

        Label {
            width: root.availableWidth
            text: root.todoItemDescription
            wrapMode: Label.Wrap
            font.pixelSize: 14
            color: '#777777'
        }

        MaterialButton {
            text: "Delete"
            highlighted: true
            Layout.alignment: Qt.AlignRight
            Material.background: Material.Red
            onClicked: {
                if (root.todoItemId !== -1) {
                    ctrl.deleteTodoItem(todoItemId)
                    root.close()
                }
            }
        }
    }
}