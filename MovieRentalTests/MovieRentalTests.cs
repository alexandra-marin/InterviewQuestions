using NUnit.Framework;
using System;
using System.Collections.Generic;
using MovieRental;

namespace CustomerTests
{
	[TestFixture ()]
	public class WithMoreThanTwentyPoints
	{
		Customer customer;
		Controller controller;

		[TestFixtureSetUp]
		public void DefineCustomer ()
		{
			customer = new Customer ();
			customer.LoyalityPoints = 21;
			controller = new Controller(customer);

		}

		[Test ()]
		public void GetsFreeRental ()
		{
			customer.Rentals = new List<Rental> ();
			customer.Rentals.Add (new Rental() {Price = PriceCode.Kids, Days = 10}); // 3pts
			controller.CalculatePrice ();

			Assert.IsTrue (controller.CustomerView.customerViewModel.Total == 0);
		}

		[Test ()]
		public void PointsAreResetted ()
		{
			Assert.IsTrue (customer.LoyalityPoints == 0);
		}
	}
}

