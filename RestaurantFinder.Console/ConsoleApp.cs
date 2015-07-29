using RestaurantFinder.Providers;

namespace RestaurantFinder.Console
{
    public class ConsoleApp : IConsoleApp
    {
        private readonly IRestaurantPrinter printer;
        private readonly IRepository repo;

        public ConsoleApp(IRestaurantPrinter printer, IRepository repo)
        {
            this.printer = printer;
            this.repo = repo;
        }

        public void Run()
        {
            var again = true;
            while (again)
            {
                System.Console.WriteLine("Welcome to Restaurant Finder");
                System.Console.WriteLine("Please enter an outcode to find nearby restaurants");
                System.Console.WriteLine();
                var outcode = System.Console.ReadLine();
                var response = repo.Get(outcode);

                var results = response.Result;
                foreach (var restaurant in results)
                {
                    printer.Print(restaurant);
                }

                System.Console.WriteLine();
                System.Console.WriteLine("Would you like to search again? Y/N");
                var ans = System.Console.ReadKey();
                if (ans.KeyChar != 'Y' && ans.KeyChar != 'y')
                {
                    again = false;
                }

                System.Console.Clear();
            }
        }
    }
}