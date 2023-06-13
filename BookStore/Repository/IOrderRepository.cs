using System;
using BookStore.DataModels;

namespace BookStore.Repository
{
	public interface IOrderRepository
	{
        public Task<bool> CreateOrder(Order order, List<OrderBookQty> orderBookQtyList);
        public List<Order> GetOrdersForACustomer(int custId);
        public List<Order> GetAllOrders();

    }
}

