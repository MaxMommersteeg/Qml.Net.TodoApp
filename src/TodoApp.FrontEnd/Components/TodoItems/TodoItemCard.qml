import QtQuick 2.11
import QtQuick.Controls 2.4
import QtQuick.Controls.Material 2.4
import QtQuick.Layouts 1.3
import TodoApp 1.0

import "../Common"

Pane {
    id: todoItemCard
    width: parent.width
    height: 60
    Material.elevation: 1

    property int itemId: modelData.id
    property string itemTitle: modelData.title
    property string itemDescription: modelData.description
    property bool itemIsOpen: modelData.isOpen()
    property TodoItemsController target: null

    signal openTodoItem(int todoItemId)
    signal closeTodoItem(int todoItemId)
    signal openTodoItemDialog(int todoItemId, string title, string description)
    onTargetChanged: {
        if (todoItemCard.itemIsOpen) {
            closeTodoItem.connect(target.handleCloseTodoItem)	
        } else {
            openTodoItem.connect(target.handleOpenTodoItem)
        }

        openTodoItemDialog.connect(target.handleOpenTodoItemDialog)
    }

    MouseArea {
        hoverEnabled: true
        anchors.fill: parent
        onEntered: todoItemCard.Material.elevation = 3
        onExited: todoItemCard.Material.elevation = 1
        onClicked: todoItemCard.openTodoItemDialog(todoItemCard.itemId, todoItemCard.itemTitle, todoItemCard.itemDescription)
    }

    RowLayout {
        anchors.fill: parent

        ColumnLayout {

            Text {
                text: todoItemCard.itemIsOpen ? ctrl.toLocalDateTimeString(modelData.createdAt) : ctrl.toPeriodString(modelData.createdAt, modelData.closedAt)
                Layout.alignment: Qt.AlignLeft
                font.pointSize: 10
                color: '#9e9e9e'
            }

            Text {
                text: todoItemCard.itemTitle
                Layout.alignment: Qt.AlignLeft
                font.pointSize: 14
                font.weight: Font.Bold
                color: '#777777'
            }
        }

        MaterialButton {
            Layout.alignment: Qt.AlignRight
            text: todoItemCard.itemIsOpen ? "Close" : "Open"
            highlighted: true
            Material.background: todoItemCard.itemIsOpen ? Material.Red : Material.Green
            onClicked: todoItemCard.itemIsOpen ? todoItemCard.closeTodoItem(todoItemCard.itemId) : todoItemCard.openTodoItem(todoItemCard.itemId)
        }
    }
}