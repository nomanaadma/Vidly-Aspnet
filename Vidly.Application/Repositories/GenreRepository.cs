using Vidly.Application.Data;
using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public class GenreRepository(IDbConnectionFactory DbConnectionFactory) : IGenreRepository
{
	public async Task<int> CreateAsync(Genre genre, CancellationToken token = default)
	{
		var context = DbConnectionFactory.Context();
		await context.Genres.AddAsync(genre, token);
		await context.SaveChangesAsync(token);
		return genre.Id;
	}
}
