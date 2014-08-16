using System;

namespace MovieRental
{
    public class PremmiereCalculatorChain : ICalculator
	{
		private PriceCalculator calculator;

		public PremmiereCalculatorChain()
		{
            calculator = new PriceCalculator().BaseCost(3).PointsGivenAfterDays(5).MaxPointsGiven(5);
		}

        public int CalculatePrice(int days)
        {
            return calculator.ForDays(days).CalculatePrice();
        }

        public int CalculatePoints()
        {
            return calculator.CalculatePoints();
        }
	}
}
