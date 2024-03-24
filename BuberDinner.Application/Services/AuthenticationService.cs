using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    private User? GetUserIfExists(string email) => _userRepository.GetUserByEmail(email);
    
    private bool ValidatePassword(User? user, string password) => user?.Password == password;
    
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if (GetUserIfExists(email) is not null)
            throw new Exception("User already exists");

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        var token = _jwtTokenGenerator.GenerateToken(user);
        _userRepository.Add(user);
        
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        var user = GetUserIfExists(email);
        
        if (user is null)
            throw new Exception("User not found");
        
        if (!ValidatePassword(user, password))
            throw new Exception("Invalid password");
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }
}