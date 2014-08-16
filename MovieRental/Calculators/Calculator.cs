using System.Collections.Generic;

namespace MovieRental
{
	public class Calculator
	{
		private Dictionary<PriceCode, ICalculator> calculatorTypes;

		public Calculator()
		{
			calculatorTypes = new Dictionary<PriceCode, ICalculator>()
			{
                {PriceCode.Normal, new NormalCalculatorChain()},
                {PriceCode.Kids, new KidsCalculatorChain()},
                {PriceCode.Premiere, new PremiereCalculatorChain()}
			};
		}

		public ICalculator GetCalculatorForType (PriceCode price)
		{
			return calculatorTypes[price];
		}
	}

}

