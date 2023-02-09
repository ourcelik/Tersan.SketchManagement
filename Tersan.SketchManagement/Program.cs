using Amazon.S3;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tersan.SketchManagement.Application.Repositories.Abstracts;
using Tersan.SketchManagement.Infrastructure;
using Tersan.SketchManagement.Infrastructure.Persistence.Repositories;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Building;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Ship;
using Tersan.SketchManagement.Infrastructure.Persistence.ViewModels.Sketch;
using Tersan.SketchManagement.Infrastructure.Validation;
using Tersan.SketchManagement.Infrastructure.Validation.Factory;
using Tersan.SketchManagement.Infrastructure.Validation.ShipValidation;
using Tersan.SketchManagement.Infrastructure.Validation.SketchValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ResolveRepositoryDependencies();
builder.Services.AddDefaultAWSOptions((builder.Configuration.GetAWSOptions()));
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.ResolveValidatorDependencies();

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
    
    public static IServiceCollection ResolveValidatorDependencies(this IServiceCollection services)
    {
        services.AddScoped<IValidator<InputAddShipViewModel>,InputAddShipViewModelValidator>();
        services.AddScoped<IValidator<InputUpdateShipViewModel>,InputUpdateShipViewModelValidator>();
        services.AddScoped<IValidator<InputShipViewModel>,InputShipViewModelValidator>();
        services.AddScoped<IValidator<InputAddBuildingViewModel>,InputAddBuildingViewModelValidator>();
        services.AddScoped<IValidator<InputUpdateBuildingViewModel>,InputUpdateBuildingViewModelValidator>();
        services.AddScoped<IValidator<InputBuildingViewModel>,InputBuildingViewModelValidator>();
        services.AddScoped<IValidator<InputSketchCreateViewModel>,InputSketchCreateViewModelValidator>();

        //Factory
        services.AddScoped<ICustomValidatorFactory, ValidatorFactory>();

        

        return services;
    }


}