using Qml.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.Interfaces;
using TodoApp.FrontEnd.Model;
using System;
using Humanizer;
using TodoApp.FrontEnd.Extensions;

namespace TodoApp.Controllers
{
    public class TodoItemsController
    {
        private readonly ITodoItemService _todoItemService;

        private IList<TodoItemModel> _openTodoItems = new List<TodoItemModel>();
        private IList<TodoItemModel> _closedTodoItems = new List<TodoItemModel>();

        public TodoItemsController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public Task Initialize()
        {
            return UpdateTodoItems();
        }

        [NotifySignal]
        public IList<TodoItemModel> OpenTodoItems
        {
            get { return _openTodoItems; }
        }

        [NotifySignal]
        public IList<TodoItemModel> ClosedTodoItems
        {
            get { return _closedTodoItems; }
        }

        public async Task AddTodoItem(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return;
            }

            await _todoItemService.AddTodoItem(title, description)
                .ConfigureAwait(false);

            await UpdateTodoItems()
                .ConfigureAwait(false);
        }

        public async Task CloseTodoItem(int todoItemId)
        {
            await _todoItemService.CloseTodoItem(todoItemId)
                .ConfigureAwait(false);

            await UpdateTodoItems()
                .ConfigureAwait(false);
        }

        public async Task OpenTodoItem(int todoItemId)
        {
            await _todoItemService.OpenTodoItem(todoItemId)
                .ConfigureAwait(false);

            await UpdateTodoItems()
                .ConfigureAwait(false);
        }

        public async Task DeleteTodoItem(int todoItemId)
        {
            await _todoItemService.DeleteTodoItem(todoItemId)
                .ConfigureAwait(false);

            await UpdateTodoItems()
                .ConfigureAwait(false);
        }

        public string ToLocalDateTimeString(DateTime dateTime)
        {
            return dateTime.Humanize(utcDate: true);
        }

        public string ToPeriodString(DateTime start, DateTime end)
        {
            var localStart = start.ToLocalTime();
            var localEnd = end.ToLocalTime();

            return $"{localStart.ToString("yyyy-dd-MM HH:mm")} - {localEnd.ToString("yyyy-dd-MM HH:mm")}";
        }

        private async Task UpdateTodoItems()
        {
            _openTodoItems = (await _todoItemService.GetOpenTodoItems().ConfigureAwait(false)).ToModel();
            this.ActivateSignal("openTodoItemsChanged");

            _closedTodoItems = (await _todoItemService.GetClosedTodoItems().ConfigureAwait(false)).ToModel();
            this.ActivateSignal("closedTodoItemsChanged");
        }
    }
}
