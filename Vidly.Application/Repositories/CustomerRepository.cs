﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Vidly.Application.Data;
using Vidly.Application.Models;

namespace Vidly.Application.Repositories;

public class CustomerRepository(IDbConnectionFactory dbConnectionFactory, IValidator<Customer> customerValidator) : ICustomerRepository
{
	public async Task<Customer> CreateAsync(Customer customer, CancellationToken token = default)
	{
		await customerValidator.ValidateAndThrowAsync(customer, token);
		await using var context = dbConnectionFactory.Context();
		await context.Customers.AddAsync(customer, token);
		await context.SaveChangesAsync(token);
		return customer;
	}

	public async Task<Customer?> GetByIdAsync(int id, CancellationToken token = default)
	{
		await using var context = dbConnectionFactory.Context();
		var customer = await context.Customers.FindAsync([id], token);
		return customer;
	}

	public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken token = default)
	{
		await using var context = dbConnectionFactory.Context();
		var customers = await context.Customers.OrderBy(g => g.Name).ToListAsync(token);
		return customers;
	}

	public async Task<Customer> UpdateAsync(Customer customer, CancellationToken token = default)
	{
		await customerValidator.ValidateAndThrowAsync(customer, token);
		await using var context = dbConnectionFactory.Context();
		context.Customers.Update(customer);
		await context.SaveChangesAsync(token);
		return customer;
	}

	public async Task DeleteByIdAsync(Customer customer, CancellationToken token = default)
	{
		await using var context = dbConnectionFactory.Context();
		context.Customers.Remove(customer);
		await context.SaveChangesAsync(token);
	}
}
