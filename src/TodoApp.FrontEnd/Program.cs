using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Qml.Net;
using System.Threading.Tasks;
using TodoApp.Controllers;
using TodoApp.Core.Interfaces;
using TodoApp.FrontEnd;
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

            serviceCollection.ConfigureServices();
            serviceCollection.ConfigureDatabase(connectionString);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Seed database. Do NOT dispose dbContext, that would destroy our only Singleton instance.
            var dbContext = serviceProvider.GetService<TodoAppDbContext>();
            await dbContext.EnsureSeedData().ConfigureAwait(false);

            QQuickStyle.SetStyle("Material");

            using (var application = new QGuiApplication(args))
            {
                using (var qmlEngine = new QQmlApplicationEngine())
                {
                    QQmlApplicationEngine.RegisterType<TodoItemsController>("TodoApp");

                    TypeCreator.Current = TypeCreator.FromDelegate((type) => serviceProvider.GetRequiredService(type));

                    qmlEngine.Load("Main.qml");

                    application.Exec();
                }
            }
        }
    }
}
