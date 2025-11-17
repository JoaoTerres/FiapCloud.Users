using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Common.Exceptions;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Roles.Queries.GetRoleById;

public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Result<RoleResult>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IClaimRepository _claimRepository;

    public GetRoleByIdQueryHandler(IRoleRepository roleRepository, IClaimRepository claimRepository)
    {
        _roleRepository = roleRepository;
        _claimRepository = claimRepository;
    }

    public async Task<Result<RoleResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(request.Id);
        if (role == null)
            throw new NotFoundException("Role não encontrada.");

        var claims = await _claimRepository.GetAllAsync();

        var result = new RoleResult
        {
            Id = role.Id,
            Name = role.Name,
            CreatedAt = role.CreatedAt,
            Claims = role.Claims
                .Select(rc =>
                {
                    var c = claims.First(x => x.Id == rc.ClaimId);
                    return new ClaimResult
                    {
                        Id = c.Id,
                        Type = c.Type,
                        Value = c.Value,
                        CreatedAt = c.CreatedAt
                    };
                }).ToList()
        };

        return Result<RoleResult>.Ok(result);
    }
}
