using System;
using System.Reflection;
using BookStore.Data;
using BookStore.DataModels;
using BookStore.HelperModels;
namespace BookStore.Repository
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly DataContext _dataContext;
		private readonly ILogger<CustomerRepository> _logger;

		public CustomerRepository
			(
			DataContext dataContext,
			ILogger<CustomerRepository> logger
			)
		{
			_dataContext = dataContext;
			_logger = logger;
		}

		public async Task<bool> CreateCustomer(Customer customer)
		{
			string methodName = nameof(CreateCustomer);
			try
			{
                await _dataContext.Customers.AddAsync(customer);
                _dataContext.SaveChanges();
                return true;
            }
			catch (Exception ex)
			{
				_logger.LogInformation("In {@method} | Exception Occured, message: {@message}", methodName, ex.Message);
				return false;
			}
            
        }

		public CustomerDetails GetCustomerDetails(int custId)
		{
			string methodName = nameof(GetCustomerDetails);
			try
			{
                var customer = _dataContext.Customers
                .Where(x => x.CustomerId == custId)
                .Select(x => new CustomerDetails
                {
                    CustomerId = x.CustomerId,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber
                })
                .First();

                return customer;
            }
			catch (Exception ex)
			{
                _logger.LogInformation("In {@method} | Exception Occured, message: {@message}", methodName, ex.Message);
				return null;
            }
		}


	}
}

