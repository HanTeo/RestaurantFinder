using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantFinder.Domain;

namespace RestaurantFinder.Providers
{
    public interface IRepository
    {
        Task<IEnumerable<Restaurant>> Get(string outcode);
    }
}