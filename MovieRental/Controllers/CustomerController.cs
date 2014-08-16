using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class CustomerController
	{
		private Customer customer;
		public CustomerView CustomerView;

		private Calculator genericCalculator = new Calculator(); // knows all the calculator types

        private int totalPoints = 0;
        private int totalPrice = 0;
        private Dictionary<IRental, int> rentalsWithPrices = new Dictionary<IRental, int>();

		public CustomerController(Customer customer)
		{
			this.customer = customer;
		}

		public void CalculatePrice ()
		{
			int lastFare = 0;
			int lastPoints = 0;

			foreach (var rental in customer.Rentals) 
			{
				ICalculator calculator = genericCalculator.GetCalculatorForType (rental.Price); // can calculate rates for a certain type
				var fare = calculator.CalculatePrice (rental.Days); //calculates the type rates depeding on the no of days	total += fare;
				totalPrice += fare;
				lastFare = fare;
				rentalsWithPrices.Add (rental, fare);
                lastPoints = calculator.CalculatePoints ();
				totalPoints += lastPoints;
			}

			customer.LoyalityPoints += totalPoints;

			if (customer.LoyalityPoints > 20)
			{
				totalPrice -= lastFare;
				customer.LoyalityPoints -= 20;
				customer.LoyalityPoints -= lastPoints;
			}
		}

        public void ShowCustomerSummary()
        {
            CustomerView = new CustomerView(new CustomerViewModel(rentalsWithPrices, totalPrice, totalPoints));
            CustomerView.ShowSummary();
        }
	}
}
