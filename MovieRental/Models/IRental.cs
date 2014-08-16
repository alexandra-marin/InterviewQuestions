using System;

namespace MovieRental
{
    public enum PriceCode { Normal, Kids, Premiere };
    public enum PurchaseType { Rental, Purchase }

	public interface IRental
	{
		int Days { get; set;}
		PriceCode Price { get; set;}
        PurchaseType Type { get; set;}
	}

}
