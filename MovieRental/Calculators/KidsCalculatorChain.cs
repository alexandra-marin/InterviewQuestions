using System;

namespace MovieRental
{

    public class KidsCalculatorChain : ICalculator
	{
		private PriceCalculator calculator;

		public KidsCalculatorChain()
		{
            calculator = new PriceCalculator().BaseCost(3).AfterDays(3).ApplyDiscount(1).PointsGivenAfterDays(7).MaxPointsGiven(3);
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
