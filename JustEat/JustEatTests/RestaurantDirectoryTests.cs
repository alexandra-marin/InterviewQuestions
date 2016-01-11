using NUnit.Framework;
using System;
using FakeItEasy;
using Ploeh.AutoFixture;
using NUnit.Framework.Internal;
using System.Linq;
using Should;
using Xamarin.UITest.Queries;
using Xamarin.UITest;

namespace JustEatTests
{
    [TestFixture()]
    public class RestaurantDirectoryTests
    {
        [Test()]
        public void SubmitQutcodeShowsRestaurantList()
        {
            //Arrange
            var outcode = "SE19";

            var restaurants = TestFixture.CreateMany<Restaurant>().ToList();

            var restaurantWithOutcode = TestFixture.Build<Restaurant>().With(x => x.Outcode, outcode).Create();
            restaurants.Add(restaurantWithOutcode);
            
            A.CallTo(() => RestaurantDirectoryService.GetAllRestaurants()).Returns(restaurants);

            //Act
            RestaurantDirectoryViewModel.FilterByOutcode(outcode).Execute();

            //Assert
            RestaurantDirectoryViewModel.Restaurants.All(x => x.Outcode == outcode).ShouldBeTrue();
        }

        [Test()]
        public void EachRestaurantHasALogo()
        {
            //Arrange
            var restaurants = TestFixture.CreateMany<Restaurant>().ToList();
            A.CallTo(() => RestaurantDirectoryService.GetAllRestaurants()).Returns(restaurants);

            //Act
            RestaurantDirectoryViewModel.GetAllRestaurants();

            //Assert
            RestaurantDirectoryViewModel.Restaurants.All(x => x.Logo != null).ShouldBeTrue();
        }


        [Test()]
        public void RequestsAccessToGPSLocation()
        {
            var app = ConfigureApp.iOS                
                .StartApp();   
            
            Func<AppQuery, AppQuery> locationPopup = c => c.Marked("locationPopup");
            app.Tap(locationPopup);

            AppResult[] results = app.Query(locationPopup);

            Assert.IsTrue(results.Any());
        }
    }
}

