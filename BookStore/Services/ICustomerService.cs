using System;
using BookStore.DataModels;

namespace BookStore.Services
{
	public interface ICustomerService
	{
        public Task<bool> CreateCustomer(Customer customer);

    }
}

