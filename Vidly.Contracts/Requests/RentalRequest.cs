namespace Vidly.Contracts.Requests;

public class RentalRequest
{
	public required int CustomerId { get; init; }

	public required int MovieId { get; init; }
}