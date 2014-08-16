using System.Collections.Generic;

namespace MovieRental
{
	public class MovieRentalThing
	{
		public static void Main ()
		{
			Customer customer = new Customer ();
            customer.Rentals = new List<IRental> ();

			customer.Rentals.Add (new Rental() {Price = PriceCode.Kids, Days = 10});
			customer.Rentals.Add (new Rental() {Price = PriceCode.Premiere, Days = 1});

            CustomerController controller = new CustomerController (customer);
            controller.ShowCustomerSummary();
		}
	}
}

