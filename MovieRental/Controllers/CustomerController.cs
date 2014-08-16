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
        private Dictionary<IPurchase, KeyValuePair<int, int>> rentalsWithPrices = new Dictionary<IPurchase, KeyValuePair<int, int>>();

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

                var lastPoints = calculator.CalculatePoints ();
				totalPoints += lastPoints;

                rentalsWithPrices.Add (rental, new KeyValuePair<int, int>(fare, lastPoints));
            }            
            customer.LoyalityPoints += totalPoints;
		}

        private void GetFreeRental()
        {
            if (customer.LoyalityPoints > 20)
            {
                var freeRental = rentalsWithPrices.LastOrDefault(x => x.Key.Type == PurchaseType.Rental).Value;

                if (freeRental.Key != -1) //TODO ...
                {
                    totalPrice -= freeRental.Key;
                    customer.LoyalityPoints -= 20;
                    customer.LoyalityPoints -= freeRental.Value;
                }
            }
        }

        public void ShowCustomerSummary()
        {           
            CalculatePrice ();
            GetFreeRental();

            CustomerView = new CustomerView(new CustomerViewModel(rentalsWithPrices, totalPrice, customer.LoyalityPoints));
            CustomerView.ShowSummary();
        }
	}
}