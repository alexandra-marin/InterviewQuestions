using System.Collections.Generic;

namespace JustEat.Core
{
	public interface IRestaurantDirectoryService
	{
        List<Restaurant> GetRestaurantsWithOutcode(string outcode);
        List<Restaurant> GetAllRestaurants();
	}
}

