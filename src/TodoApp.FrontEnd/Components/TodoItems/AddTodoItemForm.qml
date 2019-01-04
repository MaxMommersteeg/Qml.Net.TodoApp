import QtQuick 2.12
import QtQuick.Controls 2.12
import QtQuick.Controls.Material 2.12
import QtQuick.Layouts 1.12
import TodoApp 1.0

import "../Behaviors"

Pane {
    id: addTodoItemForm

    Layout.fillWidth: true

    property TodoItemsController target: null

    signal addTodoItem(string title, string description)
    onTargetChanged: addTodoItem.connect(target.handleAddTodoItem)

    RowLayout {
        id: submitBox
        anchors.fill: parent

        TextField {
            id: txtTitle
            placeholderText: "Title"
            Layout.fillWidth: true
            Keys.onReturnPressed: addTodoItemForm.submitTodoItem()
            Keys.onEnterPressed: addTodoItemForm.submitTodoItem()
        }

        TextField {
            id: txtDescription
            placeholderText: "Description"
            Layout.fillWidth: true
            Keys.onReturnPressed: addTodoItemForm.submitTodoItem()
            Keys.onEnterPressed: addTodoItemForm.submitTodoItem()
        }

        Button {
            text: "Submit"
            highlighted: true
            Material.background: Material.Blue

            PointingHandCursorOnHover {
                onClicked: addTodoItemForm.submitTodoItem()
            }
        }
    }

    function submitTodoItem() {
        if (txtTitle.text !== "")
        {
            addTodoItemForm.addTodoItem(txtTitle.text, txtDescription.text)
            txtTitle.text = null
            txtDescription.text = null
        }
    }
}
