using System;
using Microsoft.AspNetCore.Mvc;
using BookStore.Services;
using BookStore.Repository;
using BookStore.DataModels;

namespace BookStore.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpPost("CustomerSignUp")]
		public async Task<IActionResult> CustomerSignUp(Customer customer)
		{
			var res = await _customerService.CreateCustomer(customer);
			if (res)
			{
				// Successful
				return StatusCode(200, "Customer Created Successfully");
			}
			else
			{
				return StatusCode(400, "Error Occured While Customer Creation");
			}
		}
	}
}

