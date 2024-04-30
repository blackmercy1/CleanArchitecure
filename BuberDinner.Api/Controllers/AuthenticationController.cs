using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register"), Route("auth/register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        RegisterCommand command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);        
        
        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            error => Problem(error));
    }
    
    [HttpPost("login"), Route("auth/login")]
    public async Task<IActionResult> Login(RegisterRequest loginRequest)
    {
        LoginQuery loginCommand = new LoginQuery(
            loginRequest.Email,
            loginRequest.Password);
        
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(loginCommand);
        
        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: "Invalid credentials.");
        
        return authResult.Match(
            authenticationResult => Ok(MapAuthResult(authenticationResult)),
            error => Problem(error));
    }

    private AuthenticationResponse MapAuthResult(ErrorOr<AuthenticationResult> authResult)
    {
        var response = new AuthenticationResponse(
            authResult.Value.User.Id,
            authResult.Value.User.FirstName,
            authResult.Value.User.LastName,
            authResult.Value.User.Email,
            authResult.Value.Token);
        
        return response;
    }
}