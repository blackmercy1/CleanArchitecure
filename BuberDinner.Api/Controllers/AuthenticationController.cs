using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    public AuthenticationController(ISender mediator) => _mediator = mediator;
    
    [HttpPost("register"), Route("auth/register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName, 
            request.LastName,
            request.Email,
            request.Password);
        
        var registerResult = await _mediator.Send(command);        
        
        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            error => Problem(error));
    }

    private AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
        
        return response;
    }

    [HttpPost("login"), Route("auth/login")]
    public async Task<IActionResult> Login(RegisterRequest loginRequest)
    {
        var loginCommand = new LoginQuery(
            loginRequest.Email,
            loginRequest.Password);
        
        var authResult = await _mediator.Send(loginCommand);
        
        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: "Invalid credentials.");
        
        return authResult.Match(
            authenticationResult => Ok(MapAuthResult(authenticationResult)),
            error => Problem(error));
    }
}