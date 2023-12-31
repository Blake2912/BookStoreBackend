﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DataModels
{
	/*
	 * MODEL NOTES:
	 * Here are the relationship notes: One Customer can have one Cart
	 * and one cart can have Mutliple Books
	 */
	public class Cart
	{
        [Key]
        public int CartId { get; set; }

		public int CustomerId { get; set; }
		public Customer Customer { get; set; } = null!;
        public List<Book> Books { get; }

    }
}

