using System;

namespace MovieRental
{
	public class NormalCalculatorChain
	{
		private PriceCalculator calculator;

		public NormalCalculatorChain()
		{
			calculator = new PriceCalculator().BaseCost(2).AfterDays (2).ApplyDiscount (1);
		}

		public NormalCalculatorChain ForDays(int days)
		{
			calculator.ForDays(days);
			return this;
		}
	}

	public class KidsCalculatorChain
	{
		private PriceCalculator calculator;

		public KidsCalculatorChain()
		{
			calculator = new PriceCalculator().BaseCost(3).AfterDays (3).ApplyDiscount (1);

		}

		public KidsCalculatorChain ForDays(int days)
		{
			calculator.ForDays(days);
			return this;
		}
	}

	public class PremmiereCalculatorChain
	{
		private PriceCalculator calculator;

		public PremmiereCalculatorChain()
		{
			calculator = new PriceCalculator().BaseCost (3);
		}

		public PremmiereCalculatorChain ForDays(int days)
		{
			calculator.ForDays(days);			
			return this;
		}
	}
}

