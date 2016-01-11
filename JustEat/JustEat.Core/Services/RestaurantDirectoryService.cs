using System.Collections.Generic;

namespace JustEat.Core
{
    public class RestaurantDirectoryService : IRestaurantDirectoryService
    {
        public RestaurantDirectoryService()
        {
        }

        public List<Restaurant> GetRestaurantsWithOutcode(string outcode)
        {
            return new List<Restaurant>();
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return new List<Restaurant>();
        }
    }
}

