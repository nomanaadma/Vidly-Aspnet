namespace Vidly.Application.Models;

public class Rental
{
	public int Id { get; init; }
	public Customer? Customer { get; init; }
	
	public Movie? Movie { get; init; }

	public DateTime DateOut { get; init; }
	
	public DateTime DateReturned { get; init; }
	
	public int RentalFee { get; init; }

}