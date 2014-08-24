namespace MovieRental
{
    public class NormalCalculatorChain : ICalculator
	{
		private PriceCalculator calculator;

		public NormalCalculatorChain()
		{
			calculator = new PriceCalculator().BaseCost(2).AfterDays (2).ApplyDiscount (1);
		}

        public Number CalculatePrice(int days, int copiesLeft)
        {
            return calculator.ForDays(days).CopiesLeft(copiesLeft).CalculatePrice();
        }

        public Number CalculatePoints(int copies)
        {
            return new Number(calculator.CalculatePoints(copies));
        }
	}


}

