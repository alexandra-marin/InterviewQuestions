using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class CalculatorChain
	{
		int cost;
		int days;
		int discountCost;
		int afterDays;

		public CalculatorChain BaseCost(int cost)
		{
			this.cost = cost;
			return this;
		}

		public CalculatorChain ForDays(int days)
		{
			this.days = days;
			return this;
		}

		public CalculatorChain ApplyDiscount(int discount)
		{
			this.discountCost = discount;
			return this;
		}

		public CalculatorChain AfterDays(int afterDays)
		{
			this.afterDays = afterDays;
			return this;
		}

		public int Calculate()
		{
			bool discountApplies = days > afterDays;

			if (discountApplies) {
				return cost * (days - afterDays + 1) + discountCost * (afterDays - 1); //full price for the first days, discounted after
			} 
			else 
			{
				return cost * days;
			}
		}
	}

	public class NormalCalculatorChain
	{
		private CalculatorChain calculator;

		public NormalCalculatorChain()
		{
			calculator = new CalculatorChain ();
			calculator.BaseCost (2);
			calculator.AfterDays (2);
			calculator.ApplyDiscount (1);
		}

		public NormalCalculatorChain ForDays(int days)
		{
			calculator.ForDays(days);
			return this;
		}
	}

	public class KidsCalculatorChain
	{
		private CalculatorChain calculator;

		public KidsCalculatorChain()
		{
			calculator = new CalculatorChain ();
			calculator.BaseCost (3);
			calculator.AfterDays (3);
			calculator.ApplyDiscount (1);
		}

		public KidsCalculatorChain ForDays(int days)
		{
			calculator.ForDays(days);
			return this;

		}
	}

	public class PremmiereCalculatorChain
	{
		private CalculatorChain calculator;

		public PremmiereCalculatorChain()
		{
			calculator = new CalculatorChain ();
			calculator.BaseCost (3);
		}

		public PremmiereCalculatorChain ForDays(int days)
		{
			calculator.ForDays(days);			
			return this;

		}
	}
}
