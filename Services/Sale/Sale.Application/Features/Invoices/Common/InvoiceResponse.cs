namespace Sale.Application.Features.Invoices.Common;
public sealed class InvoiceResponse
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
}
