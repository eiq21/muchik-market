using Sale.Application.Clock;
using Sale.Application.Core.Messaging;
using Sale.Domain.Abstractions;
using Sale.Domain.Invoices;

namespace Sale.Application.Features.Invoices.Commands.PayInvoice;
internal class PayInvoiceCommandHandler : ICommandHandler<PayInvoiceCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    public PayInvoiceCommandHandler(
        IInvoiceRepository invoiceRepository,
        IDateTimeProvider dateTimeProvider,
        IUnitOfWork unitOfWork)
    {
        _invoiceRepository = invoiceRepository;
        _dateTimeProvider = dateTimeProvider;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(
        PayInvoiceCommand request,
        CancellationToken cancellationToken)
    {
        Invoice? invoice = await _invoiceRepository.GetByIdAsync(
            new InvoiceId(request.InvoiceId), cancellationToken);

        if (invoice is null)
            return Result.Failure(InvoiceErrors.NotFound);

        var result = invoice.Pay(_dateTimeProvider.UtcNow);

        if (result.IsFailure)
            return result;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
