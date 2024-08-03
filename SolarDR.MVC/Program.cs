using Microsoft.EntityFrameworkCore;
using SolarDR.Application.Services;
using SolarDR.Infrastructure.Core;
using SolarDR.Infrastructure.Core.Contracts;
using SolarDR.Infrastructure.Core.Implemenrations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddTransient<IPersonRepository, PersonRepository>();

builder.Services.AddTransient<IPersonService, PersonService>();

builder.Services.AddControllersWithViews();


var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(configuration.GetConnectionString("AppDb"),
    x => x.MigrationsAssembly("SolarDR.Infrastructure.Core")));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
