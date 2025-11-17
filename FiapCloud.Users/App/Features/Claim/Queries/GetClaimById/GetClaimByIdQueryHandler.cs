using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Common.Exceptions;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Claims.Queries.GetClaimById;

public class GetClaimByIdQueryHandler : IRequestHandler<GetClaimByIdQuery, Result<ClaimResult>>
{
    private readonly IClaimRepository _claimRepository;

    public GetClaimByIdQueryHandler(IClaimRepository claimRepository)
    {
        _claimRepository = claimRepository;
    }

    public async Task<Result<ClaimResult>> Handle(GetClaimByIdQuery request, CancellationToken cancellationToken)
    {
        var claim = await _claimRepository.GetByIdAsync(request.Id);

        if (claim == null)
            throw new NotFoundException("Claim", request.Id.ToString());

        var result = new ClaimResult
        {
            Id = claim.Id,
            Type = claim.Type,
            Value = claim.Value,
            CreatedAt = claim.CreatedAt
        };

        return Result<ClaimResult>.Ok(result);
    }
}
