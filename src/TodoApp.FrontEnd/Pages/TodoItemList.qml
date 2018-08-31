import QtQuick 2.6
import QtQuick.Controls 2.1
import QtQuick.Controls.Material 2.1
import TodoApp 1.0

Page {
        Column {
                anchors { horizontalCenter: parent.horizontalCenter; top: parent.top; topMargin: 20 }
                

                Row {
                        TextField {
                                id: txtTitle
                                placeholderText: "Title"
                        }
                }

                Button {
                        text: "Submit"
                        highlighted: true
                        Material.background: Material.Teal
                        onClicked: {
                                ctrl.addTodoItem(txtTitle.text)
                                txtTitle.text = null
                        }
                }
        }
        
        Column {
                spacing: 8

                Repeater {
                        id: repeater
                        model: Net.toJsArray(ctrl.todoItems)
                        Component.onCompleted : {
                                ctrl.initialize()
                        }

                        Pane {
                                width: parent.width
                                height: 60

                                Material.elevation: 6

                                Text {
                                        text: modelData.title
                                }
                        }
                }
        }

        TodoItemsController {
                id: ctrl
        }
}

