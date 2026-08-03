namespace GenerateService.Api.Extensions;

public static class ApiExtension
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddProblemDetails();

        services.AddJwtAuthentication(configuration);
        return services;
    }
}