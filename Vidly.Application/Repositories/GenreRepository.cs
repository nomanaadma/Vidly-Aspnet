using Vidly.Application.Data;
using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public class GenreRepository(IDbConnectionFactory dbConnectionFactory) : IGenreRepository
{
	public async Task<Genre> CreateAsync(Genre genre, CancellationToken token = default)
	{
		await using var context = dbConnectionFactory.Context();
		await context.Genres.AddAsync(genre, token);
		await context.SaveChangesAsync(token);
		return genre;
	}
}
