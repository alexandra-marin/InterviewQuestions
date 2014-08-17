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

        public double CalculatePrice()
        {
            if (days != 0)
            {
                var discountedDays = GetDiscountedDays();
                var total = cost * (days - discountedDays) + discountCost * discountedDays; //full price for the first days, discounted after

                if (copiesLeft >= 5)
                    return total;
                else if (copiesLeft == 4)
                    return total + (int)(total * 0.05);
                else if (copiesLeft == 3)
                    return total + (int)(total * 0.1);
                else if (copiesLeft == 2)
                    return total + (int)(total * 0.15);
                else if (copiesLeft == 1)
                    return total + total * 0.2;
            }
            return cost;
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
            return copies >= 5 && days > pointsGivenAfterDays; // if you rent more than the period and there are more than 5 copies in store
        }
    }
}