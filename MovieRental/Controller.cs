using System;
using System.Collections.Generic;

namespace MovieRental
{

	public class Controller
	{
		public Customer Customer;
		private CustomerViewModel cvm;
		public CustomerView CustomerView;

		private Calculator genericCalculator = new Calculator(); // knows all the calculator types

		public Controller(Customer customer)
		{
			this.Customer = customer;
		}

		public void CalculatePrice ()
		{
			int total = 0;
			Dictionary<Rental, int> rentalsWithPrices = new Dictionary<Rental, int>();

			foreach (var rental in Customer.Rentals) 
			{
				IPriceCalculator calculator = genericCalculator.GetCalculatorForType (rental.Price); // can calculate rates for a certain type
				var fare = calculator.Calculate (rental.Days); //calculates the type rates depeding on the no of days	total += fare;
				rentalsWithPrices.Add (rental, fare);
			}

			cvm = new CustomerViewModel (Customer, rentalsWithPrices, total);
			CustomerView = new CustomerView (cvm);
		}
	}
}
