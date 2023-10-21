using Sale.Application.Core.Messaging;
using Sale.Application.Features.Invoices.Common;

namespace Sale.Application.Features.Invoices.Queries.GetInvoices;
public record GetInvoicesQuery() : IQuery<IReadOnlyList<InvoiceResponse>>;
