using System;

namespace MovieRental
{
	public interface IPriceCalculator
	{
		int CalculatePrice(int days);
		int CalculatePoints();
	}
}

