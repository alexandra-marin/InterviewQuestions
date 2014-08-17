using System;

namespace MovieRental
{
	public interface ICalculator
	{
        double CalculatePrice(int days, int copiesLeft);
        int CalculatePoints(int copies);
	}
}

