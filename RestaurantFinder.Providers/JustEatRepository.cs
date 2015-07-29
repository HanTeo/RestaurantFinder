using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestaurantFinder.Domain;

namespace RestaurantFinder.Providers
{
    public class JustEatRepository : IRepository
    {
        public JustEatRepository()
        {
            BaseUrl = "http://api-interview.just-eat.com/";
            RequestUri = "restaurants?q=";
        }

        public async Task<IEnumerable<Restaurant>> Get(string outcode)
        {
            IEnumerable<Restaurant> results;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept-Tenant", "uk");
                client.DefaultRequestHeaders.Add("Accept-Language", "en-GB");
                client.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");
                client.DefaultRequestHeaders.Add("Host", "api-interview.just-eat.com");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    "VGVjaFRlc3RBUEk6dXNlcjI=");
                client.BaseAddress = new Uri(BaseUrl);

                var response = await client.GetAsync($"{RequestUri}{outcode}");
                response.EnsureSuccessStatusCode();

                dynamic responseMessage = await response.Content.ReadAsAsync<dynamic>();
                var restaurants = responseMessage.Restaurants.ToString();
                results = JsonConvert.DeserializeObject<List<Restaurant>>(restaurants);
            }

            return results.Where(x => x.IsCloseBy);
        }

        public string BaseUrl { get; }
        public string RequestUri { get;}
    }
}