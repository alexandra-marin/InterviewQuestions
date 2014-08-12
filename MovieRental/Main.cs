using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class MovieRentalThing
	{
		public static void Main ()
		{
			Customer customer = new Customer ();
			customer.Rentals = new List<Rental> ();

			customer.Rentals.Add (new Rental() {Price = PriceCode.Kids, Days = 10});
			customer.Rentals.Add (new Rental() {Price = PriceCode.Premiere, Days = 1});


			Controller c = new Controller (customer);
			c.CustomerView.ShowSummary ();
		}
	}


}

