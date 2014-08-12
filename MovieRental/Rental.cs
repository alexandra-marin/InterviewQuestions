using System;

namespace MovieRental
{
	public class Rental
	{
		public enum PriceCode {Normal, Kids, Premiere};

		public int Days { get; set;}
		public PriceCode Price { get; set;}

		public Rental ()
		{
		}
	}
}

