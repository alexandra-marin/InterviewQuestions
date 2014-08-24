using System;

using System.Collections.Generic;
using MovieRental;
using MovieRentalTests;
using NUnit.Framework;

namespace CustomerTests
{
    [TestFixture ()]
    public class WithLessThan20Points
    {
        Customer customer;
        CustomerController controller;

        [SetUpAttribute]
        public void DefineCustomer ()
        {
            customer = new Customer ();
            customer.LoyalityPoints = new Number(0);

            customer.Rentals = new List<IPurchase> (); 
            customer.Rentals.Add ((IPurchase)(new Mocks().MockRental.MockInstance)); 
            customer.Rentals.Add ((IPurchase)(new Mocks().MockPurchase.MockInstance));

            controller = new CustomerController(customer);
        }

        [Test ()]
        public void DoesNotGetFreeRental ()
        {
            controller.ShowCustomerSummary ();
            Assert.IsTrue (controller.CustomerView.customerViewModel.Total.Equals(31)); //28 rental + 3 purchase
        }
    }
}
