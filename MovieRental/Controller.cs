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
				var fare = calculator.CalculatePrice (rental.Days); //calculates the type rates depeding on the no of days	total += fare;
				totalPrice += fare;
				totalpoints += calculator.CalculatePoints();
				rentalsWithPrices.Add (rental, fare);
			}

			customerViewModel = new CustomerViewModel (rentalsWithPrices, totalPrice, totalpoints);
			CustomerView = new CustomerView (customerViewModel);
		}
	}
}
