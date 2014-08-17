using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class CustomerViewModel
	{
        public  Dictionary<IPurchase, KeyValuePair<double, int>> RentalsWithPrices;
        public double Total;
        public int Points;

        public CustomerViewModel ( Dictionary<IPurchase, KeyValuePair<double, int>> rentalsWithPrices, double total, int points)
		{
			this.Total = total;
			this.RentalsWithPrices = rentalsWithPrices;
            this.Points = points;
		}
	}
}

