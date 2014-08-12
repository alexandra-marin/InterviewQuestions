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

		public void BaseCost(int cost)
		{
			this.cost = cost;
		}

		public int ForDays(int days)
		{
			this.days = days;
		}

		public int ApplyDiscount(int discount)
		{
			this.discountCost = discount;
		}

		public int AfterDays(int afterDays)
		{
			this.afterDays = afterDays;
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

		public int ForDays(int days)
		{
			calculator.ForDays(days);
		}
	}
}
