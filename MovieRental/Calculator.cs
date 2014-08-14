using System;
using System.Collections.Generic;

namespace MovieRental
{
	public class Calculator
	{
		private Dictionary<PriceCode, IPriceCalculator> calculatorTypes;

		public Calculator()
		{
			calculatorTypes = new Dictionary<PriceCode, IPriceCalculator>()
			{
				{PriceCode.Normal, new NormalPriceCalculator()},
				{PriceCode.Kids, new KidsPriceCalculator()},
				{PriceCode.Premiere, new PremierePriceCalculator()}
			};
		}

		public IPriceCalculator GetCalculatorForType (PriceCode price)
		{
			return calculatorTypes[price];
		}
	}

}

