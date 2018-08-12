using Qml.Net;
using TodoApp.Controllers;
using TodoApp.Model;

namespace TodoApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            QQuickStyle.SetStyle("Material");

            using (var application = new QGuiApplication(args))
            {
                using (var qmlEngine = new QQmlApplicationEngine())
                {
                    QQmlApplicationEngine.RegisterType<TodoItem>("TodoApp");
                    QQmlApplicationEngine.RegisterType<TodoItemListController>("TodoApp");

                    qmlEngine.Load("Main.qml");

                    return application.Exec();
                }
            }
        }
    }
}
