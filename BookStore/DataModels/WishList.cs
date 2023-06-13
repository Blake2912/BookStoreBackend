using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DataModels
{
	public class WishList
	{
        [Key]
        public int WishListId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

