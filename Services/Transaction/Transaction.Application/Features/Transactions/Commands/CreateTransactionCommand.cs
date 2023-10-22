using Transaction.Application.Core.Messaging;

namespace Transaction.Application.Features.Transactions.Commands;
public sealed record CreateTransactionCommand(
    Guid InvoiceId,
    decimal Amount,
    DateTime CreatedOnUtc) : ICommand;