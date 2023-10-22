using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Transaction.Infrastructure.Persistence.Configurations;
using Transaction.Infrastructure.Persistence.Settings;

namespace Transaction.Infrastructure.Persistence;
public class TransactionDbContext
{
    private IMongoDatabase MongoDatabase { get; set; }
    private MongoClient MongoClient { get; set; }
    public IClientSessionHandle? Session { get; set; }
    public TransactionDbContext(IOptions<MongoDbSettings> configuration)
    {
        MapClasses();
        MongoClient = new MongoClient(configuration.Value.ConnectionString);
        MongoDatabase = MongoClient.GetDatabase(configuration.Value.DatabaseName);
    }
    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return MongoDatabase.GetCollection<T>(name);
    }
    private static void MapClasses()
    {
        _ = new TransactionConfiguration();
    }
}
