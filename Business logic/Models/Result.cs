public interface IOperationResult
{
    string? ErrorMessage { get; }
    bool IsSuccess { get; }
    bool IsFailure { get; }
}

public sealed record Result<T> : IOperationResult
{
    public T? Value { get; }
    public string? ErrorMessage { get; }

    public bool IsSuccess { get; }
    public bool IsFailure { get; }

    private Result(T value)
    {
        Value = value;

        IsSuccess = true;
        IsFailure = false;
    }

    private Result(string? errorMessage)
    {
        IsSuccess = false;
        IsFailure = true;

        ErrorMessage = errorMessage;
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(string? errorMessage = "") => new(errorMessage);
}

public sealed record Result : IOperationResult
{
    public string? ErrorMessage { get; }

    public bool IsSuccess { get; }
    public bool IsFailure { get; }

    private Result()
    {
        IsSuccess = true;
        IsFailure = false;
    }

    private Result(string? errorMessage)
    {
        IsSuccess = false;
        IsFailure = true;

        ErrorMessage = errorMessage;
    }

    public static Result Success() => new();
    public static Result Failure(string? errorMessage = "") => new(errorMessage);
}