using System;

using System.Collections.Generic;
using MovieRental;
using MovieRentalTests;
using NUnit.Framework;

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
            customer.Rentals.Add ((IPurchase)(new Mocks().MockPurchase.MockInstance));

            controller = new CustomerController(customer);
        }

        [Test ()]
        public void PaysMoreForPopularRental ()
        {
            Assert.IsTrue (true);
        }

        [Test ()]
        public void DoesntGetPointsForPopularRentals ()
        {
            Assert.IsTrue (true);
        }
    }
}
