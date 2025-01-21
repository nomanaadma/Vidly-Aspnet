namespace Vidly.Contracts.Requests;

public class AuthRequest
{
	public required string Email { get; init; }
	
	public required string Password { get; init; }
}