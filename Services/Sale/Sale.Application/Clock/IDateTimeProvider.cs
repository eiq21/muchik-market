namespace Sale.Application.Clock;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
