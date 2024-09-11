using Vidly.Application;
using Vidly.Application.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;

var connectionString = config.ConnectionString("database");

builder.Services.AddApplication();
builder.Services.AddDatabase(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", (DatabaseContext context) =>
	{
		return context.Database.CanConnect();
	})
	.WithName("index")
	.WithOpenApi();

app.Run();
