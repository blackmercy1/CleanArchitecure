using BuberDinner.Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class ApiController : ControllerBase
{ 
    public IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;
        var firstError = errors[0];
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status408RequestTimeout,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
            
        return Problem(statusCode:statusCode, title: firstError.Description);
    }
}