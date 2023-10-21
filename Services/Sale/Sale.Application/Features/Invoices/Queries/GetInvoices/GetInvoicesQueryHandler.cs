using Sale.Application.Core.Messaging;
using Sale.Application.Features.Invoices.Common;
using Sale.Domain.Abstractions;
using Sale.Domain.Invoices;

namespace Sale.Application.Features.Invoices.Queries.GetInvoices;
internal sealed class GetInvoicesQueryHandler : IQueryHandler<GetInvoicesQuery, IReadOnlyList<InvoiceResponse>>
{
    private readonly IInvoiceRepository _invoiceRepository;
    public GetInvoicesQueryHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }
    public async Task<Result<IReadOnlyList<InvoiceResponse>>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        var invoices = await _invoiceRepository.GetInvoicesAsync(cancellationToken);

        if (invoices is null || !invoices.Any())
            return Enumerable.Empty<InvoiceResponse>().ToList();

        var invoiceResponse = invoices.Select(invoice => new InvoiceResponse
        {
            Id = invoice.Id.Value,
            Amount = invoice.Amount,
            Status = Enum.GetName(typeof(InvoiceStatus), invoice.Status)
        }).ToList();

        return invoiceResponse;

    }
}
