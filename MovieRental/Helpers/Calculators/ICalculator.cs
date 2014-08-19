using System;

namespace MovieRental
{
	public interface ICalculator
	{
        Number CalculatePrice(int days, int copiesLeft);
        int CalculatePoints(int copies);
	}
}

