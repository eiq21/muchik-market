using Transaction.Application.Clock;

namespace Transaction.Infrastructure.Clock;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
