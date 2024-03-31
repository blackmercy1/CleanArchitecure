using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatRServiceConfiguration = Microsoft.Extensions.DependencyInjection.MediatRServiceConfiguration;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var cfg = new MediatRServiceConfiguration().RegisterServicesFromAssemblies
            (Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg);
        
        return services;
    }
}