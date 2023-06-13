using System;
namespace BookStore.DataModels
{
	public class BooksInCart
	{
		public int BookId { get; set; }
		public int CartId { get; set; }
		public Book Book { get; set; } = null!;
		public Cart Cart { get; set; } = null!;
	}
}

