using System.Collections.Generic;
using System.Text;

namespace RestaurantFinder.Domain
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }

        public bool IsOpenNow { get; set; }
        public bool IsCloseBy { get; set; }
        public bool IsOpenNowForDelivery { get; set; }
        public bool IsOpenNowForCollection { get; set; }

        public double RatingStars { get; set; }
        public int NumberOfRatings { get; set; }

        public List<Logo> Logo { get; set; }
        public int DefaultDisplayRank { get; set; }
        public string Url { get; set; }

        public List<CuisineType> CuisineTypes { get; set; }

        public string Cuisines
        {
            get
            {
                var sb = new StringBuilder();
                var first = true;
                foreach (var cuisineType in CuisineTypes)
                {
                    if (!first)
                    {
                        sb.Append(", ");
                    }
                    else
                    {
                        first = false;
                    }
                    sb.Append(cuisineType.Name);
                }

                return sb.ToString();
            }
        }
    }
}