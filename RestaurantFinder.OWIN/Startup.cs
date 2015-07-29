using Owin;
using RestaurantFinder.Providers;
using SimpleInjector;

namespace RestaurantFinder.OWIN
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();

            var container = new Container();
            container.Register<IRepository, JustEatRepository>(Lifestyle.Singleton);
            container.Verify();
        }
    }
}
