using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public interface IGenreRepository
{
	Task<int> CreateAsync(Genre genre, CancellationToken token = default);
}