using Microsoft.EntityFrameworkCore;

namespace Vidly.Application.Data;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
	
}