﻿using System.Threading.Tasks;
using TodoApp.Core.Interfaces;
using TodoApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoApp.Core.Entities;
using System;

namespace TodoApp.Infrastructure.Repositories
{
    public class TodoItemRepository : ITodoItemRepository, IDisposable
    {
        private readonly TodoAppDbContext _dbContext;

        public TodoItemRepository(TodoAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<TodoItem>> GetAll()
        {
            return _dbContext.TodoItems.ToListAsync();
        }

        public Task<TodoItem> Get(int todoItemId)
        {
            return _dbContext.FindAsync<TodoItem>(todoItemId);
        }

        public async Task Add(TodoItem todoItem)
        {
            await _dbContext.AddAsync(todoItem)
                .ConfigureAwait(false);

            await SaveChanges()
                .ConfigureAwait(false);
        }

        public async Task Update(TodoItem todoItem)
        {
            var entityToUpdate = await Get(todoItem.Id)
                .ConfigureAwait(false);
            if (entityToUpdate == null)
            {
                return;
            }

            entityToUpdate.Title = todoItem.Title;
            entityToUpdate.CompletedAt = todoItem.CompletedAt;

            _dbContext.Update(entityToUpdate);

            await SaveChanges()
                .ConfigureAwait(false);
        }

        public async Task Delete(int todoItemId)
        {
            var entityToDelete = await Get(todoItemId)
                .ConfigureAwait(false);
            if (entityToDelete == null)
            {
                return;
            }

            _dbContext.Remove(entityToDelete);

            await SaveChanges()
                .ConfigureAwait(false);
        }

        private Task SaveChanges()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}