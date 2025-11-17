namespace FiapCloud.Users.App.Common.Exceptions;

public class ValidationException : AppException
{
    public ValidationException(string message)
        : base(message)
    {
    }
}
