using System;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustEat.Core
{
    public class RestaurantDirectoryViewModel : MvxViewModel
    {
        private IRestaurantDirectoryService service;
        
        public RestaurantDirectoryViewModel(IRestaurantDirectoryService service)
        {
            this.service = service;
        }

        public List<Restaurant> Restaurants { get; set;}

        public async void GetAllRestaurants()
        {
            Restaurants = await service.GetAllRestaurants();
        }

        private MvxCommand<string> getRestaurants;
        public MvxCommand<string> GetRestaurantsWithOutcode 
        {
            get 
            {
                getRestaurants = getRestaurants ?? new MvxCommand<string>(DoGetRestaurantsWithOutcode);
                return getRestaurants;
            }
        }

        private async void DoGetRestaurantsWithOutcode(string outcode)
        {  
            Restaurants = await service.GetAllRestaurants();
        }
    }
}

