using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class MovieRentalThing
	{
		public static void Main ()
		{
			Controller c = new Controller ();
			c.View.ShowSummary ();
		}
	}

	public class CustomerView
	{
		private readonly Customer customer;

		public CustomerView()
		{
			customer = new Customer ();
			customer.Rentals = new List<Rental> ();

			customer.Rentals.Add (new Rental() {Price = PriceCode.Kids, Days = 10});
			customer.Rentals.Add (new Rental() {Price = PriceCode.Premiere, Days = 1});
		}

		public void ShowSummary()
		{
			int total = 0;

			Console.WriteLine ("Calculate for customer...");

			foreach (var rental in customer.Rentals) 
			{
				total += rental.CalculatePrice ();
				Console.WriteLine ("Rental cost is...");

//				LoyalityPoints = rental.CalculatePoints ();
//				Console.WriteLine ("Total points for rental is...");
			}

			Console.WriteLine ("Total rent is...");
		}
	}

	public class Controller
	{
		public CustomerView View;
		public Controller()
		{
			View = new CustomerView ();
		}
	}
}

