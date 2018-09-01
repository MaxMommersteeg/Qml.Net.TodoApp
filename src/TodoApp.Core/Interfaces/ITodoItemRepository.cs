using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoApp.Core.Data;

namespace TodoApp.Core.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> Get();

        Task<List<TodoItem>> Get(Expression<Func<TodoItem, bool>> predicate);

        Task<TodoItem> GetById(int todoItemId);

        Task Add(TodoItem todoItem);

        Task Update(TodoItem todoItem);

        Task Delete(int todoItemId);
    }
}
