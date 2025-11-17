using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using MediatR;

namespace FiapCloud.Users.App.Features.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<Result<IEnumerable<UserResult>>>
{
}
