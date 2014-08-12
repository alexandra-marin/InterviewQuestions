using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class CustomerViewModel
	{
		public Customer Customer;
		public Dictionary<Rental, int> RentalsWithPrices;
		public int Total;

		public CustomerViewModel (Customer customer, Dictionary<Rental, int> rentalsWithPrices, int total)
		{
			this.Total = total;
			this.RentalsWithPrices = rentalsWithPrices;
			this.Customer = customer;
		}
	}
}

