using System;
using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;

namespace JustEat.Core
{
    public class RestaurantDirectoryViewModel : MvxViewModel
    {
        public RestaurantDirectoryViewModel()
        {
        }

        public List<Restaurant> Restaurants { get; set;}

        public List<Restaurant> GetAllRestaurants()
        {
            return new List<Restaurant>();
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

        private void DoGetRestaurantsWithOutcode(string outcode)
        {           
        }
    }
}

