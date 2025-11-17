using FiapCloud.Users.Domain.Entities;

namespace FiapCloud.Users.Infra.Repositories.Interfaces;

public interface IClaimRepository
{
    Task<Claim?> GetByIdAsync(Guid id);
    Task<IEnumerable<Claim>> GetAllAsync();
    Task AddAsync(Claim claim);
    Task UpdateAsync(Claim claim);
    Task DeleteAsync(Guid id);
    Task<int> SaveChangesAsync();

}
