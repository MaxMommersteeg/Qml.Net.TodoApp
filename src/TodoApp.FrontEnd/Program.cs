using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Qml.Net;
using System.Threading.Tasks;
using TodoApp.Controllers;
using TodoApp.Core.Interfaces;
using TodoApp.Infrastructure.Database;
using TodoApp.Infrastructure.Database.Seed;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Dependency injection.
            var serviceCollection = new ServiceCollection();

            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "todoApp.db" };
            var connectionString = connectionStringBuilder.ToString();

            serviceCollection.AddDbContext<TodoAppDbContext>(options => options.UseSqlite(connectionString));
            serviceCollection.AddSingleton<ITodoItemRepository, TodoItemRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<TodoAppDbContext>();

            using (var dbContext = serviceProvider.GetService<TodoAppDbContext>())
            {
                await dbContext.EnsureSeedData();
            }

            QQuickStyle.SetStyle("Material");

            using (var application = new QGuiApplication(args))
            {
                using (var qmlEngine = new QQmlApplicationEngine())
                {
                    QQmlApplicationEngine.RegisterType<TodoItemsController>("TodoApp");

                    qmlEngine.Load("Main.qml");

                    application.Exec();
                }
            }
        }
    }
}
