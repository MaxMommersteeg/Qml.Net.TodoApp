using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Data;

namespace TodoApp.Infrastructure.Database.Mapping
{
    internal class TodoItemMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasKey(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<TodoItem>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<TodoItem>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<TodoItem>().Property(x => x.CreatedAt).IsRequired();
        }
    }
}
