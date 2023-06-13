using System;
using BookStore.DataModels;
using BookStore.HelperModels;

namespace BookStore.Services
{
	public interface ICustomerService
	{
        public Task<bool> CreateCustomer(CustomerSignUpPayload customer);
        public CustomerDetails GetCustomerDetails(int customerId);
        public bool DeleteCustomer(int customerId);
        public List<Customer> GetAllCustomers();
        public string LoginCustomer(CustomerLoginPayload payload);

    }
}

