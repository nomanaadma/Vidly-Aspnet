using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Vidly.Application.Data;
using Vidly.Application.Models;

namespace Vidly.Application.Repositories;


public interface IUserRepository
{
	Task<User> CreateAsync(User user, CancellationToken token = default);
	
	Task<User?> GetByEmailAsync(string email, CancellationToken token = default);

	Task<User?> GetByIdAsync(int id, CancellationToken token = default);
}

public class UserRepository(IDbConnectionFactory dbConnectionFactory) : IUserRepository
{
	public async Task<User> CreateAsync(User user, CancellationToken token = default)
	{
		await using var context = dbConnectionFactory.Context(); 
		await context.Users.AddAsync(user, token);
		await context.SaveChangesAsync(token);
		return user;
	}

	public async Task<User?> GetByEmailAsync(string email, CancellationToken token = default)
	{
		await using var context = dbConnectionFactory.Context();
		var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email, token);
		return user;
	}
	
	public async Task<User?> GetByIdAsync(int id, CancellationToken token = default)
	{
		await using var context = dbConnectionFactory.Context();
		var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id, token);
		return user;
	}
}