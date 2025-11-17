using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Common.Exceptions;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Users.Commands.AddClaim;

public class AddClaimCommandHandler : IRequestHandler<AddClaimCommand, Result<bool>>
{
    private readonly IUserRepository _userRepository;

    public AddClaimCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<bool>> Handle(AddClaimCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId)
            ?? throw new NotFoundException("Usuário", request.UserId.ToString());

        await _userRepository.AddClaimAsync(request.UserId, request.ClaimId);
        await _userRepository.SaveChangesAsync();

        return Result<bool>.Ok(true, "Claim adicionada ao usuário.");
    }
}
