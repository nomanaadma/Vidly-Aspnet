using Vidly.Application.Models;

namespace Vidly.Application.Services;

public interface IGenreService
{
	Task<Genre> CreateAsync(Genre genre, CancellationToken token = default);
}