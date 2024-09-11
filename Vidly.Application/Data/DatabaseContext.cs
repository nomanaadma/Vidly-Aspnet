using System.Reflection;
using Microsoft.EntityFrameworkCore;
// using Vidly.Application.Data.EntityMapping;
using Vidly.Application.Models;

namespace Vidly.Application.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
	public DbSet<Genre> Genres => Set<Genre>();
	public DbSet<Customer> Customers => Set<Customer>();
	public DbSet<Movie> Movies => Set<Movie>();
	public DbSet<Rental> Rentals => Set<Rental>();
	public DbSet<User> Users => Set<User>();
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(
			Assembly.GetExecutingAssembly(), 
			t => t.GetInterfaces().Any(i => 
				i.IsGenericType &&
				i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
		);
		
		base.OnModelCreating(modelBuilder);
	}
	
}