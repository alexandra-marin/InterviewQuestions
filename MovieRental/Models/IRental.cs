using System;

namespace MovieRental
{
	public interface IRental
	{
		int Days { get; set;}
		PriceCode Price { get; set;}
	}
}
