using Sale.Application.Core.Messaging;

namespace Sale.Application.Features.Invoices.Commands.PayInvoice;
public sealed record PayInvoiceCommand(Guid InvoiceId) : ICommand;