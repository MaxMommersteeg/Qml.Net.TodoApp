import QtQuick 2.11
import QtQuick.Controls 2.4
import QtQuick.Controls.Material 2.4
import QtQuick.Layouts 1.3

import "../Common"

Pane {
        id: openTodoItemCard
        width: parent.width
        height: 60
        Material.elevation: 1
        property int todoItemId: modelData.id
        property string todoItemTitle: modelData.title
        property string todoItemDescription: modelData.description

        MouseArea {
                hoverEnabled: true
                anchors.fill: parent
                onEntered: openTodoItemCard.Material.elevation = 3
                onExited: openTodoItemCard.Material.elevation = 1
                onClicked: todoItemDialog.open()
        }

        RowLayout {
                anchors.fill: parent

                ColumnLayout {

                        Text {
                                text: ctrl.toLocalDateTimeString(modelData.createdAt)
                                Layout.alignment: Qt.AlignLeft
                                font.pointSize: 8
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
                        text: "Done"
                        highlighted: true
                        Material.background: Material.Green
                        onClicked: ctrl.markAsDone(openTodoItemCard.todoItemId)
                }
        }

        TodoItemDialog {
                id: todoItemDialog
        }
}