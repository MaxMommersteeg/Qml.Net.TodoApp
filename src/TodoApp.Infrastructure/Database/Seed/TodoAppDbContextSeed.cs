using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Core.Entities;

namespace TodoApp.Infrastructure.Database.Seed
{
    public static class TodoAppDbContextSeed
    {
        private static readonly List<TodoItem> _todoItems = new List<TodoItem>
        {
            new TodoItem
            {
                Title = "Get groceries",
                CreatedAt = new DateTime(2018, 6, 18, 14, 0, 0, DateTimeKind.Utc),
                CompletedAt = new DateTime(2018, 6, 19, 15, 0, 0, DateTimeKind.Utc)
            },
            new TodoItem
            {
                Title = "Setup a meeting with stakeholders",
                CreatedAt = new DateTime(2018, 7, 12, 10, 0, 0, DateTimeKind.Utc),
                CompletedAt = new DateTime(2018, 7, 15, 18, 0, 0, DateTimeKind.Utc)
            },
            new TodoItem
            {
                Title = "Get a haircut",
                CreatedAt = new DateTime(2018, 8, 20, 10, 0, 0, DateTimeKind.Utc),
            }
        };

        public async static Task EnsureSeedData(this TodoAppDbContext dbContext)
        {
            if (dbContext.TodoItems.Any())
            {
                return;
            }

            await dbContext.AddRangeAsync(_todoItems)
                .ConfigureAwait(false);

            await dbContext.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
