using System;
using NUnit.Mocks;
using MovieRental;

namespace MovieRentalTests
{
    public class Mocks
    {
        public DynamicMock MockRental = new DynamicMock(typeof(IRental));
        public DynamicMock MockPurchase = new DynamicMock(typeof(IPurchase));

        public Mocks()
        {
            //Rental
            MockRental.ExpectAndReturn("get_Price", PriceCode.Kids);
            MockRental.ExpectAndReturn("get_Days", 10);

            //Purchase
            MockPurchase.ExpectAndReturn("get_Price", PriceCode.Kids);
        }
    }
}

