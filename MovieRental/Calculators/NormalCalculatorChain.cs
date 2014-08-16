namespace MovieRental
{
    public class NormalCalculatorChain : ICalculator
	{
		private PriceCalculator calculator;

		public NormalCalculatorChain()
		{
			calculator = new PriceCalculator().BaseCost(2).AfterDays (2).ApplyDiscount (1);
		}

        public int CalculatePrice(int days)
        {
            return calculator.ForDays(days).CalculatePrice();
        }

        public int CalculatePoints()
        {
            return calculator.CalculatePoints();
        }
	}


}

