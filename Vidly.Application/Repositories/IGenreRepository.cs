using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public interface IGenreRepository
{
	Task<Genre> CreateAsync(Genre genre, CancellationToken token = default);
}