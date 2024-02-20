//using BuberDinner.Application.Services.Authentication.Commands;
//using BuberDinner.Application.Services.Authentication.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        // services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        //services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}