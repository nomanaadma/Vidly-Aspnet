using Vidly.Application.Models;

namespace Vidly.Application.Services;

public interface IGenreService
{
	Task<Genre> CreateAsync(Genre genre, CancellationToken token = default);
	
	Task<Genre?> GetByIdAsync(int id, CancellationToken token = default);
	
	Task<IEnumerable<Genre>> GetAllAsync(CancellationToken token = default);
	
	Task<Genre> UpdateAsync(Genre genre, CancellationToken token = default);
	
	Task DeleteByIdAsync(Genre genre, CancellationToken token = default);
	
}