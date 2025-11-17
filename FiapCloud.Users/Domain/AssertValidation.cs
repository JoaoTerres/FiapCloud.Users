namespace FiapCloud.Users.Domain;

public static class AssertValidation
{
    public static void NotEmpty(string value, string message)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException(message);
    }

    public static void NotNull(object? obj, string message)
    {
        if (obj == null)
            throw new DomainException(message);
    }

    public static void IsTrue(bool condition, string message)
    {
        if (!condition)
            throw new DomainException(message);
    }
}

