namespace Vidly.Application.Models;

public class Movie
{
	public int Id { get; init; }

	public string Title { get; init; } = string.Empty;

	public Genre Genre { get; init; } = null!;
	public int NumberInStock { get; init; }

	public int DailyRentalRate { get; init; }
	
}