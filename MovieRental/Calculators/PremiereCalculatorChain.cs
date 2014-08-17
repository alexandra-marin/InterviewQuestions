namespace MovieRental
{
    public class PremiereCalculatorChain : ICalculator
	{
		private PriceCalculator calculator;

		public PremiereCalculatorChain()
		{
            calculator = new PriceCalculator().BaseCost(3).PointsGivenAfterDays(5).MaxPointsGiven(5);
		}

        public double CalculatePrice(int days, int copiesLeft)
        {
            return calculator.ForDays(days).CopiesLeft(copiesLeft).CalculatePrice();
        }

        public int CalculatePoints(int copies)
        {
            return calculator.CalculatePoints(copies);
        }
	}
}
