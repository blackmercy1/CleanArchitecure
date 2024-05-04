using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;

using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    private bool ValidatePassword(User? user, string password) => user?.Password == password;
    private User? GetUserIfExists(string email) => _userRepository.GetUserByEmail(email);
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var user = GetUserIfExists(query.Email);

        if (user is null)
            return Errors.Authentication.InvalidCredentials;

        if (!ValidatePassword(user, query.Password))
            return Errors.Authentication.InvalidCredentials;
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }
}
