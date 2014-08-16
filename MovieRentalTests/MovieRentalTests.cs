using NUnit.Framework;
using System;
using System.Collections.Generic;
using MovieRental;
using MovieRentalTests;

namespace CustomerTests
{
	[TestFixture ()]
	public class WithMoreThanTwentyPoints
	{
		Customer customer;
		CustomerController controller;

		[SetUpAttribute]
		public void DefineCustomer ()
		{
			customer = new Customer ();
			customer.LoyalityPoints = 21;

			customer.Rentals = new List<IRental> ();
			customer.Rentals.Add ((IRental)(new RentalMock().MockRental.MockInstance)); 

			controller = new CustomerController(customer);
		}

		[Test ()]
		public void GetsOneFreeRental ()
		{
			controller.CalculatePrice ();
			Assert.IsTrue (controller.CustomerView.customerViewModel.Total == 0);
		}

		[Test ()]
		public void PaysSecondRental ()
		{
			//Add second rental
			customer.Rentals.Add ((IRental)(new RentalMock().MockRental.MockInstance)); 

			controller.CalculatePrice ();
			Assert.IsTrue (controller.CustomerView.customerViewModel.Total > 0);
		}

		[Test ()]
		public void PointsAreReset ()
		{
			controller.CalculatePrice ();
			Assert.IsTrue (customer.LoyalityPoints == 1); //21+3-20
		}
	}
}

