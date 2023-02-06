using Microsoft.EntityFrameworkCore;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Infrastructure;
using Tersan.SketchManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ResolveRepositoryDependencies();

builder.Services.ConfigureDB(builder.Configuration.GetValue<string>("ConnectionStrings:SqlServerSketchManagement"));

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


public static class DbConfiguration
{
    public static IServiceCollection ConfigureDB(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SketchManagementDbContext>(options =>
        options.UseSqlServer(connectionString));
        
        return services;
    }
}

//dependency resolver extension
public static class DependencyInjectionResolver
{
    public static IServiceCollection ResolveRepositoryDependencies(this IServiceCollection services)
    {
        services.AddScoped<IBuildingRepository, BuildingRepository>();
        services.AddScoped<IShipRepository, ShipRepository>();
        services.AddScoped<IShipStatusRepository, ShipStatusRepository>();

        return services;
    }
}