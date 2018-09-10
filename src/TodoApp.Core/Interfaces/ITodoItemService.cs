using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces
{
    public interface ITodoItemService
    {
        Task<TodoItem> GetTodoItem(int todoItemId);

        Task<List<TodoItem>> GetOpenTodoItems();

        Task<List<TodoItem>> GetCompletedTodoItems();

        Task AddTodoItem(string title, string description);

        Task MarkAsDone(int todoItemId);

        Task DeleteTodoItem(int todoItemId);
    }
}
