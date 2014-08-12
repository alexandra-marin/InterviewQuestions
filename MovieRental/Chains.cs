using System;

namespace MovieRental
{
	public class NormalCalculatorChain
	{
		private PriceCalculator calculator;

		public NormalCalculatorChain()
		{
			calculator = new PriceCalculator ();
			calculator.BaseCost (2);
			calculator.AfterDays (2);
			calculator.DiscountedCost (1);
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
			calculator = new PriceCalculator ();
			calculator.BaseCost (3);
			calculator.AfterDays (3);
			calculator.DiscountedCost (1);
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
			calculator = new PriceCalculator ();
			calculator.BaseCost (3);
		}

		public PremmiereCalculatorChain ForDays(int days)
		{
			calculator.ForDays(days);			
			return this;
		}
	}
}

