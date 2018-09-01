using Qml.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.Interfaces;
using TodoApp.FrontEnd.Model;
using TodoApp.FrontEnd.Extensions;
using System;
using Humanizer;

namespace TodoApp.Controllers
{
    public class TodoItemsController
    {
        private readonly ITodoItemService _todoItemService;

        private IList<TodoItemModel> _todoItems = new List<TodoItemModel>();

        public TodoItemsController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public Task Initialize()
        {
            return UpdateTodoItems();
        }

        [NotifySignal]
        public IList<TodoItemModel> TodoItems
        {
            get { return _todoItems; }
            private set => _todoItems = value;
        }

        public async Task AddTodoItem(string title)
        {
            await _todoItemService.AddTodoItem(title)
                .ConfigureAwait(false);

            await UpdateTodoItems()
                .ConfigureAwait(false);
        }

        public async Task MarkAsDone(int todoItemId)
        {
            await _todoItemService.MarkAsDone(todoItemId)
                .ConfigureAwait(false);

            await UpdateTodoItems()
                .ConfigureAwait(false);
        }

        public string ToLocalDateTimeString(DateTime dateTime)
        {
            return dateTime.Humanize(utcDate: true);
        }

        private async Task UpdateTodoItems()
        {
            _todoItems = (await _todoItemService.GetOpenTodoItems().ConfigureAwait(false)).ToModel();
            this.ActivateSignal("todoItemsChanged");
        }
    }
}
