using FluentValidation;
using FluentValidation.Results;
using Riok.Mapperly.Abstractions;
using Vidly.Contracts.Responses;

namespace Vidly.Api.Mappers;

[Mapper]
public static partial class ValidationMapper
{
	public static partial ValidationFailureResponse MapToResponse(ValidationException validationFailure);
}