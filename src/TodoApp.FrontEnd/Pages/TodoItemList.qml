import QtQuick 2.11
import QtQuick.Controls 2.4
import QtQuick.Controls.Material 2.4
import QtQuick.Layouts 1.3
import TodoApp 1.0

import "../Components"
import "../Components/Buttons"

Page {
        width: parent.width

        ColumnLayout {
                anchors.fill: parent
                anchors.margins: 8

                Pane {
                        ColumnLayout {
                        id: submitBox
                        Layout.fillWidth: true

                        RowLayout {
                                Layout.fillWidth: true
                                Layout.alignment: Qt.AlignLeft

                                TextField {
                                        id: txtTitle
                                        placeholderText: "Title"
                                        Layout.fillWidth: true
                                        Keys.onReturnPressed: submitBox.submitTodoItem()
                                }
                        }

                        RowLayout {
                                Layout.fillWidth: true
                                Layout.alignment: Qt.AlignLeft

                                TextArea {
                                        id: txtDescription
                                        placeholderText: "Description"
                                        Layout.fillWidth: true
                                        Keys.onReturnPressed: submitBox.submitTodoItem()
                                }

                                MaterialButton {
                                        text: "Submit"
                                        highlighted: true
                                        Material.background: Material.Green
                                        onClicked: submitBox.submitTodoItem()
                                }
                        }

                        function submitTodoItem() {
                                if (txtTitle.text !== "")
                                {
                                        ctrl.addTodoItem(txtTitle.text, txtDescription.text)
                                        txtTitle.text = null
                                        txtDescription.text = null
                                }
                        }
                }
                }

                Divider { }

                Pane {
                        Layout.fillWidth: true
                        Layout.fillHeight: true

                        StackLayout {
                                anchors.fill: parent

                                Column {
                                        spacing: 6

                                        Repeater {
                                                model: Net.toListModel(ctrl.openTodoItems)
                                                Component.onCompleted: ctrl.initialize()

                                                Pane {
                                                        id: todoItemCard
                                                        width: parent.width
                                                        height: 60
                                                        Material.elevation: 1
                                                        property int itemId: modelData.id
                                                        
                                                        MouseArea {
                                                                hoverEnabled: true
                                                                anchors.fill: parent
                                                                onEntered: todoItemCard.Material.elevation = 3
                                                                onExited: todoItemCard.Material.elevation = 1
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
                                                                        onClicked: ctrl.markAsDone(todoItemCard.itemId)
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

