using System;

namespace MovieRental
{
	public interface IPriceCalculator
	{
		int Calculate(int days);
	}

	public class NormalPriceCalculator : IPriceCalculator
	{
		public int Calculate(int days)
		{
			var total = 0;
			total += 2;
			if (days > 2)
				total += 1;
			return total;
		}
	}

	public class KidsPriceCalculator : IPriceCalculator
	{
		public int Calculate(int days)
		{
			var total = 0;
			total += 3;
			if (days > 3)
				total += 1;
			return total;
		}
	}

	public class PremierePriceCalculator : IPriceCalculator
	{
		public int Calculate(int days)
		{
			var total = 3;
			return total;
		}
	}
}

