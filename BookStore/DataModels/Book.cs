using System;
namespace BookStore.DataModels
{
	/*
	 * This is the model of a Book where one book can have multiple Orders i.e.
	 * many-to-many relationship
	 * One book can be in Multiple Carts and One cart can have multiple books
	 */
	public class Book
	{
		public int BookId { get; set; }
		public string BookName { get; set; }
		public string AuthorName { get; set; }
		public int InventoryQty { get; set; }
		public List<BooksInOrder> BooksInOrders { get; } = new();
	}
}

