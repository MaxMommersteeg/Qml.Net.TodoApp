import QtQuick 2.11
import QtQuick.Controls 2.4
import QtQuick.Controls.Material 2.4
import QtQuick.Layouts 1.3
import TodoApp 1.0

Pane {
	id: openTodoItemList
    Layout.fillWidth: true
    Layout.fillHeight: true

    property TodoItemsController target: null

    StackLayout {
        anchors.fill: parent

        Column {
            spacing: 6

            Text {
                text: "Open"
                Layout.alignment: Qt.AlignLeft
                font.pointSize: 14
                font.weight: Font.Bold
                color: '#000000'
                visible: repeater.count > 0 ? true : false
            }

            Repeater {
                id: repeater
                model: Net.toListModel(ctrl.openTodoItems)
                //Component.onCompleted: ctrl.initialize()

                TodoItemCard {
                    target: openTodoItemList.target
                }
            }
        }
    }
}