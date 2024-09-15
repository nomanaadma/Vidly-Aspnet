namespace Vidly.Contracts.Requests;

public class CustomerRequest
{
	public required string Name { get; init; }
	
	public required string Phone { get; init; }
	
	public required bool IsGold { get; init; }
}