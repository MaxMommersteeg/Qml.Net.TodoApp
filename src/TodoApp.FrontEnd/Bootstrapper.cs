using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using TodoApp.Controllers;
using TodoApp.Core.Interfaces;
using TodoApp.Infrastructure.Database;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp.FrontEnd
{
    internal static class Bootstrapper
    {
        internal static void ConfigureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITodoItemRepository, TodoItemRepository>();
            serviceCollection.AddSingleton<TodoItemsController>();
        }

        internal static void ConfigureDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<TodoAppDbContext>(options => options.UseSqlite(connectionString), ServiceLifetime.Singleton);
        }
    }
}
