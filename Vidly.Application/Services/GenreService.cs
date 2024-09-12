using Vidly.Application.Models;
using Vidly.Application.Repositories;

namespace Vidly.Application.Services;

public class GenreService(IGenreRepository genreRepository) : IGenreService
{
	public async Task<int> CreateAsync(Genre genre, CancellationToken token = default)
	{
		return await genreRepository.CreateAsync(genre, token);
	}
}