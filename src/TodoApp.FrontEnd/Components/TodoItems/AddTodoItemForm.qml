import QtQuick 2.11
import QtQuick.Controls 2.4
import QtQuick.Controls.Material 2.4
import QtQuick.Layouts 1.3
import TodoApp 1.0

import "../Common"

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

        MaterialButton {
            text: "Submit"
            highlighted: true
            Material.background: Material.Blue
            onClicked: addTodoItemForm.submitTodoItem()
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