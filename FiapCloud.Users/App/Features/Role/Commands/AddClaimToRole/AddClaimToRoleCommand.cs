using FiapCloud.Users.App.Common;
using MediatR;

namespace FiapCloud.Users.App.Features.Roles.Commands.AddClaimToRole;

public class AddClaimToRoleCommand : IRequest<Result<string>>
{
    public Guid RoleId { get; }
    public Guid ClaimId { get; }

    public AddClaimToRoleCommand(Guid roleId, Guid claimId)
    {
        RoleId = roleId;
        ClaimId = claimId;
    }
}
