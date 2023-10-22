using MongoDB.Driver;
using Transaction.Domain.Abstractions;

namespace Transaction.Infrastructure.Persistence.Repositories;

internal abstract class Repository<TEntity>
    where TEntity : IEntity
{
    private readonly TransactionDbContext DbContext;
    private readonly IMongoCollection<TEntity> dbCollection;
    private readonly FilterDefinitionBuilder<TEntity> filterBuilder = Builders<TEntity>.Filter;

    public Repository(TransactionDbContext dbContext)
    {
        DbContext = dbContext;
        dbCollection = DbContext.GetCollection<TEntity>(typeof(TEntity).Name.ToLower());
    }

    public async Task<TEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        FilterDefinition<TEntity> filter = filterBuilder.Eq(entity => entity.Id, id);
        return await dbCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    public void Add(TEntity entity)
    {
        dbCollection.InsertOne(entity);
    }
}
