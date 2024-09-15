namespace Vidly.Application.Models;

public class Movie
{
	public int Id { get; set; }

	public string Title { get; init; } = string.Empty;

	public int GenreId { get; init; }
	public Genre Genre { get; set; } = null!;
	public int NumberInStock { get; init; }

	public int DailyRentalRate { get; init; }
	
}