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
	
		return Ok(response);
		
		// return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
		
	}
}
