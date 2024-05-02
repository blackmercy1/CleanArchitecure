using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Authorize]
[Route("[controller]")]
public class DinnersControllers : ApiController
{
    [HttpGet("dinners"), Route("/dinners")]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}