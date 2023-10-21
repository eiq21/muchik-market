namespace Payment.API.Controllers.Payments;
public sealed record CreatePaymentRequest(Guid InvoiceId, decimal Amount);
