using System;
using BookStore.Repository;
using BookStore.DataModels;

namespace BookStore.Services
{
	public class CustomerService :ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public async Task<bool> CreateCustomer(Customer customer)
		{
			customer.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(customer.Password);
			return await _customerRepository.CreateCustomer(customer);
		}
	}
}

