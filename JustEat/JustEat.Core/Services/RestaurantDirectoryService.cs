using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustEat.Core
{
    public class RestaurantDirectoryService : IRestaurantDirectoryService
    {
        public RestaurantDirectoryService()
        {
        }

        public virtual async Task<List<Restaurant>> GetRestaurantsWithOutcode(string outcode)
        {
            return new List<Restaurant>();
        }

        public virtual async Task<List<Restaurant>> GetAllRestaurants()
        {
            return new List<Restaurant>();
        }
    }
}

