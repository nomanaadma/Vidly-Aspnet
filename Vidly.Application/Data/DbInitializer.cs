using Microsoft.EntityFrameworkCore;

namespace Vidly.Application.Data;

public class DbInitializer(IDbConnectionFactory dbConnectionFactory)
{
	public async Task InitializeAsync()
	{
		await using var context = dbConnectionFactory.Context();
		await context.Genres.FindAsync(1);
	}
}