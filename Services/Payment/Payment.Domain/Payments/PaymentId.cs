namespace Payment.Domain.Payments;
public record PaymentId(Guid Value)
{
    public static PaymentId New() => new(Guid.NewGuid());
}
