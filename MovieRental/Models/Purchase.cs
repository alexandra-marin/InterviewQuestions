﻿namespace MovieRental
{
	public class Purchase : IPurchase
	{
		public int Days { get; set;}
		public PriceCode Price { get; set;}
        public PurchaseType Type { get; set;}
	}

}

