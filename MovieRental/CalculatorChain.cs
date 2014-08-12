using System;
using System.Collections.Generic;

namespace MovieRental
{

	public class NormalCalculatorChain
	{
		int cost;
		int days;

		public void BaseCost(int cost)
		{
			cost = cost;
		}

		public int AfterDays(int days)
		{
			days = days;
		}

		public int Calculate()
		{
			return cost * days;
		}
	}
}
