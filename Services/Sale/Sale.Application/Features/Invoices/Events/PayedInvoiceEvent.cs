using EventBus;

namespace Sale.Application.Features.Invoices.Events;
public class PayedInvoiceEvent : Event
{
    public Guid InvoiceId { get; set; }
    public decimal Amount { get; set; }
}
