using FiapCloud.Users.Domain.Entities;

namespace FiapCloud.Users.Infra.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllAsync();

    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeactivateAsync(Guid id);

    Task AssignRoleAsync(Guid userId, Guid roleId);
    Task RemoveRoleAsync(Guid userId, Guid roleId);
    Task AddClaimAsync(Guid userId, Guid claimId);
    Task RemoveClaimAsync(Guid userId, Guid claimId);

    Task<int> SaveChangesAsync();
}
