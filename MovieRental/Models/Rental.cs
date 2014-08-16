using System;

namespace MovieRental
{
	public class Rental : IRental
	{
		public int Days { get; set;}
		public PriceCode Price { get; set;}
        public PurchaseType Type { get; set;}
	}

}

