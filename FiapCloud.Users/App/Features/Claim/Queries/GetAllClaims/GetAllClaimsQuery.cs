using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using MediatR;

namespace FiapCloud.Users.App.Features.Claims.Queries.GetAllClaims;

public class GetAllClaimsQuery : IRequest<Result<IEnumerable<ClaimResult>>>
{
}
