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
        private Number totalPrice;
        private Dictionary<IPurchase, KeyValuePair<double, int>> rentalsWithPrices = new Dictionary<IPurchase, KeyValuePair<double, int>>();

		public CustomerController(Customer customer)
		{
			this.customer = customer;
		}

        private void CalculatePrice ()
		{
			foreach (var rental in customer.Rentals) 
			{
                // Get a calculator for this type of movie
				ICalculator calculator = genericCalculator.GetCalculatorForType (rental.Price);
				
                //Get the normal fare based on rental days and no of copies
                var fare = calculator.CalculatePrice (rental.Days, rental.CopiesAvailable);
                totalPrice += fare;

                //Calculate points based on no of copies
                var lastPoints = calculator.CalculatePoints (rental.CopiesAvailable);
                totalPoints += lastPoints;

                // Descrease available copies
                rental.CopiesAvailable -= 1;

                rentalsWithPrices.Add (rental, new KeyValuePair<double, int>(fare.GetValue(), lastPoints));
            }        
            customer.LoyalityPoints += totalPoints;
		}

        private void GetFreeRental()
        {
            if (customer.LoyalityPoints > 20)
            {
                var freeRental = rentalsWithPrices.LastOrDefault(x => x.Key.Type == PurchaseType.Rental).Value;

                if (!default(KeyValuePair<double, int>).Equals(freeRental))
                {
                    totalPrice -= new Number(freeRental.Key);
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