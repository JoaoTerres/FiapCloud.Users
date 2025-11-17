using FiapCloud.Users.App.Features.Claims.Queries.GetClaimById;
using FiapCloud.Users.App.Features.Claims.Commands.CreateClaim;
using FiapCloud.Users.App.Features.Claims.Queries.GetAllClaims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloud.Users.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClaimController : BaseController
{
    private readonly IMediator _mediator;

    public ClaimController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClaimCommand command)
    {
        return FromResult(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return FromResult(await _mediator.Send(new GetAllClaimsQuery()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return FromResult(await _mediator.Send(new GetClaimByIdQuery(id)));
    }
}
