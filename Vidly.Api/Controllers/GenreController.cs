using Microsoft.AspNetCore.Mvc;
using Vidly.Application.Models;
using Vidly.Application.Services;

namespace Vidly.Api.Controllers;

[ApiController]
public class GenreController(IGenreService genreService) : ControllerBase
{
	[HttpPost(ApiEndpoints.Genre.Create)]
	// [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status201Created)]
	// [ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Create([FromBody]Genre request, 
		CancellationToken token)
	{
		var id = await genreService.CreateAsync(request, token);
		return Ok(new { id });
	}
}
