
using System;
namespace BookStore.DataModels
{
	/*
	 * This is the datamodel which is used to define the many-to-many
	 * relationship
	 */
	public class BooksInOrder
	{
		public int BookId { get; set; }
		public int OrderId { get; set; }
		public Book Book { get; set; } = null!;
		public Order Order { get; set; } = null!;
	}

}

