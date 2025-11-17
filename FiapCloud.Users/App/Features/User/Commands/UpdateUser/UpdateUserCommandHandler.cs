using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Common.Exceptions;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UserResult>>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserResult>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("Usuário", request.Id.ToString());

        user.Update(request.Username, request.Email);
        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();

        var result = new UserResult
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Active = user.IsActive
        };

        return Result<UserResult>.Ok(result, "Usuário atualizado com sucesso.");
    }
}
