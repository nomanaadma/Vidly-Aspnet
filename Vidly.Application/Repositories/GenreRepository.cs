using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Vidly.Application.Data;
using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public class GenreRepository(IDbConnectionFactory dbConnectionFactory, IValidator<Genre> genreValidator) : IGenreRepository
{
	public async Task<Genre> CreateAsync(Genre genre, CancellationToken token = default)
	{
		await genreValidator.ValidateAndThrowAsync(genre, token);
		await using var context = dbConnectionFactory.Context();
		await context.Genres.AddAsync(genre, token);
		await context.SaveChangesAsync(token);
		return genre;
	}

	public async Task<Genre?> GetByIdAsync(int id, CancellationToken token = default)
	{
		await using var context = dbConnectionFactory.Context();
		var genre = await context.Genres.FindAsync([id], token);
		return genre;
	}

	public async Task<IEnumerable<Genre>> GetAllAsync(CancellationToken token = default)
	{
		await using var context = dbConnectionFactory.Context();
		var genres = await context.Genres.OrderBy(g => g.Name).ToListAsync(token);
		return genres;
	}

	public async Task<Genre> UpdateAsync(Genre genre, CancellationToken token = default)
	{
		await genreValidator.ValidateAndThrowAsync(genre, token);
		await using var context = dbConnectionFactory.Context();
		context.Genres.Update(genre);
		await context.SaveChangesAsync(token);
		return genre;
	}

	public async Task DeleteByIdAsync(Genre genre, CancellationToken token = default)
	{
		await using var context = dbConnectionFactory.Context();
		context.Genres.Remove(genre);
		await context.SaveChangesAsync(token);
	}
}
