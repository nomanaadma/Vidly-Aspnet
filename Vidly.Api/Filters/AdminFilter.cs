using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using Vidly.Contracts.Responses;

namespace Vidly.Api.Filters;

public class AdminFilter : IAsyncActionFilter
{
	public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
	{
		var jwt  = context.HttpContext.Items["user"]!.ToString();
		
		var jsonObject = JObject.Parse( (jwt!.Split('.')[^1]) );

		var isAdmin = bool.Parse(jsonObject["IsAdmin"]!.ToString());

		if (!isAdmin)
		{
			context.Result = new JsonResult(new ValidationResponse
			{
				PropertyName = "User",
				ErrorMessage = "Access Denied"
			})
			{
				StatusCode = StatusCodes.Status400BadRequest
			};

			return;
		}

		await next();

	}
}