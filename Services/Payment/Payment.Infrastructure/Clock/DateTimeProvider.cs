using Payment.Application.Clock;

namespace Payment.Infrastructure.Clock;
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
