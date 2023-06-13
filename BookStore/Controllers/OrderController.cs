using System;
using BookStore.DataModels;
using BookStore.Services;
using BookStore.HelperModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
	[ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		private readonly ILogger<OrderController> _logger;

		public OrderController(IOrderService orderService, ILogger<OrderController> logger)
		{
			_orderService = orderService;
			_logger = logger;
		}

		/*
		 * TODO::
		 *  - Create Order
		 *  - View List of orders for a given customer
		 *  - View all Orders
		 *
		 */

		[HttpPost("CreateOrder")]
		public async Task<IActionResult> CreateOrder(CreateOrderPayload payload)
		{
			var controllerName = nameof(CreateOrder);
			try
			{
				var res = await _orderService.CreateOrder(payload);
				if (!res)
				{
					return BadRequest("Order Create Failed");
				}
				return StatusCode(201, "Order was successfully created");
			}
            catch (Exception ex)
            {
                _logger.LogInformation("In {@controller} controller | Exception Occured with Message: {@message}", controllerName, ex.Message);
                return BadRequest($"Exception Occured! | Message: {ex.Message}");
            }
        }

		[HttpGet("GetAllOrders")]
		public IActionResult GetAllOrders()
		{
            var controllerName = nameof(GetAllOrders);
			try
			{
				return Ok(_orderService.GetAllOrders());
			}
            catch (Exception ex)
            {
                _logger.LogInformation("In {@controller} controller | Exception Occured with Message: {@message}", controllerName, ex.Message);
                return BadRequest($"Exception Occured! | Message: {ex.Message}");
            }
        }
	}
}

