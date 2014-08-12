using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class Customer
	{
		public string Name {get; set;}
		public List<Rental> Rentals { get; set;}
		int LoyalityPoints = 0;

		public Customer ()
		{
		}

		public void ShowSummary()
		{
			int total = 0;

			Console.WriteLine ("Calculate for customer...");

			foreach (var rental in Rentals) 
			{
				switch (rental.Price) 
				{
					case MovieRental.Rental.PriceCode.Normal:
							total += 1.5;
							if (rental.Days > 2)
								total += 1.2;
						break;
					case MovieRental.Rental.PriceCode.Kids:
							total += 3;
							if (rental.Days > 2)
								total += 1.5;
						break;
					case MovieRental.Rental.PriceCode.Premiere:
							total += 3;
						break;
				}
				Console.WriteLine ("Rental cost is...");

				LoyalityPoints++;

				if (rental.Days > 5 && rental.Price == MovieRental.Rental.PriceCode.Premiere)
					LoyalityPoints++;

				if (rental.Days > 7 && rental.Price == MovieRental.Rental.PriceCode.Kids)
					LoyalityPoints += 2;

				Console.WriteLine ("Total points for rental is...");
			}

			Console.WriteLine ("Total rent is...");
		}
	}
}

