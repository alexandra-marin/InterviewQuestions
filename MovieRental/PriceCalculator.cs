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
			var discountedDays = GetDiscountedDays ();
			return cost * (days - discountedDays) + discountCost * GetDiscountedDays(); //full price for the first days, discounted after
		}

		public int GetDiscountedDays()
		{
			return days > afterDays ? afterDays - 1 : 0;
		}
	}
}
