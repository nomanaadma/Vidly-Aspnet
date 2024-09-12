using Vidly.Application.Models;

namespace Vidly.Application.Services;

public interface IGenreService
{
	Task<int> CreateAsync(Genre genre, CancellationToken token = default);
}