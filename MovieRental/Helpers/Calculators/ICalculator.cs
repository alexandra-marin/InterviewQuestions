using System;

namespace MovieRental
{
	public interface ICalculator
	{
        Number CalculatePrice(int days, int copiesLeft);
        Number CalculatePoints(int copies);
	}
}

