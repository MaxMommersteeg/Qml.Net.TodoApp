using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Core.Data;

namespace TodoApp.Infrastructure.Database.Seed
{
    public static class TodoAppDbContextSeed
    {
        private static readonly List<TodoItem> _todoItems = new List<TodoItem>
        {
            new TodoItem
            {
                Title = "Get groceries",
                Description = "Cheese, meat, fruit, snacks.",
                CreatedAt = new DateTime(2018, 6, 18, 14, 0, 0, DateTimeKind.Utc),
                ClosedAt = new DateTime(2018, 6, 19, 15, 0, 0, DateTimeKind.Utc)
            },
            new TodoItem
            {
                Title = "Setup a meeting with stakeholders",
                Description = "Make some calls, send some e-mails.",
                CreatedAt = new DateTime(2018, 7, 12, 10, 0, 0, DateTimeKind.Utc)
            },
            new TodoItem
            {
                Title = "Get a haircut",
                Description = "Make an appointment.",
                CreatedAt = new DateTime(2018, 8, 20, 10, 0, 0, DateTimeKind.Utc),
            }
        };

        public async static Task EnsureSeedData(this TodoAppDbContext dbContext)
        {
            if (dbContext.TodoItems.Any())
            {
                return;
            }

            await dbContext.AddRangeAsync(_todoItems);

            await dbContext.SaveChangesAsync();
        }
    }
}
