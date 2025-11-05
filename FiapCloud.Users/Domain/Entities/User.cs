namespace FiapCloud.Users.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string? FullName { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IReadOnlyCollection<UserRole> Roles => _roles;
    public IReadOnlyCollection<UserClaim> Claims => _claims;
    private readonly List<UserRole> _roles = new();
    private readonly List<UserClaim> _claims = new();

    private User() { }

    public User(string username, string email, string passwordHash, string? fullName = null)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        FullName = fullName?.Trim();
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        Id = Guid.NewGuid();

        Validate();
    }

    public void UpdateProfile(string? fullName, string? email)
    {
        if (!string.IsNullOrWhiteSpace(fullName))
            FullName = fullName.Trim();

        if (!string.IsNullOrWhiteSpace(email))
        {
            AssertValidation.NotEmpty(email, "Email é obrigatório.");
            Email = email.Trim();
        }
    }

    public void ChangePassword(string newHash)
    {
        AssertValidation.NotEmpty(newHash, "Senha inválida.");
        PasswordHash = newHash;
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;

    public void AssignRole(Role role)
    {
        AssertValidation.NotNull(role, "Role inválida.");
        if (_roles.Any(r => r.RoleId == role.Id))
            return;

        _roles.Add(new UserRole(Id, role.Id));
    }

    public void RemoveRole(Guid roleId)
    {
        var link = _roles.FirstOrDefault(r => r.RoleId == roleId);
        if (link != null)
            _roles.Remove(link);
    }

    public void AddClaim(Claim claim)
    {
        AssertValidation.NotNull(claim, "Claim inválida.");
        if (_claims.Any(c => c.ClaimId == claim.Id))
            return;

        _claims.Add(new UserClaim(Id, claim.Id));
    }

    public void RemoveClaim(Guid claimId)
    {
        var link = _claims.FirstOrDefault(c => c.ClaimId == claimId);
        if (link != null)
            _claims.Remove(link);
    }

    private void Validate()
    {
        AssertValidation.NotEmpty(Username, "Username é obrigatório.");
        AssertValidation.NotEmpty(Email, "Email é obrigatório.");
        AssertValidation.NotEmpty(PasswordHash, "Senha inválida.");
    }
}
