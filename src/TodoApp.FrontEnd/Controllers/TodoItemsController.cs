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
        private IList<TodoItemModel> _completedTodoItems = new List<TodoItemModel>();

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
        public IList<TodoItemModel> CompletedTodoItems
        {
            get { return _completedTodoItems; }
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

        public async Task MarkAsDone(int todoItemId)
        {
            await _todoItemService.MarkAsDone(todoItemId)
                .ConfigureAwait(false);

            await UpdateTodoItems()
                .ConfigureAwait(false);
        }

        public async Task Delete(int todoItemId)
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

            _completedTodoItems = (await _todoItemService.GetCompletedTodoItems().ConfigureAwait(false)).ToModel();
            this.ActivateSignal("completedTodoItemsChanged");
        }
    }
}
