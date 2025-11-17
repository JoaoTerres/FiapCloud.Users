using FiapCloud.Users.Domain.Entities;
using FiapCloud.Users.Infra.Data;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiapCloud.Users.Infra.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Role> _roles;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
        _roles = _context.Set<Role>();
    }

    public async Task<Role?> GetByIdAsync(Guid id)
    {
        return await _roles
            .Include(r => r.Claims)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<Role>> GetAllAsync()
    {
        return await _roles
            .Include(r => r.Claims)
            .ToListAsync();
    }

    public async Task AddAsync(Role role)
    {
        await _roles.AddAsync(role);
    }

    public Task UpdateAsync(Role role)
    {
        _roles.Update(role);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var role = await GetByIdAsync(id);
        if (role != null)
            _roles.Remove(role);
    }

    public async Task AddClaimAsync(Guid roleId, Guid claimId)
    {
        var role = await GetByIdAsync(roleId);
        if (role == null) return;

        role.AddClaim(claimId);
        _roles.Update(role);
    }

    public async Task RemoveClaimAsync(Guid roleId, Guid claimId)
    {
        var role = await GetByIdAsync(roleId);
        if (role == null) return;

        role.RemoveClaim(claimId);
        _roles.Update(role);
    }

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
