import QtQuick 2.11
import QtQuick.Controls 2.4
import QtQuick.Controls.Material 2.4
import QtQuick.Layouts 1.3

import "../Common"

Pane {
        Layout.fillWidth: true

        RowLayout {
                id: submitBox
                anchors.fill: parent

                TextField {
                        id: txtTitle
                        placeholderText: "Title"
                        Layout.fillWidth: true
                        Keys.onReturnPressed: submitBox.submitTodoItem()
                }

                TextField {
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