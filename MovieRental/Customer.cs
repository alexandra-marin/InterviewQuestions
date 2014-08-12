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
				total += rental.CalculatePrice ();
				Console.WriteLine ("Rental cost is...");

				LoyalityPoints = rental.CalculatePoints ();
				Console.WriteLine ("Total points for rental is...");
			}

			Console.WriteLine ("Total rent is...");
		}
	}
}

