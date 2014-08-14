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
				{PriceCode.Normal, new NormalCalculatorChain()},
				{PriceCode.Kids, new KidsCalculatorChain()},
				{PriceCode.Premiere, new PremmiereCalculatorChain()}
			};
		}

		public IPriceCalculator GetCalculatorForType (PriceCode price)
		{
			return calculatorTypes[price];
		}
	}

}

