using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.Domain.Entities;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Roles.Commands.CreateRole;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Result<RoleResult>>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Result<RoleResult>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role(request.Name);

        await _roleRepository.AddAsync(role);
        await _roleRepository.SaveChangesAsync();

        var result = new RoleResult
        {
            Id = role.Id,
            Name = role.Name,
            CreatedAt = role.CreatedAt,
            Claims = new List<ClaimResult>()
        };

        return Result<RoleResult>.Ok(result, "Role criada com sucesso.");
    }
}
