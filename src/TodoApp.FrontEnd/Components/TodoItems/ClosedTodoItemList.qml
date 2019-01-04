import QtQuick 2.12
import QtQuick.Controls 2.12
import QtQuick.Controls.Material 2.12
import QtQuick.Layouts 1.12
import TodoApp 1.0

Pane {
    id: todoItemList
    Layout.fillWidth: true
    Layout.fillHeight: true

    property TodoItemsController target: null

    StackLayout {
        anchors.fill: parent

        Column {
            spacing: 6

            Repeater {
                id: repeater
                model: Net.toListModel(ctrl.closedTodoItems)

                TodoItemCard {
                    target: todoItemList.target
                }
            }
        }
    }
}
