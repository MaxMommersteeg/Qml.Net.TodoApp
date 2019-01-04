import QtQuick 2.12
import QtQuick.Controls 2.12
import QtQuick.Controls.Material 2.12
import QtQuick.Layouts 1.12
import TodoApp 1.0

import "../Behaviors"

Pane {
    id: todoItemCard
    width: parent.width
    height: 60
    Material.elevation: 1

    readonly property int itemId: modelData.id
    readonly property string itemTitle: modelData.title
    readonly property string itemDescription: modelData.description
    readonly property bool itemIsOpen: modelData.isOpen()
    
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
        onEntered: todoItemCard.Material.elevation = 5
        onExited: todoItemCard.Material.elevation = 1
        onClicked: todoItemCard.openTodoItemDialog(todoItemCard.itemId, todoItemCard.itemTitle, todoItemCard.itemDescription)
    }

    RowLayout {
        anchors.fill: parent

        ColumnLayout {

            Text {
                text: todoItemCard.itemIsOpen ? ctrl.toLocalDateTimeString(modelData.createdAt) : ctrl.toPeriodString(modelData.createdAt, modelData.closedAt)
                Layout.alignment: Qt.AlignLeft | Qt.AlignTop
                font.pointSize: 10
                color: '#9e9e9e'
            }

            Text {
                text: todoItemCard.itemTitle
                Layout.alignment: Qt.AlignLeft | Qt.AlignVCenter
                font.pointSize: 14
                font.weight: Font.Bold
                color: '#777777'
            }
        }

        Button {
            Layout.alignment: Qt.AlignRight | Qt.AlignVCenter
            text: todoItemCard.itemIsOpen ? "Close" : "Open"
            highlighted: true
            Material.background: todoItemCard.itemIsOpen ? Material.Orange : Material.Green

            PointingHandCursorOnHover {
                onClicked: todoItemCard.itemIsOpen ? todoItemCard.closeTodoItem(todoItemCard.itemId) : todoItemCard.openTodoItem(todoItemCard.itemId)
            }
        }
    }
}
