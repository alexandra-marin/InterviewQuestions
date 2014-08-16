using System.Collections.Generic;

namespace MovieRental
{
	public class MovieRentalThing
	{
		public static void Main ()
		{
			Customer customer = new Customer ();
            customer.Rentals = new List<IPurchase> ();

			customer.Rentals.Add (new Purchase() {Price = PriceCode.Kids, Days = 10});
			customer.Rentals.Add (new Purchase() {Price = PriceCode.Premiere, Days = 1});

            CustomerController controller = new CustomerController (customer);
            controller.ShowCustomerSummary();
		}
	}
}

