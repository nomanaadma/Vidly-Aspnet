using FluentValidation;
using Microsoft.VisualBasic;
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

	public async Task<Genre?> GetByIdAsync(int id, CancellationToken token = default)
	{
		return await genreRepository.GetByIdAsync(id, token);
	}

	public async Task<IEnumerable<Genre>> GetAllAsync(CancellationToken token = default)
	{
		return await genreRepository.GetAllAsync(token);
	}

	public async Task<Genre> UpdateAsync(Genre genre, CancellationToken token = default)
	{
		await genreValidator.ValidateAndThrowAsync(genre, token);
		return await genreRepository.UpdateAsync(genre, token);
	}

	public async Task DeleteByIdAsync(Genre genre, CancellationToken token = default)
	{
		await genreRepository.DeleteByIdAsync(genre, token);
	}
}