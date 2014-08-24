using System.Collections.Generic;

namespace MovieRental
{
	public class Customer
	{
		public string Name {get; set;}
        public Number LoyalityPoints;
        public List<IPurchase> Rentals { get; set;}
        public static readonly Number MaxLoyalityPoints = new Number(20);
	}
}

