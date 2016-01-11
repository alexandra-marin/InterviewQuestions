using NUnit.Framework;
using System;
using FakeItEasy;
using Ploeh.AutoFixture;
using System.Linq;
using Should;
using JustEat.Core;

namespace JustEatTests
{
    [TestFixture()]
    public class RestaurantDirectoryTests
    {
        [Test()]
        public void SubmitQutcodeShowsRestaurantList()
        {
            var fixture = new Fixture();
            var service = A.Fake<RestaurantDirectoryService>();
            var vm = new RestaurantDirectoryViewModel();
            //Arrange
            var outcode = "SE19";

            var restaurants = fixture.CreateMany<Restaurant>().ToList();

            var restaurantWithOutcode = fixture.Build<Restaurant>().With(x => x.Outcode, outcode).Create();
            restaurants.Add(restaurantWithOutcode);
            
            A.CallTo(() => service.GetRestaurantsWithOutcode(A<string>.Ignored)).Returns(restaurants);

            //Act
            vm.GetRestaurantsWithOutcode.Execute(outcode);

            //Assert
            vm.Restaurants.All(x => x.Outcode == outcode).ShouldBeTrue();
        }

        [Test()]
        public void EachRestaurantHasALogo()
        {
            var fixture = new Fixture();
            var service = A.Fake<RestaurantDirectoryService>();
            var vm = new RestaurantDirectoryViewModel();

            //Arrange
            var restaurants = fixture.CreateMany<Restaurant>().ToList();
            A.CallTo(() => service.GetAllRestaurants()).Returns(restaurants);

            //Act
            vm.GetAllRestaurants();

            //Assert
            vm.Restaurants.All(x => x.Logo != null).ShouldBeTrue();
        }


//        [Test()]
//        public void RequestsAccessToGPSLocation()
//        {
//            var app = ConfigureApp.iOS                
//                .StartApp();   
//            
//            Func<AppQuery, AppQuery> locationPopup = c => c.Marked("locationPopup");
//            app.Tap(locationPopup);
//
//            AppResult[] results = app.Query(locationPopup);
//
//            Assert.IsTrue(results.Any());
//        }
    }
}

