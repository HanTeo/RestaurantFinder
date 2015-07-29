using Microsoft.Owin.Hosting;

namespace RestaurantFinder.OWIN
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://+:8080";

            using (WebApp.Start<Startup>(url))
            {
                System.Console.WriteLine("Running on {0}", url);
                System.Console.WriteLine("Press enter to exit");
                System.Console.ReadLine();
            }
        }
    }
}
