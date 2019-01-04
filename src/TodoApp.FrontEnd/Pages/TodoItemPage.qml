import QtQuick 2.12
import QtQuick.Controls 2.12
import QtQuick.Controls.Material 2.12
import QtQuick.Layouts 1.12
import TodoApp 1.0

import "../Components/TodoItems"

Page {
    width: parent.width

    ColumnLayout {
        anchors.fill: parent
        anchors.margins: 8

        AddTodoItemForm {
            id: addTodoItemForm
            target: ctrl
        }

        ClosedTodoItemList {
            id: closedTodoItemList
            target: ctrl
        }

        OpenTodoItemList {
            id: openTodoItemList
            target: ctrl
        }
    }

    TodoItemsController {
        id: ctrl

        Component.onCompleted: {
            ctrl.initialize()
        }

        function handleAddTodoItem(title, description) {
            console.log("Handle AddTodoItem called")
            ctrl.addTodoItem(title, description)
        }

        function handleCloseTodoItem(todoItemId) {
            console.log("Handle CloseTodoItem called")
            ctrl.closeTodoItem(todoItemId)
        }

        function handleOpenTodoItem(todoItemId) {
            console.log("Handle OpenTodoItem called")
            ctrl.openTodoItem(todoItemId)
        }

        function handleDeleteTodoItem(todoItemId) {
            console.log("Handle DeleteTodoItem called")
            ctrl.deleteTodoItem(todoItemId)
        }

        function handleOpenTodoItemDialog(todoItemId, title, description) {
            console.log("Handle OpenTodoItemDialog called")
            todoItemDialog.todoItemId = todoItemId
            todoItemDialog.todoItemTitle = title
            todoItemDialog.todoItemDescription = description
            todoItemDialog.open()
        }
    }

    TodoItemDialog {
        id: todoItemDialog
    }
}
