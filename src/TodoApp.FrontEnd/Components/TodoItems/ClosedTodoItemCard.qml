import QtQuick 2.11
import QtQuick.Controls 2.4
import QtQuick.Controls.Material 2.4
import QtQuick.Layouts 1.3

import "../Common"

Pane {
        id: closedTodoItemCard
        width: parent.width
        height: 60
        Material.elevation: 1
        property int todoItemId: modelData.id
        property string todoItemTitle: modelData.title
        property string todoItemDescription: modelData.description

        MouseArea {
                hoverEnabled: true
                anchors.fill: parent
                onEntered: closedTodoItemCard.Material.elevation = 3
                onExited: closedTodoItemCard.Material.elevation = 1
                onClicked: todoItemDialog.open()
        }

        RowLayout {
                anchors.fill: parent

                ColumnLayout {

                        Text {
                                text: ctrl.toPeriodString(modelData.createdAt, modelData.closedAt)
                                Layout.alignment: Qt.AlignLeft
                                font.pointSize: 10
                                color: '#9e9e9e'
                        }

                        Text {
                                text: modelData.title
                                Layout.alignment: Qt.AlignLeft
                                font.pointSize: 14
                                font.weight: Font.Bold
                                color: '#777777'
                        }
                }

                MaterialButton {
                        Layout.alignment: Qt.AlignRight
                        text: "Open"
                        highlighted: true
                        Material.background: Material.Green
                        onClicked: ctrl.openTodoItem(closedTodoItemCard.todoItemId)
                }
        }

        TodoItemDialog {
                id: todoItemDialog
        }
}