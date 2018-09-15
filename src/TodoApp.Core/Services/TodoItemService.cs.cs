using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Core.Entities;
using TodoApp.Core.Extensions;
using TodoApp.Core.Interfaces;

namespace TodoApp.Core.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<TodoItem> GetTodoItem(int todoItemId)
        {
            var todoItem = await _todoItemRepository.GetById(todoItemId);
            return todoItem.ToEntity();
        }

        public Task AddTodoItem(string title, string description)
        {
            var todoItem = new TodoItem
            {
                Title = title,
                Description = description
            };

            todoItem.Create();

            return _todoItemRepository.Add(todoItem.ToData());
        }

        public async Task<List<TodoItem>> GetClosedTodoItems()
        {
            var todoItems = (await _todoItemRepository.Get(x => x.ClosedAt != null)).ToEntities();
            return todoItems.OrderBy(x => x.CreatedAt).ToList();
        }

        public async Task<List<TodoItem>> GetOpenTodoItems()
        {
            var todoItems = (await _todoItemRepository.Get(x => x.ClosedAt == null)).ToEntities();
            return todoItems.OrderBy(x => x.CreatedAt).ToList();
        }

        public async Task CloseTodoItem(int todoItemId)
        {
            var todoItem = (await _todoItemRepository.GetById(todoItemId)).ToEntity();

            if (todoItem == null)
            {
                return;
            }

            if (todoItem.IsClosed())
            {
                return;
            }

            todoItem.Close();
            await _todoItemRepository.Update(todoItem.ToData());
        }

        public async Task OpenTodoItem(int todoItemId)
        {
            var todoItem = (await _todoItemRepository.GetById(todoItemId)).ToEntity();

            if (todoItem == null)
            {
                return;
            }

            if (todoItem.IsOpen())
            {
                return;
            }

            todoItem.Open();
            await _todoItemRepository.Update(todoItem.ToData());
        }

        public Task DeleteTodoItem(int todoItemId)
        {
            return _todoItemRepository.Delete(todoItemId);
        }
    }
}
