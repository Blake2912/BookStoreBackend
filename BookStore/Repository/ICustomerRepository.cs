using System;
using BookStore.DataModels;
using BookStore.HelperModels;

namespace BookStore.Repository
{
	public interface ICustomerRepository
	{
        public Task<bool> CreateCustomer(Customer customer);
        public CustomerDetails GetCustomerDetails(int custId);
        public Task<bool> DeleteCustomer(int custId);
        public List<Customer> GetAllCustomers();
        public string AuthenticateCustomerLogin(CustomerLoginPayload payload);
    }
}

