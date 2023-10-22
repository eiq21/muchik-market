namespace Transaction.Domain.Transactions;
public interface ITransactionRepository
{
    Task<Transaction?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Transaction transaction);
}
