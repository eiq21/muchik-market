using Transaction.Domain.Transactions;

namespace Transaction.Infrastructure.Persistence.Repositories;
internal sealed class TransactionRepository : Repository<Domain.Transactions.Transaction>, ITransactionRepository
{
    public TransactionRepository(TransactionDbContext dbContext) : base(dbContext)
    {
    }
}