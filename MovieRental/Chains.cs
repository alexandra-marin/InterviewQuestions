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

		public NormalCalculatorChain ForDays(int days)
		{
			calculator.ForDays(days);
			return this;
		}

		#region IPriceCalculator implementation

		public int CalculatePrice (int days)
		{
			return calculator.CalculatePrice ();
		}

		#endregion

		public int CalculatePoints ()
		{
			return 0;// calculator.CalculatePoints ();
		}
	}

	public class KidsCalculatorChain : ICalculator
	{
		private PriceCalculator calculator;

		public KidsCalculatorChain()
		{
			calculator = new PriceCalculator().BaseCost(3).AfterDays (3).ApplyDiscount (1).PointsGivenAfterDays(7).MaxPointsGiven(3);

		}

		public KidsCalculatorChain ForDays(int days)
		{
			calculator.ForDays(days);
			return this;
		}

		#region IPriceCalculator implementation

		public int CalculatePrice (int days)
		{
			return calculator.CalculatePrice ();
		}

		#endregion

		public int CalculatePoints ()
		{
			return calculator.CalculatePoints ();
		}
	}

	public class PremmiereCalculatorChain : ICalculator
	{
		private PriceCalculator calculator;

		public PremmiereCalculatorChain()
		{
			calculator = new PriceCalculator().BaseCost (3).PointsGivenAfterDays(5).MaxPointsGiven(5);
		}

		public PremmiereCalculatorChain ForDays(int days)
		{
			calculator.ForDays(days);			
			return this;
		}

		#region IPriceCalculator implementation

		public int CalculatePrice (int days)
		{
			return calculator.CalculatePrice ();
		}

		#endregion

		public int CalculatePoints ()
		{
			return calculator.CalculatePoints ();
		}
	}
}

