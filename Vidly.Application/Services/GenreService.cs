using FluentValidation;
using Vidly.Application.Models;
using Vidly.Application.Repositories;

namespace Vidly.Application.Services;

public class GenreService(IGenreRepository genreRepository, IValidator<Genre> genreValidator) : IGenreService
{
	public async Task<Genre> CreateAsync(Genre genre, CancellationToken token = default)
	{
		await genreValidator.ValidateAndThrowAsync(genre, token);
		return await genreRepository.CreateAsync(genre, token);
	}
}