import QtQuick 2.6
import QtQuick.Controls 2.1
import TodoApp 1.0

Page {
        Column {
                spacing: 40
                width: parent.width

                Row {
                        TextField {
                                id: txtTitle
                                placeholderText: "Title"
                        }
                }

                Button {
                        text: "Submit"
                        onClicked: {
                                ctrl.addTodoItem(txtTitle.text)
                        }
                }
        }

        Repeater {
                id: repeater
                model: Net.toJsArray(ctrl.todoItems)
                Column {
                        Text {
                                text: "Title: " + modelData.title
                        }
                }
        }

        TodoItemsController {
                id: ctrl
        }
}

