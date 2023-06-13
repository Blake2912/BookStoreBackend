using System;
using BookStore.Repository;
using BookStore.DataModels;
using BookStore.HelperModels;
using System.Text;

namespace BookStore.Services
{
	public class CustomerService :ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public async Task<bool> CreateCustomer(CustomerSignUpPayload customer)
		{

			customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);
            Customer dbCustomer = new Customer
            {
                ApiKey = RandomString(64),
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

        public bool DeleteCustomer(int customerId)
        {
            return _customerRepository.DeleteCustomer(customerId);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public string LoginCustomer(CustomerLoginPayload payload)
        {
            return _customerRepository.AuthenticateCustomerLogin(payload);
        }

        private static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            Random _random = new Random();

             // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.

            // char is a single Unicode character
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length = 26

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}

