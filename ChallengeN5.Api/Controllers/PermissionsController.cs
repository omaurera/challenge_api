using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeN5.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PermissionsController : ControllerBase
{

    private readonly IMediator _mediator;

    public PermissionsController()
    {
    }

    [HttpGet()]
    
}

