using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Infrastructure;
using Tersan.SketchManagement.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ResolveRepositoryDependencies();
builder.Services.AddDefaultAWSOptions((builder.Configuration.GetAWSOptions()));
builder.Services.AddAWSService<IAmazonS3>();
// configure cors 
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
builder.Services.ConfigureDB(builder.Configuration.GetValue<string>("ConnectionStrings:SqlServerSketchManagement"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers().RequireCors("CorsPolicy");

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
        services.AddScoped<ISketchRepository, SketchRepository>();
        services.AddScoped<IFileRepository, AWSRepository>();
        
        return services;
    }
}