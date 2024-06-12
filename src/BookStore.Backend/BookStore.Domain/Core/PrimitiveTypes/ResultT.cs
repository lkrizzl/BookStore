namespace BookStore.Domain.Core.PrimitiveTypes;

public class Result<TValue> : Result
{

    private TValue _value;

    public TValue Value 
    { 
        get 
        {
            if(IsFailure)
            {
                throw new InvalidOperationException("The value of a failure result can not be accessed.");
            }
            return _value;
        }  
    }

    protected internal Result(TValue value, bool isFailure, Error error) : base(isFailure , error)
    {
        _value = value;
    }

    public static implicit operator Result<TValue>(TValue value) => Success(value);
}
