using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using FiapCloud.Users.Domain.Entities;
using MediatR;

namespace FiapCloud.Users.App.Features.Claims.Commands.CreateClaim;

public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand, Result<ClaimResult>>
{
    private readonly IClaimRepository _claimRepository;

    public CreateClaimCommandHandler(IClaimRepository claimRepository)
    {
        _claimRepository = claimRepository;
    }

    public async Task<Result<ClaimResult>> Handle(CreateClaimCommand request, CancellationToken cancellationToken)
    {
        var claim = new Claim(request.Type, request.Value);

        await _claimRepository.AddAsync(claim);
        await _claimRepository.SaveChangesAsync();

        var result = new ClaimResult
        {
            Id = claim.Id,
            Type = claim.Type,
            Value = claim.Value,
            CreatedAt = claim.CreatedAt
        };

        return Result<ClaimResult>.Ok(result, "Claim criada com sucesso.");
    }
}
