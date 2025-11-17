using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Common.Exceptions;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Users.Commands.AssignRole;


public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand, Result<bool>>
{
    private readonly IUserRepository _userRepository;

    public AssignRoleCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<bool>> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new NotFoundException("Usuário", request.UserId.ToString());

        await _userRepository.AssignRoleAsync(request.UserId, request.RoleId);
        await _userRepository.SaveChangesAsync();

        return Result<bool>.Ok(true, "Role atribuída ao usuário.");
    }
}
