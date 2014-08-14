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
			Dictionary<Rental, int> rentalsWithPrices = new Dictionary<Rental, int>();
			var lastFare;

			foreach (var rental in customer.Rentals) 
			{
				ICalculator calculator = genericCalculator.GetCalculatorForType (rental.Price); // can calculate rates for a certain type
				var fare = calculator.CalculatePrice (rental.Days); //calculates the type rates depeding on the no of days	total += fare;
				totalPrice += fare;
				lastFare = fare;
				totalPoints += calculator.CalculatePoints();
				rentalsWithPrices.Add (rental, fare);
			}

			//Give the last rental free to loyal customers
			if (totalPoints > 20) 
            {
				totalPrice -= lastFare;
                customer.LoyalityPoints = 0;
			} 
            else 
            {
                customer.LoyalityPoints = totalPoints;
			}

			customerViewModel = new CustomerViewModel (rentalsWithPrices, totalPrice, totalPoints);
			CustomerView = new CustomerView (customerViewModel);
		}
	}
}
