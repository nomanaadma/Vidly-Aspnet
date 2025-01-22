using Serilog;
using Vidly.Api.Filters;
using Vidly.Api.Middlewares;
using Vidly.Application;
using Vidly.Application.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((ctx, cf) =>
{
	cf.WriteTo.Console();
});


builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthFilter>();
builder.Services.AddScoped<AdminFilter>();

var config = builder.Configuration;

var connectionString = config.ConnectionString("database");

builder.Services.AddApplication(config);
builder.Services.AddDatabase(connectionString);

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ValidationMiddleware>();

app.MapControllers();


var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
await dbInitializer.InitializeAsync();

app.Run();
