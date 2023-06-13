using System;
using BookStore.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
	public class DataContext : DbContext
    {

        public DataContext()
		{
        }
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        // DbSet Init
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<WishList> WishLists { get; set; }

    }
}

