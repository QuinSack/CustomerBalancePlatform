using CustomerBalancePlatform.Dtos;
using CustomerBalancePlatform.Models;

namespace CustomerBalancePlatform.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(string id);
        Task<Customer?> AddCustomerAsync(SaveCustomerRequest request);
        Task<Customer?> UpdateCustomerAsync(string id, UpdateCustomerRequest updatedCustomer);
        Task<bool> DeleteCustomerAsync(string id);
    }
}
