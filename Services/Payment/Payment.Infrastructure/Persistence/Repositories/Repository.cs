using Microsoft.EntityFrameworkCore;

namespace Payment.Infrastructure.Persistence.Repositories;
internal abstract class Repository<TEntity, TEntityId>
where TEntity : Entity<TEntityId>
where TEntityId : class
{
    protected readonly PaymentDbContext DbContext;
    public Repository(PaymentDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(
       TEntityId id,
       CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public void Add(TEntity entity)
    {
        DbContext.Add(entity);
    }
}
