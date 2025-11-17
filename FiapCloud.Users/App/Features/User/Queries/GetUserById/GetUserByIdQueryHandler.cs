using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Common.Exceptions;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserResult>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UserResult>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("Usuário", request.Id.ToString());

        var result = new UserResult
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Active = user.IsActive
        };

        return Result<UserResult>.Ok(result, "Usuário encontrado com sucesso.");
    }
}
