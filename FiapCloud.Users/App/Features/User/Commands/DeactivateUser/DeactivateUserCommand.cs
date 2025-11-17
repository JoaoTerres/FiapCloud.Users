using FiapCloud.Users.App.Common;
using MediatR;

namespace FiapCloud.Users.App.Features.Users.Commands.DeactivateUser;

public class DeactivateUserCommand : IRequest<Result<bool>>
{
    public DeactivateUserCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}
