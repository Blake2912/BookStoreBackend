using System;
namespace BookStore.DataModels
{
    /*
	 * MODEL NOTES:
	 * This is the model of the customer, One Customer can have multiple orders
	 * One Customer can have one cart
	 */
    public class Customer
	{
		
		public int CustomerId { get; set; }
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public ICollection<Order> Orders { get; set; } = new List<Order>();
		public Cart? Cart { get; set; }
	}
}

