namespace AppWithoutMediatR.Domain;

public abstract record CustomError;

public class Result<T>
{
    private readonly T? _value;
    public CustomError? Error { get; }
    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
    }
    private Result(CustomError error)
    {
        IsSuccess = false;
        Error = error;
    }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public T Value
    {
        get
        {
            if (IsFailure)
                throw new InvalidOperationException("there is no value for failure");
            return _value!;
        }
        private init => _value = value;
    }
    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }
    public static Result<T> Failure(CustomError error)
    {
        return new Result<T>(error);
    }
}