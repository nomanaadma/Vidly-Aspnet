using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidly.Application.Models;

namespace Vidly.Application.Data.EntityMapping;

public class RentalMapping : IEntityTypeConfiguration<Rental>
{
	public void Configure(EntityTypeBuilder<Rental> builder)
	{
		// builder.Property(rental => rental.Customer)
			//.IsRequired();
		
		//
		// builder.Property(rental => rental.Movie)
		// 	.IsRequired();
		
		builder.Property(rental => rental.DateOut)
			.HasDefaultValue(DateTime.Now.ToUniversalTime())
			.IsRequired();
		
	}
}