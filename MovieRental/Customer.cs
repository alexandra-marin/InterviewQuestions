using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class Customer
	{
		public string Name {get; set;}
		public List<Rental> Rentals { get; set;}

		public Customer ()
		{
		}

		public void ShowSummary()
		{
			int total = 0;
			int loyalityPoints = 0;

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

				if (rental.Days > 5 && rental.Price == MovieRental.Rental.PriceCode.Premiere)
					loyalityPoints++;

				if (rental.Days > 7 && rental.Price == MovieRental.Rental.PriceCode.Kids)
					loyalityPoints += 2;
			}

			loyalityPoints++;

			Console.WriteLine ("Total points is...");
			Console.WriteLine ("Total rent is...");
		}
	}
}

