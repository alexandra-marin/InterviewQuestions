using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustEat.Core
{
	public interface IRestaurantDirectoryService
	{
        Task<List<Restaurant>> GetRestaurantsWithOutcode(string outcode);
        Task<List<Restaurant>> GetAllRestaurants();
	}
}

