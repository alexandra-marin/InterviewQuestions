using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class CustomerViewModel
	{
        public Dictionary<IRental, int> RentalsWithPrices;
		public int Total;
        public int Points;

        public CustomerViewModel (Dictionary<IRental, int> rentalsWithPrices, int total, int points)
		{
			this.Total = total;
			this.RentalsWithPrices = rentalsWithPrices;
            this.Points = points;
		}
	}
}

