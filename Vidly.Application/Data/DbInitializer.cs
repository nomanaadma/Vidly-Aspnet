using Microsoft.EntityFrameworkCore;

namespace Vidly.Application.Data;

public class DbInitializer(IDbConnectionFactory dbConnectionFactory)
{
	public async Task InitializeAsync()
	{
		await using var context = dbConnectionFactory.Context();
		await context.Genres.FindAsync(1);
		
		var pendingMigration = await context.Database.GetPendingMigrationsAsync();
		if (pendingMigration.Any())
			throw new Exception("Database is not fully migrated");
		
	}
}