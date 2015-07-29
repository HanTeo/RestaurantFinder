using RestaurantFinder.Domain;

namespace RestaurantFinder.Console
{
    public interface IRestaurantPrinter
    {
        void Print(Restaurant restaurant);
    }
}