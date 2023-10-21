namespace Transaction.Application.Clock;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
