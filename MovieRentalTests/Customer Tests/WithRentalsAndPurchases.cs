﻿using System.Collections.Generic;
using MovieRental;
using MovieRentalTests;
using NUnit.Framework;

namespace CustomerTests
{
    [TestFixture ()]
    public class WithRentalsAndPurchases
    {
        Customer customer;
        CustomerController controller;

        [SetUpAttribute]
        public void DefineCustomer ()
        {
            customer = new Customer ();
            customer.LoyalityPoints = 21;

            customer.Rentals = new List<IPurchase> (); 
            customer.Rentals.Add ((IPurchase)(new Mocks().MockRental.MockInstance)); 

            controller = new CustomerController(customer);
        }
   
        [Test ()]
        public void GetsOneFreeRental ()
        {
            customer.Rentals.Add ((IPurchase)(new Mocks().MockPurchase.MockInstance));

            controller.ShowCustomerSummary ();

            Assert.IsTrue (controller.CustomerView.customerViewModel.Total == 3);
        }
    }
}

