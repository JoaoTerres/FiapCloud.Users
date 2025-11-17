using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Common.Exceptions;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Roles.Commands.AddClaimToRole;


public class AddClaimToRoleCommandHandler : IRequestHandler<AddClaimToRoleCommand, Result<string>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IClaimRepository _claimRepository;

    public AddClaimToRoleCommandHandler(IRoleRepository roleRepository, IClaimRepository claimRepository)
    {
        _roleRepository = roleRepository;
        _claimRepository = claimRepository;
    }

    public async Task<Result<string>> Handle(AddClaimToRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(request.RoleId);

        if (role == null)
            throw new NotFoundException("Role", request.RoleId.ToString());

        var claim = await _claimRepository.GetByIdAsync(request.ClaimId);
        if (claim == null)
            throw new NotFoundException("Claim", request.ClaimId.ToString());

        role.AddClaim(request.ClaimId);

        await _roleRepository.UpdateAsync(role);
        await _roleRepository.SaveChangesAsync();

        return Result<string>.Ok("Claim adicionada à role com sucesso.");
    }
}
