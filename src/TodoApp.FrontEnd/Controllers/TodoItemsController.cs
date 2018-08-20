using Qml.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.Interfaces;
using TodoApp.FrontEnd.Model;
using TodoApp.FrontEnd.Extensions;
using System;

namespace TodoApp.Controllers
{
    public class TodoItemsController
    {
        private readonly ITodoItemRepository _todoItemRepository;

        private IList<TodoItemModel> _todoItems = new List<TodoItemModel>();

        public TodoItemsController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [NotifySignal]
        public IList<TodoItemModel> TodoItems
        {
            get { return _todoItems; }
            private set { _todoItems = value; }
        }

        public async Task AddTodoItem(string title)
        {
            await _todoItemRepository.Add(new Core.Entities.TodoItem
            {
                Title = title,
            })
            .ConfigureAwait(false);

            await UpdateTodoItems()
                .ConfigureAwait(false);
        }

        public async Task MarkAsDone(int todoItemId)
        {
            var todoItem = await _todoItemRepository.Get(todoItemId)
                .ConfigureAwait(false);
            if (todoItem == null)
            {
                return;
            }

            todoItem.CompletedAt = DateTime.UtcNow;

            await _todoItemRepository.Update(todoItem)
                .ConfigureAwait(false);

            await UpdateTodoItems()
                .ConfigureAwait(false);
        }

        public async Task DeleteTodoItem(int todoItemId)
        {
            await _todoItemRepository.Delete(todoItemId)
                .ConfigureAwait(false);

            await UpdateTodoItems()
                .ConfigureAwait(false);
        }

        private async Task UpdateTodoItems()
        {
            _todoItems = (await _todoItemRepository.GetAll().ConfigureAwait(false)).ToModel();
            this.ActivateSignal("todoItemsChanged");
        }
    }
}
