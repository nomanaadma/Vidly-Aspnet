namespace Vidly.Contracts.Requests;

public class UserRequest : AuthRequest
{
	public required string Name { get; init; }
	public bool IsAdmin { get; init; }
}