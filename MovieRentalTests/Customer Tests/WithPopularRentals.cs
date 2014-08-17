using System.Collections.Generic;
using MovieRental;
using MovieRentalTests;
using NUnit.Framework;
using System.Linq;

namespace CustomerTests
{
    [TestFixture ()]
    public class WithPopularRentals
    {
        Customer customer;
        CustomerController controller;
        [SetUpAttribute]
        public void DefineCustomer ()
        {
            customer = new Customer ();
            customer.LoyalityPoints = 0;

            customer.Rentals = new List<IPurchase> (); 
            customer.Rentals.Add ((IPurchase)(new Mocks().MockRental.MockInstance)); 
            customer.Rentals.Add ((IPurchase)(new Mocks().MockPopularRental.MockInstance));

            controller = new CustomerController(customer);
        }

        [Test ()]
        public void PaysMoreForPopularRental ()
        {
            controller.ShowCustomerSummary();

            var normalRentalPrice = controller.CustomerView.customerViewModel.RentalsWithPrices.Values.First().Key;
            var popularRentalPrice = controller.CustomerView.customerViewModel.RentalsWithPrices.Values.Last().Key;

            Assert.IsTrue (normalRentalPrice < popularRentalPrice);
        }

        [Test ()]
        public void DoesntGetPointsForPopularRentals ()
        {
            controller.ShowCustomerSummary();
            var popularRentalPoints = controller.CustomerView.customerViewModel.RentalsWithPrices.Values.Last().Value;

            Assert.IsTrue (popularRentalPoints == 0);
        }
    }
}
