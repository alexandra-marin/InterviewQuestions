namespace MovieRental
{
    public class PriceCalculator
    {
        private int cost;
        private int days;
        private int discountCost;
        private int afterDays;
        private int pointsGivenAfterDays;
        private int maxPointsGiven;
        private int copiesLeft;
        private const int copiesLeftThreshold = 5;

        public PriceCalculator BaseCost(int cost)
        {
            this.cost = cost;
            return this;
        }

        public PriceCalculator ForDays(int days)
        {
            this.days = days;
            return this;
        }

        public PriceCalculator ApplyDiscount(int discount)
        {
            this.discountCost = cost - discount;
            return this;
        }

        public PriceCalculator AfterDays(int afterDays)
        {
            this.afterDays = afterDays;
            return this;
        }

        public PriceCalculator PointsGivenAfterDays(int pointsGivenAfterDays)
        {
            this.pointsGivenAfterDays = pointsGivenAfterDays;
            return this;
        }

        public PriceCalculator MaxPointsGiven(int maxPointsGiven)
        {
            this.maxPointsGiven = maxPointsGiven;
            return this;
        }

        public PriceCalculator CopiesLeft(int copiesLeft)
        {
            this.copiesLeft = copiesLeft;
            return this;
        }

        public Number CalculatePrice()
        {
            if (days != 0)
            {
                var discountedDays = GetDiscountedDays();

                var nonDiscountedDaysCost = cost * (days - discountedDays);
                var discountedDaysCost = discountCost * discountedDays;

                return new Number((nonDiscountedDaysCost + discountedDaysCost) * LastCopiesOvercharge());
            }
            return new Number(cost);
        }

        private bool DiscountApplies ()
        {
            return days > afterDays;
        }

        private int GetDiscountedDays()
        {
            return DiscountApplies () ? afterDays - 1 : 0;
        }

        public int CalculatePoints(int copies)
        {
            return MaxPointCanBeGiven (copies) ? maxPointsGiven : 1;
        }

        private bool MaxPointCanBeGiven(int copies)
        {
            return copies >= copiesLeftThreshold && days > pointsGivenAfterDays; // if you rent more than the period and there are more than 5 copies in store
        }

        private double LastCopiesOvercharge()
        {
            return 1 +  (OverchargeApplies() ? (copiesLeftThreshold - copiesLeft) * 0.05 : 0);        
        }

        private bool OverchargeApplies()
        {
            return copiesLeft < copiesLeftThreshold;
        }
    }
}