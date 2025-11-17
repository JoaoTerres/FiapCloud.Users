using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using MediatR;

namespace FiapCloud.Users.App.Features.Claims.Queries.GetClaimById;

public class GetClaimByIdQuery : IRequest<Result<ClaimResult>>
{
    public Guid Id { get; }

    public GetClaimByIdQuery(Guid id)
    {
        Id = id;
    }
}
