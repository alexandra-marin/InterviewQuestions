using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class CustomerViewModel
	{
        public  Dictionary<IPurchase, KeyValuePair<double, int>> RentalsWithPrices;
        public double Total;
        public int Points;

        public CustomerViewModel ( Dictionary<IPurchase, KeyValuePair<double, int>> rentalsWithPrices, Number total, Number points)
		{
            this.Total = total.GetDoubleValue();
			this.RentalsWithPrices = rentalsWithPrices;
            this.Points = points.GetIntValue();
		}
	}
}

