using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Vidly.Application.Data;
using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public class MovieRepository(
	DatabaseContext context,
	IGenreRepository genreRepository,
	IValidator<Movie> movieValidator)
	: IMovieRepository
{
	public async Task<Movie> CreateAsync(Movie movie, CancellationToken token = default)
	{
		await movieValidator.ValidateAndThrowAsync(movie, token);
		await context.Movies.AddAsync(movie, token);
		await context.SaveChangesAsync(token);
		
		var genre = await genreRepository.GetByIdAsync(movie.GenreId, token);
		movie.Genre = genre!;
		
		return movie;
	}

	public async Task<Movie?> GetByIdAsync(int id, CancellationToken token = default)
	{
		var movie = await context.Movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.Id == id, token);
		return movie;
	}
	
	public async Task<Movie?> FindByIdAsync(int id, CancellationToken token = default)
	{
		var movie = await context.Movies.FindAsync([id], token);
		return movie;
	}

	public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default)
	{
		var movies = await context.Movies
			.Include(m => m.Genre)
			.OrderBy(m => m.Title)
			.ToListAsync(token);
		return movies;
	}

	public async Task<Movie> UpdateAsync(Movie movie, CancellationToken token = default)
	{
		await movieValidator.ValidateAndThrowAsync(movie, token);
		context.Movies.Update(movie);
		await context.SaveChangesAsync(token);
		
		var genre = await genreRepository.GetByIdAsync(movie.GenreId, token);
		movie.Genre = genre!;
		
		return movie;
	}

	public async Task DeleteByIdAsync(Movie movie, CancellationToken token = default)
	{
		context.Movies.Remove(movie);
		await context.SaveChangesAsync(token);
	}
}
