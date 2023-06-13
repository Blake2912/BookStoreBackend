using System;
namespace BookStore.DataModels
{
	public class WishList
	{
        public int WishListId { get; set; }
        public Customer? Customer { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}

