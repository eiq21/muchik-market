namespace Payment.Application.Exceptions;
public class ConcurrencyException : Exception
{
    public ConcurrencyException(string message, Exception innerExceptoin)
    : base(message, innerExceptoin)
    {

    }
}
