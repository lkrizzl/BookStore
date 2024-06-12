using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookStore.Domain.Core.PrimitiveTypes;

public class Result
{
    protected Result(bool isFailure, Error error)
    {
        if (isFailure && error == Error.None || !isFailure && error != Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsFailure = isFailure;
        Error = error;

    }
    public static Result Success() => new Result(false, Error.None);
    
    public static Result Failure(Error error) => new Result(true, error);

    public bool IsSuccess { get => !IsFailure; }

    public bool IsFailure { get; private set; }

    public Error Error { get; private set; }

    public static Result<TValue> Success<TValue>(TValue value) 
        => new Result<TValue>(value, false, Error.None);

    public static Result<TValue> Failure<TValue>(Error error) 
        => new Result<TValue>(default!, true, error);
}
