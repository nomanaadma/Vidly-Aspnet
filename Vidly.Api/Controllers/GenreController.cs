using Microsoft.AspNetCore.Mvc;
using Vidly.Application.Services;
using Vidly.Contracts.Requests;
using Vidly.Contracts.Responses;
using Vidly.Api.Mappers;

namespace Vidly.Api.Controllers;

[ApiController]
public class GenreController(IGenreService genreService) : ControllerBase
{
	[HttpPost(ApiEndpoints.Genre.Create)]
	[ProducesResponseType(typeof(GenreResponse), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Create([FromBody]GenreRequest request,
		CancellationToken token)
	{
		var genre = GenreMapper.MapToGenre(request);
		
		genre = await genreService.CreateAsync(genre, token);
		
		var response = GenreMapper.MapToResponse(genre);
	
		return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
		
	}
	
	[HttpGet(ApiEndpoints.Genre.Get)]
	[ProducesResponseType(typeof(GenreResponse), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Get([FromRoute] int id,
		CancellationToken token)
	{
		var genre = await genreService.GetByIdAsync(id, token);
		
		if (genre is null)
			return NotFound();

		var response = GenreMapper.MapToResponse(genre);
		return Ok(response);
	}
	
	[HttpGet(ApiEndpoints.Genre.GetAll)]
	[ProducesResponseType(typeof(GenresResponse), StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAll(CancellationToken token)
	{
		var genres = await genreService.GetAllAsync(token);
		var response = GenreMapper.MapToListResponse(genres);
		return Ok(response);
	}
	
	
	[HttpPut(ApiEndpoints.Genre.Update)]
	[ProducesResponseType(typeof(GenreResponse), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Update([FromRoute] int id, 
		[FromBody] GenreRequest request, 
		CancellationToken token)
	{
		var existingGenre = await genreService.GetByIdAsync(id, token);
		
		if (existingGenre is null)
			return NotFound();
		
		var genre = GenreMapper.MapToGenreWithId(request, id);
		
		genre = await genreService.UpdateAsync(genre, token);
		
		var response = GenreMapper.MapToResponse(genre);
		
		return Ok(response);
		
	}
	
	
	[HttpDelete(ApiEndpoints.Genre.Delete)]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
	{
		var existingGenre = await genreService.GetByIdAsync(id, token);
		
		if (existingGenre is null)
			return NotFound();
		
		await genreService.DeleteByIdAsync(existingGenre, token);
		
		return Ok();
	}
	
}
