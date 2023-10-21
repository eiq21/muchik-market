using Microsoft.EntityFrameworkCore;
using Sale.Domain.Invoices;

namespace Sale.Infrastructure.Persistence.Repositories;
internal sealed class InvoiceRepository : Repository<Invoice, InvoiceId>, IInvoiceRepository
{
    public InvoiceRepository(SaleDbContext dbContext)
     : base(dbContext)
    {
    }

    public async Task<IReadOnlyList<Invoice>> GetInvoicesAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<Invoice>().ToArrayAsync(cancellationToken);
    }
}
