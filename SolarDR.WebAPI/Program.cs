using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SolarDR.Application;
using SolarDR.Application.Mapper;
using SolarDR.Application.Services;
using SolarDR.Infrastructure.Core;
using SolarDR.Infrastructure.Core.Contracts;
using SolarDR.Infrastructure.Core.Implemenrations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("AppDb"),
    x => x.MigrationsAssembly("SolarDR.Infrastructure.Core")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
    options.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date",
        Example = new OpenApiString("2022-01-01")
    })
);

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
