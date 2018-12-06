using Humanizer;
using Qml.Net;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.Interfaces;
using TodoApp.FrontEnd.Extensions;
using TodoApp.FrontEnd.Model;

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

            await _todoItemService.AddTodoItem(title, description);

            await UpdateTodoItems();
        }

        public async Task CloseTodoItem(int todoItemId)
        {
            await _todoItemService.CloseTodoItem(todoItemId);

            await UpdateTodoItems();
        }

        public async Task OpenTodoItem(int todoItemId)
        {
            await _todoItemService.OpenTodoItem(todoItemId);

            await UpdateTodoItems();
        }

        public async Task DeleteTodoItem(int todoItemId)
        {
            await _todoItemService.DeleteTodoItem(todoItemId);

            await UpdateTodoItems();
        }

        public string ToLocalDateTimeString(DateTime dateTime)
        {
            return dateTime.Humanize(utcDate: true);
        }

        public string ToPeriodString(DateTime start, DateTime end)
        {
            var localStart = start.ToLocalTime();
            var localEnd = end.ToLocalTime();

            return $"{localStart.ToString("yyyy-dd-MM")} until {localEnd.ToString("yyyy-dd-MM")}";
        }

        private Task UpdateTodoItems()
        {
            return Task.WhenAll(UpdateOpenTodoItems(), UpdateClosedTodoItems());
        }

        private async Task UpdateOpenTodoItems()
        {
            _openTodoItems = (await _todoItemService.GetOpenTodoItems()).ToModel();
            this.ActivateSignal("openTodoItemsChanged");
        }

        private async Task UpdateClosedTodoItems()
        {
            _closedTodoItems = (await _todoItemService.GetClosedTodoItems()).ToModel();
            this.ActivateSignal("closedTodoItemsChanged");
        }
    }
}
