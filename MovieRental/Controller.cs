using System;
using System.Collections.Generic;

namespace MovieRental
{

	public class Controller
	{
		private Customer customer;
		public CustomerView CustomerView;
		private CustomerViewModel customerViewModel;

		private Calculator genericCalculator = new Calculator(); // knows all the calculator types

		public Controller(Customer customer)
		{
			this.customer = customer;
		}

		public void CalculatePrice ()
		{
			int totalPrice = 0;
			int totalPoints = 0;
			int lastFare = 0;
			Dictionary<Rental, int> rentalsWithPrices = new Dictionary<Rental, int>();

			foreach (var rental in customer.Rentals) 
			{
				IPriceCalculator calculator = genericCalculator.GetCalculatorForType (rental.Price); // can calculate rates for a certain type
				var fare = calculator.Calculate (rental.Days); //calculates the type rates depeding on the no of days	total += fare;
				totalPrice += fare;
				lastFare = fare;
				rentalsWithPrices.Add (rental, fare);
				totalPoints += rental.CalculatePoints ();
			}

			customer.LoyalityPoints += totalPoints;

			if (customer.LoyalityPoints > 20)
			{
				totalPrice -= lastFare;
				customer.LoyalityPoints = 0;
			}

			customerViewModel = new CustomerViewModel (customer, rentalsWithPrices, totalPrice);
			CustomerView = new CustomerView (customerViewModel);
		}
	}
}
