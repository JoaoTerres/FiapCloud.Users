using FiapCloud.Users.App.Common;
using MediatR;

namespace FiapCloud.Users.App.Features.Users.Commands.AddClaim;

public class AddClaimCommand : IRequest<Result<bool>>
{
    public AddClaimCommand(Guid userId, Guid claimId)
    {
        UserId = userId;
        ClaimId = claimId;
    }

    public Guid UserId { get; }
    public Guid ClaimId { get; }
}
