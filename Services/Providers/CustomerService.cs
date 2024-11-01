using CustomerBalancePlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerBalancePlatform.Services.Providers
{
    public class CustomerService
    {
        private readonly CustomerContext _dbContext;
        public CustomerService(CustomerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return _dbContext.Customers?.ToList() ?? new List<Customer>();
        }

        public async Task<Customer?> GetCustomerByIdAsync(string id)
        {
            return _dbContext.Customers == null ? null : await _dbContext.Customers.FindAsync(id);
        }

        public async Task<Customer?> AddCustomerAsync(Customer customer)
        {
            if (_dbContext.Customers == null) return null;

            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> UpdateCustomerAsync(string id, Customer updatedCustomer)
        {
            var customer = await _dbContext.Customers!.FindAsync(id);
            if (customer == null) return null;

            customer.Name = updatedCustomer.Name;
            customer.Description = updatedCustomer.Description;
            customer.ContactInformation.Email = updatedCustomer.ContactInformation.Email;
            customer.ContactInformation.PrimaryMobileNumber = updatedCustomer.ContactInformation.PrimaryMobileNumber;
            customer.ContactInformation.SecondaryMobileNumber = updatedCustomer.ContactInformation.SecondaryMobileNumber;
            customer.ContactInformation.Address = updatedCustomer.ContactInformation.Address;
            customer.CurrentBalance = updatedCustomer.CurrentBalance;

            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomerAsync(string id)
        {
            var customer = await _dbContext.Customers!.FindAsync(id);
            if (customer == null) return false;

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
