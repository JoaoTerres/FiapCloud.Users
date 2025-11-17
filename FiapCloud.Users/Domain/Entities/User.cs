namespace FiapCloud.Users.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyCollection<UserRole> Roles => _roles;
    public IReadOnlyCollection<UserClaim> Claims => _claims;

    private readonly List<UserRole> _roles = new();
    private readonly List<UserClaim> _claims = new();

    private User() { }

    public User(string username, string email, string passwordHash)
    {
        Id = Guid.NewGuid();
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;

        Validate();
    }

    public void Update(string username, string email)
    {
        AssertValidation.NotEmpty(username, "Username é obrigatório.");
        AssertValidation.NotEmpty(email, "Email é obrigatório.");

        Username = username;
        Email = email;
    }

    public void AssignRole(Guid roleId)
    {
        AssertValidation.IsTrue(roleId != Guid.Empty, "RoleId inválido.");
        if (_roles.Any(r => r.RoleId == roleId))
            return;

        _roles.Add(new UserRole(Id, roleId));
    }

    public void RemoveRole(Guid roleId)
    {
        AssertValidation.IsTrue(roleId != Guid.Empty, "RoleId inválido.");
        var existing = _roles.FirstOrDefault(r => r.RoleId == roleId);
        if (existing != null)
            _roles.Remove(existing);
    }

    public void AddClaim(Guid claimId)
    {
        AssertValidation.IsTrue(claimId != Guid.Empty, "ClaimId inválido.");
        if (_claims.Any(c => c.ClaimId == claimId))
            return;

        _claims.Add(new UserClaim(Id, claimId));
    }

    public void RemoveClaim(Guid claimId)
    {
        AssertValidation.IsTrue(claimId != Guid.Empty, "ClaimId inválido.");
        var existing = _claims.FirstOrDefault(c => c.ClaimId == claimId);
        if (existing != null)
            _claims.Remove(existing);
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;

    private void Validate()
    {
        AssertValidation.NotEmpty(Username, "Username é obrigatório.");
        AssertValidation.NotEmpty(Email, "Email é obrigatório.");
        AssertValidation.NotEmpty(PasswordHash, "Senha é obrigatória.");
    }
}
