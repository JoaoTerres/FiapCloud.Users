using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using MediatR;

namespace FiapCloud.Users.App.Features.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest<Result<RoleResult>>
{
    public string Name { get; }

    public CreateRoleCommand(string name)
    {
        Name = name;
    }
}
