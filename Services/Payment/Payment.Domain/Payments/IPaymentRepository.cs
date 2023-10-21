namespace Payment.Domain.Payments;
public interface IPaymentRepository
{
    Task<Payment?> GetByIdAsync(PaymentId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Payment>> GetPaymentAsync(CancellationToken cancellationToken = default);
    void Add(Payment payment);
}
