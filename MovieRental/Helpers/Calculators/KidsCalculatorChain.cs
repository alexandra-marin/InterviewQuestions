namespace MovieRental
{
    public class KidsCalculatorChain : ICalculator
	{
		private PriceCalculator calculator;

		public KidsCalculatorChain()
		{
            calculator = new PriceCalculator().BaseCost(3).AfterDays(3).ApplyDiscount(1).PointsGivenAfterDays(7).MaxPointsGiven(3);
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
