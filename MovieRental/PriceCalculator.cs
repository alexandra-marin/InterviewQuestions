using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class PriceCalculator
	{
		int cost;
		int days;
		int discountCost;
		int afterDays;

		public PriceCalculator BaseCost(int cost)
		{
			this.cost = cost;
			return this;
		}

		public PriceCalculator ForDays(int days)
		{
			this.days = days;
			return this;
		}

		public PriceCalculator DiscountedCost(int discount)
		{
			this.discountCost = discount;
			return this;
		}

		public PriceCalculator AfterDays(int afterDays)
		{
			this.afterDays = afterDays;
			return this;
		}

		public int Calculate()
		{
			var discountApplies = DiscountApplies ();

			if (discountApplies) 
			{
				CalculateSpecialCost (); 
			} 
			else 
			{
				CalculateSimpleCost ();
			}
		}

		public bool DiscountApplies ()
		{
			return days > afterDays;
		}

		public int CalculateSimpleCost ()
		{
			return cost * days;
		}

		public int CalculateSpecialCost ()
		{
			return cost * (days - afterDays + 1) + discountCost * (afterDays - 1); //full price for the first days, discounted after
		}
	}
}
