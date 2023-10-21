namespace Payment.Application.Clock;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
