using EventBus;

namespace Payment.Application.Features.Payments.Events;
public class PayedInvoiceEvent : Event
{
    public Guid InvoiceId { get; set; }
    public decimal Amount { get; set; }

}
