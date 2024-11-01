using CustomerBalancePlatform.Models;

namespace CustomerBalancePlatform.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(string id);
        Task<Customer?> AddCustomerAsync(Customer customer);
        Task<Customer?> UpdateCustomerAsync(string id, Customer updatedCustomer);
        Task<bool> DeleteCustomerAsync(string id);
    }
}
