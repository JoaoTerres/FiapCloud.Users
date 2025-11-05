namespace FiapCloud.Users.Domain.Entities;

public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public IReadOnlyCollection<RoleClaim> Claims => _claims;
    private readonly List<RoleClaim> _claims = new();

    private Role() { }

    public Role(string name, string? description = null)
    {
        Name = name;
        Description = description?.Trim();
        Id = Guid.NewGuid();

        Validate();
    }

    public void Rename(string newName)
    {
        AssertValidation.NotEmpty(newName, "Nome inválido.");
        Name = newName;
    }

    public void UpdateDescription(string? description)
    {
        Description = description?.Trim();
    }

    public void AddClaim(Claim claim)
    {
        AssertValidation.NotNull(claim, "Claim inválida.");
        if (_claims.Any(c => c.ClaimId == claim.Id))
            return;

        _claims.Add(new RoleClaim(Id, claim.Id));
    }

    public void RemoveClaim(Guid claimId)
    {
        var rc = _claims.FirstOrDefault(c => c.ClaimId == claimId);
        if (rc != null)
            _claims.Remove(rc);
    }

    private void Validate()
    {
        AssertValidation.NotEmpty(Name, "Nome da role é obrigatório.");
    }
}



