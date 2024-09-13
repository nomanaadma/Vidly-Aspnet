using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public interface IGenreRepository
{
	Task<Genre> CreateAsync(Genre genre, CancellationToken token = default);
	
	Task<Genre?> GetByIdAsync(int id, CancellationToken token = default);
	
	Task<IEnumerable<Genre>> GetAllAsync(CancellationToken token = default);
	
	Task<Genre> UpdateAsync(Genre genre, CancellationToken token = default);
	
	Task DeleteByIdAsync(Genre genre, CancellationToken token = default);
	
}