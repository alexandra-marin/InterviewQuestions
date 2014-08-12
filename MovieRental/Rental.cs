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

		public int CalculatePoints ()
		{
			if (this.Days > 5 && this.Price == PriceCode.Premiere)
				return 5;
			else if (this.Days > 7 && this.Price == PriceCode.Kids)
				return 3;
			else
				return 1;
		}
	}
}

