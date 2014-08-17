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

            controller = new CustomerController(customer);
        }

        [Test ()]
        public void PaysMoreForPopularRental ()
        {
            customer.Rentals.Add ((IPurchase)(new Mocks().MockRental.MockInstance)); 
            customer.Rentals.Add ((IPurchase)(new Mocks().MockPopularRental.MockInstance));
            controller.ShowCustomerSummary();

            var normalRentalPrice = controller.CustomerView.customerViewModel.RentalsWithPrices.Values.First().Key;
            var popularRentalPrice = controller.CustomerView.customerViewModel.RentalsWithPrices.Values.Last().Key;

            Assert.IsTrue (normalRentalPrice < popularRentalPrice);
        }

        [Test ()]
        public void PaysTwentyPercentMoreForLastCopyRental ()
        {            
            customer.Rentals.Add ((IPurchase)(new Mocks().MockPopularRental.MockInstance));
            controller.ShowCustomerSummary();

            int popularRentalPrice = controller.CustomerView.customerViewModel.RentalsWithPrices.Values.Last().Key;

            Assert.IsTrue (popularRentalPrice.Equals(33.6));
        }

        [Test ()]
        public void DoesntGetPointsForPopularRentals ()
        { 
            customer.Rentals.Add ((IPurchase)(new Mocks().MockPopularRental.MockInstance));
            controller.ShowCustomerSummary();
            var popularRentalPoints = controller.CustomerView.customerViewModel.RentalsWithPrices.Values.Last().Value;

            Assert.IsTrue (popularRentalPoints == 1);
        }
    }
}
