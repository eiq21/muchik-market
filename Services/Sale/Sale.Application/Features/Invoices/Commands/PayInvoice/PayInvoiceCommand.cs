using Sale.Application.Core.Messaging;
using Sale.Domain.Invoices;

namespace Sale.Application.Features.Invoices.Commands.PayInvoice;
public sealed record PayInvoiceCommand(Guid InvoiceId) : ICommand;