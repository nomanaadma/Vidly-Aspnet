using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Vidly.Application.Models;
using Vidly.Application.Repositories;
using BC = BCrypt.Net.BCrypt;

namespace Vidly.Application.Services;

public interface IUserService
{
	Task<User> CreateAsync(User user, CancellationToken token = default);
	
	string GenerateAuthToken(User user);
}

public class UserService(
	IUserRepository userRepository,
	IValidator<User> userValidator
	) : IUserService
{
	public async Task<User> CreateAsync(User user, CancellationToken token = default)
	{
		await userValidator.ValidateAndThrowAsync(user, token);
		user.Password = BC.HashPassword(user.Password, 10);
		return await userRepository.CreateAsync(user, token);
	}

	public string GenerateAuthToken(User user)
	{
		const string tokenSecret = "vidly_application_jwt_private_key";
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.UTF8.GetBytes(tokenSecret);
		
		var claims = new List<Claim>
		{
			new("Id", user.Id.ToString()),
			new("IsAdmin", user.IsAdmin.ToString(), ClaimValueTypes.Boolean)
		};
		
		var token = tokenHandler.CreateJwtSecurityToken(
			subject: new ClaimsIdentity(claims),
			signingCredentials: new SigningCredentials(
				new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		);

		return tokenHandler.WriteToken(token);
	}
	
}