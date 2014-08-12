using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class Customer
	{
		public string Name {get; set;}
		public List<Rental> Rentals { get; set;}
		int LoyalityPoints = 0;
	}
}

