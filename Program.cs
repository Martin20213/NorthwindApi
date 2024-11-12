using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Add the DbContext to the container, using the connection string from appsettings.json
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("NorthwindDatabase")));

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
