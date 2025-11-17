using FiapCloud.Users.App.Common;
using FiapCloud.Users.App.Common.Exceptions;
using FiapCloud.Users.App.Dtos;
using FiapCloud.Users.App.Interfaces;
using FiapCloud.Users.Domain.Entities;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using MediatR;

namespace FiapCloud.Users.App.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<UserResult>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existing = await _userRepository.GetByEmailAsync(request.Email);
        if (existing != null)
            throw new ValidationException("E-mail já cadastrado.");

        var hashedPassword = _passwordHasher.HashPassword(request.PasswordHash);

        var user = new User(request.Username, request.Email, hashedPassword);

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        var result = new UserResult
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Active = user.IsActive
        };

        return Result<UserResult>.Ok(result, "Usuário criado com sucesso.");
    }
}

