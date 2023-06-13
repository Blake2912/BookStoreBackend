using System;
using BookStore.Data;
using BookStore.DataModels;

namespace BookStore.Repository
{
	public class OrderRepository : IOrderRepository
	{

		private readonly DataContext _context;
		private readonly ILogger<OrderRepository> _logger;

		public OrderRepository(DataContext context, ILogger<OrderRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<bool> CreateOrder(Order order, List<OrderBookQty> orderBookQtyList)
		{
			var methodName = nameof(CreateOrder);
			try
			{
				await _context.Order.AddAsync(order);
				await _context.OrderBookQties.AddRangeAsync(orderBookQtyList);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("In {@method} | Excpetion Occurred: {@message}", methodName, ex.Message);
				return false;
			}
		}

		public List<Order> GetOrdersForACustomer(int custId)
		{
			var methodName = nameof(GetOrdersForACustomer);
			try
			{
				return _context.Order.Where(order => order.Customer.CustomerId == custId).ToList();
			}
            catch (Exception ex)
            {
                _logger.LogInformation("In {@method} | Excpetion Occurred: {@message}", methodName, ex.Message);
				return null;
            }
        }

		public List<Order> GetAllOrders()
		{
            var methodName = nameof(GetAllOrders);
            try
            {
                return _context.Order.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("In {@method} | Excpetion Occurred: {@message}", methodName, ex.Message);
                return null;
            }
        }
    }
}

