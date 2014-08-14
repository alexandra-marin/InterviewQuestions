using System;
using NUnit.Mocks;
using MovieRental;

namespace MovieRentalTests
{
    public class RentalMock
    {
        public DynamicMock mockRental = new DynamicMock(typeof(IRental));

        public RentalMock()
        {
            mockRental.SetReturnValue("CalculatePoints", 3);
            mockRental.ExpectAndReturn("get_Price", PriceCode.Kids);
            mockRental.ExpectAndReturn("get_Days", 10);
        }
    }
}

