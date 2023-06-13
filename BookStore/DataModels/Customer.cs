using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DataModels
{
    /*
	 * MODEL NOTES:
	 * This is the model of the customer, One Customer can have multiple orders
	 * One Customer can have one cart
	 */
    public class Customer
	{
        [Key]
        public int CustomerId { get; set; }
		[Required]
		public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
		public ICollection<Order> Orders { get; set; } = new List<Order>();
		public Cart? Cart { get; set; }
		public string ApiKey { get; set; }
	}
}

