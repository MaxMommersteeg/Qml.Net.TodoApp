using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entities;
using TodoApp.Infrastructure.Database.Mapping;

namespace TodoApp.Infrastructure.Database
{
    public class TodoAppDbContext : DbContext
    {
        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : 
            base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TodoItemMapping.Map(modelBuilder);
        }
    }
}
