using FiapCloud.Users.App.Features.Roles.Commands.AddClaimToRole;
using FiapCloud.Users.App.Features.Roles.Queries.GetRoleById;
using FiapCloud.Users.App.Features.Roles.Commands.CreateRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloud.Users.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : BaseController
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
    {
        return FromResult(await _mediator.Send(command));
    }

    [HttpPost("{roleId:guid}/claims/{claimId:guid}")]
    public async Task<IActionResult> AddClaim(Guid roleId, Guid claimId)
    {
        return FromResult(await _mediator.Send(new AddClaimToRoleCommand(roleId, claimId)));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return FromResult(await _mediator.Send(new GetRoleByIdQuery(id)));
    }
}
