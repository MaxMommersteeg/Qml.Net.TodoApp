import QtQuick 2.6
import QtQuick.Controls 2.1
import QtQuick.Controls.Material 2.1
import QtQuick.Layouts 1.3
import TodoApp 1.0

import "../Components"

Page {
        width: parent.width

        ColumnLayout {
                anchors.fill: parent
                anchors.margins: 8

                Pane {
                        Layout.fillWidth: true

                        RowLayout {
                                anchors.fill: parent
                                TextField {
                                        id: txtTitle
                                        placeholderText: "Title"
                                        Layout.fillWidth: true
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
                }

                Divider { }

                Text {
                        text: "Todo items"
                        Layout.fillWidth: true
                }

                Pane {
                        Layout.fillWidth: true
                        Layout.fillHeight: true

                        StackLayout {
                                anchors.fill: parent

                                Column {
                                        spacing: 6

                                        Repeater {
                                                model: Net.toJsArray(ctrl.todoItems)
                                                Component.onCompleted : {
                                                        ctrl.initialize()
                                                }

                                                Pane {
                                                        width: parent.width
                                                        height: 60

                                                        Material.elevation: 6

                                                        RowLayout {
                                                                anchors.fill: parent
                                                                Text {
                                                                        text: modelData.title
                                                                }

                                                                Button {
                                                                        text: "Done"
                                                                        highlighted: true
                                                                        Material.background: Material.Green
                                                                        onClicked: {
                                                                                ctrl.markAsDone(modelData.id)
                                                                        }
                                                                }
                                                        }
                                                }
                                        }
                                }
                        }
                }
        }
        
        TodoItemsController {
                id: ctrl
        }
}

