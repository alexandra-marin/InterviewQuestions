using System;

namespace MovieRental
{
    public class NormalCalculatorChain : ICalculator
	{
		private PriceCalculator calculator;

		public NormalCalculatorChain()
		{
			calculator = new PriceCalculator().BaseCost(2).AfterDays (2).ApplyDiscount (1);
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

