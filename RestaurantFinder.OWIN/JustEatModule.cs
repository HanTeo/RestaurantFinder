using Nancy;
using RestaurantFinder.Providers;

namespace RestaurantFinder.OWIN
{
    public class JustEatModule : NancyModule
    {
        private readonly IRepository repository;

        public JustEatModule(IRepository repository)
        {
            this.repository = repository;

            Get["/restaurants/{outcode}"] = parameters =>
            {
                var outcode = parameters.outcode;

                var results = repository.Get(outcode).Result;

                return View["Finder", results];
            };

            Get["/restaurants/"] = parameters =>
            {
                var results = repository.Get("").Result;

                return View["Finder", results];
            };
        }
    }
}