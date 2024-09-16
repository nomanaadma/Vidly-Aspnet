using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public interface IMovieRepository
{
	Task<Movie> CreateAsync(Movie movie, CancellationToken token = default);
	
	Task<Movie?> GetByIdAsync(int id, CancellationToken token = default);
	
	Task<Movie?> FindByIdAsync(int id, CancellationToken token = default);
	
	Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default);
	
	Task<Movie> UpdateAsync(Movie movie, CancellationToken token = default);
	
	Task DeleteByIdAsync(Movie movie, CancellationToken token = default);
	
}