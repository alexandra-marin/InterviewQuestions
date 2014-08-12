using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class Customer
	{
		public string Name {get; set;}
		public int LoyalityPoints = 0;
		public List<Rental> Rentals { get; set;}
	}
}

