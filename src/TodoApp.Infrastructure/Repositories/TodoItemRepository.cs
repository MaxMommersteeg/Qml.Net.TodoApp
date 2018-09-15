using System.Threading.Tasks;
using TodoApp.Core.Interfaces;
using TodoApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoApp.Core.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace TodoApp.Infrastructure.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoAppDbContext _dbContext;

        public TodoItemRepository(TodoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<TodoItem>> Get()
        {
            return _dbContext.TodoItems.ToListAsync();
        }

        public Task<List<TodoItem>> Get(Expression<Func<TodoItem, bool>> predicate)
        {
            return _dbContext.TodoItems
                .Where(predicate)
                .ToListAsync();
        }

        public Task<TodoItem> GetById(int todoItemId)
        {
            return _dbContext.FindAsync<TodoItem>(todoItemId);
        }

        public async Task Add(TodoItem todoItem)
        {
            await _dbContext.AddAsync(todoItem);

            await SaveChanges();
        }

        public async Task Update(TodoItem todoItem)
        {
            var entityToUpdate = await GetById(todoItem.Id);
            if (entityToUpdate == null)
            {
                return;
            }

            entityToUpdate.Title = todoItem.Title;
            entityToUpdate.Description = todoItem.Description;
            entityToUpdate.ClosedAt = todoItem.ClosedAt;

            _dbContext.Update(entityToUpdate);

            await SaveChanges();
        }

        public async Task Delete(int todoItemId)
        {
            var entityToDelete = await GetById(todoItemId);
            if (entityToDelete == null)
            {
                return;
            }

            _dbContext.Remove(entityToDelete);

            await SaveChanges();
        }

        private Task SaveChanges()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
