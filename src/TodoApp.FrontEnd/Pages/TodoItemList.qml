import QtQuick 2.6
import QtQuick.Controls 2.1
import TodoApp 1.0

Page {
        ListView {
                model: listViewModel
                Component.onCompleted: {
                        var arrTodoItems = ctrl.getTodoItems()
                        var todoItems = arrTodoItems.split(";")
                        for (var i = 0; i < todoItems.length; i++)
                        {
                                listViewModel.append({"item": todoItems[i]})
                        }
                }

                ListModel {
                        id: listViewModel
                }
        }

        TodoItemListController {
                id: ctrl
        }
}

