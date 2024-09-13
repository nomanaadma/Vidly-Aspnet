using FluentValidation;
using FluentValidation.Results;
using Riok.Mapperly.Abstractions;
using Vidly.Contracts.Responses;

namespace Vidly.Api.Mappers;

[Mapper]
public static partial class ValidationMapper
{
	private static partial ValidationResponse MapToResponse(ValidationFailure validationFailure);
	public static ValidationFailureResponse MapToListResponse(
		IEnumerable<ValidationFailure> validationFailure) => 
		new() { Errors = validationFailure.Select(MapToResponse) };
		
}


