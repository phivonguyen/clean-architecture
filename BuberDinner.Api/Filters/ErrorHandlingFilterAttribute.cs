using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

//Custom Exception Filter Attribute
public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {

        var exception = context.Exception;

        //Problem Details Response from Handling Filter
        var problemDetails = new ProblemDetails
        {
            Title = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = exception.StackTrace
        };

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
    }
}