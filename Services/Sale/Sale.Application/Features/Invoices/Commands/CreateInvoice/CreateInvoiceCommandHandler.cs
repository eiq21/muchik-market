using Sale.Application.Core.Messaging;
using Sale.Domain.Abstractions;
using Sale.Domain.Invoices;

namespace Sale.Application.Features.Invoices.Commands.CreateInvoice;

internal class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand>
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateInvoiceCommandHandler(
        IInvoiceRepository invoiceRepository,
        IUnitOfWork unitOfWork)
    {
        _invoiceRepository = invoiceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoiceResult = Invoice.Create(request.Amount);

        _invoiceRepository.Add(invoiceResult.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
