using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vidly.Application.Data;

namespace Vidly.Application;

public static class ApplicationServiceCollectionExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		return services;
	}
	
	public static IServiceCollection AddDatabase(this IServiceCollection services, 
		string? connectionString)
	{
		services.AddDbContext<DatabaseContext>(optionBuilder =>
		{
			optionBuilder.UseNpgsql(connectionString);
		});
		return services;
	}

	public static string ConnectionString(this IConfigurationRoot configuration, string key)
	{
		var connectionString = configuration.GetConnectionString(key);
		if (string.IsNullOrEmpty(connectionString))
		{
			throw new InvalidOperationException($"{key} connection string not found.");
		}
		return connectionString;
	}
	
}