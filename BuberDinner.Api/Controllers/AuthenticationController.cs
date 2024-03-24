using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Services;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [HttpPost("register"), Route("auth/register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        var authResult = _authenticationService.Register(
            registerRequest.FirstName, 
            registerRequest.LastName,
            registerRequest.Email,
            registerRequest.Password);
        
        var response = new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token);
        
        return Ok(response);
    }
    
    [HttpPost("login"), Route("auth/login")]
    public IActionResult Login(RegisterRequest loginRequest)
    {
        var authResult = _authenticationService.Login(
            loginRequest.Email,
            loginRequest.Password);
        
        var response = new AuthenticationResponse(
            authResult.user.Id,
            "hello",
            "authResult.LastName",
            authResult.user.Email,
            authResult.Token);
        
        return Ok(response);
    }
}