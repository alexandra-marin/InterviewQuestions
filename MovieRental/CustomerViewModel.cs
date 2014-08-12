using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class CustomerViewModel
	{
		public Customer customer;
		public Dictionary<Rental, int> rentalsWithPrices;
		public int total;

		public CustomerViewModel (Customer customer, Dictionary<Rental, int> rentalsWithPrices, int total)
		{
			this.total = total;
			this.rentalsWithPrices = rentalsWithPrices;
			this.customer = customer;
		}
	}
}

