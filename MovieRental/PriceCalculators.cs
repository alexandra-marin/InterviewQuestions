using System;

namespace MovieRental
{
	public interface ICalculator
	{
		int CalculatePrice(int days);
		int CalculatePoints();
	}
}

