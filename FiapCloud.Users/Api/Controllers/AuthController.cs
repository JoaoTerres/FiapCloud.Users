using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.App.Features.Users.Commands.AuthUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloud.Users.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Create([FromBody] AuthUserCommand command)
    {
        return FromResult(await _mediator.Send(command));
    }
}
