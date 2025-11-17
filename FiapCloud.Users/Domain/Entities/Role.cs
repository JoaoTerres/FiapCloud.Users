namespace FiapCloud.Users.Domain.Entities;

public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyCollection<RoleClaim> Claims => _claims;
    private readonly List<RoleClaim> _claims = new();

    private Role() { }

    public Role(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;

        Validate();
    }

    public void AddClaim(Guid claimId)
    {
        AssertValidation.IsTrue(claimId != Guid.Empty, "ClaimId inválido.");
        if (_claims.Any(c => c.ClaimId == claimId))
            return;

        _claims.Add(new RoleClaim(Id, claimId));
    }

    public void RemoveClaim(Guid claimId)
    {
        AssertValidation.IsTrue(claimId != Guid.Empty, "ClaimId inválido.");
        var existing = _claims.FirstOrDefault(c => c.ClaimId == claimId);
        if (existing != null)
            _claims.Remove(existing);
    }

    private void Validate()
    {
        AssertValidation.NotEmpty(Name, "Nome da role é obrigatório.");
    }
}


