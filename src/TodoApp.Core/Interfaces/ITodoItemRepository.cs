using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetAll();

        Task<TodoItem> Get(int todoItemId);

        Task Add(TodoItem todoItem);

        Task Update(TodoItem todoItem);

        Task Delete(int todoItemId);
    }
}
