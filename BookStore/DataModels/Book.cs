using System;
namespace BookStore.DataModels
{
	public class Book
	{
		public int BookId { get; set; }
		public string BookName { get; set; }
		public string AuthorName { get; set; }
		public int InventoryQty { get; set; }
	}
}

