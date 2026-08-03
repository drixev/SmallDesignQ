using GenerateService.Infraestructure.Security.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace GenerateService.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}