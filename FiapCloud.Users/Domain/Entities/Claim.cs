namespace FiapCloud.Users.Domain.Entities;

public class Claim
{
    public Guid Id { get; private set; }
    public string Type { get; private set; }
    public string Value { get; private set; }
    private Claim() { }

    public Claim(string type, string value)
    {
        Type = type;
        Value = value;
        Id = Guid.NewGuid();

        Validate();
    }

    public void ChangeValue(string newValue)
    {
        AssertValidation.NotEmpty(newValue, "Valor da claim é obrigatório.");
        Value = newValue;
    }

    private void Validate()
    {
        AssertValidation.NotEmpty(Type, "Tipo de claim é obrigatório.");
        AssertValidation.NotEmpty(Value, "Valor da claim é obrigatório.");
    }
}
