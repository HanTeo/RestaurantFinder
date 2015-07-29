using RestaurantFinder.Providers;
using SimpleInjector;

namespace RestaurantFinder.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();
            container.Register<IRepository, JustEatRepository>(Lifestyle.Singleton);
            container.Register<IRestaurantPrinter, RestaurantPrinter>(Lifestyle.Singleton);
            container.Register<IConsoleApp, ConsoleApp>(Lifestyle.Singleton);
            container.Verify();

            var console = container.GetInstance<IConsoleApp>();
            console.Run();
        }
    }
}
