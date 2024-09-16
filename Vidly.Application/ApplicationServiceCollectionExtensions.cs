﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vidly.Application.Data;
using Vidly.Application.Repositories;

namespace Vidly.Application;

public static class ApplicationServiceCollectionExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddSingleton<IGenreRepository, GenreRepository>();
		services.AddSingleton<ICustomerRepository, CustomerRepository>();
		services.AddSingleton<IMovieRepository, MovieRepository>();
		services.AddSingleton<IRentalRepository, RentalRepository>();
		services.AddSingleton<IReturnRepository, ReturnRepository>();
		
		services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Singleton);
		
		return services;
	}
	
	public static IServiceCollection AddDatabase(this IServiceCollection services, 
		string? connectionString)
	{
		services.AddDbContext<DatabaseContext>(optionBuilder =>
		{
			optionBuilder.UseNpgsql(connectionString);
		});
		
		services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
		services.AddSingleton<DbInitializer>();
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