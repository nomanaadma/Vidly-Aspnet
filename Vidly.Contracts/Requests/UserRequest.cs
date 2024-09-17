namespace Vidly.Contracts.Requests;

public class UserRequest
{
	public required string Name { get; init; }
	
	public required string Email { get; init; }
	
	public required string Password { get; init; }

	public bool IsAdmin { get; init; }
}