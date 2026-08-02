public static class ApiExtension
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddProblemDetails();
        return services;
    }
}