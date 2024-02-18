
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication
{

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            //1. Validate the user does not exist
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                //throw new DuplicateEmailException();
                //return new DuplicateEmailError();

                //return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });
                return Errors.User.DuplicateEmail;
            }

            //2. Create the user (generate unique ID) & Persist to DB
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            //3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult
            (
                user,
                token
            );
        }
        public ErrorOr<AuthenticationResult> Login(
            string email,
            string password)
        {
            //1. Validate the user exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                //Maybe return List Error if we want
                //return new[] { Errors.Authentication.InvalidCredentials };

                return Errors.Authentication.InvalidCredentials;
            }

            //2. Validate the password is correct
            if (user.Password != password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult
            (
                user,
                token
            );
        }


    }
}