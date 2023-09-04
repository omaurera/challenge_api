using System.Net;
using ChallengeN5.Application.Features.Commands;
using ChallengeN5.Application.Features.Queries;
using ChallengeN5.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ChallengeN5.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PermissionsController : ControllerBase
{

    private readonly IMediator _mediator;

    public PermissionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetPermissions")]
    [ProducesResponseType(typeof(CustomMultipleResponse<PermissionResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CustomMultipleResponse<PermissionResponse>>> GetPermissions()
    {
        return Ok(await _mediator.Send(new GetPermissionsQuery()));
    }

    [HttpPost("RequestPermission")]
    [ProducesResponseType(typeof(CustomResponse<PermissionResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CustomResponse<PermissionResponse>>> RequestPermission([FromBody] RequestPermissionCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("ModifyPermission")]
    [ProducesResponseType(typeof(CustomResponse<PermissionResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CustomResponse<PermissionResponse>>> ModifyPermission([FromBody] UpdatePermissionCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}

