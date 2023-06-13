using System;
using BookStore.Data;
using BookStore.DataModels;
namespace BookStore.Repository
{
	public class OrderBookQtyRepository : IOrderBookQtyRepository
	{
		private readonly DataContext _context;
		private readonly ILogger<OrderBookQtyRepository> _logger;


		public OrderBookQtyRepository(DataContext context, ILogger<OrderBookQtyRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<bool> AddOrderBookQtyData(List<OrderBookQty> orderBookQtyList)
		{
			var methodName = nameof(AddOrderBookQtyData);
			try
			{
				await _context.OrderBookQties.AddRangeAsync(orderBookQtyList);
				await _context.SaveChangesAsync();
				return true;
			}
			catch(Exception ex)
			{
				_logger.LogInformation("In {@method} | Exception Occurred: {@message}", methodName, ex.Message);
				return false;
			}
		}
	}
}

