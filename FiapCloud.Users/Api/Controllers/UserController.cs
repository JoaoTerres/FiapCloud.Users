using FiapCloud.Users.App.Features.Queries.GetAllUsers;
using FiapCloud.Users.App.Features.Queries.GetUserById;
using FiapCloud.Users.App.Features.Users.Commands.AddClaim;
using FiapCloud.Users.App.Features.Users.Commands.AssignRole;
using FiapCloud.Users.App.Features.Users.Commands.CreateUser;
using FiapCloud.Users.App.Features.Users.Commands.DeactivateUser;
using FiapCloud.Users.App.Features.Users.Commands.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloud.Users.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        return FromResult(await _mediator.Send(command));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
    {
        return FromResult(await _mediator.Send(command));
    }

    [HttpPatch("{id:guid}/deactivate")]
    public async Task<IActionResult> Deactivate(Guid id)
    {
        return FromResult(await _mediator.Send(new DeactivateUserCommand(id)));
    }

    [HttpPost("{userId:guid}/roles/{roleId:guid}")]
    public async Task<IActionResult> AssignRole(Guid userId, Guid roleId)
    {
        return FromResult(await _mediator.Send(new AssignRoleCommand(userId, roleId)));
    }

    [HttpPost("{userId:guid}/claims/{claimId:guid}")]
    public async Task<IActionResult> AddClaim(Guid userId, Guid claimId)
    {
        return FromResult(await _mediator.Send(new AddClaimCommand(userId, claimId)));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return FromResult(await _mediator.Send(new GetUserByIdQuery(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return FromResult(await _mediator.Send(new GetAllUsersQuery()));
    }

}

