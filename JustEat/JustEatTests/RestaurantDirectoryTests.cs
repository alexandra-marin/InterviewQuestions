using NUnit.Framework;
using System;
using FakeItEasy;
using Ploeh.AutoFixture;
using System.Linq;
using Should;
using JustEat.Core;
using Cirrious.MvvmCross.Test.Core;

namespace JustEatTests
{
    [TestFixture()]
    public class RestaurantDirectoryTests : MvxIoCSupportingTest
    {
        private Fixture fixture;
        private RestaurantDirectoryService service;
        private RestaurantDirectoryViewModel viewModelUnderTest;

        [SetUp]
        public void BeforeEachTest()
        {
            base.Setup();

            fixture = new Fixture();
            service = A.Fake<RestaurantDirectoryService>();
            viewModelUnderTest = new RestaurantDirectoryViewModel(service);
        }

        [Test()]
        public void SubmitQutcodeShowsRestaurantList()
        {
            //Arrange
            var outcode = "SE19";

            var restaurants = fixture.CreateMany<Restaurant>().ToList();

            var restaurantWithOutcode = fixture.Build<Restaurant>().With(x => x.Outcode, outcode).Create();
            restaurants.Add(restaurantWithOutcode);
            
            A.CallTo(() => service.GetRestaurantsWithOutcode(A<string>.Ignored)).Returns(restaurants);

            //Act
            viewModelUnderTest.GetRestaurantsWithOutcode.Execute(outcode);

            //Assert
            viewModelUnderTest.Restaurants.All(x => x.Outcode == outcode).ShouldBeTrue();
        }

        [Test()]
        public void EachRestaurantHasALogo()
        {
            //Arrange
            var restaurants = fixture.CreateMany<Restaurant>().ToList();
            A.CallTo(() => service.GetAllRestaurants()).Returns(restaurants);

            //Act
            viewModelUnderTest.GetAllRestaurants();

            //Assert
            viewModelUnderTest.Restaurants.All(x => x.Logo != null).ShouldBeTrue();
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

