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

		public PriceCalculator ApplyDiscount(int discount)
		{
			this.discountCost = cost - discount;
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
				return CalculateWithDiscount (); 
			} 
			else 
			{
				return CalculateWithoutDiscount ();
			}
		}

		public bool DiscountApplies ()
		{
			return days > afterDays;
		}

		public int CalculateWithoutDiscount ()
		{
			return cost * days;
		}

		public int CalculateWithDiscount ()
		{
			return cost * (days - afterDays + 1) + discountCost * DiscountedDays(); //full price for the first days, discounted after
		}

		public int DiscountedDays()
		{
			return afterDays - 1;
		}
	}
}
