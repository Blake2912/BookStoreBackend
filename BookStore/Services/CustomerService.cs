using System;
using BookStore.Repository;
using BookStore.DataModels;
using BookStore.HelperModels;
using BookStore.Util;
using System.Text;

namespace BookStore.Services
{
	public class CustomerService :ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
        private readonly IUtil _util;

		public CustomerService(ICustomerRepository customerRepository, IUtil util)
		{
			_customerRepository = customerRepository;
            _util = util;
		}

		public async Task<bool> CreateCustomer(CustomerSignUpPayload customer)
		{

			customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);
            Customer dbCustomer = new Customer
            {
                ApiKey = _util.RandomString(64),
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                Password = customer.Password
            };
			return await _customerRepository.CreateCustomer(dbCustomer);
		}

		public CustomerDetails GetCustomerDetails(int customerId)
		{
			return _customerRepository.GetCustomerDetails(customerId);
		}

        public async Task<bool> DeleteCustomer(int customerId)
        {
            return await _customerRepository.DeleteCustomer(customerId);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public string LoginCustomer(CustomerLoginPayload payload)
        {
            return _customerRepository.AuthenticateCustomerLogin(payload);
        }
    }
}

