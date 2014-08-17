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
                // Get a calculator for this type of movie
				ICalculator calculator = genericCalculator.GetCalculatorForType (rental.Price); // can calculate rates for a certain type
				
                //Get the normal fare based on rental days and no of copies
                var fare = calculator.CalculatePrice (rental.Days, rental.CopiesAvailable); //calculates the type rates depeding on the no of days	total += fare;
				totalPrice += fare;

                //Calculate points based on no of copies
                var lastPoints = calculator.CalculatePoints (rental.CopiesAvailable);
                totalPoints += lastPoints;

                // Descrease available copies
                rental.CopiesAvailable -= 1;

                rentalsWithPrices.Add (rental, new KeyValuePair<int, int>(fare, lastPoints));
            }        
            customer.LoyalityPoints += totalPoints;
		}

        private void GetFreeRental()
        {
            if (customer.LoyalityPoints > 20)
            {
                var freeRental = rentalsWithPrices.LastOrDefault(x => x.Key.Type == PurchaseType.Rental).Value;

                if (!default(KeyValuePair<int, int>).Equals(freeRental))
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