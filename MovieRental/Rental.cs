using System;

namespace MovieRental
{
	public enum PriceCode {Normal, Kids, Premiere};

	public class Rental : IRental
	{
		public int Days { get; set;}
		public PriceCode Price { get; set;}

		public int CalculatePoints ()
		{
			//TODO same as price
			if (this.Days > 5 && this.Price == PriceCode.Premiere)
				return 5;
			else if (this.Days > 7 && this.Price == PriceCode.Kids)
				return 3;
			else
				return 1;
		}
	}

	public interface IRental
	{
		int Days { get; set;}
		PriceCode Price { get; set;}
		int CalculatePoints();
	}
}

