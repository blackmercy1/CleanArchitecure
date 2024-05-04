using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.UserAggregate;

using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    private User? GetUserIfExists(string email) => _userRepository.GetUserByEmail(email);
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (command.Email == "")
            return Error.Unexpected();
        
        if (GetUserIfExists(command.Email) is not null)
            return Errors.User.DuplicateEmail;

        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password
        );

        var token = _jwtTokenGenerator.GenerateToken(user);
        _userRepository.Add(user);
        
        return new AuthenticationResult(user, token);
    }
}
