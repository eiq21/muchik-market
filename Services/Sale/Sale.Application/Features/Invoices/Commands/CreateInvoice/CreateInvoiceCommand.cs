using Sale.Application.Core.Messaging;

namespace Sale.Application.Features.Invoices.Commands.CreateInvoice;
public sealed record CreateInvoiceCommand(decimal Amount) : ICommand;
