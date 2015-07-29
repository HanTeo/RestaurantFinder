using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using RestaurantFinder.Console;
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
