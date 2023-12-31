﻿using System;
using System.Reflection;
using System.Text;
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

		public async Task<bool> DeleteCustomer(int custId)
		{
			string methodName = nameof(DeleteCustomer);
			try
			{
				Customer customer = _dataContext.Customers.Where(x => x.CustomerId == custId).First();
				_dataContext.Customers.Remove(customer);
				await _dataContext.SaveChangesAsync();
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

		public Customer GetCustomerDetailsWithId(int custId)
		{
			string methodName = nameof(GetCustomerDetailsWithId);
            try
            {
                var customer = _dataContext.Customers
                .Where(x => x.CustomerId == custId)
                .First();

                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("In {@method} | Exception Occured, message: {@message}", methodName, ex.Message);
                return null;
            }
        }

		public List<Customer> GetAllCustomers()
		{
            string methodName = nameof(GetAllCustomers);
            try
            {
				return _dataContext.Customers.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("In {@method} | Exception Occured, message: {@message}", methodName, ex.Message);
                return null;
            }
        }

		public string AuthenticateCustomerLogin(CustomerLoginPayload payload)
		{
            string methodName = nameof(AuthenticateCustomerLogin);
            try
            {
				var cust = _dataContext.Customers.Where(x => x.PhoneNumber == payload.PhoneNumber).First();
				if (BCrypt.Net.BCrypt.Verify(payload.Password, cust.Password))
				{
					return cust.ApiKey;
				}
				return "Invalid Credentials";
            }
            catch (Exception ex)
            {
                _logger.LogInformation("In {@method} | Exception Occured, message: {@message}", methodName, ex.Message);
                return "Error Occured Please check log";
            }
        }
    }
}