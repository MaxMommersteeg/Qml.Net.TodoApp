import QtQuick 2.11
import QtQuick.Controls 2.4
import QtQuick.Controls.Material 2.4
import QtQuick.Layouts 1.3
import TodoApp 1.0

import "../Components"

Page {
        width: parent.width

        ColumnLayout {
                anchors.fill: parent
                anchors.margins: 8

                AddTodoItemForm { }

                Divider { }

                TodoItemCardList { }
        }

        TodoItemsController {
                id: ctrl
        }
}

