using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public interface ICustomerRepository
{
	Task<Customer> CreateAsync(Customer customer, CancellationToken token = default);
	
	Task<Customer?> GetByIdAsync(int id, CancellationToken token = default);
	
	Task<IEnumerable<Customer>> GetAllAsync(CancellationToken token = default);
	
	Task<Customer> UpdateAsync(Customer customer, CancellationToken token = default);
	
	Task DeleteByIdAsync(Customer customer, CancellationToken token = default);
	
}