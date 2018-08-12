using System.Collections.Generic;
using System.Linq;
using TodoApp.Model;

namespace TodoApp.Controllers
{
    public class TodoItemListController
    {
        private readonly List<TodoItem> _todoItems;

        public TodoItemListController()
        {
            _todoItems = new List<TodoItem>
            {
                new TodoItem("Cleaning the house"),
                new TodoItem("Doing groceries"),
                new TodoItem("Getting a haircut")
            };
        }

        public string GetTodoItems()
        {
            return string.Join(";", _todoItems.Select(x => x.Title));
        }
    }
}
