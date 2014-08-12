﻿using System;

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

		public int CalculatePrice ()
		{
			int total = 0;
			switch (this.Price) 
			{
				case PriceCode.Normal:
					total += 2;
					if (this.Days > 2)
						total += 1;
					break;
				case PriceCode.Kids:
					total += 5;
					if (this.Days > 2)
						total += 2;
					break;
				case PriceCode.Premiere:
					total += 3;
					break;
			}
			return total;
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

