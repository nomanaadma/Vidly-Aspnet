using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Vidly.Contracts.Responses;

namespace Vidly.Api.Filters;

public class AuthFilter(IConfigurationManager config) : IAsyncActionFilter
{
	public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
	{
		if (!context.HttpContext.Request.Headers.TryGetValue("x-auth-token", out var token))
		{

			context.Result = new JsonResult(new ValidationResponse
			{
				PropertyName = "Auth Token",
				ErrorMessage = "Token is required"	
			})
			{
				StatusCode = StatusCodes.Status401Unauthorized
			};

			return;
		}
		
		var tokenHandler = new JwtSecurityTokenHandler();
		
		var key = Encoding.UTF8.GetBytes(config["JwtTokenSecret"]!);
		
		var validationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key)
		};

		try
		{
			var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

			context.HttpContext.User = principal;
			context.HttpContext.Items["user"] = validatedToken;

		}
		catch (Exception ex)
		{
			context.Result = new JsonResult(new ValidationResponse
			{
				PropertyName = "Auth Token",
				ErrorMessage = ex.Message	
			})
			{
				StatusCode = StatusCodes.Status400BadRequest
			};

			return;
		}
		
		await next();
	}
}