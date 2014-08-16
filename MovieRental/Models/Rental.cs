using System;

namespace MovieRental
{
	public enum PriceCode { Normal, Kids, Premiere };

	public class Rental : IRental
	{
		public int Days { get; set;}
		public PriceCode Price { get; set;}
	}

}

