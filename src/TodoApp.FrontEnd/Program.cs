﻿using System.Threading.Tasks;
using TodoApp.Controllers;

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

            // Seed database. Do NOT dispose dbContext, that would destroy our only dbContext singleton instance.
            var dbContext = serviceProvider.GetRequiredService<TodoAppDbContext>();
            await dbContext.EnsureSeedData();

            QQuickStyle.SetStyle("Material");

            using (var application = new QGuiApplication(args))
            {
                using (var qmlEngine = new QQmlApplicationEngine())
                {
                    Qml.Net.Qml.RegisterType<TodoItemsController>("TodoApp");

                    TypeCreator.Current = TypeCreator.FromDelegate((type) => serviceProvider.GetRequiredService(type));

                    qmlEngine.Load("Main.qml");

                    application.Exec();
                }
            }
        }
    }
}
