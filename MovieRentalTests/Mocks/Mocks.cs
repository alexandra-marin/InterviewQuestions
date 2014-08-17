﻿using NUnit.Mocks;
using MovieRental;

namespace MovieRentalTests
{
    public class Mocks
    {
        public DynamicMock MockRental = new DynamicMock(typeof(IPurchase));
        public DynamicMock MockPopularRental = new DynamicMock(typeof(IPurchase));
        public DynamicMock MockPurchase = new DynamicMock(typeof(IPurchase));

        public Mocks()
        {
            //Rental
            MockRental.ExpectAndReturn("get_Price", PriceCode.Kids);
            MockRental.ExpectAndReturn("get_Days", 10);
            MockRental.ExpectAndReturn("get_Type", PurchaseType.Rental);
            MockRental.ExpectAndReturn("get_CopiesAvailable", 5);
            MockRental.ExpectAndReturn("get_CopiesAvailable", 5);
            MockRental.ExpectAndReturn("get_CopiesAvailable", 5);

            //Last Rental
            MockPopularRental.ExpectAndReturn("get_Price", PriceCode.Kids);
            MockPopularRental.ExpectAndReturn("get_Days", 10);
            MockPopularRental.ExpectAndReturn("get_Type", PurchaseType.Rental);
            MockPopularRental.ExpectAndReturn("get_CopiesAvailable", 1);
            MockPopularRental.ExpectAndReturn("get_CopiesAvailable", 1);
            MockPopularRental.ExpectAndReturn("get_CopiesAvailable", 1);

            //Purchase
            MockPurchase.ExpectAndReturn("get_Price", PriceCode.Premiere);
            MockPurchase.ExpectAndReturn("get_Type", PurchaseType.Purchase);
            MockPurchase.ExpectAndReturn("get_CopiesAvailable", 5);
            MockPurchase.ExpectAndReturn("get_CopiesAvailable", 5);
            MockPurchase.ExpectAndReturn("get_CopiesAvailable", 5);
        }
    }
}

