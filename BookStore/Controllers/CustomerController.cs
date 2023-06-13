using BookStore.DataModels;
using BookStore.Services;
using BookStore.HelperModels;
using Microsoft.AspNetCore.Mvc;

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
		public async Task<IActionResult> CustomerSignUp(CustomerSignUpPayload customer)
		{
			var res = await _customerService.CreateCustomer(customer);
			if (res)
			{
				// Successful
				return StatusCode(201, "Customer Created Successfully");
			}
			else
			{
				return StatusCode(400, "Error Occured While Customer Creation");
			}
		}

		[HttpGet("GetCustomerDetails")]
		public IActionResult GetCustomerDetails(int customerId)
		{
			try
			{
                var res = _customerService.GetCustomerDetails(customerId);
                return StatusCode(200, res);
            }
			catch (Exception ex)
			{
                return StatusCode(400, $"Some error occured error message: {ex.Message}");
            }
        }

		[HttpDelete("DeleteCustomer")]
		public async Task<IActionResult> DeleteCustomer(int customerId)
		{
			var res = await _customerService.DeleteCustomer(customerId);
            if (res)
            {
                return StatusCode(200, "Customer Deleted Successfully");
            }
            else
            {
                return StatusCode(400, "Error Occured While Customer Deletion");
            }
        }

		[HttpGet("GetAllCustomers")]
		public IActionResult GetAllCustomers()
		{
			try
			{
				var cust = _customerService.GetAllCustomers();
				return Ok(cust);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

        [HttpPost("CustomerLogin")]
		public IActionResult CustomerLogin(CustomerLoginPayload payload)
		{
			var res = _customerService.LoginCustomer(payload);
			if (res != null)
			{
				return Ok(new CustomerLoginResponse { ApiKey=res});
			}
            else
            {
                return StatusCode(400, "Invalid Credentials");
            }
		}

    }
}

