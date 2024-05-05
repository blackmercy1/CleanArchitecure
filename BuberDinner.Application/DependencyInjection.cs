using System.Reflection;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MediatRServiceConfiguration = Microsoft.Extensions.DependencyInjection.MediatRServiceConfiguration;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var cfg = new MediatRServiceConfiguration()
            .RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        
        services.AddMediatR(cfg);
        
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));
        
        services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
        services.AddScoped<IValidator<LoginQuery>, LoginQueryValidator>();
        
        return services;
    }
}