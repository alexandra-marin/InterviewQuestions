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

        public int CalculatePoints(int copies)
        {
            return calculator.CalculatePoints(copies);
        }
	}


}

