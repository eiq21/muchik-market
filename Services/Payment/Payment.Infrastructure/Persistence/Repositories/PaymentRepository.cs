using Microsoft.EntityFrameworkCore;
using Payment.Domain.Payments;

namespace Payment.Infrastructure.Persistence.Repositories;
internal sealed class PaymentRepository : Repository<Domain.Payments.Payment, PaymentId>, IPaymentRepository
{
    public PaymentRepository(PaymentDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Domain.Payments.Payment>> GetPaymentAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Domain.Payments.Payment>().ToArrayAsync(cancellationToken);
    }
}
