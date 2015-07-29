using RestaurantFinder.Domain;

namespace RestaurantFinder.Console
{
    public class RestaurantPrinter : IRestaurantPrinter
    {
        public void Print(Restaurant r)
        {
            var types = new string[r.CuisineTypes.Count];
            int i = 0;
            foreach (var type in r.CuisineTypes)
            {
                types[i++] = type.Name;
            }
            System.Console.WriteLine($"{r.Name} - {string.Join(",", types)} - {r.RatingStars}");
        }
    }
}