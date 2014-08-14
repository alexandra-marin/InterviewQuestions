using NUnit.Framework;
using System;
using System.Collections.Generic;
using MovieRental;

namespace CustomerTests
{
	[TestFixture ()]
	public class WithMoreThanTwentyPoints
	{
		Controller c;
		Customer customer = new Customer ();

		[TestFixtureSetUp]
		public void DefineCustomer ()
		{
			customer.Rentals = new List<Rental> ();
			customer.Rentals.Add (new Rental() {Price = PriceCode.Kids, Days = 10}); // 3pts
			customer.Rentals.Add (new Rental() {Price = PriceCode.Premiere, Days = 15}); //5 pts
			customer.Rentals.Add (new Rental() {Price = PriceCode.Premiere, Days = 15});
			customer.Rentals.Add (new Rental() {Price = PriceCode.Premiere, Days = 15});
			customer.Rentals.Add (new Rental() {Price = PriceCode.Premiere, Days = 15});

			c = new Controller (customer);
			c.CalculatePrice ();
		}

		[Test ()]
		public void GetsFreeRental ()
		{
			Calculator genericCalculator = new Calculator(); // knows all the calculator types
			int totalPrice = 0;
			int totalPoints = 0;
			Dictionary<Rental, int> rentalsWithPrices = new Dictionary<Rental, int>();

			foreach (var rental in customer.Rentals) 
			{
				IPriceCalculator calculator = genericCalculator.GetCalculatorForType (rental.Price); // can calculate rates for a certain type
				var fare = calculator.Calculate (rental.Days); //calculates the type rates depeding on the no of days	total += fare;
				totalPrice += fare;
				rentalsWithPrices.Add (rental, fare);
				totalPoints += rental.CalculatePoints ();
			}

			Assert.IsTrue (totalPrice);
		}

		[Test ()]
		public void PointsAreResetted ()
		{
			Assert.IsTrue (customer.LoyalityPoints == 0);
		}
	}
}

