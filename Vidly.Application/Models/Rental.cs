namespace Vidly.Application.Models;

public class Rental
{
	public int Id { get; init; }
	
	public Customer Customer { get; init; } = null!;

	public Movie Movie { get; init; } = null!;

	public DateTime DateOut { get; init; }
	
	public DateTime DateReturned { get; init; }
	
	public int RentalFee { get; init; }

}