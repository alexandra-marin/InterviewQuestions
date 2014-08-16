using System;
using System.Collections.Generic;
using System.Linq;

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
        int lastPoints = 0;

		public CustomerController(Customer customer)
		{
			this.customer = customer;
		}

        private void CalculatePrice ()
		{
			foreach (var rental in customer.Rentals) 
			{
				ICalculator calculator = genericCalculator.GetCalculatorForType (rental.Price); // can calculate rates for a certain type
				
                var fare = calculator.CalculatePrice (rental.Days); //calculates the type rates depeding on the no of days	total += fare;
				totalPrice += fare;
				rentalsWithPrices.Add (rental, fare);

                lastPoints = calculator.CalculatePoints ();
				totalPoints += lastPoints;
            }            
            customer.LoyalityPoints += totalPoints;
		}

        private void CalculatePoints()
        {
            if (customer.LoyalityPoints > 20)
            {
                totalPrice -= rentalsWithPrices.Values.Last();
                customer.LoyalityPoints -= 20;
                customer.LoyalityPoints -= lastPoints;
            }
        }

        public void ShowCustomerSummary()
        {           
            CalculatePrice ();
            CalculatePoints();

            CustomerView = new CustomerView(new CustomerViewModel(rentalsWithPrices, totalPrice, totalPoints));
            CustomerView.ShowSummary();
        }
	}
}
