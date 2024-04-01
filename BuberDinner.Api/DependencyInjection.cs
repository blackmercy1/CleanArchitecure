using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mapping;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        services.AddMappings();
        return services;
    }
}