using FiapCloud.Users.Domain.Entities;

namespace FiapCloud.Users.App.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);

}
