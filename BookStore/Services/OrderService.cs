using System;
using BookStore.Repository;
using BookStore.DataModels;
using BookStore.HelperModels;
using BookStore.Util;

namespace BookStore.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly ICustomerRepository _customerRepsoitory;
		private readonly IBookRepository _bookRepository;
		private readonly IUtil _util;
		private readonly ILogger<OrderService> _logger;

		public OrderService(
			IOrderRepository orderRepository,
			ICustomerRepository customerRepository,
			IBookRepository bookRepository,
			IUtil util,
			ILogger<OrderService> logger
			)
		{
			_orderRepository = orderRepository;
			_customerRepsoitory = customerRepository;
			_bookRepository = bookRepository;
			_util = util;
			_logger = logger;
		}

        /*
		 * TODO::
		 *  - Create Order
		 *  - View List of orders for a given customer
		 *  - View all Orders
		 *
		 */

		public async Task<bool> CreateOrder(CreateOrderPayload payload)
		{
			var methodName = nameof(CreateOrder);
			try
			{
				var customer = _customerRepsoitory.GetCustomerDetailsWithId(payload.CustomerId);
				var books = new List<Book>();
				var orderBookQties = new List<OrderBookQty>();
				// Generating Order Id
				var orderId = _util.RandomString(32, true);

				foreach (var i in payload.BookIdsWithQty)
				{
					books.Add(_bookRepository.GetBookWithId(i.BookId));
					orderBookQties.Add(new OrderBookQty { BookId = i.BookId, OrderId = orderId, Quantity = i.Quantity });
				}
				var order = new Order() {
					OrderId = orderId,
					Customer = customer,
					Books = books,
					OrderPlacedDateTime = payload.OrderDateTime
				};
				return await _orderRepository.CreateOrder(order, orderBookQties);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("In {@method} | Exception Occured: {@message}", methodName, ex.Message);
                return false;
            }
		}

		public List<Order> GetAllOrders()
		{
            var methodName = nameof(GetAllOrders);
			try
			{
				return _orderRepository.GetAllOrders();
			}
            catch (Exception ex)
            {
                _logger.LogInformation("In {@method} | Exception Occured: {@message}", methodName, ex.Message);
                return null;
            }
        }

	}
}

