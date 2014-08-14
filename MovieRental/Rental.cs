using System;

namespace MovieRental
{
	public enum PriceCode {Normal, Kids, Premiere};

	public class Rental
	{
		public int Days { get; set;}
		public PriceCode Price { get; set;}
	}
}

