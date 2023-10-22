namespace Transaction.API.Controllers.Transactions;
public sealed record CreateTransactionRequest(
    Guid InvoiceId,
    decimal Amount,
    DateTime CreatedOnUtc);
