using System;
namespace BookStore.DataModels
{
	public class Order
	{
		public int OrderId { get; set; }
		public DateTime OrderPlacedDateTime { get; set; }
		// One order can have only one customer
		public Customer Customer { get; set; } = null!;
		// Many to Many Relationship
        public List<BooksInOrder> BooksInOrders { get; } = new();
    }
}

