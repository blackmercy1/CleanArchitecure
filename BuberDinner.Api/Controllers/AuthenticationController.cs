using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper =  mapper;
    }

    [HttpPost("register"), Route("auth/register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        
        var registerResult = await _mediator.Send(command);        
        
        return registerResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
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
        var loginCommand = _mapper.Map<LoginQuery>(loginRequest);
        
        var authResult = await _mediator.Send(loginCommand);
        
        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: "Invalid credentials.");
        
        return authResult.Match(
            authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
            error => Problem(error));
    }
}