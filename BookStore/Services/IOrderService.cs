using System;
using BookStore.DataModels;
using BookStore.HelperModels;

namespace BookStore.Services
{
	public interface IOrderService
	{
        public Task<bool> CreateOrder(CreateOrderPayload payload);
        public List<Order> GetAllOrders();

    }
}

