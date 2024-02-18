using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Filters;
//using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    ////Custom Exception Filter Attribute
    ////Problem Details Response from Handling Filter
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();

    //Middleware Endpoint (Use Second Best Option) + Custom Problem Details Factory (Best Option)
    // Custom More Fields for Problem Details (For Example: customProperty in  API.Error Folder)
    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
}

var app = builder.Build();
{
    ////Custom Error Handling Middleware
    //app.UseMiddleware<ErrorHandlingMiddleware>();

    ////UseExceptionHandler Middleware & Error Endpoint (Second Best Option)
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

