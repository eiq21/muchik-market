using Payment.Domain.Abstractions;

namespace Payment.Domain.Payments;
public sealed class Payment : Entity<PaymentId>
{
    private Payment(
        PaymentId id,
        Guid invoiceId,
        decimal amount,
        DateTime payedOnUtc)
        : base(id)
    {
        InvoiceId = invoiceId;
        Amount = amount;
        PayedOnUtc = payedOnUtc;
    }
    public Guid InvoiceId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime PayedOnUtc { get; private set; }
    private Payment() { }

    public static Result<Payment> Create(
        Guid invoiceId,
        decimal amount,
        DateTime payedOnUtc)
    {
        var payment = new Payment(
          PaymentId.New(),
          invoiceId,
          amount,
          payedOnUtc
        );
        return payment;
    }
}