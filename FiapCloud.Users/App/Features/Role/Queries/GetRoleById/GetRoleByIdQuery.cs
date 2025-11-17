using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using MediatR;

namespace FiapCloud.Users.App.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQuery : IRequest<Result<RoleResult>>
{
    public Guid Id { get; }
    public GetRoleByIdQuery(Guid id)
    {
        Id = id;
    }
}
