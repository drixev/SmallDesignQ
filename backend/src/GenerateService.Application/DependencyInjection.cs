namespace GenerateService.Application;

using FluentValidation;
using GenerateService.Application.DTOs;
using GenerateService.Application.Ports;
using GenerateService.Application.Services;
using GenerateService.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGenerateSample, GenerateSample>();
        services.AddScoped<IValidator<GenerateRequest>, GenerateRequestValidator>();
        return services;
    }
}