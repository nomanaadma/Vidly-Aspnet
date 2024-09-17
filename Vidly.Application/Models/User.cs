namespace Vidly.Application.Models;

public class User
{
	public int Id { get; init; }
	
	public string Name { get; init; } = string.Empty;
	
	public string Email { get; init; } = string.Empty;
	
	public string Password { get; set; } = string.Empty;

	public bool IsAdmin { get; init; }
	
}