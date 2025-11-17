namespace FiapCloud.Users.App.Common;

public class Result<T>
{
    public bool Success { get; private set; }
    public string Message { get; private set; } = string.Empty;
    public T? Data { get; private set; }

    public static Result<T> Ok(T data, string message = "") => new()
    {
        Success = true,
        Message = message,
        Data = data
    };

    public static Result<T> Fail(string message) => new()
    {
        Success = false,
        Message = message
    };
}
