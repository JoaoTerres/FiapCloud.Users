using FiapCloud.Users.Domain.Entities;

namespace FiapCloud.Users.Infra.Repositories.Interfaces;

public interface IRoleRepository
{
    Task<Role?> GetByIdAsync(Guid id);
    Task<IEnumerable<Role>> GetAllAsync();
    Task AddAsync(Role role);
    Task UpdateAsync(Role role);
    Task DeleteAsync(Guid id);

    Task AddClaimAsync(Guid roleId, Guid claimId);
    Task RemoveClaimAsync(Guid roleId, Guid claimId);

    Task<int> SaveChangesAsync();

}
