using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
) : IRequest<ErrorOr<AuthenticationResult>>;