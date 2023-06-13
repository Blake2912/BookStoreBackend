using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DataModels
{
	public class OrderBookQty
	{
		public string OrderId { get; set; }
		public int BookId { get; set; }
		public int Quantity { get; set; }
	}
}

