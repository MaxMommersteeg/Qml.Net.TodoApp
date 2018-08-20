﻿using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entities;

namespace TodoApp.Infrastructure.Database.Mapping
{
    internal class TodoItemMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasKey(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<TodoItem>().Property(x => x.CreatedAt).HasDefaultValueSql("getutcdate()");
        }
    }
}