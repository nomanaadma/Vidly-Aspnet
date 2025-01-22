using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Vidly.Application.Data;
using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public class GenreRepository(DatabaseContext context, IValidator<Genre> genreValidator) : IGenreRepository
{
	public async Task<Genre> CreateAsync(Genre genre, CancellationToken token = default)
	{
		await genreValidator.ValidateAndThrowAsync(genre, token);
		await context.Genres.AddAsync(genre, token);
		await context.SaveChangesAsync(token);
		return genre;
	}

	public async Task<Genre?> GetByIdAsync(int id, CancellationToken token = default)
	{
		var genre = await context.Genres.FindAsync([id], token);
		return genre;
	}

	public async Task<IEnumerable<Genre>> GetAllAsync(CancellationToken token = default)
	{
		var genres = await context.Genres.OrderBy(g => g.Name).ToListAsync(token);
		return genres;
	}

	public async Task<Genre> UpdateAsync(Genre genre, CancellationToken token = default)
	{
		await genreValidator.ValidateAndThrowAsync(genre, token);
		context.Genres.Update(genre);
		await context.SaveChangesAsync(token);
		return genre;
	}

	public async Task DeleteByIdAsync(Genre genre, CancellationToken token = default)
	{
		context.Genres.Remove(genre);
		await context.SaveChangesAsync(token);
	}
}
