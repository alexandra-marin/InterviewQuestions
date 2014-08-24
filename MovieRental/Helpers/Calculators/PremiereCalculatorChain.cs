namespace MovieRental
{
    public class PremiereCalculatorChain : ICalculator
	{
		private PriceCalculator calculator;

		public PremiereCalculatorChain()
		{
            calculator = new PriceCalculator().BaseCost(3).PointsGivenAfterDays(5).MaxPointsGiven(5);
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
