using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using MediatR;

namespace FiapCloud.Users.App.Features.Claims.Commands.CreateClaim;

public class CreateClaimCommand : IRequest<Result<ClaimResult>>
{
    public string Type { get; }
    public string Value { get; }

    public CreateClaimCommand(string type, string value)
    {
        Type = type;
        Value = value;
    }
}