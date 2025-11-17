using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserResult>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<IEnumerable<UserResult>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();

        var results = users.Select(u => new UserResult
        {
            Id = u.Id,
            Username = u.Username,
            Email = u.Email,
            Active = u.IsActive
        });

        return Result<IEnumerable<UserResult>>.Ok(results, "Usuários carregados com sucesso.");
    }
}
