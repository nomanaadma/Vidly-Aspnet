using FluentValidation;
using Vidly.Api.Mappers;

namespace Vidly.Api.Middlewares;

public class ValidationMiddleware(RequestDelegate next)
{
	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await next(context);
		} 
		catch (ValidationException ex)
		{
			context.Response.StatusCode = 400;
			 
			var validationFailureResponse = ValidationMapper.MapToResponse(ex);
			
			await context.Response.WriteAsJsonAsync(validationFailureResponse);
		}
	}
}