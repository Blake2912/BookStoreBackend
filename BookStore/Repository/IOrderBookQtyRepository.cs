using System;
using BookStore.DataModels;

namespace BookStore.Repository
{
	public interface IOrderBookQtyRepository
	{
        public Task<bool> AddOrderBookQtyData(List<OrderBookQty> orderBookQtyList);

    }
}

