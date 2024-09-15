namespace Vidly.Contracts.Requests;

public class MovieRequest
{
	
	public required string Title { get; init; }

	public required int GenreId { get; init; }
	
	public required int NumberInStock { get; init; }

	public required int DailyRentalRate { get; init; }
	
}