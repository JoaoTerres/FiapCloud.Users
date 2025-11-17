namespace FiapCloud.Users.Domain.Entities;

public class Claim
{
    public Guid Id { get; private set; }
    public string Type { get; private set; }
    public string Value { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Claim() { }

    public Claim(string type, string value)
    {
        Id = Guid.NewGuid();
        Type = type;
        Value = value;
        CreatedAt = DateTime.UtcNow;

        Validate();
    }

    private void Validate()
    {
        AssertValidation.NotEmpty(Type, "Tipo da claim é obrigatório.");
        AssertValidation.NotEmpty(Value, "Valor da claim é obrigatório.");
    }
}