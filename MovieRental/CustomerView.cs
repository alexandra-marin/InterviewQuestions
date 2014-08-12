using System;
using System.Collections.Generic;

namespace MovieRental
{

	public class CustomerView
	{
		CustomerViewModel cvm;

		public CustomerView(CustomerViewModel cvm)
		{
			this.cvm = cvm;

		}

		public void ShowSummary()
		{
			Console.WriteLine (cvm.customer);
			Console.WriteLine (cvm.rentalsWithPrices);
			Console.WriteLine (cvm.total);
		}
	}

}
