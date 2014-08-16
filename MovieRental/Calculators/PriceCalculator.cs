using System;
using System.Collections.Generic;
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
        public int CalculatePrice()
        {
            var discountedDays = GetDiscountedDays ();
            return cost * (days - discountedDays) + discountCost * GetDiscountedDays(); //full price for the first days, discounted after
        }
        private bool DiscountApplies ()
        {
            return days > afterDays;
        }
        private int GetDiscountedDays()
        {
            return DiscountApplies () ? afterDays - 1 : 0;
        }
        public int CalculatePoints()
        {
            return MaxPointCanBeGiven () ? maxPointsGiven : 1;
        }
        private bool MaxPointCanBeGiven()
        {
            return days > pointsGivenAfterDays; // if you rent more than the period
        }
    }
}