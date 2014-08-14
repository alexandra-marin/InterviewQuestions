using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class CustomerViewModel
	{
		public Dictionary<Rental, int> RentalsWithPrices;
		public int TotalPriceOfRentals;
		public int Points;

		public CustomerViewModel (Dictionary<Rental, int> rentalsWithPrices, int rentalPrice, int points)
		{
			this.Points = points;
			this.TotalPriceOfRentals = rentalPrice;
			this.RentalsWithPrices = rentalsWithPrices;
		}
	}
}

