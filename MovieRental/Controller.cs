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
			int totalpoints = 0;
			Dictionary<Rental, int> rentalsWithPrices = new Dictionary<Rental, int>();

			foreach (var rental in customer.Rentals) 
			{
				IPriceCalculator calculator = genericCalculator.GetCalculatorForType (rental.Price); // can calculate rates for a certain type
				var fare = calculator.Calculate (rental.Days); //calculates the type rates depeding on the no of days	total += fare;
				totalPrice += fare;
				totalpoints += CalculateRentalPoints(rental);
				rentalsWithPrices.Add (rental, fare);
			}

			customerViewModel = new CustomerViewModel (rentalsWithPrices, totalPrice, totalpoints);
			CustomerView = new CustomerView (customerViewModel);
		}

		public int CalculateRentalPoints (Rental rental)
		{
			if (rental.Days > 5 && rental.Price == PriceCode.Premiere)
				return 5;
			else if (rental.Days > 7 && rental.Price == PriceCode.Kids)
				return 3;
			else
				return 1;
		}
	}
}
