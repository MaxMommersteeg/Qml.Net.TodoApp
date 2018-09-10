using System.Collections.Generic;
using System.Collections.ObjectModel;
using Data = TodoApp.Core.Data;
using Entity = TodoApp.Core.Entities;

namespace TodoApp.Core.Extensions
{
    internal static class TodoItemMapper
    {
        internal static Entity.TodoItem ToEntity(this Data.TodoItem todoItem)
        {
            return new Entity.TodoItem
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                CreatedAt = todoItem.CreatedAt,
                CompletedAt = todoItem.CompletedAt
            };
        }

        internal static Data.TodoItem ToData(this Entity.TodoItem todoItem)
        {
            return new Data.TodoItem
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                CreatedAt = todoItem.CreatedAt,
                CompletedAt = todoItem.CompletedAt
            };
        }

        internal static IEnumerable<Entity.TodoItem> ToEntities(this IEnumerable<Data.TodoItem> todoItems)
        {
            var result = new Collection<Entity.TodoItem>();
            foreach (var todoItem in todoItems)
            {
                result.Add(todoItem.ToEntity());
            }

            return result;
        }
    }
}
