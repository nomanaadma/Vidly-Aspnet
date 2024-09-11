namespace Vidly.Application.Models;

public class Customer
{
	public int Id { get; init; }

	public string Name { get; init; } = string.Empty;
	
	public bool IsGold { get; init; }
	
	public string Phone { get; init; } = string.Empty;
}