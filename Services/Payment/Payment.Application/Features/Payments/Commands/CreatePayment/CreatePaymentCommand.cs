using Payment.Application.Core.Messaging;

namespace Payment.Application.Features.Payments.Commands.CreatePayment;
public sealed record CreatePaymentCommand(
    Guid InvoiceId,
    decimal Amount) : ICommand;
