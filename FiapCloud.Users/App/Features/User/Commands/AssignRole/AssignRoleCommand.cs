using MediatR;
using FiapCloud.Users.App.Common;

namespace FiapCloud.Users.App.Features.Users.Commands.AssignRole;

public class AssignRoleCommand : IRequest<Result<bool>>
{
    public AssignRoleCommand(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public Guid UserId { get; }
    public Guid RoleId { get; }
}
