using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class CustomerView
	{
        public CustomerViewModel customerViewModel;

		public CustomerView(CustomerViewModel cvm)
		{
			this.customerViewModel = cvm;
		}

		public void ShowSummary()
		{
			Console.WriteLine (customerViewModel.RentalsWithPrices);
			Console.WriteLine (customerViewModel.Total);
            Console.WriteLine (customerViewModel.Points);
		}
	}

}
