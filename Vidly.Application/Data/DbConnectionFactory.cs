using Microsoft.Extensions.DependencyInjection;

namespace Vidly.Application.Data;

public interface IDbConnectionFactory
{
	DatabaseContext Context();
}

public class DbConnectionFactory(IServiceProvider serviceProvider) : IDbConnectionFactory
{
	public DatabaseContext Context()
	{
		var scope = serviceProvider.CreateScope();
		return scope.ServiceProvider.GetRequiredService<DatabaseContext>();
	}
}