using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class PriceCalculator
	{
		private int cost;
		private int days;
		private int discountCost;
		private int afterDays;

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
			var discountedDays = GetDiscountedDays ();
			return cost * (days - discountedDays) + discountCost * GetDiscountedDays(); //full price for the first days, discounted after
		}

		private bool DiscountApplies ()
		{
			return days > afterDays;
		}

		private int GetDiscountedDays()
		{
			return DiscountApplies () ? afterDays - 1 : 0;
		}
	}
}
