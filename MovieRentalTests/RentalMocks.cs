using System;
using NUnit.Mocks;
using MovieRental;

namespace MovieRentalTests
{
    public class RentalMock
    {
        public DynamicMock mockRental = new DynamicMock(typeof(Rental));

        public RentalMock()
        {
//            ((Rental)mockRental.MockInstance).Days = 10;
//            ((Rental)mockRental.MockInstance).Price = PriceCode.Kids;
            mockRental.SetReturnValue("CalculatePoints", 3);
        }
    }
}

