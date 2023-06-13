using System;
namespace BookStore.HelperModels
{
	public class CreateOrderPayload
	{
		public int CustomerId { get; set; }
		public List<OrderBookQuantityPayload> BookIdsWithQty { get; set; } = new List<OrderBookQuantityPayload>();
		public DateTime OrderDateTime { get; set; }
	}
}

