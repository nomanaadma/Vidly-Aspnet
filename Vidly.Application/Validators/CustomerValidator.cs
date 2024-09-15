using FluentValidation;
using Vidly.Application.Models;

namespace Vidly.Application.Validators;

public class CustomerValidator : AbstractValidator<Customer> 
{
	public CustomerValidator()
	{
		RuleFor(g => g.Name)
			.Length(5, 50)
			.NotEmpty();
		
		RuleFor(g => g.Phone)
			.Length(5, 50)
			.NotEmpty();
		
		// RuleFor(g => g.IsGold)
		// 	.Must(x => x is false or true)
		// 	.NotEmpty();
		
	}
}