using EventBus;
using Sale.Application.Clock;
using Sale.Domain.Abstractions;
using Sale.Domain.Invoices;

namespace Sale.Application.Features.Invoices.Events;
public class PayedInvoiceEventHandler : IEventHandler<PayedInvoiceEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    public PayedInvoiceEventHandler(
        IUnitOfWork unitOfWork,
        IInvoiceRepository invoiceRepository,
        IDateTimeProvider dateTimeProvider)
    {
        _unitOfWork = unitOfWork;
        _invoiceRepository = invoiceRepository;
        _dateTimeProvider = dateTimeProvider;
    }
    public async Task Handle(PayedInvoiceEvent @event)
    {
        Invoice? invoice = await _invoiceRepository.GetByIdAsync(
            new InvoiceId(@event.InvoiceId),
            cancellationToken: default);

        invoice.Pay(_dateTimeProvider.UtcNow);
        await _unitOfWork.SaveChangesAsync(cancellationToken: default);
        await Task.FromResult(true);
    }
}
