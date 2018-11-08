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

        public TodoItemsController(ITodoItemService todoItemService)
        {
            OpenTodoItems = new List<TodoItemModel>();
            ClosedTodoItems = new List<TodoItemModel>();
            _todoItemService = todoItemService;
        }

        public Task Initialize()
        {
            return UpdateTodoItems();
        }

        [NotifySignal]
        public IList<TodoItemModel> OpenTodoItems { get; private set; }

        [NotifySignal]
        public IList<TodoItemModel> ClosedTodoItems { get; private set; }

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
            OpenTodoItems = (await _todoItemService.GetOpenTodoItems()).ToModel();
            this.ActivateSignal("openTodoItemsChanged");
        }

        private async Task UpdateClosedTodoItems()
        {
            ClosedTodoItems = (await _todoItemService.GetClosedTodoItems()).ToModel();
            this.ActivateSignal("closedTodoItemsChanged");
        }
    }
}
