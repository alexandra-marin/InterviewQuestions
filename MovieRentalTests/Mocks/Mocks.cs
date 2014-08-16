using NUnit.Mocks;
using MovieRental;

namespace MovieRentalTests
{
    public class Mocks
    {
        public DynamicMock MockRental = new DynamicMock(typeof(IRental));
        public DynamicMock MockPurchase = new DynamicMock(typeof(IRental));

        public Mocks()
        {
            //Rental
            MockRental.ExpectAndReturn("get_Price", PriceCode.Kids);
            MockRental.ExpectAndReturn("get_Days", 10);
            MockRental.ExpectAndReturn("get_Type", PurchaseType.Rental);

            //Purchase
            MockPurchase.ExpectAndReturn("get_Price", PriceCode.Premiere);
            MockPurchase.ExpectAndReturn("get_Type", PurchaseType.Purchase);
        }
    }
}

