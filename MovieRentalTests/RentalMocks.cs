using System;
using NUnit.Mocks;
using MovieRental;

namespace MovieRentalTests
{
    public class RentalMock
    {
        public DynamicMock MockRental = new DynamicMock(typeof(IRental));

        public RentalMock()
        {
            //Props
            MockRental.ExpectAndReturn("get_Price", PriceCode.Kids);
            MockRental.ExpectAndReturn("get_Days", 10);

            //Meths
            MockRental.SetReturnValue("CalculatePoints", 3);
        }
    }
}

