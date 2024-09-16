using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public interface IRentalRepository
{
	Task<Rental> CreateAsync(Rental rental, CancellationToken token = default);
	
	Task<Rental?> GetByIdAsync(int id, CancellationToken token = default);
	
	Task<IEnumerable<Rental>> GetAllAsync(CancellationToken token = default);
	
}