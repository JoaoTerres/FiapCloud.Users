namespace FiapCloud.Users.Domain;

    public static class AssertValidation
    {
        public static void NotNull(object? value, string message)
        {
            if (value is null)
                throw new DomainException(message);
        }

        public static void NotEmpty(string? value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException(message);
        }

        public static void GreaterThanZero(decimal value, string message)
        {
            if (value <= 0)
                throw new DomainException(message);
        }

        public static void IsTrue(bool condition, string message)
        {
            if (!condition)
                throw new DomainException(message);
        }
    }

