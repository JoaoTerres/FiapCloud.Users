using FiapCloud.Users.Domain.Entities;
using FiapCloud.Users.Infra.Data;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiapCloud.Users.Infra.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<User> _users;

    public UserRepository(AppDbContext context)
    {
        _context = context;
        _users = _context.Set<User>();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _users
            .Include(u => u.Roles)
            .Include(u => u.Claims)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _users
            .Include(u => u.Roles)
            .Include(u => u.Claims)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _users
            .Include(u => u.Roles)
            .Include(u => u.Claims)
            .ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _users.AddAsync(user);
    }

    public Task UpdateAsync(User user)
    {
        _users.Update(user);
        return Task.CompletedTask;
    }

    public async Task DeactivateAsync(Guid id)
    {
        var user = await GetByIdAsync(id);
        if (user != null)
        {
            user.Deactivate();
            _users.Update(user);
        }
    }

    public async Task AssignRoleAsync(Guid userId, Guid roleId)
    {
        var user = await GetByIdAsync(userId);
        if (user == null) return;

        user.AssignRole(roleId);
        _users.Update(user);
    }

    public async Task RemoveRoleAsync(Guid userId, Guid roleId)
    {
        var user = await GetByIdAsync(userId);
        if (user == null) return;

        user.RemoveRole(roleId);
        _users.Update(user);
    }

    public async Task AddClaimAsync(Guid userId, Guid claimId)
    {
        var user = await GetByIdAsync(userId);
        if (user == null) return;

        user.AddClaim(claimId);
        _users.Update(user);
    }

    public async Task RemoveClaimAsync(Guid userId, Guid claimId)
    {
        var user = await GetByIdAsync(userId);
        if (user == null) return;

        user.RemoveClaim(claimId);
        _users.Update(user);
    }

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
