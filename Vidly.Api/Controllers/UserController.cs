using Microsoft.AspNetCore.Mvc;
using Vidly.Api.Mappers;
using Vidly.Application.Services;
using Vidly.Contracts.Requests;
using Vidly.Contracts.Responses;

namespace Vidly.Api.Controllers;

[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
	
	[HttpPost(ApiEndpoints.User.Create)]
	[ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ValidationFailureResponse), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Create([FromBody]UserRequest request,
		CancellationToken token)
	{
		var user = UserMapper.MapToUser(request);
		
		user = await userService.CreateAsync(user, token);

		Response.Headers["x-auth-token"] = userService.GenerateAuthToken(user);
		
		var response = UserMapper.MapToResponse(user);
		
		return Ok(response);
		
	}
}