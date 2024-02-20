using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        //Middleware Endpoint (Use Second Best Option) + Custom Problem Details Factory (Best Option)
        // Custom More Fields for Problem Details (For Example: customProperty in  API.Error Folder)
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

        services.AddMapping();
        return services;
    }
}