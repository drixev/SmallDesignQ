namespace GenerateService.Application;

using GenerateService.Application.Ports;
using GenerateService.Application.Services;
using Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IGenerateSample, GenerateSample>();
        return services;
    }
}