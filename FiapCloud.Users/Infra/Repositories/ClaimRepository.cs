using FiapCloud.Users.Domain.Entities;
using FiapCloud.Users.Infra.Data;
using FiapCloud.Users.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiapCloud.Users.Infra.Repository;

public class ClaimRepository : IClaimRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Claim> _claims;

    public ClaimRepository(AppDbContext context)
    {
        _context = context;
        _claims = _context.Set<Claim>();
    }

    public async Task<Claim?> GetByIdAsync(Guid id)
    {
        return await _claims.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Claim>> GetAllAsync()
    {
        return await _claims.ToListAsync();
    }

    public async Task AddAsync(Claim claim)
    {
        await _claims.AddAsync(claim);
    }

    public Task UpdateAsync(Claim claim)
    {
        _claims.Update(claim);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var claim = await GetByIdAsync(id);
        if (claim != null)
            _claims.Remove(claim);
    }

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
