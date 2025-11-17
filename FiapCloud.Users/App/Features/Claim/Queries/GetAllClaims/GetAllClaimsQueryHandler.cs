using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Claims.Queries.GetAllClaims;

public class GetAllClaimsQueryHandler : IRequestHandler<GetAllClaimsQuery, Result<IEnumerable<ClaimResult>>>
{
    private readonly IClaimRepository _claimRepository;

    public GetAllClaimsQueryHandler(IClaimRepository claimRepository)
    {
        _claimRepository = claimRepository;
    }

    public async Task<Result<IEnumerable<ClaimResult>>> Handle(GetAllClaimsQuery request, CancellationToken cancellationToken)
    {
        var claims = await _claimRepository.GetAllAsync();

        var result = claims.Select(c => new ClaimResult
        {
            Id = c.Id,
            Type = c.Type,
            Value = c.Value,
            CreatedAt = c.CreatedAt
        });

        return Result<IEnumerable<ClaimResult>>.Ok(result);
    }
}
