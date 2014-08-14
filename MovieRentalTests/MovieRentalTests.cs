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

		[SetUpAttribute]
		public void DefineCustomer ()
		{
			customer = new Customer ();
			customer.Rentals = new List<Rental> ();
			customer.LoyalityPoints = 21;
			controller = new Controller(customer);

		}

		[Test ()]
		public void GetsOneFreeRental ()
		{
			customer.Rentals.Add (new Rental() {Price = PriceCode.Kids, Days = 10}); // 3pts
			controller.CalculatePrice ();

			Assert.IsTrue (controller.CustomerView.customerViewModel.Total == 0);
		}

		[Test ()]
		public void PaysSecondRental ()
		{
			customer.Rentals.Add (new Rental() {Price = PriceCode.Kids, Days = 10}); // 3pts
			customer.Rentals.Add (new Rental() {Price = PriceCode.Kids, Days = 10}); // 3pts

			controller.CalculatePrice ();

			Assert.IsTrue (controller.CustomerView.customerViewModel.Total > 0);
		}

		[Test ()]
		public void PointsAreResetted ()
		{
			customer.Rentals.Add (new Rental() {Price = PriceCode.Kids, Days = 10}); // 3pts
			controller.CalculatePrice ();
			Assert.IsTrue (customer.LoyalityPoints == 4); //21+3-20
		}
	}
}

