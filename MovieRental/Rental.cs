using System;

namespace MovieRental
{
	public enum PriceCode {Normal, Kids, Premiere};

	public class Rental
	{
		private Calculator genericCalculator = new Calculator(); // knows all the calculator types

		public int Days { get; set;}
		public PriceCode Price { get; set;}

		public Rental ()
		{
		}

		public int CalculatePrice ()
		{
			int total = 0;

			IPriceCalculator calculator = genericCalculator.GetCalculatorForType (this.Price); // can calculate rates for a certain type
			total += calculator.Calculate (this.Days); //calculates the type rates depeding on the no of days

			return total;
		}

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
}

