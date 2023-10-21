using Sale.Domain.Abstractions;

namespace Sale.Domain.Invoices;
public sealed class Invoice : Entity<InvoiceId>
{
    private Invoice(InvoiceId id, decimal amount, InvoiceStatus status)
    : base(id)
    {
        Amount = amount;
        Status = status;
    }

    private Invoice() { }
    public decimal Amount { get; private set; }
    public InvoiceStatus Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }

    public DateTime? PayedOnUtc { get; private set; }

    public DateTime? CancelledOnUtc { get; private set; }

    public static Result<Invoice> Create(decimal amount)
    {
        var invoce = new Invoice(
            InvoiceId.New(),
            amount,
            InvoiceStatus.Pending);

        return invoce;
    }

    public Result Pay(DateTime utcNow)
    {
        if (Status != InvoiceStatus.Pending)
            return Result.Failure(InvoiceErrors.NotPending);

        Status = InvoiceStatus.Paid;
        PayedOnUtc = utcNow;

        return Result.Success();
    }
}
